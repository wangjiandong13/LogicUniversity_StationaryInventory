define(['app'], function (app) {
    app.controller('PurchaseOrderControllers', ['$rootScope', '$scope', 'BaseService', PurchaseOrderControllers]);
    function PurchaseOrderControllers($rootScope, $scope, BaseService) {
        //load the date picker
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.employeeselectdata = {
            availableOptions: [],
            selectedOption: { EmpID: 0, EmpName: 'ALL' }
        };
        BaseService.getStoreClerk()
            .then(function (data) {
                ////console.log(data);
                $scope.employeeselectdata.availableOptions = data;
                $scope.employeeselectdata.availableOptions.unshift({ EmpID: 0, EmpName: 'ALL' });
            })
        var MyBaseService = BaseService;
        BaseService.getPoList("null", "null", "null", "null")
                .then(function (data) {
                    $scope.polist = data;
                    $.each(data, function (index, value) {
                        MyBaseService.getEmployee(value.EmpID)
                            .then(function (data) {
                                value.EmpName = data.EmpName;
                            })
                    })
                })
        $scope.search = function () {
            var S_EmpID = $scope.employeeselectdata.selectedOption.EmpID;
            if (S_EmpID == 0) {
                S_EmpID = "null";
            }
            var S_PONo = $scope.PONo;
            if (S_PONo == ""||S_PONo == null) {
                S_PONo = "null";
            }
            var startDate = $("#datestartdata").val();
            if (startDate == "") { startDate = "null"; }
            var endDate = $("#dateenddata").val();
            if (endDate == "") { endDate = "null"; }
            BaseService.getPoList(startDate, endDate, S_EmpID, S_PONo)
                .then(function (data) {
                    $scope.polist = data;
                    $.each(data, function (index, value) {
                        MyBaseService.getEmployee(value.EmpID)
                            .then(function (data) {
                                value.EmpName = data.EmpName;
                            })
                    })
                })
        }
    }
});