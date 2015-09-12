var EmployeeRepAPP = angular.module('EmployeeRepAPP', [
                                                 'ngRoute', 'RequisitionControllers', 'appfilter'
]);

EmployeeRepAPP.config(['$routeProvider', routeset]);

function routeset($routeProvider) {
    $routeProvider.
        when('/requisition', {
            templateUrl: '../EM/requisition.html',
            controller: 'BaseReControllers'
        }).

        when('/catalogList', {
            templateUrl: '../EM/catalogList.html',
            controller: 'catalogListCtrl'
        }).
        when('/catalogTile', {
            templateUrl: '../EM/catalogTile.html',
            controller: 'catalogTileCtrl'
        }).
        when('/department', {
            templateUrl: '../EM/department.html',
            controller: 'departmentCtrl'
        }).
        when('/notification', {
            templateUrl: '../EM/notification.html',
            controller: 'notificationCtrl'
        }).
        when('/requestCart', {
            templateUrl: '../EM/requestCart.html',
            controller: 'requestCartCtrl'
        }).
        when('/requisitionDetail', {
            templateUrl: '../EM/requisitionDetail.html',
            controller: 'requisitionDetailCtrl'
        }).
        when('/disbursement', {
            templateUrl: 'disbursement.html',
            controller: 'disbursementCtrl'
        }).
        when('/disbursementDetail', {
            templateUrl: 'disbursementDetail.html',
            controller: 'disbursementDetailCtrl'
        }).
        when('/disbursementRequisition', {
            templateUrl: 'disbursementRequisition.html',
            controller: 'disbursementRequisitionCtrl'
        }).

      otherwise({
          redirectTo: '../EM/requisition'
      });
}

