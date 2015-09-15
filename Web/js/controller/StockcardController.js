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
                        Supplier1 = value.SuuplierID;
                    if (value.Rank == 2)
                        Supplier2 = value.SuuplierID;
                    if (value.Rank == 3)
                        Supplier3 = value.SuuplierID;
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