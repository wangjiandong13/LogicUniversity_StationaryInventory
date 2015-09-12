define(['app'], function (app) {
    app.controller('departmentCtrl', ['$rootScope', '$scope', 'BaseService', departmentCtrl]);
    app.controller('depSelectoptionControllers', ['$rootScope', 'BaseService', depSelectoptionControllers]);
    function departmentCtrl($rootScope, $scope, BaseService) {
        //get from session
        $rootScope.dptID = "REGR";
        $rootScope.roleid = "DD";
        //set mean highlight
        $rootScope.mean = {
            Requistion: "",
            Catalog: "",
            Department: "active",
            RequestCart: "",
            ifRequistion: false,
            ifCatalog: false,
            ifDepartment: true,
            ifRequestCart: false
        };
        if ($rootScope.roleid == "EM" || $rootScope.roleid == "DR") {
            //cannot edit hide button
            $scope.setting = {
                textbox: true,
                btnSave: false,
                btnEdit: false
            };
        }
        if ($rootScope.roleid == "DH" || $rootScope.roleid == "DD") {
            $scope.setting = {
                textbox: true,
                btnSave: false,
                btnEdit: true
            };
        }
        
        $scope.edit = function () {
            $scope.setting = {
                textbox: false,
                btnSave: true,
                btnEdit: false
            };
        }
        $scope.save = function () {
            $scope.updatemodel = {

            }

            $scope.setting = {
                textbox: true,
                btnSave: false,
                btnEdit: true
            };
        }
        var selfBaseService = BaseService;
        console.log("enter  departmentCtrl");
        BaseService.getDepartment($rootScope.dptID)
                   .then(function (data) {
                       $scope.Department = data;
                       depth = data.DeptHead;
                       selfBaseService.getEmployee(depth)
                           .then(function (data) {
                               console.log(data.EmpName);
                               $scope.DeptHeadName = data.EmpName;
                           }, function (data) {
                               alert(data);
                           }
                           );
                   }, function (data) {
                       alert(data);
                   }
                   );
            }

    function depSelectoptionControllers($rootScope, BaseService) {
        $rootScope.optiondata = {
            availableOptions: [],
            selectedOption: { 'EmpID': 0, 'EmpName': 'ALL' }
        };
        BaseService.getDeptEmployee($rootScope.dptID)
            .then(function (data) {
                console.log(data);
                $rootScope.optiondata.availableOptions = data;
                $rootScope.optiondata.availableOptions.unshift({ EmpID: 0, EmpName: 'ALL' });
                $.each(data, function (index, value) {
                    if (value.RoleID == "DR") {
                            console.log("enter");
                            $rootScope.optiondata.selectedOption = { 'EmpID': value.EmpID, 'EmpName': value.EmpName }
                        }
                })
                console.log($rootScope.optiondata.selectedOption);
                
            },function(data){
                alert(data);
            })
        
    }
})
