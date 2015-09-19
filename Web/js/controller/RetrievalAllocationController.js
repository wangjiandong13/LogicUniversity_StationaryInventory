define(['app'], function (app) {
    app.controller('RetrievalAllocationControllers', ['$rootScope', '$scope', 'BaseService', '$routeParams', RetrievalAllocationControllers]);

    function RetrievalAllocationControllers($rootScope, $scope, BaseService, $routeParams) {
        $rootScope.changehighlight(14);

        var retid = $routeParams.retid;
        $scope.retid = retid;
        //console.log($scope.retid);

        var myBaseService = BaseService;

        BaseService.getRetrievalListBySC("null", "null", $scope.retid)
            .then(function (data) {
                //console.log(data);
                $scope.RetrievalData = data[0];

            }, function (data) {
                alert(data);
            })

        BaseService.getRequisitionListByRetID($scope.retid)
            .then(function (data) {
                //console.log(data);
                $scope.RequisitionData = data;
            }, function (data) {
                alert(data);
            })

        BaseService.getRetrievalDetail($scope.retid)
            .then(function (data) {
                //console.log(data);
                $scope.RetrievalDetail = data;
            }, function (data) {
                alert(data);
            })
        BaseService.getReqAllocation($scope.retid)
            .then(function (data) {
                //console.log(data);
                $scope.ReqAllocation = data;
            }, function (data) {
                alert(data);
            })

        $scope.confirm = function () {
            var msg = [];
            $.each($scope.ReqAllocation, function (index, value) {
                //if (value.ActualQty == "") {
                //    value.ActualQty = 0;
                //}
                var each = {
                    ReqID: value.ReqID,
                    ItemID: value.ItemID,
                    IssueQty: value.IssueQty,
                };
                msg.push(each);
            });
            //console.log(angular.toJson(msg));
            BaseService.confirmReqAllocation(angular.toJson(msg))
            .then(function (data) {
                alert('Saved Successfully!');
                location.href = "#/retrievalDetailReq/" + retid;
            }, function (data) {
                alert(data);
            })
        }
    }
})