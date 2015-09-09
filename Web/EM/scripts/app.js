var EmployeeAPP = angular.module('EmployeeAPP', [
'ngRoute','EmployeeControllers'
]);

EmployeeAPP.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/requisition', {
        templateUrl: 'requisition.html',
        controller: 'requisitionCtrl'
      }).
        when('/catalogList', {
            templateUrl: 'catalogList.html',
            controller: 'catalogListCtrl'
        }).
        when('/catalogTile', {
            templateUrl: 'catalogTile.html',
            controller: 'catalogTileCtrl'
        }).
        when('/department', {
            templateUrl: 'department.html',
            controller: 'departmentCtrl'
        }).
        when('/notification', {
            templateUrl: 'notification.html',
            controller: 'notificationCtrl'
        }).
        when('/requestCart', {
            templateUrl: 'requestCart.html',
            controller: 'requestCartCtrl'
        }).
        when('/requisitionDetail', {
            templateUrl: 'requisitionDetail.html',
            controller: 'requisitionDetailCtrl'
        }).
      otherwise({
        redirectTo: '/requisition'
      });
  }]);