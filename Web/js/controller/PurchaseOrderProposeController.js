define(['app'], function (app) {
    app.controller('PurchaseOrderProposeControllers', ['$scope', '$rootScope', 'BaseService', PurchaseOrderProposeControllers]);
    function PurchaseOrderProposeControllers($scope, $rootScope, BaseService) {
        $rootScope.changehighlight(13);
        $scope.listitems = [];
        $scope.addtolistbtn = true;
        $scope.Savebtn = true;
        $scope.additem = {
            ItemName: "",
            ItemID: "",
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
        BaseService.getCatalogList()
    .then(function (data) {
        $scope.items = data;
    })
        $scope.supplier = function (item) {
            $scope.addtolistbtn = true;
            $scope.Savebtn = false;
            $('#ChooseSupplier').modal('show');
            $scope.additem.ItemName = item.ItemName;
            $scope.additem.supplier1Qty = item.RoQty;
            $scope.additem.ItemID = item.ItemID;
        }
        $scope.edit = function (item) {
            $scope.addtolistbtn = false;
            $scope.Savebtn = true;
            $('#ChooseSupplier').modal('show');
            $scope.additem.ItemName = item.ItemName;
            $scope.additem.supplier1Qty = item.supplier1Qty;
            $scope.additem.supplier2Qty = item.supplier2Qty;
            $scope.additem.supplier3Qty = item.supplier3Qty;
            $scope.additem.ItemID = item.ItemID;
        }

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
            if (checkifinlist()) {
                $.each($scope.listitems, function (index, value) {
                    if (value.ItemID == $scope.additem.ItemID) {
                        value.supplier1Qty = value.supplier1Qty + $scope.additem.supplier1Qty;
                    }
                })
            }
            else {
                $scope.listitems.push($scope.additem);
            }
            $('#ChooseSupplier').modal('hide');
            $('#Additem').modal('hide');
            $scope.additem = {
                ItemName: "",
                ItemID: "",
                supplier1: "",
                supplier2: "",
                supplier3: "",
                supplier1Qty: 0,
                supplier2Qty: 0,
                supplier3Qty: 0
            }
        }
        $scope.delect = function (item) {
            var car = [];
            $.each($scope.listitems, function (index, value) {
                if (value.ItemID != item.ItemID) {
                    car.push(value);
                }
            })
            $scope.listitems = car;
        }
        $scope.save = function () {
            $.each($scope.listitems, function (index, value) {
                if (value.ItemID == additem.ItemID) {
                    car.push(value);
                }
            })
        }
        function checkifinlist() {
            var str_return = false;
            $.each($scope.listitems, function (index, value) {
                console.log(value);
                console.log($scope.additem.ItemID);
                if (value.ItemID == $scope.additem.ItemID) {
                    str_return = true;
                }
            })
            return str_return;
        }
    }
})