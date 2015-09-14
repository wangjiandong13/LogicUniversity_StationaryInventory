define(['app'], function (app) {
    app.controller('DisbursementnControllers', ['$rootScope', '$scope', 'BaseService', DisbursementnControllers]);
    app.controller('DisbursementList', ['$rootScope', '$scope', 'BaseService', DisbursementList]);
    function DisbursementnControllers($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(5);
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.search = function () {
            var startDate = $("#datestartdata").val();
            if (startDate == "") { startDate = "null"; }
            var endDate = $("#datestartdata").val();
            if (endDate == "") { endDate = "null"; }
            var disID = $scope.DisbursementNo;
            if (disID == null) { disID = "null" }
            BaseService.getDisbursementList($rootScope.UserInfo.DeptId, "null", disID, startDate, endDate)
                .then(function (data) {
                    console.log(data);
                    $rootScope.Disbursements = data;
                }, function (data) {
                    alert(data);
                }
                )
        }
    }
    function DisbursementList($rootScope, $scope, BaseService) {
        BaseService.getDisbursementList($rootScope.UserInfo.DeptId, "null", "null", "null", "null")
            .then(function (data) {
                console.log(data);
                $rootScope.Disbursements = data;
            }, function (data) {
                alert(data);
            }
        )
        $scope.disbursementdetail = function (Disbursement) {
            $rootScope.disbBackTo = 0;
            location.href = "#/disbursementDetail/" + Disbursement.DisID;
        };
    }
});