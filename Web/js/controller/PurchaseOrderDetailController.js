define(['app'], function (app) {
    app.controller('PurchaseOrderDetailControllers', ['$scope', '$rootScope', "$routeParams", 'BaseService', PurchaseOrderDetailControllers]);
    function PurchaseOrderDetailControllers($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(13);
        var PoID = $routeParams.PoID;
        var MyBaseService = BaseService;
        BaseService.getPoList("null", "null", "null", PoID)
            .then(function (data) {
                $scope.PoData = data[0];
            })
        BaseService.getPoDetail(PoID)
            .then(function (data) {
                $scope.PoDetails = data;
                $.each($scope.PoDetails, function (index, value) {
                    MyBaseService.getItemDetail(value.ItemID)
                        .then(function (data) {
                            value.ItemName = data.ItemName;
                        })
                })
            })

        $scope.Restock = function () {
            
        }
        $scope.back = function () {
            location.href = "#/purchaseOrder";
        }
    }
})