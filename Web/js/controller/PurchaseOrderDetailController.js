define(['app'], function (app) {
    app.controller('PurchaseOrderDetailControllers', ['$scope', '$rootScope', "$routeParams", 'BaseService', PurchaseOrderDetailControllers]);
    function PurchaseOrderDetailControllers($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(13);
        console.log(">>>>enter PurchaseOrderDetailControllers")
        var PoID = $routeParams.PoID;
        console.log(PoID);
        alert(PoID);
    }
})