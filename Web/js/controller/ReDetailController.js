define(['app'], function (app) {
    app.controller('ReDetailController', ['$scope', '$rootScope', "$routeParams", 'BaseService', ReDetailController]);

    function ReDetailController($scope, $rootScope, $routeParams, BaseService) {
        var reqid = $routeParams.reqid;
        $scope.reqid = reqid;
        var myBaseService = BaseService;
        
        BaseService.getRequisitionByReqID(reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data;
                myBaseService.getEmployee(data.EmpID)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.EmpName = data.EmpName;
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
                               myBaseService.getEmployee(data.EmpID)
                                   .then(function (data) {
                                       $scope.RequisitionData.ProcessedByName = data.EmpName;
                                   })
                           })
                } else {
                    data.ProcessedByName = "";
                }
            }, function (data) {
                alert(data);
            }
            )
        //if ($scope.RequisitionData.StatusID == 1) {
        //    $scope.cancelbtn = true;
        //} else {
        //    $scope.cancelbtn = false;
        //}
        BaseService.getRequisitionDetailList(reqid)
            .then(function (data) {
                //console.log(data);
                $scope.RequisitionDetailLists = data;
                $.each($scope.RequisitionDetailLists, function (index, value) {
                    //console.log(value.ItemID);
                    myBaseService.getItemDetail(value.ItemID)
                        .then(function (data) {
                            value.Description = data.ItemName;
                            value.Measurement = data.UOM;
                        }, function (data) {
                            alert(data);
                        }
                        )
                });
                myBaseService.getItemDetail()
            }, function (data) {
                alert(data);
            }
            )
        $scope.reorderbtn = false;
        $.each(function (index, value) {
            if (value.RequestQty != value.IssueQty && $scope.RequisitionData.StatusID==4) {
                $scope.reorderbtn = true;
            }
        })
        $scope.back = function () {
            location.href = "#/requisition";
        }
        $scope.Cancel = function () {
            BaseService.getRequisitionCancel($scope.reqid)
                .then(function (data) {
                    alert("success!");
                }, function (data) {
                    alert(data);
                })
        }
        $scope.Reorder = function () {
            
        }
    }
})