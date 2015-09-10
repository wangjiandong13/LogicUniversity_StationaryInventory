var EmployeeAPP = angular.module('EmployeeAPP', [
                                                 'ngRoute', 'RequisitionControllers'
]);

EmployeeAPP.config(['$routeProvider', routeset]);

function routeset($routeProvider) {
    $routeProvider.
      when('/requisition', {
          templateUrl: 'requisition.html',
          controller: 'requisitionCtrl'
      }).
      otherwise({
          redirectTo: '/requisition'
      });
}

