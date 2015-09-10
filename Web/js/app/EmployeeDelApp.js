var EmployeeDelApp = angular.module('EmployeeDelApp', [
                                                 'ngRoute', 'RequisitionControllers', 'appfilter'
]);

EmployeeDelApp.config(['$routeProvider', routeset]);

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
            templateUrl: '../ER/disbursement.html',
            controller: 'disbursementCtrl'
        }).
        when('/disbursementDetail', {
            templateUrl: '../ER/disbursementDetail.html',
            controller: 'disbursementDetailCtrl'
        }).
        when('/disbursementRequisition', {
            templateUrl: '../ER/disbursementRequisition.html',
            controller: 'disbursementRequisitionCtrl'
        }).
        when('/requisitionApproval', {
            templateUrl: 'requisitionApproval.html',
            controller: 'requisitionApprovalCtrl'
        }).

      otherwise({
          redirectTo: '../EM/requisition'
      });
}

