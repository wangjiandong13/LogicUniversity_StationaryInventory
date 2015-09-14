define(['app'], function (app) {
    app.controller('DelegateNewControllers', ['$rootScope', '$scope', 'BaseService', DelegateNewControllers]);
    function DelegateNewControllers($rootScope, $scope, BaseService) {
        $scope.employeelist = {
            availableOptions: [],
            selectedOption: { 'EmpID': 0, 'EmpName': 'ALL' }
        };
        BaseService.getDeptEmployee($rootScope.UserInfo.DeptId)
            .then(function (data) {
                console.log(data);
                $scope.employeelist.availableOptions = data;
                $scope.employeelist.selectedOption = { 'EmpID': data[0].EmpID, 'EmpName': data[0].EmpName }
                //console.log($rootScope.employeelist.selectedOption);

            }, function (data) {
                alert(data);
            })
    }
})