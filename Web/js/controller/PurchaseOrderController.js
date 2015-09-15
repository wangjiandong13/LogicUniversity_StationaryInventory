define(['app'], function (app) {
    app.controller('PurchaseOrderControllers', ['$rootScope', '$scope', 'BaseService', PurchaseOrderControllers]);
    function PurchaseOrderControllers($rootScope, $scope, BaseService) {
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
    }
});