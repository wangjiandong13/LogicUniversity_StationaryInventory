define(['app'], function (app) {
    app.controller('ReDetailController', ['$scope', '$rootScope', "$routeParams", 'BaseService', ReDetailController]);

    function ReDetailController($scope, $rootScope, $routeParams, BaseService) {
        var reqid = $routeParams.reqid;
        $scope.reqid = reqid;
        var myBaseService = BaseService;
        BaseService.getRequisitionList("null", reqid, "null")
            .then(function (data) {
                console.log("getRequisitionList");
                console.log(data);
                $scope.RequisitionData = data;
                myBaseService.getEmployee(data.EmpID)
                       .then(function (data) {
                           console.log("getEmployee");
                           console.log(data);
                           $scope.RequisitionData.EmpName = data.EmpName;
                       })
                if (data.HandledBy != null) {
                    myBaseService.getEmployee(data.HandledBy)
                           .then(function (data) {
                               $scope.RequisitionData.HandledByName = data.EmpName;
                           })
                } else {
                    data.HandledByName = "";
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
        BaseService.getRequisitionDetailList(reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionDetailLists = data;
                $.each($scope.RequisitionDetailLists, function (index, value) {
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
    }
})