define(['app'], function (app) {
    app.controller('AdjustmentDetailController', ['$rootScope', '$scope', 'BaseService', AdjustmentDetailController]);
    function AdjustmentDetailController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);
    }
});