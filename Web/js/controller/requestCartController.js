define(['app'], function (app) {
    app.controller('RequestCartControllers', [ '$scope',  RequestCartControllers]);
    app.controller('RequestCartListCtrl', ['$scope', 'BaseService', RequestCartList]);

    function RequestCartControllers($scope) {
        console.log("enter  RequestCartControllers")
        $scope.back = function () {
            location.href = '#/requestCart';
        }
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
            var msg = '{"ItemID":"'+RequestCart.ItemID+'" ,"EmpID":'+EmpId+'}';
            console.log(msg);
            BaseService.removeRequestCart(msg)
                    .then(function (data) {
                        selfBaseService.getRequestCart(EmpId)
                        .then(function (data) {
                            console.log(data);
                            
                            $scope.$apply(function () {
                                $scope.RequestCarts = data;
                            });
                        }, function (data) {
                            alert(data);
                        })
                    }, function (data) {

                    })
        }
    }
})
