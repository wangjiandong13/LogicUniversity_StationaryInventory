define(['app'], function (app) {
    app.controller('SuppliernewController', ['$rootScope', '$scope', 'BaseService', SuppliernewController]);
    function SuppliernewController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(16);
    }
});