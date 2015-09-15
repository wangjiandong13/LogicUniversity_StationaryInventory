define(['app'], function (app) {
    app.controller('SupplierdetailController', ['$rootScope', '$scope', 'BaseService', SupplierdetailController]);
    function SupplierdetailController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(16);
    }
});