define(['app'], function (app) {
    app.controller('RequisitionSCControllers', ['$rootScope', '$scope', 'BaseService', RequisitionSCControllers]);

    function RequisitionControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(8);

        var myBaseService = BaseService;
        $scope.search = function () {
            var status = $rootScope.optiondata.selectedOption.StatusID;
            var ReqID = $scope.RequisitionNo;
            if (ReqID == null || ReqID == "") { ReqID = "null"; }
            //console.log(ReqID);
            BaseService.getRequisitionApprovedList()
                .then(function (data) {
                    console.log(data);
                    $rootScope.Requisitions = data;
                    $.each(data, function (index, value) {
                        myBaseService.getEmployee(value.EmpId)
                            .then(function (empdata){
                                $scope.Requisitions.EmpName = empdata.EmpName;
                            })
                        myBaseService.getEmployee(value.EmpId)
                    })
                    
                }, function (data) {
                    alert(data);
                }
                )
        }
    }
    function RequisitionList($rootScope, $scope, BaseService) {
        BaseService.getRequisitionList("null", "null", $rootScope.UserInfo.EmpId, $rootScope.UserInfo.DeptId)
            .then(function (data) {
                console.log(data);
                $rootScope.Requisitions = data;
            }, function (data) {
                alert(data);
            }
        )
        $scope.requisitiondetail = function (Requisition) {
            location.href = "#/requisitionDetail/" + Requisition.ReqID;
            $rootScope.backTo = 0;
        };
    }
    function SelectoptionControllers($rootScope, BaseService) {
        $rootScope.optiondata = {
            availableOptions: [],
            selectedOption: { 'StatusID': 0, 'StatusName': 'ALL' }
        };
        BaseService.getRequisitionStatus()
            .then(function (data) {
                $rootScope.optiondata.availableOptions = data;
                //console.log(data);
                $rootScope.optiondata.availableOptions.unshift({ StatusID: 0, StatusName: 'ALL' });
            }, function (data) {
                alert(data);
            })
    }
});