var RequestControllers = angular.module('RequestControllers', ['BaseServices']);

RequestControllers.controller('departmentCtrl', ['$scope', '$rootScope', 'BaseService', departmentCtrl]);

function departmentCtrl($scope, BaseService) {
    var detId = "COMM";//get from session
    BaseService.getDepartment(detId)
           .then(function (data) {
               console.log(data);
               $scope.Requisitions = data;
           }, function (data) {
               alert(data);
           }
           )
}

