var myApp = angular.module('login', []);

myApp.controller('logincontroller', ['$scope',logincontroller]);
function logincontroller($scope) {
    $scope.spice = 'very';

    $scope.chiliSpicy = function () {
        $scope.spice = 'chili';
    };

    $scope.jalapenoSpicy = function () {
        $scope.spice = 'jalapeño';
    };
}