define(['app'], function (app) {
    app.controller('DelegateControllers', ['$rootScope', '$scope', 'BaseService', DelegateControllers]);

    function DelegateControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(1);
    }

})