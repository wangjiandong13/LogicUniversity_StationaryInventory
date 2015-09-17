define(['app'], function (app) {
    app.controller('ReDetailController', ['$scope', '$rootScope', "$routeParams", 'BaseService', ReDetailController]);

    function ReDetailController($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(9);

        var reqid = $routeParams.reqid;
        $scope.reqid = reqid;
        var myBaseService = BaseService;
        console.log($scope.reqid);
        BaseService.getRequisitionByReqID($scope.reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data;
                if ($scope.RequisitionData.StatusID == 1) {
                    $scope.cancelbtn = true;
                } else {
                    $scope.cancelbtn = false;
                }
                myBaseService.getEmployee(data.EmpID)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.EmpName = data.EmpName;
                       })
                myBaseService.getPriorityName(data.PriorityID)
                        .then(function (data) {
                            //console.log("getPriorityName");
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
                    myBaseService.getRetrievalListBySC("null","null",data.RetID)
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
        $scope.reorderbtn = false;
        BaseService.getRequisitionDetailList(reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionDetailLists = data;
                $.each($scope.RequisitionDetailLists, function (index, value) {
                    console.log(value.ItemID);
                    if (value.RequestQty != value.IssueQty && $scope.RequisitionData.StatusID == 4) {
                        $scope.reorderbtn = true;
                    }
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
            if ($rootScope.backTo == 0) {
                location.href = "#/requisition";
            }
            else {
                location.href = "#/disbursementRequisition/" + $rootScope.disid;
            }
            
        }
        $scope.Cancel = function () {
            BaseService.getRequisitionCancel($scope.reqid)
                .then(function (data) {
                    alert("success!");
                    location.href = "#/requisition";
                }, function (data) {
                    alert(data);
                })
        }
        $scope.Reorder = function () {
            
        }
    }
})