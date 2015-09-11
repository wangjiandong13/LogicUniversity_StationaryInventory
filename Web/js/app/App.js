define(['routes', 'dependencyResoverFor'], function (config, dependencyResolverFor) {
    console.log("enter app");
    var app = angular.module('app', ['ngRoute', 'BaseServices']);

    app.config(
    [
        '$routeProvider',
        '$locationProvider',
        '$controllerProvider',
        '$compileProvider',
        '$filterProvider',
        '$provide',

        function ($routeProvider, $locationProvider, $controllerProvider, $compileProvider, $filterProvider, $provide) {
            app.controller = $controllerProvider.register;
            app.directive = $compileProvider.directive;
            app.filter = $filterProvider.register;
            app.factory = $provide.factory;
            app.service = $provide.service;

            //$locationProvider.html5Mode(true);

            if (config.routes !== undefined) {
                angular.forEach(config.routes, function (route, path) {
                    $routeProvider.when(path, { templateUrl: route.templateUrl, resolve: dependencyResolverFor(route.dependencies) });
                });
            }

            if (config.defaultRoutePaths !== undefined) {
                $routeProvider.otherwise({ redirectTo: config.defaultRoutePaths });
            }
        }
    ]);

    return app;
});