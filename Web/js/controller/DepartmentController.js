define(['app'], function (app) {
    app.controller('departmentCtrl', ['$rootScope', '$scope', 'BaseService', departmentCtrl]);
    app.controller('depSelectoptionControllers', ['$rootScope', 'BaseService', depSelectoptionControllers]);
    function departmentCtrl($rootScope, $scope,BaseService) {
        console.log("enter  departmentCtrl");
            BaseService.getDepartment("COMM")
                   .then(function (data) {
                       console.log(data);
                       $scope.Department = data;
                   }, function (data) {
                       alert(data);
                   }
                   );
            BaseService.getemployeebyId($scope.Department.DeptHead)
                   .then(function (data) {
                       console.log(data);
                       $scope.DeptHead = data;
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
        BaseService.getDepartment(detId)
               .then(function (data) {
                   console.log(data);
                   $scope.Department = data;
               }, function (data) {
                   alert(data);
               }
               );

        BaseService.getDeptEmployee(detId)
            .then(function (data) {
                console.log(data);
                $rootScope.optiondata.availableOptions = data;
                $rootScope.optiondata.availableOptions.unshift({ EmpID: 0, EmpName: 'ALL' });
            },function(data){
                alert(data);
            })
    }
})
