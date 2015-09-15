define(['app'], function (app) {
    app.controller('PurchaseOrderDetailControllers', ['$rootScope', '$scope', ' $routeParams', 'BaseService', PurchaseOrderDetailControllers]);
    function PurchaseOrderDetailControllers($rootScope, $scope, $routeParams, BaseService) {
        $rootScope.changehighlight(13);
        console.log(">>>>enter PurchaseOrderDetailControllers")
        var PoID = $routeParams.PoID;
        console.log(PoID);
        alert(PoID);
    }
})