var StoreSupManApp = angular.module('StoreSupManApp', [
                                                 'ngRoute', 'RequisitionControllers', 'appfilter'
]);

StoreSupManApp.config(['$routeProvider', routeset]);

function routeset($routeProvider) {
    $routeProvider.
        when('/requisitionStoreClerk', {
            templateUrl: '../SC/requisitionStoreClerk.html',
              controller: 'BaseReControllers'
        }).
        
        when('/adjustment', {
            templateUrl: '../SC/adjustment.html',
            controller: 'adjustmentCtrl'
        }).
        when('/adjustmentDetail', {
            templateUrl: '../SC/adjustmentDetail.html',
            controller: 'adjustmentDetailCtrl'
        }).
        when('/adjustmentNew', {
            templateUrl: '../SC/adjustmentNew.html',
            controller: 'adjustmentNewCtrl'
        }).
        when('/departmentStoreclerk', {
            templateUrl: '../SC/departmentStoreclerk.html',
            controller: 'departmentStoreclerkCtrl'
        }).
        when('/disbursementDetailStoreClerk', {
            templateUrl: '../SC/disbursementDetailStoreClerk.html',
            controller: 'disbursementDetailStoreClerkCtrl'
        }).
        when('/disbursementStoreClerk', {
            templateUrl: '../SC/disbursementStoreClerk.html',
            controller: 'disbursementStoreClerkCtrl'
        }).
        when('/inventoryList', {
            templateUrl: '../SC/inventoryList.html',
            controller: 'inventoryListCtrl'
        }).

        when('/inventoryNew', {
            templateUrl: '../SC/inventoryNew.html',
            controller: 'inventoryNewCtrl'
        }).
        when('/inventoryTile', {
            templateUrl: '../SC/inventoryTile.html',
            controller: 'inventoryTileCtrl'
        }).
        when('/notification', {
            templateUrl: '../EM/notification.html',
            controller: 'notificationCtrl'
        }).
        when('/purchaseOrder', {
            templateUrl: '../SC/purchaseOrder.html',
            controller: 'purchaseOrderCtrl'
        }).
        when('/purchaseOrderDetail', {
            templateUrl: '../SC/purchaseOrderDetail.html',
            controller: 'purchaseOrderDetailCtrl'
        }).
        when('/purchaseOrderPropose', {
            templateUrl: '../SC/purchaseOrderPropose.html',
            controller: 'purchaseOrderProposeCtrl'
        }).
        when('/requisitionProcessed', {
            templateUrl: '../SC/requisitionProcessed.html',
            controller: 'requisitionProcessedCtrl'
        }).
        when('/retrieval', {
            templateUrl: '../SC/retrieval.html',
            controller: 'retrievalCtrl'
        }).
        when('/retrievalAllocation', {
            templateUrl: '../SC/retrievalAllocation.html',
            controller: 'retrievalAllocationCtrl'
        }).
        when('/retrievalDetailDept', {
            templateUrl: '../SC/retrievalDetailDept.html',
            controller: 'retrievalDetailDeptCtrl'
        }).
        when('/retrievalDetailReq', {
            templateUrl: '../SC/retrievalDetailReq.html',
            controller: 'retrievalDetailReqCtrl'
        }).
        when('/retrievalUpdateActual', {
            templateUrl: '../SC/retrievalUpdateActual.html',
            controller: 'retrievalUpdateActualCtrl'
        }).
        when('/stockcard', {
            templateUrl: '../SC/stockcard.html',
            controller: 'stockcardCtrl'
        }).
         when('/supplier', {
             templateUrl: 'supplier.html',
             controller: 'supplierCtrl'
         }).
        when('/supplierdetail', {
            templateUrl: 'supplierdetail.html',
            controller: 'supplierdetailCtrl'
        }).
        when('/suppliernew', {
            templateUrl: 'suppliernew.html',
            controller: 'suppliernewCtrl'
        }).
        when('/adjustmentApproval', {
            templateUrl: 'adjustmentApproval.html',
            controller: 'adjustmentApprovalCtrl'
        }).

      otherwise({
          redirectTo: '../SC/requisitionStoreClerk'
      });
}

