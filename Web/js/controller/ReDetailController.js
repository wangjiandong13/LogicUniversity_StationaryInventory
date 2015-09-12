var ReDetailControllers = angular.module('ReDetailControllers', ['BaseServices']);

ReDetailControllers.controller('ReDetailCtrl', ['$scope', '$rootScope', "$routeParams", 'BaseService', ReDetailCtrl]);

function ReDetailCtrl($scope, $rootScope) {
    console.log($routeParams);
}