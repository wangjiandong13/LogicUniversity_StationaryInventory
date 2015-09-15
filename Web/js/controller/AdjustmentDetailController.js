define(['app'], function (app) {
    app.controller('AdjustmentDetailController', ['$rootScope', '$scope', 'BaseService', AdjustmentDetailController]);
    function AdjustmentDetailController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);

        var adjid = $routeParams.adjid;
        $scope.adjid = adjid;
        console.log($scope.adjid);

        var myBaseService = BaseService;
        BaseService.getAdjVoucherByID(adjid)
                .then(function (data) {
                    console.log(data);
                    $scope.Adjustment = data;
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

        BaseService.getAdjDetail(adjid)
            .then(function (data) {
                console.log(data);
                $scope.AdjustmentDetails = data;
            }, function (data) {
                alert(data);
            }
            )

        $scope.back = function () {
            location.href = "#/requisition";
        }

    }
});