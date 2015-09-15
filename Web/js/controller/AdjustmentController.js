define(['app'], function (app) {
    app.controller('AdjustmentController', ['$rootScope', '$scope', 'BaseService', AdjustmentController]);
    function AdjustmentController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);

        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.search = function () {
            var startDate = $("#datestartdata").val();
            if (startDate == "") { startDate = "null"; }
            var endDate = $("#dateenddata").val();
            if (endDate == "") { endDate = "null"; }
            var AdjID = $scope.VoucherNo;
            if (AdjID == null || AdjID == "") { AdjID = "null" }
            console.log(startDate);
            console.log(endDate);
            msg = { "AdjID": AdjID, "startDate": startDate, "endDate": endDate};
            BaseService.getAdjList(msg)
                .then(function (data) {
                    console.log(data);
                    $scope.Adjustments = data;
                    $.each(data, function (index, value) {
                        myBaseService.getEmployee(value.ReportedBy)
                                .then(function (empdata) {
                                    value.EmpName = empdata.EmpName;
                                }, function (data) {
                                    alert(data);
                                })
                    })
                }, function (data) {
                    alert(data);
                }
                )
        }

        msg = { "AdjID": "null", "startDate": "null", "endDate": "null" };
        var myBaseService = BaseService;
        BaseService.getAdjList(msg)
            .then(function (data) {
                console.log(data);
                $scope.Adjustments = data;
                $.each(data, function (index, value) {
                    myBaseService.getEmployee(value.ReportedBy)
                            .then(function (empdata) {
                                value.EmpName = empdata.EmpName;
                            }, function (data) {
                                alert(data);
                            })
                })
            }, function (data) {
                alert(data);
            }
            )

        $scope.new = function () {
            location.href = "#/adjustmentNew";
        };

        $scope.adjdetail = function (Adjustment) {
            $rootScope.AdjID = Adjustment.AdjID;
            location.href = "#/adjustmentDetail";
        };

    }
});
        