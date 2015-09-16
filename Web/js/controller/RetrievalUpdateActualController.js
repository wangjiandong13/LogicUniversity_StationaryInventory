define(['app'], function (app) {
    app.controller('RetUpdateActController', ['$scope', '$rootScope', "$routeParams", 'BaseService', RetUpdateActController]);

    function RetUpdateActController($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(14);

        var retid = $routeParams.retid;
        $scope.retid = retid;
        console.log($scope.retid);

        var myBaseService = BaseService;
        
        BaseService.getRetrievalListBySC("null", "null", $scope.retid)
            .then(function (data) {
                console.log(data);
                $scope.RetrievalData = data[0];

            }, function (data) {
                alert(data);
            })

        BaseService.getRequisitionListByRetID($scope.retid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data;
                //var msg = "";
                //$.each($scope.RequisitionData, function (index, value) {
                //    msg.concat(value.ReqID);
                //    console.log(">>>>>" + msg);
                //})
                //$scope.reqForms = msg;
            }, function (data) {
                alert(data);
            })

        BaseService.getRetrievalDetail(retid)
            .then(function (data) {
                console.log(data);
                $scope.RetrievalDetails = data;
            }, function (data) {
                alert(data);
            }
            )
        //cancel btn
        $scope.cancel = function () {
            alert('Are you sure you want to leave this page? New input will not be saved.');
            location.href = "#/retrieval";
        }

        //save btn
        $scope.save = function (RetrievalDetail) {
            var msg = { RetID: RetrievalDetail.RetID, ItemID: RetrievalDetail.ItemID, ActualQty: RetrievalDetail.ActualQty };
            BaseService.saveRetrieval(angular.toJson(msg))
            .then(function (data) {
                alert('Saved Successfully!');
                location.href = "#/retrieval";
            }, function (data) {
                alert(data);
            })
            
        }

        //submit btn
        $scope.submit = function (RetrievalDetail) {
            var msg = { RetID: RetrievalDetail.RetID, ItemID: RetrievalDetail.ItemID, ActualQty: RetrievalDetail.ActualQty };
            BaseService.submitRetrieval(angular.toJson(msg))
            .then(function (data) {
                alert('Saved Successfully!');
                location.href = "#/retrievalDetailReq/" + retid;
            }, function (data) {
                alert(data);
            })
        }
    }
})