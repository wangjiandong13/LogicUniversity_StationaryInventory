define(['app'], function (app) {
    app.controller('ReDetailController', ['$scope', '$rootScope', "$routeParams", 'BaseService', ReDetailController]);

    function ReDetailController($scope, $rootScope, $routeParams, BaseService) {
        var reqid = $routeParams.reqid;
        $scope.reqid = reqid;
        var myBaseService = BaseService;
        
        BaseService.getRequisitionList("null", reqid, "null")
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data[0];
                myBaseService.getEmployee(data[0].EmpID)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.EmpName = data.EmpName;
                       })
                if (data[0].HandledBy != null) {
                    myBaseService.getEmployee(data[0].HandledBy)
                           .then(function (data) {
                               //console.log("getEmployee");
                               $scope.RequisitionData.HandledByName = data.EmpName;
                           })
                } else {
                    $scope.RequisitionData.HandledByName = "";
                }
                if (data[0].RetID != null) {
                    myBaseService.getRetrievalListBySC("null","null",data[0].RetID)
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
        $scope.back = function () {
            location.href = "#/requisition";
        }

    }
})