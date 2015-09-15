define(['app'], function (app) {
    app.controller('AdjustmentApprovalController', ['$rootScope', '$scope', 'BaseService', AdjustmentApprovalController]);
    function AdjustmentApprovalController($rootScope, $scope, BaseService) {
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
                        myBaseService.getEmployee(value.ApprovedBy)
                                .then(function (empdata) {
                                    value.ApprovedBy = empdata.EmpName;
                                }, function (data) {
                                    alert(data);
                                })
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

        $scope.reject = function (Adjustment) {
            var msgReject = { adjId: Adjustment.AdjID, ApprovedBy: $rootScope.UserInfo.EmpId };
            BaseService.rejectAdj(angular.toJson(msgReject))
            .then(function (data) {
                alert('Success!');
                location.href = "#/adjustment";
            }, function (data) {
                alert(data);
            })
        }

        $scope.approve = function (Adjustment) {
            var msgApprove = { adjId: Adjustment.AdjID, ApprovedBy: $rootScope.UserInfo.EmpId };
            BaseService.approveAdj(angular.toJson(msgApprove))
            .then(function (data) {
                alert('Success!');
                location.href = "#/adjustment";
            }, function (data) {
                alert(data);
            })
        }

    }
});