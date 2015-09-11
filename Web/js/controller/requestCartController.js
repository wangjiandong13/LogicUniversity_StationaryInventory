define(['app'], function (app) {
    app.controller('RequestCartControllers', ['$rootScope', '$scope', 'BaseService', RequestCartControllers]);
    //app.controller('requestCartListCtrl', ['$scope', '$rootScope', 'BaseService', requestCartListCtrl]);

    function RequestCartControllers(){
        console.log("enter  RequestCartControllers")
    }
    function requestCartListCtrl($rootScope,BaseService) {
        BaseService.getRequestCart("11233")
            .then(function (data) {
                console.log(data);
                $rootScope.RequestCarts = data;
            }, function (data) {
                alert(data);
            })
    }
})
