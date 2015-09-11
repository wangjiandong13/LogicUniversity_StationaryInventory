define(['app'], function (app) {
    app.controller('RequisitionControllers', ['$rootScope', '$scope', RequisitionControllers]);
    app.controller('RequisitionList', ['$rootScope', 'BaseService', RequisitionList]);
    app.controller('SelectoptionControllers', ['$rootScope', 'BaseService', SelectoptionControllers]);
    function RequisitionControllers($rootScope, $scope) {
        //$rootScope.pageTitle = $route.current.title;
        $scope.viewCart = function () {
            location.href = '#/requestCart';
        }
    }
    function RequisitionList($rootScope, BaseService) {
        BaseService.getRequisitionList("null", "null", 11233)
            .then(function (data) {
                $rootScope.Requisitions = data;
            }, function (data) {
                alert(data);
            }
        )
    }
    function SelectoptionControllers($rootScope, BaseService) {
        $rootScope.optiondata = {
            availableOptions: [],
            selectedOption: { 'StatusID': 0, 'StatusName': 'ALL' }
        };
        BaseService.getRequisitionStatus()
            .then(function (data) {
                $rootScope.optiondata.availableOptions = data;
                console.log(data);
                $rootScope.optiondata.availableOptions.unshift({ StatusID: 0, StatusName: 'ALL' });
            },function(data){
                alert(data);
            })
    }
});