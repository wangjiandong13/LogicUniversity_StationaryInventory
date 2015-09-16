define(['app'], function (app) {
    app.controller('SupplierController', ['$rootScope', '$scope', 'BaseService', SupplierController]);
    function SupplierController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(16);
        $scope.ifedit = true;
        $scope.supplierselect = {
            availableOptions: []
        }
        $scope.supplier1 = {};
        $scope.supplier2 = {};
        $scope.supplier3 = {};

        if ($rootScope.UserInfo.RoleId == "SC") {
            $scope.setting = {
                ifedit: false,
                editPrioritybtn: false,
                savePrioritybtn: false,
                //disablebox: true,
                saveDetailbtn: false,
                editSupplierRank: false,
            }
        }

        if ($rootScope.UserInfo.RoleId == "SS" || $rootScope.UserInfo.RoleId == "SM") {
            $scope.setting = {
                ifedit: false,
                editPrioritybtn: false,
                savePrioritybtn: false,
                disablebox: true,
                saveDetailbtn: false,
                editSupplierRank: true,
            }
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
            if ($scope.supplier1.SupplierID == $scope.supplier2.SupplierID || $scope.supplier1.SupplierID == $scope.supplier3.SupplierID || $scope.supplier2.SupplierID == $scope.supplier3.SupplierID) {
                alert('Please choose three different supplier.');
            }
            var myBaseService = BaseService;
            BaseService.getSupplierInfo()
                .then(function (data) {
                    $.each(data, function (index, value) {
                        if ($scope.supplier1.SupplierID == value.SupplierID) {
                            myBaseService.updateSupplierRank($scope.supplier1.SupplierID, 1)
                            .then(function (data) {
                                console.log('Success! supplier 1 rank updated');
                            }, function (data) {
                                console.log('Fail to update supplier 1');
                            })
                        }
                        else if ($scope.supplier2.SupplierID == value.SupplierID) {
                            myBaseService.updateSupplierRank($scope.supplier1.SupplierID, 2)
                                .then(function (data) {
                                    console.log('Success! supplier 2 rank updated');
                                }, function (data) {
                                    console.log('Fail to update supplier 2');
                                })
                        }
                        else if ($scope.supplier3.SupplierID == value.SupplierID) {
                            myBaseService.updateSupplierRank($scope.supplier1.SupplierID, 3)
                            .then(function (data) {
                                console.log('Success! supplier 3 rank updated');
                            }, function (data) {
                                console.log('Fail to update supplier 3');
                            })
                        }
                        else {
                            myBaseService.updateSupplierRank($scope.supplier1.SupplierID, 4)
                            .then(function (data) {
                                console.log('Success! Other rank updated');
                            }, function (data) {
                                console.log('Fail to update other');
                            })
                        }

                    })

                    $scope.setting.savePrioritybtn = false;
                    $scope.setting.editPrioritybtn = true;
                    $scope.setting.disablebox = true;
                }, function (data) {
                    alert(data);
                })
        }
        $scope.NewSupplier = function () {
            location.href = "#/suppliernew/0";
        }

        BaseService.getSupplierInfo()
                .then(function (data) {
                    $scope.Suppliers = data;
                    console.log(data);
                }, function (data) {
                    alert(data);
                })
        $scope.editDetail = function (Supplier)
        {
            location.href = "#/suppliernew/" + Supplier.SupplierID;
        }
        $scope.delete = function (Supplier) {
            BaseService.deleteSupplier(Supplier.SupplierID)
            .then(function (data) {
                alert('Success!');
                location.href = "#/supplier";
            }, function (data) {
                alert(data);
            })
        }
    }
})