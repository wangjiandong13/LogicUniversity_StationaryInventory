define(['app'], function (app) {
    app.controller('ReDetailController', ['$scope', '$rootScope', "$routeParams", 'BaseService', ReDetailController]);

    function ReDetailController($scope, $rootScope, $routeParams, BaseService) {
        var reqid = $routeParams.reqid;
        BaseService.g
    }
})