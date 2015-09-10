var StoreClerkApp = angular.module('StoreClerkApp', [
                                                 'ngRoute', 'RequisitionControllers', 'appfilter'
]);

StoreClerkApp.config(['$routeProvider', routeset]);

function routeset($routeProvider) {
    $routeProvider.
        when('/requisitionStoreClerk', {
            templateUrl: 'requisitionStoreClerk.html',
              controller: 'BaseReControllers'
        }).
        
        when('/adjustment', {
            templateUrl: 'adjustment.html',
            controller: 'adjustmentCtrl'
        }).
        when('/adjustmentDetail', {
            templateUrl: 'adjustmentDetail.html',
            controller: 'adjustmentDetailCtrl'
        }).
        when('/adjustmentNew', {
            templateUrl: 'adjustmentNew.html',
            controller: 'adjustmentNewCtrl'
        }).
        when('/departmentStoreclerk', {
            templateUrl: 'departmentStoreclerk.html',
            controller: 'departmentStoreclerkCtrl'
        }).
        when('/disbursementDetailStoreClerk', {
            templateUrl: 'disbursementDetailStoreClerk.html',
            controller: 'disbursementDetailStoreClerkCtrl'
        }).
        when('/disbursementStoreClerk', {
            templateUrl: 'disbursementStoreClerk.html',
            controller: 'disbursementStoreClerkCtrl'
        }).
        when('/inventoryList', {
            templateUrl: 'inventoryList.html',
            controller: 'inventoryListCtrl'
        }).

        when('/inventoryNew', {
            templateUrl: 'inventoryNew.html',
            controller: 'inventoryNewCtrl'
        }).
        when('/inventoryTile', {
            templateUrl: 'inventoryTile.html',
            controller: 'inventoryTileCtrl'
        }).
        when('/notification', {
            templateUrl: '../EM/notification.html',
            controller: 'notificationCtrl'
        }).
        when('/purchaseOrder', {
            templateUrl: 'purchaseOrder.html',
            controller: 'purchaseOrderCtrl'
        }).
        when('/purchaseOrderDetail', {
            templateUrl: 'purchaseOrderDetail.html',
            controller: 'purchaseOrderDetailCtrl'
        }).
        when('/purchaseOrderPropose', {
            templateUrl: 'purchaseOrderPropose.html',
            controller: 'purchaseOrderProposeCtrl'
        }).
        when('/requisitionProcessed', {
            templateUrl: 'requisitionProcessed.html',
            controller: 'requisitionProcessedCtrl'
        }).
        when('/retrieval', {
            templateUrl: 'retrieval.html',
            controller: 'retrievalCtrl'
        }).
        when('/retrievalAllocation', {
            templateUrl: 'retrievalAllocation.html',
            controller: 'retrievalAllocationCtrl'
        }).
        when('/retrievalDetailDept', {
            templateUrl: 'retrievalDetailDept.html',
            controller: 'retrievalDetailDeptCtrl'
        }).
        when('/retrievalDetailReq', {
            templateUrl: 'retrievalDetailReq.html',
            controller: 'retrievalDetailReqCtrl'
        }).
        when('/retrievalUpdateActual', {
            templateUrl: 'retrievalUpdateActual.html',
            controller: 'retrievalUpdateActualCtrl'
        }).
        when('/stockcard', {
            templateUrl: 'stockcard.html',
            controller: 'stockcardCtrl'
        }).
        when('/supplierStoreClerk', {
            templateUrl: 'supplierStoreClerk.html',
            controller: 'supplierStoreClerkCtrl'
        }).
       
      otherwise({
          redirectTo: '/requisitionStoreClerk'
      });
}

