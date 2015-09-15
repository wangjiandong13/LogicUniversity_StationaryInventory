define(['app'], function (app) {
    app.controller('DepartmentStoreclerkController', ['$rootScope', '$scope', 'BaseService', DepartmentStoreclerkController]);
    function DepartmentStoreclerkController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(10);
    }
});