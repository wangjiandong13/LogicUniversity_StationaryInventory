define(['app'], function (app) {
    app.controller('StockcardController', ['$scope', '$rootScope', "$routeParams", 'BaseService', StockcardController]);

    function StockcardController($scope, $rootScope, $routeParams, BaseService) {
        var itemid = $routeParams.itemid;
        $scope.itemid = itemid;
        var myBaseService = BaseService;
        console.log($scope.itemid);
        BaseService.getItemDetail($scope.itemid)
            .then(function (data) {
                console.log(data);
                $scope.ItemData = data;
            }, function (data) {
                alert(data);
            }
            )

        BaseService.getSupplierInfo()
            .then(function (supplierdata) {
                console.log(supplierdata);
                $.each(supplierdata, function (index, value) {
                    if (value.Rank == 1)
                        $scope.Supplier1 = value.SupplierID;
                    if (value.Rank == 2)
                        $scope.Supplier2 = value.SupplierID;
                    if (value.Rank == 3)
                        $scope.Supplier3 = value.SupplierID;
                })
            })

        BaseService.getStockCard($scope.itemid)
            .then(function (data) {
                console.log(data);
                $scope.StockcardList = data;
            }, function (data) {
                alert(data);
            }
            )
        $scope.back = function () {
            location.href = "#/inventoryList";
        }
    }
})