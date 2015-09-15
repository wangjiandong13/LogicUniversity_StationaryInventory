define(['app'], function (app) {
    app.controller('SupplierStoreClerkController', ['$rootScope', '$scope', 'BaseService', SupplierStoreClerkController]);
    function SupplierStoreClerkController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(15);
    }
});