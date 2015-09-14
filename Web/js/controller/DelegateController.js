define(['app'], function (app) {
    app.controller('DelegateControllers', ['$rootScope', '$scope', 'BaseService', DelegateControllers]);

    function DelegateControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(7);
        var MyBaseService = BaseService;
        BaseService.getDeptDelegate($rootScope.UserInfo.DeptId)
            .then(function (data) {
                console.log(data);
                $scope.Delegates = data;
                $.each(data, function (index, value) {
                    if (value.EmpID != null) {
                        MyBaseService.getEmployee(value.EmpID)
                            .then(function (data) {
                                value.EmpName = data.EmpName;
                            }
                            )
                    }
                })
            })
        $scope.delectDelegate = function (delegagte) {
            BaseService.removeDelegate(delegagte.DelegateSN)
                .then(function (data) {
                    alert("Success Delect!");
                    BaseService.getDeptDelegate($rootScope.UserInfo.DeptId)
            .then(function (data) {
                console.log(data);
                $scope.Delegates = data;
                $.each(data, function (index, value) {
                    if (value.EmpID != null) {
                        MyBaseService.getEmployee(value.EmpID)
                            .then(function (data) {
                                value.EmpName = data.EmpName;
                            }
                            )
                    }
                })
            })
                })
        }
        $scope.newDelegate = function () {
            location.href = "#/delegatenew";
        }
    }
})