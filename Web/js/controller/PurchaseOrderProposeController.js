define(['app'], function (app) {
    app.controller('PurchaseOrderProposeControllers', ['$scope', '$rootScope', "$routeParams", 'BaseService', PurchaseOrderProposeControllers]);
    function PurchaseOrderProposeControllers($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(13);
        console.log("PurchaseOrderProposeControllers");
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').focus()
        })
    }
})