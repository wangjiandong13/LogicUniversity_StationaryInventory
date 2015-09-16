define(['app'], function (app) {
    app.controller('RetrievalDetailDeptControllers', ['$rootScope', '$scope', 'BaseService', '$routeParams', RetrievalDetailDeptControllers]);

    function RetrievalDetailDeptControllers($rootScope, $scope, BaseService, $routeParams) {
        var RetID = 1017;
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
            }, function (data) {
                alert(data);
            })

        BaseService.getRetrievalDetail(RetID)
            .then(function (data) {
                console.log(data);
                $scope.RetrievalDetail = data;
            }, function (data) {
                alert(data);
            })
        BaseService.getReqAllocation(RetID)
            .then(function (data) {
                console.log(data);
                $scope.ReqAllocation = data;
            }, function (data) {
                alert(data);
            })

        $scope.viewByReq = function () {
            location.href = "#/retrievalDetailReq/" + retid;
        }
        $scope.backToList = function () {
            location.href = "#/retrieval";
        }
    }
})