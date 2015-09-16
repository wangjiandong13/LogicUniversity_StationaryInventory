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
        $scope.setting = {
            DepartmentSelect: false,
            ItemSelect: false,
            SupplierSelect: false,
            Departmentradio: false,
            Categoryradio: false,
            Supplierradio: false
        };
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.typechange = function () {

        };
        BaseService.getDepartmentList()
            .then(function (data) {
                $scope.DepartmentData.availableOptions = data;
                $scope.DepartmentData.availableOptions.unshift()
            })
        BaseService.getCategory()
            .then(function (data) {
                $scope.ItemData.availableOptions = data;
            })
        BaseService.getSupplierList()
            .then(function (data) {
                $scope.SupplierData.availableOptions = data;
            })
        //$("#datestartdata").val()
    }
});