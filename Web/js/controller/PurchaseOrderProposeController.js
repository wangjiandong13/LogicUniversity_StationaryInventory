define(['app'], function (app) {
    app.controller('PurchaseOrderProposeControllers', ['$scope', '$rootScope',  'BaseService', PurchaseOrderProposeControllers]);
    function PurchaseOrderProposeControllers($scope, $rootScope,  BaseService) {
        $rootScope.changehighlight(13);
        console.log("PurchaseOrderProposeControllers");
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').focus()
        })
        $scope.suppli = function (item) {
            $('#ChooseSupplier').modal('show');

        }
        BaseService.getCatalogList()
            .then(function (data) {
                $scope.items = data;
            })
    }
})