define(['app'], function (app) {
    app.controller('catalogListCtrl', ['$rootScope', '$scope', 'BaseService', catalogListCtrl]);
    app.controller('catalogListDataCtrl', ['$rootScope', 'BaseService', catalogListDataCtrl]);
    function catalogListCtrl($rootScope, $scope, BaseService) {
        //from session get empID
        var EmpID = 11233;

        //get categoryselectData
        console.log("enter catalogListCtrl");
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
        $scope.add = function (item) {
            var msg = '{"EmpID":' + EmpID + ',"ItemID":"' + item.ItemID + '","Qty":' + item.qty + '}';
            console.log(msg);
            BaseService.addItemToCart(msg)
                .then(function (data) {
                    alert("sucess!");
                })
        }
    }
    //load catalogList
    function catalogListDataCtrl($rootScope, BaseService) {
        console.log("enter");
        BaseService.getCatalogList()
            .then(function (data) {
                console.log(data);
                $rootScope.catalogListdata = data;
                $.each($rootScope.catalogListdata, function (index, value) {
                    value.qty = 1;
                });
            }, function (data) {
                alert(data);
            }
       )
    }
})