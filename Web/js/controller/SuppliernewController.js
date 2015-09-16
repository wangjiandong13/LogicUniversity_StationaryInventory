define(['app'], function (app) {
    app.controller('SuppliernewController', ['$rootScope', '$scope', 'BaseService', '$routeParams', SuppliernewController]);
    function SuppliernewController($rootScope, $scope, BaseService, $routeParams) {
        $rootScope.changehighlight(16);

        var supplierid = $routeParams.supplierid;
        $scope.supplierid = supplierid;

        //New Page
        if (supplierid == 0) {
            $scope.Title = "New";

            $scope.save = function () {
                if ($scope.Supplier.SupplierID == "" || $scope.Supplier.SupplierID == null || $scope.Supplier.SupplierName == "" || $scope.Supplier.SupplierName == null || $scope.Supplier.Contact == "" || $scope.Supplier.Contact == null || $scope.Supplier.RegNo == "" || $scope.Supplier.RegNo == null || $scope.Supplier.Phone == "" || $scope.Supplier.Phone == null || $scope.Supplier.Address == "" || $scope.Supplier.Address == null || $scope.Supplier.Fax == "" || $scope.Supplier.Fax == null)
                    alert('Unable to save. Kindly fill in all fields');
                msg = {SupplierID: $scope.Supplier.SupplierID, SupplierName: $scope.Supplier.SupplierName, Contact: $scope.Supplier.Contact, RegNo: $scope.Supplier.RegNo, Phone: $scope.Supplier.Phone, Address: $scope.Supplier.Address, Fax: $scope.Supplier.Fax}
                BaseService.createSupplier(angular.toJson(msg))
                .then(function (data) {
                    alert('Success!');
                    location.href = "#/supplier";
                }, function(data){
                    alert(data);
                })
            }
        }
        //Edit Page
        else {
            $scope.Title = "Edit";

            BaseService.getBySupplierID(supplierid)
            .then(function (data) {
                $scope.Supplier = data;
                console.log(data);
            }, function (data) {
                alert(data);
            })

            $scope.save = function () {
                if ($scope.Supplier.SupplierID == "" || $scope.Supplier.SupplierID == null || $scope.Supplier.SupplierName == "" || $scope.Supplier.SupplierName == null || $scope.Supplier.Contact == "" || $scope.Supplier.Contact == null || $scope.Supplier.RegNo == "" || $scope.Supplier.RegNo == null || $scope.Supplier.Phone == "" || $scope.Supplier.Phone == null || $scope.Supplier.Address == "" || $scope.Supplier.Address == null || $scope.Supplier.Fax == "" || $scope.Supplier.Fax == null)
                    alert('Unable to save. Kindly fill in all fields');
                msg = { SupplierID: $scope.Supplier.SupplierID, SupplierName: $scope.Supplier.SupplierName, Contact: $scope.Supplier.Contact, RegNo: $scope.Supplier.RegNo, Phone: $scope.Supplier.Phone, Address: $scope.Supplier.Address, Fax: $scope.Supplier.Fax }
                BaseService.updateSupplier(angular.toJson(msg))
                .then(function (data) {
                    alert('Success!');
                    location.href = "#/supplier";
                }, function (data) {
                    alert(data);
                })
            }
        }

        $scope.back = function () {
            location.href = "#/supplier";
        }
    }
});