define(['app'], function (app) {
    app.controller('supplierController', ['$rootScope', '$scope', 'BaseService', supplierController]);
    function supplierController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(16);
        $scope.ifedit = true;
        $scope.supplierselect={
            availableOptions : []}
        $scope.supplier1 = {};
        $scope.supplier2 = {};
        $scope.supplier3 = {};
        $scope.setting = {
            ifedit:true,
            editPrioritybtn: true,
            savePrioritybtn: false,
            disablebox: true,
            saveDetailbtn: false,
        }
        BaseService.getSupplierList()
            .then(function (data) {
                $scope.supplierselect.availableOptions = data;
                $.each(data, function (index, value) {
                    if (value.Rank == 1) {
                        $scope.supplier1 = { SupplierID: value.SupplierID, SupplierName: value.SupplierName };
                    }
                    if (value.Rank == 2) {
                        $scope.supplier2 = { SupplierID: value.SupplierID, SupplierName: value.SupplierName };
                    }
                    if (value.Rank == 3) {
                        $scope.supplier3 = { SupplierID: value.SupplierID, SupplierName: value.SupplierName };
                    }
                })
            }
            )
        $scope.editPriority = function () {
            $scope.setting.savePrioritybtn = true;
            $scope.setting.editPrioritybtn = false;
            $scope.setting.disablebox = false;
        }
        $scope.savePriority = function () {

        }
        $scope.NewSupplier = function () {
            location.href = "#/suppliernew";
        }
    }
})