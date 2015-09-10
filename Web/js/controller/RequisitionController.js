var RequisitionControllers = angular.module('RequisitionControllers', ['BaseServices']);

RequisitionControllers.controller('requisitionCtrl', ['$scope', 'BaseService',
                                                       RequisitionList
]);

function RequisitionList($scope, BaseService) {
    BaseService.getRequisitionList(1)
        .then(function (data) {
            $scope.Requisitions = data;
        }, function (data) {
            alert(data);
        }
        )
}

