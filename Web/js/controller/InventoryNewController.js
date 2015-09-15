define(['app'], function (app) {
    app.controller('InventoryNewControllers', ['$rootScope', '$scope', 'BaseService', InventoryNewControllers]);
    app.controller('InventoryNewListCtrl', ['$rootScope', '$scope', 'BaseService', InventoryNewList]);

    function InventoryNewControllers($rootScope, $scope, BaseService) {
        //set mean highlight
        $rootScope.changehighlight(12);

        var myBaseService = BaseService;
        
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

        if ($scope.toNewInvt == 0) {
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

            //Edit: click submit 
            $scope.submit = function () {
                console.log("enter");
                var msg = [];
                if ($rootScope.RequestCarts != null) {
                    $.each($rootScope.RequestCarts, function (index, value) {
                        var each = {
                            EmpID: $rootScope.UserInfo.EmpId,
                            ItemID: value.ItemID,
                            Qty: value.Qty,

                        };
                        msg.push(each);
                    });
                    var req_id = "";
                    selfBaseService.createRequisition(angular.toJson(msg))
                        .then(function (data) {
                            console.log(data);
                            req_id = data;
                            var priority = 2;
                            if ($('#create-switch').is(":checked")) { priority = 1 }
                            selfBaseService.setReqPriority(req_id, priority, $scope.remoarks)
                                .then(function (data) {
                                    alert("success!");
                                    location.href = '#/requisition';
                                })
                        }, function (data) {
                            alert(data);
                        })
                }
            }
        }

        $scope.cancel = function () {
            location.href = '#/inventoryList';
        }
        
    }
    function InventoryNewList($rootScope, $scope, BaseService) {
        //get EmpId from session
        var EmpId = $rootScope.UserInfo.EmpId;
        var selfBaseService = BaseService;
        console.log("enter requestCartListCtrls");
        BaseService.getRequestCart(EmpId)
            .then(function (data) {
                console.log(data);
                $rootScope.RequestCarts = data;
            }, function (data) {
                alert(data);
            })
        $scope.delect = function (RequestCart) {
            var msg = '{"ItemID":"' + RequestCart.ItemID + '" ,"EmpID":' + EmpId + '}';
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
