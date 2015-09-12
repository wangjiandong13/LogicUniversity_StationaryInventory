define(['app'], function (app) {
    app.controller('RequestCartControllers', ['$rootScope', '$scope',  RequestCartControllers]);
    app.controller('RequestCartListCtrl', ['$rootScope', 'BaseService', RequestCartList]);

    function RequestCartControllers($rootScope,$scope) {
        //set mean highlight
        $rootScope.mean = {
            Requistion: " ",
            Catalog: " ",
            Department: " ",
            RequestCart: "active",
            ifRequistion: false,
            ifCatalog: false,
            ifDepartment: false,
            ifRequestCart:true
        };

        console.log("enter  RequestCartControllers")
        $scope.back = function () {
            location.href = '#/requisition';
        }
        $scope.submit = function () {
            console.log("enter");
            console.log(angular.toJson($scope.RequestCarts));
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
                            $rootScope.RequestCarts = data;
                            if (!$scope.$$phase) {
                                $rootScope.$apply();
                            }
                        }, function (data) {
                            alert(data);
                        })
                    }, function (data) {

                    })
        }
    }
})
