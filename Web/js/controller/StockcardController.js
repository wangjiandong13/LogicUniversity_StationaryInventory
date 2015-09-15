﻿define(['app'], function (app) {
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
                if (supplierdata.Rank == 1)
                    Supplier1 = supplierdata.SuuplierID;
                if (supplierdata.Rank == 2)
                    Supplier2 = supplierdata.SuuplierID;
                if (supplierdata.Rank == 3)
                    Supplier3 = supplierdata.SuuplierID;
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