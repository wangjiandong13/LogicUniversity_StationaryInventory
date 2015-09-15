define(['app'], function (app) {
    app.controller('InventoryNewControllers', ['$rootScope', '$scope', 'BaseService', '$routeParams', InventoryNewControllers]);

    function InventoryNewControllers($rootScope, $scope, BaseService, $routeParams) {
        //set mean highlight
        $rootScope.changehighlight(12);

        var itemid = $routeParams.itemid;
        $scope.itemid = itemid;
        var myBaseService = BaseService;
       
        //get categoryselectData
        $scope.CategorySelectData = {
            availableOptions: [],
            selectedOption: { ItemCatID: 1, ItemDescription: 'Clips' }
        };
        BaseService.getCategory()
            .then(function (data) {
                //console.log(data);
                $scope.CategorySelectData.availableOptions = data;
                //$scope.CategorySelectData.availableOptions.unshift({ ItemCatID: 0, ItemDescription: 'ALL' });
            }, function (data) {
                alert(data);
            })

        if ($rootScope.toNewInvt == 0) {
            $scope.Title = "New";

            //New: click submit
            $scope.submit = function () {
                console.log("enter");
                var msgItem = {
                    ItemID: $scope.ItemID, ItemName: $scope.ItemName, ItemCatID: $scope.ItemCatID, RoLvl: $scope.RoLvl,
                    RoQty: $scope.RoQty, UOM: $scope.UOM, Stock: $scope.Stock, Bin: $scope.Bin
                };
                var msgItemPrice = [{ ItemID: $scope.ItemID, SupplierID: $scope.supplier1, Price: $scope.supplier1Price },
                            { ItemID: $scope.ItemID, SupplierID: $scope.supplier2, Price: $scope.supplier2Price },
                            { ItemID: $scope.ItemID, SupplierID: $scope.supplier3, Price: $scope.supplier3Price }];

                myBaseService.createItem(angular.toJson(msgItem))
                    .then(function (data) {
                        console.log(data);
                        myBaseService.createItemPrice(angular.toJson(msgItemPrice))
                            .then(function (data) {
                                alert("success!");
                                location.href = '#/inventoryList';
                            })
                    }, function (data) {
                        alert(data);
                    })
            }
        }
        else {
            $scope.Title = "Edit";

            //load item data
            BaseService.getItemDetail(itemid)
            .then(function (data) {
                console.log(data);
                $scope.ItemDesc = data.ItemName;
                $scope.ItemID = data.ItemID;
                $scope.CategorySelectData.selectedOption.ItemCatID = data.ItemCatID;
                $scope.CategorySelectData.selectedOption.ItemDescription = data.ItemDescription;
                $scope.RoLvl = data.RoLvl;
                $scope.RoQty = data.RoQty;
                $scope.UOM = data.UOM;
            }, function (data) {
                alert(data);
            })
            //load itemPrice data
            BaseService.getItemPrice(itemid)
            .then(function (data) {
                console.log(data);
                $scope.supplier1 = data[0].SupplierID;
                $scope.supplier1Price = data[0].Price;
                $scope.supplier2 = data[1].SupplierID;
                $scope.supplier2Price = data[1].Price;
                $scope.supplier3 = data[2].SupplierID;
                $scope.supplier3Price = data[2].Price;
            }, function (data) {
                alert(data);
            })

            //Edit: click submit 
            $scope.submit = function () {
                console.log("enter");
                var msgItem = {
                    ItemID: $scope.ItemID, ItemName: $scope.ItemDesc, ItemCatID: $scope.CategorySelectData.selectedOption.ItemCatID,
                    RoLvl: $scope.RoLvl, RoQty: $scope.RoQty, UOM: $scope.UOM
                };
                var msgItemPrice = [{ ItemID: $scope.ItemID, SupplierID: $scope.supplier1, Price: $scope.supplier1Price },
                            { ItemID: $scope.ItemID, SupplierID: $scope.supplier2, Price: $scope.supplier2Price },
                            { ItemID: $scope.ItemID, SupplierID: $scope.supplier3, Price: $scope.supplier3Price }];

                myBaseService.updateItemInv(angular.toJson(msgItem))
                    .then(function (data) {
                        console.log(data);
                        myBaseService.updateItemPriceInv(angular.toJson(msgItemPrice))
                            .then(function (data) {
                                alert("success!");
                                location.href = '#/inventoryList';
                            })
                    }, function (data) {
                        alert(data);
                    })
            }
        }

        $scope.cancel = function () {
            location.href = '#/inventoryList';
        }
        
    }
    
})
