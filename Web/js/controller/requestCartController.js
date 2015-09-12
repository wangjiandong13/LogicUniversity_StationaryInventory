define(['app'], function (app) {
    app.controller('RequestCartControllers', ['$rootScope', '$scope', 'BaseService', RequestCartControllers]);
    app.controller('RequestCartListCtrl', ['$rootScope', '$scope', 'BaseService', RequestCartList]);

    function RequestCartControllers($rootScope, $scope,BaseService) {
        var selfBaseService = BaseService;
        //set mean highlight
        $rootScope.mean = {
            Requistion: " ",
            Catalog: " ",
            Department: " ",
            RequestCart: "active",
            ifRequistion: false,
            ifCatalog: false,
            ifDepartment: false,
            ifRequestCart:true
        };
        console.log("enter  RequestCartControllers")
        $scope.back = function () {
            location.href = '#/requisition';
        }
        $scope.submit = function () {
            console.log("enter");
            var msg = [];
            $.each($rootScope.RequestCarts, function (index, value) {
                var each = {
                    EmpId: 11233,
                    ItemID: value.ItemID,
                    Qty: value.Qty
                };
                msg.push(each);
            });
            console.log(angular.toJson(msg));
            selfBaseService.createRequisition(angular.toJson(msg))
                .then(function (data) {
                    location.href = '#/requisition';
                }, function (data) {
                    alert(data);
                })
        }
    }
    function RequestCartList($rootScope, $scope, BaseService) {
        //get EmpId from session
        var EmpId = "11233";
        var selfBaseService = BaseService;
        console.log("enter requestCartListCtrls");
        BaseService.getRequestCart(EmpId)
            .then(function (data) {
                console.log(data);
                $rootScope.RequestCarts = data;
            }, function (data) {
                alert(data);
            })
        $scope.delect = function (RequestCart) {
            var msg = '{"ItemID":"'+RequestCart.ItemID+'" ,"EmpID":'+EmpId+'}';
            console.log(msg);
            BaseService.removeRequestCart(msg)
                    .then(function (data) {
                        selfBaseService.getRequestCart(EmpId)
                        .then(function (data) {
                            console.log(data);
                            $rootScope.RequestCarts = data;
                            if (!$scope.$$phase) {
                                $rootScope.$apply();
                            }
                        }, function (data) {
                            alert(data);
                        })
                    }, function (data) {

                    })
        }
    }
})
