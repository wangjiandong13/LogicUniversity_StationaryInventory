define(['app'], function (app) {
    app.controller('AdjustmentController', ['$rootScope', '$scope', 'BaseService', AdjustmentController]);
    function AdjustmentController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);
    }
});