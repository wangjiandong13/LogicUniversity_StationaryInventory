﻿define(['app'], function (app) {
    app.controller('DisbursementnControllers', ['$rootScope', '$scope', 'BaseService', DisbursementnControllers]);
    app.controller('DisbursementList', ['$rootScope', '$scope', 'BaseService', DisbursementList]);
    function DisbursementnControllers($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(5);

        $scope.search = function () {
            var startDate = $rootScope.StartDate;
            if (startDate == "") { startDate = "null"; }
            var endDate = $rootScope.EndDate;
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
            location.href = "#/disbursementDetail/" + Disbursement.DisID;
        };
    }
});