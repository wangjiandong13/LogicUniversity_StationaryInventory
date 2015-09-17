define(['app'], function (app) {
    app.controller('RequisitionApprovalController', ['$scope', '$rootScope', "$routeParams", 'BaseService', RequisitionApprovalController]);

    function RequisitionApprovalController($scope, $rootScope, $routeParams, BaseService) {
        var reqid = $routeParams.reqid;
        $scope.reqid = reqid;
        var myBaseService = BaseService;
        console.log($scope.reqid);
        BaseService.getRequisitionByReqID($scope.reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data;
                myBaseService.getEmployee(data.EmpID)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.EmpName = data.EmpName;
                       })
                myBaseService.getPriorityName(data.PriorityID)
                        .then(function (data) {
                            console.log(data);
                            $scope.RequisitionData.Priority = data;
                        })
                if (data.HandledBy != null) {
                    myBaseService.getEmployee(data.HandledBy)
                           .then(function (data) {
                               //console.log("getEmployee");
                               $scope.RequisitionData.HandledByName = data.EmpName;
                           })
                } else {
                    $scope.RequisitionData.HandledByName = "";
                }
                if (data.RetID != null) {
                    myBaseService.getRetrievalListBySC("null", "null", data.RetID)
                           .then(function (data) {
                               if (data.EmpID != null) {
                                   myBaseService.getEmployee(data.EmpID)
                                       .then(function (data) {
                                           $scope.RequisitionData.ProcessedByName = data.EmpName;
                                       })
                               }
                           })
                } else {
                    data.ProcessedByName = "";
                }
            }, function (data) {
                alert(data);
            }
            )
        BaseService.getRequisitionDetailList(reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionDetailLists = data;
                $.each($scope.RequisitionDetailLists, function (index, value) {
                    console.log(value.ItemID);
                    myBaseService.getItemDetail(value.ItemID)
                        .then(function (data) {
                            value.Description = data.ItemName;
                            value.Measurement = data.UOM;
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
            location.href = "#/requisition";
        }
        $scope.reject = function () {
            BaseService.rejectRequisition($scope.reqid, $rootScope.UserInfo.EmpId, $scope.Remark)
                .then(function (data) {
                    alert("success!");
                    location.href = "#/Approval";
                }, function (data) {
                    alert(data);
                })
        }
        $scope.approve = function () {
            console.log("enter approve");
            BaseService.approveRequisition($scope.reqid, $rootScope.UserInfo.EmpId, $scope.Remark)
                .then(function (data) {
                    alert("success!");
                    location.href = "#/Approval";
                }, function (data) {
                    alert(data);
                })
        }
    }
})