define(['app'], function (app) {
    app.controller('AdjustmentNewController', ['$rootScope', '$scope', 'BaseService', AdjustmentNewController]);
    function AdjustmentNewController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);

        //status combobox
        $scope.reasonSelect = {
            availableOptions: [{ id: '0', name: '---Please select your reason---' },
                                { id: '1', name: 'Damaged' },
                                { id: '3', name: 'Oversight' },
                                { id: '4', name: 'Ad-hoc' }],
            selectedOption: { id: '0', name: '---Please select your reason---' }
        };

        $scope.search = function () {
            console.log(">>>>enter search button");
            //enter search codes here (JD)
        }
        
        $scope.add = function () {
            console.log(">>>>enter add button");
            //enter add codes here (JD)
        }

        $scope.cancel = function () {
            console.log(">>>>enter cancel button");
            location.href = "#/adjustment";
        }

        $scope.submit = function () {
            //enter submit codes here
        }
    }
});

        