define(['app'], function (app) {
    app.controller('DisbursementnControllers', ['$rootScope', '$scope', 'BaseService', DisbursementnControllers]);
    app.controller('DisbursementList', ['$rootScope', '$scope', 'BaseService', DisbursementList]);
    function DisbursementnControllers($rootScope, $scope, BaseService) {
        //set mean highlight
        $rootScope.mean = {
            Requistion: "active",
            Catalog: "",
            Department: "",
            RequestCart: "",
            ifRequistion: true,
            ifCatalog: false,
            ifDepartment: false,
            ifRequestCart: false
        };

        $scope.search = function () {
            var startDate = $rootScope.StartDate;
            if (startDate == "") { startDate = "null"; }
            var endDate = $rootScope.EndDate;
            if (endDate == "") { endDate = "null"; }
            var disID = $scope.DisbursementNo;
            if (disID == null) { disID = "null" }
            BaseService.getDisbursementList("null", "null", disID, startDate, endDate)
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
        BaseService.getDisbursementList("null", "null", $rootScope.UserInfo.EmpId)
            .then(function (data) {
                console.log(data);
                $rootScope.Disbursements = data;
            }, function (data) {
                alert(data);
            }
        )
        $scope.requisitiondetail = function (Requisition) {
            location.href = "#/requisitionDetail/" + Requisition.ReqID;
        };
    }
});