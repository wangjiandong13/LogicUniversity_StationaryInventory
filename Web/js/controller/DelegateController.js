define(['app'], function (app) {
    app.controller('DelegateControllers', ['$rootScope', '$scope', 'BaseService', DelegateControllers]);

    function DelegateControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(7);
        var MyBaseService = BaseService;
        BaseService.getDeptDelegate($rootScope.UserInfo.DeptID)
            .then(function (data) {
                $scope.Delegates = data;
                MyBaseService.getEmployee(data.EmpID)
                    .then(function (data) {
                        $scope.Delegates.EmpName = data.EmpName;
                    }
                    )
            })
    }
})