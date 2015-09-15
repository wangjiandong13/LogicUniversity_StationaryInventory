define(['app'], function (app) {
    app.controller('PurchaseOrderProposeControllers', ['$scope', '$rootScope', 'BaseService', PurchaseOrderProposeControllers]);
    function PurchaseOrderProposeControllers($scope, $rootScope, BaseService) {
        $rootScope.changehighlight(13);
        $scope.listitems = [];
        $scope.additem = {
            ItemName: "",
            ItemID:"",
            supplier1: "",
            supplier2: "",
            supplier3: "",
            supplier1Qty: 0,
            supplier2Qty: 0,
            supplier3Qty: 0
        }
        BaseService.getSupplierList()
            .then(function (data) {
                $scope.additem.supplier1 = data[0].SupplierID;
                $scope.additem.supplier2 = data[1].SupplierID;
                $scope.additem.supplier3 = data[2].SupplierID;
            })
        $scope.supplier = function (item) {
            $('#ChooseSupplier').modal('show');
            $scope.additem.ItemName = item.ItemName;
            $scope.additem.supplier1Qty = item.RoQty;
            $scope.additem.ItemID
        }
        BaseService.getCatalogList()
            .then(function (data) {
                $scope.items = data;
            })
        $scope.search = function () {
            if ($scope.additem.ItemName == null || $scope.additem.ItemName == "") {
                BaseService.getCatalogList()
                    .then(function (data) {
                        $scope.items = data;
                    })
            }
            else {
                BaseService.getItemByName($scope.additem.ItemName)
                .then(function (data) {
                    $scope.items = data;
                })
            }
        }
        $scope.addtolist = function () {
            $scope.listitems.push($scope.additem);
        }
    }
})