define(['app'], function (app) {
    app.controller('AdjustmentNewController', ['$rootScope', '$scope', 'BaseService', AdjustmentNewController]);
    function AdjustmentNewController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);
    }
});