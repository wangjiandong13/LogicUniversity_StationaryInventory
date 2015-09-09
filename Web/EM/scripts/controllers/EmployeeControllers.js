var EmployeeControllers = angular.module('EmployeeControllers', []);

EmployeeControllers.controller('requisitionCtrl', ['$scope', '$http',
  function ($scope, $http) {
    $http.get('http://www.team5.com/api/requisitionAPI.svc/getRequisitionById/1')
      .success(function(data,header,config,status) {
        $scope.Requisitions = data;
      })
      .error(function(data,header,config,status){
        alert(status);
    });
  }]);

EmployeeControllers.controller('catalogListCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('http://www.team5.com/api/catalogAPI.svc/getItem')
        .success(function (data, header, config, status) {
            $scope.Items = data;
            $scope.qty = 1;
            $scope.test = function () {
                alert($scope.filterCategory);
            }
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);

EmployeeControllers.controller('catalogTileCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('http://www.team5.com/api/catalogAPI.svc/getItem')
        .success(function (data, header, config, status) {
            $scope.Items = data;
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);

EmployeeControllers.controller('departmentCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('url')
        .success(function (data, header, config, status) {
            //$scope.Requisitions = data;
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);

EmployeeControllers.controller('notificationCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('url')
        .success(function (data, header, config, status) {
            //$scope.Requisitions = data;
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);

EmployeeControllers.controller('requestCartCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('url')
        .success(function (data, header, config, status) {
            //$scope.Requisitions = data;
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);

EmployeeControllers.controller('requisitionDetailCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('url')
        .success(function (data, header, config, status) {
            //$scope.Requisitions = data;
        })
        .error(function (data, header, config, status) {
            alert(status);
        });
  }]);