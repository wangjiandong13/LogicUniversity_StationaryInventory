define(['app'], function (app) {
    app.controller('AnalyticsController', ['$rootScope', '$scope', 'BaseService', AnalyticsController]);
    function AnalyticsController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(17);

        var myBaseService = BaseService;
        BaseService.getReports()
            .then(function (data) {
                //console.log(data);
                $scope.Reports = data;
                $.each(data, function (index, value) {
                    myBaseService.getEmployee(value.EmpID)
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

        $scope.generate = function () {
            location.href = "#/analyticsnew";
        };

        $scope.rptdetail = function (Report) {
            var reportid = Report.ReportID;
            location.href = "#/analyticsdetail/" + reportid;
        };

    }
});
