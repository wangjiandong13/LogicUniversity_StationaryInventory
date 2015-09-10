var RequisitionControllers = angular.module('RequisitionControllers', ['BaseServices']);

RequisitionControllers.controller('BaseReControllers', ['$scope', BaseReControllers]);
RequisitionControllers.controller('RequisitionList', ['$scope', 'BaseService', RequisitionList]);
RequisitionControllers.controller('SelectoptionControllers', ['$rootScope', SelectoptionControllers]);

function BaseReControllers($scope) {
    $scope.viewCart = function () {
        alert("click view cart");
    }
    $scope.search = function () {
        alert("search");
    }
}

function RequisitionList($scope, BaseService) {
    BaseService.getRequisitionList(1)
        .then(function (data) {
            $scope.Requisitions = data;
        }, function (data) {
            alert(data);
        }
        )
}
function SelectoptionControllers($rootScope) {
    $rootScope.optiondata = {
        singleSelect: null, //This sets the default value of the select in the ui
        availableOptions: [
          { id: '0', name: 'ALL' },
          { id: '1', name: 'Option B' },
          { id: '2', name: 'Option C' }
        ],
        selectedOption: { id: '0', name: 'ALL' }
    };
}

