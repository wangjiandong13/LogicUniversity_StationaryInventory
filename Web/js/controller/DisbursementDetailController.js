define(['app'], function (app) {
    app.controller('DisbursementDetailController', ['$scope', '$rootScope', "$routeParams", 'BaseService', DisbursementDetailController]);

    function DisbursementDetailController($scope, $rootScope, $routeParams, BaseService) {
        var disid = $routeParams.disid;
        $scope.disid = disid;
        var myBaseService = BaseService;
        console.log($scope.disid);
        BaseService.getDisbursementList("null", "null", disid, "null", "null")
            .then(function (data) {
                console.log(data);
                $scope.DisbursementData = data;
                myBaseService.getEmployee(data.EmpID)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.DisbursedBy = data.EmpName;
                       })
                console.log("++++++"+data.ReceivedBy);

                if (data.ReceivedBy != null) {
                    myBaseService.getEmployee(data.ReceivedBy)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.ReceivedBy = data.EmpName;
                       })
                } else {
                    $scope.RequisitionData.ReceivedBy = "";
                }
            }, function (data) {
                alert(data);
            }
            )
        BaseService.getDisbursementDetail(disid)
            .then(function (data) {
                console.log(data);
                $scope.DisbursementDetailLists = data;
                $.each($scope.DisbursementDetailLists, function (index, value) {
                    console.log(value.ItemID);
                    myBaseService.getItemDetail(value.ItemID)
                        .then(function (data) {
                            value.Description = data.ItemName;
                        }, function (data) {
                            alert(data);
                        }
                        )
                });
            }, function (data) {
                alert(data);
            }
            )
        $scope.back = function () {
            location.href = "#/disbursement";
        }
        $scope.viewRequisition = function () {
            location.href = "#/disbursementRequisition/" + disid;
        }
    }
})