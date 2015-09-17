
define(['app'], function (app) {
    app.controller('catalogtileCtrl', ['$rootScope', '$scope', 'BaseService', catalogtileCtrl]);
    app.controller('catalogListtileCtrl'
        , ['$rootScope', 'BaseService', catalogListtileCtrl]);
    function catalogtileCtrl($rootScope, $scope, BaseService) {
        //from session get empID
        var EmpID = $rootScope.UserInfo.EmpId;

        //set mean highlight
        $rootScope.mean = {
            Requistion: "",
            Catalog: "active",
            Department: "",
            RequestCart: "",
            ifRequistion: false,
            ifCatalog: true,
            ifDepartment: false,
            ifRequestCart: false
        };
        $scope.categoryname = "";
       
        //click the viewcart button
        $scope.viewCart = function () {
            location.href = '#/requestCart';
        };

        //get categoryselectData
        $scope.CategorySelectData = {
            availableOptions: [],
            selectedOption: { ItemCatID: 0, ItemDescription: 'ALL' }
        };
        BaseService.getCategory()
            .then(function (data) {
                ////console.log(data);
                $scope.CategorySelectData.availableOptions = data;
                $scope.CategorySelectData.availableOptions.unshift({ ItemCatID: 0, ItemDescription: 'ALL' });
            }, function (data) {
                alert(data);
            })

        //search function
        $scope.search = function () {
            var S_category = $scope.CategorySelectData.selectedOption.ItemCatID;
            if (S_category == 0) {
                S_category = "null";
            }
            var S_categoryname = $scope.categoryname;
            
            if (S_categoryname == "" || S_categoryname == null) {
                S_categoryname = "null";
            }
            //console.log(S_category);
            //console.log(S_categoryname);
            BaseService.searchItem(S_category, S_categoryname)
                .then(function (data) {
                    //console.log(data);
                    $rootScope.catalogtiledata = data;
                }, function (data) {
                    alert(data);
                }
            )
        }
        $scope.add = function (item) {
            var msg = '{"EmpID":' + EmpID + ',"ItemID":"' + item.ItemID + '","Qty":' + item.qty + '}';
            //console.log(msg);
            BaseService.addItemToCart(msg)
                .then(function (data) {
                    alert("sucess!");
                })
        }
    }
    //load catalogList
    function catalogListtileCtrl($rootScope,BaseService) {
        BaseService.getCatalogList()
            .then(function (data) {
                $rootScope.catalogtiledata = data;
                $('.mix-grid').mixitup();
            }, function (data) {
                alert(data);
            }
       )
        
    }
})