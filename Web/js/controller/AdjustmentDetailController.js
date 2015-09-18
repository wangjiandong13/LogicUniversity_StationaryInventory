define(['app'], function (app) {
    app.controller('AdjustmentDetailController', ['$rootScope', '$scope', 'BaseService', AdjustmentDetailController]);
    function AdjustmentDetailController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);

        var adjid = $rootScope.AdjID;
        console.log(adjid);

        var myBaseService = BaseService;
        
        var msg = { "AdjID": adjid, "startDate": "null", "endDate": "null" };
        BaseService.getAdjList(msg)
                .then(function (data) {
                    console.log(data);
                    $scope.Adjustment = data[0];
                    $.each(data, function (index, value) {
                        myBaseService.getEmployee(value.ReportedBy)
                                .then(function (empdata) {
                                    value.ReportedBy = empdata.EmpName;
                                }, function (data) {
                                    alert(data);
                                })
                        if (value.ApprovedBy != null || value.ApprovedBy != "" || value.ApprovedBy != "NULL") {
                            myBaseService.getEmployee(value.ApprovedBy)
                                .then(function (empdata) {
                                    value.ApprovedBy = empdata.EmpName;
                                }, function (data) {
                                    alert(data);
                                })
                        } else {
                            value.ApprovedBy = "";
                        }
                        
                    })
                }, function (data) {
                    alert(data);
                }
                )

        var msgAdjId = { "adjId": adjid };
        BaseService.getAdjDetail(angular.toJson(msgAdjId))
            .then(function (data) {
                console.log(data);
                $scope.AdjustmentDetails = data;
            }, function (data) {
                alert(data);
            }
            )

        $scope.back = function () {
            location.href = "#/adjustment";
        }

    }
});