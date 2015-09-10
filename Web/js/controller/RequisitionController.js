var RequisitionControllers = angular.module('RequisitionControllers', ['BaseServices']);

RequisitionControllers.controller('BaseReControllers', ['$scope', '$rootScope', 'BaseService', BaseReControllers]);
RequisitionControllers.controller('RequisitionList', ['$scope', 'BaseService', RequisitionList]);
RequisitionControllers.controller('SelectoptionControllers', ['$rootScope', 'BaseService', SelectoptionControllers]);

function BaseReControllers($scope, $rootScope, BaseService) {
    $scope.viewCart = function () {
        alert("viewCart");
    }
    $scope.search = function () {
        var status = $rootScope.optiondata.selectedOption.StatusID;
        if (status == 0) { status = "null"; }
        var ReqID = $scope.ReuisitionNo;
        if (ReqID == null) { ReqID ="null"}
        BaseService.getRequisitionList(status, ReqID, 11233)
            .then(function (data) {
                console.log(data);
                $scope.Requisitions = data;
                
            }, function (data) {
                alert(data);
            }
            )
    }
}

function RequisitionList($scope, BaseService) {
    BaseService.getRequisitionList("null", "null", 11233)
        .then(function (data) {
            $scope.Requisitions = data;
        }, function (data) {
            alert(data);
        }
    )
}
function SelectoptionControllers($rootScope, BaseService) {
    $rootScope.optiondata = {
        singleSelect: null, //This sets the default value of the select in the ui
        availableOptions: [],
        selectedOption: { 'StatusID': 0, 'StatusName': 'ALL' }
    };
    BaseService.getRequisitionStatus()
        .then(function (data) {
            $rootScope.optiondata.availableOptions = data;
            $rootScope.optiondata.availableOptions.unshift({ StatusID: 0, StatusName: 'ALL' });
        },function(data){
            alert(data);
        })
}

