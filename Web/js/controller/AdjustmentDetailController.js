define(['app'], function (app) {
    app.controller('AdjustmentDetailController', ['$rootScope', '$scope', 'BaseService', AdjustmentDetailController]);
    function AdjustmentDetailController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);

        var adjid = $rootScope.AdjID;
        console.log(adjid);

        var myBaseService = BaseService;
        
        var msg = { "AdjID": adjid, "startDate": "null", "endDate": "null" };
        BaseService.getAdjVoucherByID(msg)
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

        var msgAdjId = { "AdjID": adjid };
        BaseService.getAdjDetail(msgAdjId)
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