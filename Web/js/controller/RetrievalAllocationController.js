define(['app'], function (app) {
    app.controller('RetrievalAllocationControllers', ['$rootScope', '$scope', 'BaseService', RetrievalAllocationControllers]);

    function RetrievalAllocationControllers($rootScope, $scope, BaseService) {
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
            })
        BaseService.getReqAllocation(RetID)
            .then(function (data) {
                console.log(data);
                $scope.ReqAllocation = data;
            })
    }
})