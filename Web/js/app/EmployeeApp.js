var EmployeeAPP = angular.module('EmployeeAPP', [
                                                 'ngRoute', 'RequisitionControllers', 'appfilter'
]);

EmployeeAPP.config(['$routeProvider', routeset]);

function routeset($routeProvider) {
    $routeProvider.
        when('/requisition', {
              templateUrl: 'requisition.html',
              controller: 'BaseReControllers'
        }).
        /*
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
        */
      otherwise({
          redirectTo: '/requisition'
      });
}

