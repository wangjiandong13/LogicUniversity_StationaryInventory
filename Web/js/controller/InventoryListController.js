define(['app'], function (app) {
    app.controller('inventoryListCtrl', ['$rootScope', '$scope', 'BaseService', inventoryListCtrl]);
    function inventoryListCtrl($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(12);
        var myBaseService = BaseService;
        //click the New button
        $scope.new = function () {
            $rootScope.toNewInvt = 0;
            location.href = '#/inventoryNew/0';
        };

        //get categoryselectData
        $scope.CategorySelectData = {
            availableOptions: [],
            selectedOption: { ItemCatID: 0, ItemDescription: 'ALL' }
        };
        BaseService.getCategory()
            .then(function (data) {
                ////console.log(data);
                $scope.CategorySelectData.availableOptions = data;
                $scope.CategorySelectData.availableOptions.unshift({ ItemCatID: 0, ItemDescription: 'ALL' });
            }, function (data) {
                alert(data);
            })

        var myBaseService = BaseService;
        var invtListData = "";
        BaseService.getSupplierList()
        .then(function (supplierdata) {
            $.each(supplierdata, function (index, value) {
                //console.log(value.Rank);
                if (value.Rank == 1)
                    $scope.supplierID = value.SupplierID;
            })

            myBaseService.getCatalogList()
            .then(function (data) {
                ////console.log(data);
                $scope.inventoryListdata = data;
                $.each($scope.inventoryListdata, function (index, value) {
                    myBaseService.getItemPrice(value.ItemID)
                    .then(function (itemdata) {
                        ////console.log(itemdata);
                        ////console.log($scope.supplierID);
                        $.each(itemdata, function (index, ipvalue) {
                            ////console.log(ipvalue.SupplierID);
                            if (ipvalue.SupplierID == $scope.supplierID) {
                                ////console.log($scope.inventoryListdata.Price);
                                value.Price = ipvalue.Price;
                            }

                        })

                    })
                });
            }, function (data) {
                alert(data);
            })

        })

        //click the Stock Card button
        $scope.stockCard = function (item) {
            location.href = '#/stockcard/' + item.ItemID;
        };

        //click the Edit button
        $scope.edit = function (item) {
            //console.log(item);
            $rootScope.toNewInvt = 1;
            location.href = '#/inventoryNew/' + item.ItemID;
        };

        //click the Delete button
        $scope.delete = function (item) {
            //console.log(item);
            BaseService.deleteItem(item.ItemID)
            .then(function (data) {
                alert('Success!');
                location.href = '#/inventoryList/';
            }), function (data) {
                alert(data);
            }
            
        };


        //search function
        $scope.search = function () {
            var S_category = $scope.CategorySelectData.selectedOption.ItemCatID;
            if (S_category == 0) {
                S_category = "null";
            }

            var S_categoryname = $scope.itemName;

            if (S_categoryname == "" || S_categoryname == null) {
                S_categoryname = "null";
            }
            ////console.log("S_category"+S_category);
            //console.log("S_categoryname"+S_categoryname);
            BaseService.searchItem(S_category, S_categoryname)
                .then(function (data) {
                    ////console.log(">>>>>itemdata");
                    ////console.log(data);
                    $scope.inventoryListdata = data;
                    $.each($scope.inventoryListdata, function (index, value) {
                        myBaseService.getItemPrice(value.ItemID)
                            .then(function (itemdata) {
                                ////console.log("itemdata"+itemdata);
                                ////console.log("$scope.supplierID"+$scope.supplierID);
                                $.each(itemdata, function (index, ipvalue) {
                                    ////console.log(ipvalue.SupplierID);
                                    if (ipvalue.SupplierID == $scope.supplierID) {
                                        ////console.log($scope.inventoryListdata.Price);
                                        value.Price = ipvalue.Price;
                                    }

                                })

                            })
                    });
                }, function (data) {
                    alert(data);
                }
            )
        }

    }
})