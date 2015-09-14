define(['app'], function (app) {
    app.controller('DelegateControllers', ['$rootScope', '$scope', 'BaseService', DelegateControllers]);

    function DelegateControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(7);
        var MyBaseService = BaseService;
        BaseService.getDeptDelegate($rootScope.UserInfo.DeptID)
            .then(function (data) {
                console.log(data);
                $scope.Delegates = data;
                if (data.EmpID != null) {
                    MyBaseService.getEmployee(data.EmpID)
                        .then(function (data) {
                            $scope.Delegates.EmpName = data.EmpName;
                        }
                        )
                }
            })
        $scope.Delegate = function (delegagte) {
            BaseService.removeDelegate(delegagte.DelegateSN)
                .then(function (data) {
                    alert("Success Delect!");
                })
        }
        $scope.newDelegate = function () {
            location.href = "#/delegatenew";
        }
    }
})