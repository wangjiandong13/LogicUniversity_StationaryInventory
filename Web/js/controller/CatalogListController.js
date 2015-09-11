define(['app'], function (app) {
    app.controller('catalogListCtrl', ['$rootScope', '$scope', 'BaseService', catalogListCtrl]);
    app.controller('catalogListDataCtrl', ['$rootScope', 'BaseService', catalogListDataCtrl]);
    function catalogListCtrl($rootScope, $scope, BaseService) {
        //get categoryselectData
        $scope.CategorySelectData = {
            availableOptions: [],
            selectedOption: { ItemCatID: 0, ItemDescription: 'ALL' }
        };
        BaseService.getCategory()
            .then(function (data) {
                console.log(data);
                $scope.CategorySelectData.availableOptions = data;
                $scope.CategorySelectData.availableOptions.unshift({ ItemCatID: 0, ItemDescription: 'ALL' });
            }, function (data) {
                alert(data);
            })

        //search function
        $scope.search = function () {
            var S_category = $scope.CategorySelectData.selectedOption.ItemCatID;
            if (S_category == null) {
                S_category = "null";
            }
            //BaseService.
        }

    }
    //load catalogList
    function catalogListDataCtrl($rootScope, BaseService) {
        BaseService.getCatalogList()
            .then(function (data) {
                $rootScope.catalogListdata = data;
            }, function (data) {
                alert(data);
            }
       )
    }
})