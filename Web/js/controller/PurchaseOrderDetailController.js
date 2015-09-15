define(['app'], function (app) {
    app.controller('PurchaseOrderDetailControllers', ['$scope', '$rootScope', "$routeParams", 'BaseService', PurchaseOrderDetailControllers]);
    function PurchaseOrderDetailControllers($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(13);
        var PoID = $routeParams.PoID;
        var MyBaseService = BaseService;
        BaseService.getPoList("null", "null", "null", PoID)
            .then(function (data) {
                $scope.PoData = data[0];
                MyBaseService.getPoDetail(PoID)
                    .then(function (data) {
                        $scope.PoDetails = data;
                        $.each($scope.PoDetails, function (index, value) {
                            MyBaseService.getItemDetail(value.ItemID)
                                .then(function (data) {
                                    value.ItemName = data.ItemName;
                                })
                            if ($scope.PoData.Status == "DELIVERED") {
                                $scope.Restockbtn = false;
                                $scope.ActualQty = true;
                            } else {
                                $scope.Restockbtn = true;
                                $scope.ActualQty = false;
                                $.each($scope.PoDetails, function (index, value) {
                                    value.ActualQty = 0;
                                })
                            }
                        })
                    })
            })

        $scope.Restock = function () {  
            var msg = [];
            if (checkActualQty()) {
                $.each($scope.PoDetails, function (index, value) {
                    var each = {
                        PoID: value.PoID,
                        ItemID: value.ItemID,
                        ActualQty: value.ActualQty
                    };
                    msg.push(each);
                })
                MyBaseService.restockPo(angular.toJson(msg))
                    .then(data, function (data) {
                        alert("Success!");
                    })
            }
        }
        $scope.back = function () {
            location.href = "#/purchaseOrder";
        }
        function checkActualQty() {
            $.each($scope.PoDetails, function (index,value) {
                if (value.ActualQty == 0) {
                    alert("Please enter  " + value.ItemName + "Qty Received");
                    return false
                }
            })
            return true
        }
    }
    
})