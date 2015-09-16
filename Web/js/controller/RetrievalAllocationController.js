define(['app'], function (app) {
    app.controller('RetrievalAllocationControllers', ['$rootScope', '$scope', 'BaseService', RetrievalAllocationControllers]);

    function RetrievalAllocationControllers($rootScope, $scope, BaseService) {
        var RetID = 1017;
        $rootScope.changehighlight(1);
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