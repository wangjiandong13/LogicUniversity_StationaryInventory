var DelegateControllers = angular.module('DelegateControllers', []);

DelegateControllers.controller('delegateCtrl', ['$scope', '$http',
  function ($scope, $http) {
    $http.get('http://www.team5.com/api/requisitionAPI.svc/getRequisitionById/1')
      .success(function(data,header,config,status) {
        $scope.Requisitions = data;
      })
      .error(function(data,header,config,status){
        alert(status);
    });
  }]);

EmployeeControllers.controller('delegatenewCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('url')
        .success(function (data, header, config, status) {
            //$scope.Requisitions = data;
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);
