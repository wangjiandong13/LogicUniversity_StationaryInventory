define(['app'], function (app) {
    app.controller('PurchaseOrderProposeControllers', ['$scope', '$rootScope', 'BaseService', PurchaseOrderProposeControllers]);
    function PurchaseOrderProposeControllers($scope, $rootScope, BaseService) {
        $rootScope.changehighlight(13);
        $scope.listitems = [];
        $scope.addtolistbtn = true;
        $scope.Savebtn = true;
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.supplierName = {
            supplier1: "",
            supplier2: "",
            supplier3: ""
        }
        $scope.additem = {
            ItemName: "",
            ItemID: "",
            supplier1Qty: 0,
            supplier2Qty: 0,
            supplier3Qty: 0,
            total:0
        }
        BaseService.proposePo()
            .then(function (data) {
                $scope.listitems = data;
            }, function (data) {
                alert(data);
            })
        BaseService.getSupplierList()
            .then(function (data) {
                $scope.supplierName.supplier1 = data[0].SupplierID;
                $scope.supplierName.supplier2 = data[1].SupplierID;
                $scope.supplierName.supplier3 = data[2].SupplierID;
            })
        BaseService.getCatalogList()
            .then(function (data) {
                $scope.items = data;
            })
        $scope.supplier = function (item) {
            openchoosesupplier();
            ////console.log($('#ChooseSupplier').modal());
            $scope.addtolistbtn = true;
            $scope.Savebtn = false;
            $scope.additem.ItemName = item.ItemName;
            $scope.additem.supplier1Qty = item.RoQty;
            $scope.additem.ItemID = item.ItemID;
        }
        $scope.edit = function (item) {
            $scope.addtolistbtn = false;
            $scope.Savebtn = true;
            openchoosesupplier();
            ////console.log(item);
            $scope.additem.ItemName = item.ItemName;
            $scope.additem.supplier1Qty = item.supplier1Qty;
            $scope.additem.supplier2Qty = item.supplier2Qty;
            $scope.additem.supplier3Qty = item.supplier3Qty;
            $scope.additem.ItemID = item.ItemID;
            ////console.log($scope.additem);
        }
        function openchoosesupplier() {
                $('#ChooseSupplier').modal('toggle');
        }
        function closechoosesupplier() {
            $('#ChooseSupplier').modal('hide');
        }
        function closeAdditem() {
            $('#Additem').modal('hide');
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
                        value.supplier2Qty = value.supplier2Qty + $scope.additem.supplier2Qty;
                        value.supplier3Qty = value.supplier3Qty + $scope.additem.supplier3Qty;
                    }
                })
            }
            else {
                $scope.listitems.push($scope.additem);
            }
            closechoosesupplier();
            closeAdditem();
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
                if (value.ItemID == $scope.additem.ItemID) {
                    value.supplier1Qty = $scope.additem.supplier1Qty;
                    value.supplier2Qty = $scope.additem.supplier2Qty;
                    value.supplier3Qty = $scope.additem.supplier3Qty;
                }
            })
            $('#ChooseSupplier').modal('hide');
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
        function checkifinlist() {
            var str_return = false;
            $.each($scope.listitems, function (index, value) {
                ////console.log(value);
                ////console.log($scope.additem.ItemID);
                if (value.ItemID == $scope.additem.ItemID) {
                    str_return = true;
                }
            })
            return str_return;
        }
        $scope.cancelbtn = function () {
            location.href = "#/purchaseOrder";
        }
        $scope.submit = function () {
            var date=$("#datedata").val();
            var msg = [];
            if (date != null && date != "" && $scope.listitems.length != 0) {
                $.each($scope.listitems, function (index, value) {
                    var each = {
                        EmpID: $rootScope.UserInfo.EmpId,
                        EstDate: date,
                        ItemID: value.ItemID,
                        ItemName: value.ItemName,
                        totalQty: value.supplier1Qty + value.supplier2Qty + value.supplier3Qty,
                        supplier1Qty: value.supplier1Qty,
                        supplier2Qty: value.supplier2Qty,
                        supplier3Qty: value.supplier3Qty,
                    };
                    msg.push(each);
                })
                console.log(angular.toJson(msg));
                BaseService.generatePo(angular.toJson(msg))
                    .then(function (data) {
                        alert("Success");
                        location.href = "#/purchaseOrder";
                    }, function (data) {
                        alert("Fail");
                    })
            }
            else {
                alert("data error");
            }
        }
    }
})