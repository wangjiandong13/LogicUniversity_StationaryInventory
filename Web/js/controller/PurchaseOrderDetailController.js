define(['app'], function (app) {
    app.controller('PurchaseOrderDetailControllers', ['$rootScope', '$scope', 'BaseService', PurchaseOrderDetailControllers]);
    function PurchaseOrderDetailControllers($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(13);
        console.log(">>>>enter PurchaseOrderDetailControllers")
        var PoID = $routeParams.PoID;
        console.log(PoID);
        alert(PoID);
    }
})