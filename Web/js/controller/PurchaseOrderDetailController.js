define(['app'], function (app) {
    app.controller('PurchaseOrderDetailControllers', ['$rootScope', '$scope', 'BaseService', PurchaseOrderDetailControllers]);
    function PurchaseOrderDetailControllers($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(13);

        var PoID = $routeParams.PoID;
        alert(PoID);
    }
})