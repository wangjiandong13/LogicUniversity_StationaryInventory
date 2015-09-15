define(['app'], function (app) {
    app.controller('AdjustmentApprovalController', ['$rootScope', '$scope', 'BaseService', AdjustmentApprovalController]);
    function AdjustmentApprovalController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);
    }
});