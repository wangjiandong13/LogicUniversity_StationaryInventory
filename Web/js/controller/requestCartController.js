define(['app'], function (app) {
    app.controller('RequestCartControllers', ['$rootScope', '$scope', 'BaseService', RequestCartControllers]);
    app.controller('RequestCartListCtrl', ['$scope', 'BaseService', RequestCartList]);

    function RequestCartControllers() {
        console.log("enter  RequestCartControllers")
    }
    function RequestCartList($scope, BaseService) {
        //get EmpId from session
        var EmpId = "11233";
        var selfBaseService = BaseService;
        console.log("enter requestCartListCtrls");
        console.log(BaseService);
        BaseService.getRequestCart(EmpId)
            .then(function (data) {
                console.log(data);
                $scope.RequestCarts = data;
            }, function (data) {
                alert(data);
            })
        $scope.delect = function (RequestCart) {
            var msg = '{"ItemID":"'+RequestCart.ItemID+'" ,"EmpID":"'+EmpId+'"}';
            console.log(msg);
            BaseService.removeRequestCart(msg)
                    .then(function (data) {
                        selfBaseService.getRequestCart(EmpId)
                        .then(function (data) {
                            console.log(data);
                            $scope.RequestCarts = data;
                        }, function (data) {
                            alert(data);
                        })
                    }, function (data) {

                    })
        }
    }
})
