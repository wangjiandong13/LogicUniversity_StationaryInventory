define(['app'], function (app) {
    app.controller('analyticsNew', ['$rootScope', '$scope', 'BaseService', analyticsNew]);
    function analyticsNew($rootScope, $scope, BaseService) {
        $scope.Reporttype = {
            availableOptions: [{ 'id': 1, 'Type': 'Total no. of Requisitions' }, { 'id': 2, 'Type': 'Total no. of Request Items' },
                { 'id': 3, 'Type': 'Total no. of Purchase Orders' }, { 'id': 4, 'Type': 'Total no. of Reorder Items' }
            ],
            selectedOption: { 'id': 1, 'Type': 'Total no. of Requisitions' }
        };
        $scope.DepartmentData = {
            availableOptions: [],
            selectedOption: { DeptID: 0, DeptName: '--Over All--' }
        };
        $scope.ItemData = {
            availableOptions: [],
            selectedOption: { ItemID: 0, ItemName: '--Over All--' }
        };
        $scope.SupplierData = {
            availableOptions: [],
            selectedOption: { SupplierID: 0, SupplierName: '--Over All--' }
        };
        $scope.FilterData = {
            availableOptions: [{ ID: 0, Name: 'Department' }],
            selectedOption: { ID: 0, Name: 'Department' }
        };
        $scope.setting = {
            DepartmentSelect: false,
            ItemSelect: false,
            SupplierSelect: false
        };
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.typechange = function () {
            if ($scope.Reporttype.selectedOption.id == 1) {
                $scope.setting = {
                    DepartmentSelect: false,
                    ItemSelect: false,
                    SupplierSelect: false
                };
                $scope.FilterData.availableOptions = [{ ID: 0, Name: 'Department' }];
                $scope.FilterData.selectedOption = { ID: 0, Name: 'Department' };
            }
            if ($scope.Reporttype.selectedOption.id == 2) {
                $scope.setting = {
                    DepartmentSelect: false,
                    ItemSelect: false,
                    SupplierSelect: false
                };
                $scope.FilterData.availableOptions = [{ ID: 0, Name: 'Department' }, { ID: 1, Name: 'Item Category' }];
                $scope.FilterData.selectedOption = { ID: 0, Name: 'Department' };
                $scope.setting.ItemSelect = true;
            }
            if ($scope.Reporttype.selectedOption.id == 3) {
                $scope.setting = {
                    DepartmentSelect: false,
                    ItemSelect: false,
                    SupplierSelect: false
                };
                $scope.FilterData.availableOptions = [{ ID: 2, Name: 'Supplier' }];
                $scope.FilterData.selectedOption = { ID: 2, Name: 'Supplier' };
            }
            if ($scope.Reporttype.selectedOption.id == 4) {
                $scope.setting = {
                    DepartmentSelect: false,
                    ItemSelect: false,
                    SupplierSelect: false
                };
                $scope.FilterData.availableOptions = [{ ID: 1, Name: 'Item Category' }, { ID: 2, Name: 'Supplier' }];
                $scope.FilterData.selectedOption = { ID: 1, Name: 'Item Category' };
                $scope.setting.SupplierSelect = true;
            }
        };
        $scope.Filterchange = function () {
            console.log(">>enter filterchange")
            if ($scope.FilterData.selectedOption.ID == 0 || $scope.FilterData.selectedOption.ID == 2) {
                $scope.setting = {
                    DepartmentSelect: false,
                    ItemSelect: true,
                    SupplierSelect: false
                };
            }
            if ($scope.FilterData.selectedOption.ID == 1) {
                if ($scope.Reporttype.selectedOption.id == 2) {
                    $scope.setting = {
                        DepartmentSelect: true,
                        ItemSelect: false,
                        SupplierSelect: false
                    };
                }
                if ($scope.Reporttype.selectedOption.id == 4) {
                    $scope.setting = {
                        DepartmentSelect: false,
                        ItemSelect: true,
                        SupplierSelect: false
                    };
                }
            }
        }
        BaseService.getDepartmentList()
            .then(function (data) {
                $scope.DepartmentData.availableOptions = data;
                $scope.DepartmentData.availableOptions.unshift({ DeptID: 0, DeptName: '--Over All--' });
            })
        BaseService.getCategory()
            .then(function (data) {
                console.log(data);
                $scope.ItemData.availableOptions = data;
                $scope.ItemData.availableOptions.unshift({ ItemID: 0, ItemDescription: '--Over All--' });
            })
        BaseService.getSupplierList()
            .then(function (data) {
                $scope.SupplierData.availableOptions = data;
                $scope.SupplierData.availableOptions.unshift({ SupplierID: 0, SupplierName: '--Over All--' });
            })
        $scope.cancel = function () {
            location.href = "#/analytics";
        }
        $scope.generate = function () {
            if ($scope.title != null && $scope.title != "") {
                if ($("#datestartdata").val() != null && $("#dateenddata").val() != null&&$("#datestartdata").val() != "" && $("#dateenddata").val() != "") {
                    var msg = {
                        EmpID: $rootScope.UserInfo.EmpId,
                        Title: $scope.title,
                        StartD: $("#datestartdata").val(),
                        EndD: $("#dateenddata").val(),
                        Remark: $scope.Remarks,
                        Type: $scope.Reporttype.selectedOption.id,
                        Precriteria: $scope.FilterData.selectedOption.ID,
                        Criteria: ""
                    }
                    if ($scope.setting.DepartmentSelect) {
                        msg.Criteria = $scope.DepartmentData.selectedOption.DeptID;
                    }
                    else if ($scope.setting.ItemSelect) {
                        msg.Criteria = $scope.ItemData.selectedOption.ItemID;
                    }
                    else if ($scope.setting.SupplierSelect) {
                        msg.Criteria = $scope.SupplierData.selectedOption.SupplierID;
                    } else {
                        msg.Criteria = "0";
                    }
                    BaseService.generateNewReport(angular.toJson(msg))
                        .then(function (data) {
                            alert("Success");
                            location.href = "#/analyticsdetail/" + data;
                        }, function (data) {
                            alert("Faided");
                        })
                } else {
                    alert("Enter your Date!");
                }
            } else {
                alert("Enter your tile!");
            }
        }
    }
});