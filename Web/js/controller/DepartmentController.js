define(['app'], function (app) {
    app.controller('departmentCtrl', ['$rootScope', '$scope', 'BaseService', departmentCtrl]);
    app.controller('depSelectoptionControllers', ['$rootScope', 'BaseService', depSelectoptionControllers]);
    function departmentCtrl($rootScope, $scope, BaseService) {
        var selfBaseService = BaseService;
        console.log("enter  departmentCtrl");
            BaseService.getDepartment("COMM")
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
        BaseService.getDeptEmployee("COMM")
            .then(function (data) {
                console.log(data);
                $rootScope.optiondata.availableOptions = data;
                $rootScope.optiondata.availableOptions.unshift({ EmpID: 0, EmpName: 'ALL' });
            },function(data){
                alert(data);
            })
    }
})
