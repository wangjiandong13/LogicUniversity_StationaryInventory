define(['app'], function (app) {
    app.controller('RequisitionApprovalListControllers', ['$rootScope', '$scope', 'BaseService', RequisitionApprovalListControllers]);
    app.controller('RequisitionApprovalList', ['$rootScope', '$scope', 'BaseService', RequisitionApprovalList]);
    app.controller('SelectoptionControllersStatus', ['$rootScope', 'BaseService', SelectoptionControllersStatus]);
    app.controller('SelectoptionControllersEmp', ['$rootScope', 'BaseService', SelectoptionControllersEmp]);
    function RequisitionApprovalListControllers($rootScope, $scope, BaseService) {
        //set mean highlight
        $rootScope.mean = {
            Requistion: "active",
            Catalog: "",
            Department: "",
            RequestCart: "",
            ifRequistion: true,
            ifCatalog: false,
            ifDepartment: false,
            ifRequestCart: false
        };
        //$rootScope.pageTitle = $route.current.title;
        $scope.viewCart = function () {
            location.href = '#/requestCart';
        };
        var myBaseService = BaseService;
        $scope.search = function () {
            var status = $rootScope.optiondata.selectedOption.StatusID;
            if (status == 0) { status = "null"; }
            var EmpID = $rootScope.optiondataEmp.selectedOption.EmpID;
            if (EmpID == null) { EmpID = "null" }
            BaseService.getRequisitionList(status, "null", EmpId)
                .then(function (data) {
                    console.log(data);
                    $rootScope.RequisitionsApproval = data;
                    console.log("I am here");
                    $.each(data, function (index, value) {
                        console.log("I am in each");
                        console.log(">>>>" + value);
                        console.log(">>>>"+value.EmpID);
                        myBaseService.getEmployee(value.EmpID)
                            .then(function (data) {
                                value.EmpName = data.EmpName;
                            }, function (data) {
                                alert(data);
                            }
                            )
                    });
                }, function (data) {
                    alert(data);
                }
                )
        }
    }
    function RequisitionApprovalList($rootScope, $scope, BaseService) {
        console.log(">>>enter RequisitionApprovalList")
        BaseService.getRequisitionApprovalList($rootScope.UserInfo.DeptId)
            .then(function (data) {
                console.log(data);
                $rootScope.RequisitionsApproval = data;
            }, function (data) {
                alert(data);
            }
        )
        $scope.requisitiondetail = function (Requisition) {
            if (Requisition.StatusID == 1) {
                location.href = "#/requisitionApproval/" + Requisition.ReqID;
            }
            else {
                location.href = "#/requisitionDetail/" + Requisition.ReqID;
            }
        };
    }
    function SelectoptionControllersStatus($rootScope, BaseService) {
        $rootScope.optiondataStatus = {
            availableOptions: [],
            selectedOption: { 'StatusID': 1, 'StatusName': 'Pending Approval' }
        };
        BaseService.getRequisitionStatus()
            .then(function (data) {
                $rootScope.optiondataStatus.availableOptions = data;
                //console.log(data);
                $rootScope.optiondataStatus.availableOptions.unshift({ StatusID: 0, StatusName: 'ALL' });
            }, function (data) {
                alert(data);
            })
    }
    function SelectoptionControllersEmp($rootScope, BaseService) {
        $rootScope.optiondataEmp = {
            availableOptions: [],
            selectedOption: { 'EmpID': 0, 'EmpName': 'ALL' }
        };
        BaseService.getDeptEmployee($rootScope.UserInfo.DeptId)
            .then(function (data) {
                $rootScope.optiondataEmp.availableOptions = data;
                //console.log(data);
                $rootScope.optiondataEmp.availableOptions.unshift({ EmpID: 0, EmpName: 'ALL' });
            }, function (data) {
                alert(data);
            })
    }
});