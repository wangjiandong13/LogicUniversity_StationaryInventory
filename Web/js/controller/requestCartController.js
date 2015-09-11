define(['app'], function (app) {
    app.controller('RequestCartControllers', ['$rootScope', '$scope', 'BaseService', RequestCartControllers]);
    app.controller('RequestCartListCtrl', ['$Scope', '$rootScope', 'BaseService', RequestCartList]);

    function RequestCartControllers(){
        console.log("enter  RequestCartControllers")
    }
    function RequestCartList($Scope, $rootScope, BaseService) {
        console.log("enter requestCartListCtrls");
        console.log(BaseService);
        BaseService.getRequestCart("11233")
            .then(function (data) {
                console.log(data);
                $rootScope.RequestCarts = data;
            }, function (data) {
                alert(data);
            })
        $Scope.delect = function (ItemID) {

        }
    }
})
