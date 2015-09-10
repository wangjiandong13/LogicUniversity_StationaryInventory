var RequestCartControllers = angular.module('RequestCartControllers', ['BaseServices']);

RequestCartControllers.controller('requestCartCtrl', ['$scope', '$rootScope', 'BaseService', requestCartCtrl]);
RequestCartControllers.controller('requestCartListCtrl', ['$scope', '$rootScope', 'BaseService', requestCartListCtrl]);

function requestCartCtrl($scope, $rootScope) {

}
function requestCartListCtrl($rootScope) {
    BaseService.getRequestCart(11233)
        .then(function (data) {
            $rootScope.RequestCarts = data;
        }, function (data) {
            alert(data);
        }
}