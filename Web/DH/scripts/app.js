var DelegateAPP = angular.module('DelegateAPP', [
'ngRoute'
]);

DelegateAPP.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/delegate', {
        templateUrl: 'delegate.html',
        controller: 'delegateCtrl'
      }).
        when('/delegatenew', {
            templateUrl: 'delegatenew.html',
            controller: 'delegatenewCtrl'
        }).
      otherwise({
        redirectTo: '/requisition'
      });
  }]);