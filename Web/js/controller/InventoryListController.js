﻿define(['app'], function (app) {
    app.controller('inventoryListCtrl', ['$rootScope', '$scope', 'BaseService', inventoryListCtrl]);
    app.controller('inventoryListDataCtrl', ['$scope', 'BaseService', inventoryListDataCtrl]);
    function inventoryListCtrl($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(12);
        var myBaseService = BaseService;
        //click the New button
        $scope.new = function () {
            location.href = '#/inventoryNew';
        };

        //get categoryselectData
        $scope.CategorySelectData = {
            availableOptions: [],
            selectedOption: { ItemCatID: 0, ItemDescription: 'ALL' }
        };
        BaseService.getCategory()
            .then(function (data) {
                //console.log(data);
                $scope.CategorySelectData.availableOptions = data;
                $scope.CategorySelectData.availableOptions.unshift({ ItemCatID: 0, ItemDescription: 'ALL' });
            }, function (data) {
                alert(data);
            })

        //search function
        $scope.search = function () {
            var S_category = $scope.CategorySelectData.selectedOption.ItemCatID;
            if (S_category == 0) {
                S_category = "null";
            }

            var S_categoryname = $scope.categoryname;

            if (S_categoryname == "" || S_categoryname == null) {
                S_categoryname = "null";
            }
            //console.log(S_category);
            //console.log(S_categoryname);
            BaseService.searchItem(S_category, S_categoryname)
                .then(function (data) {
                    //console.log(data);
                    $scope.inventoryListdata = data;
                    $.each($scope.inventoryListdata, function (index, value) {
                        myBaseService.getItemPrice(value.ItemID)
                            .then(function (itemdata) {
                                //console.log(itemdata);
                                //console.log($scope.supplierID);
                                $.each(itemdata, function (index, ipvalue) {
                                    //console.log(ipvalue.SupplierID);
                                    if (ipvalue.SupplierID == $scope.supplierID) {
                                        //console.log($scope.inventoryListdata.Price);
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
    //load catalogList
    function inventoryListDataCtrl($scope, BaseService) {
        //console.log("enter");
        var myBaseService = BaseService;
        BaseService.getSupplierList()
        .then(function (supplierdata) {
            $.each(supplierdata, function (index, value) {
                console.log(value.Rank);
                if (value.Rank == 1)
                    $scope.supplierID = value.SupplierID;
            })

            myBaseService.getCatalogList()
            .then(function (data) {
                //console.log(data);
                $scope.inventoryListdata = data;
                $.each($scope.inventoryListdata, function (index, value) {
                    myBaseService.getItemPrice(value.ItemID)
                    .then(function (itemdata) {
                        //console.log(itemdata);
                        //console.log($scope.supplierID);
                        $.each(itemdata, function (index, ipvalue) {
                            //console.log(ipvalue.SupplierID);
                            if (ipvalue.SupplierID == $scope.supplierID)
                            {
                                //console.log($scope.inventoryListdata.Price);
                                value.Price = ipvalue.Price;
                            }
                                
                        })
                        
                    })
                });
            }, function (data) {
                alert(data);
            }
       )
        })




        //click the Stock Card button
        $scope.stockCard = function () {
            location.href = '#/stockcard';
        };
        //click the Edit button
        $scope.edit = function () {
            console.log($scope.catalogListdata.itemID);
            location.href = '#/inventoryNew/' + $scope.catalogListdata.itemID;
        };
    }
})