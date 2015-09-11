define([], function () {
    return {
        defaultRoutePath: '/',
        routes: {
            '/': {
                templateUrl: 'requisitionStoreClerk.html',
                dependencies: [
                    '../controller/RequisitionStoreClerkController'
                ]
            },
            '/requisitionStoreClerk': {
                templateUrl: 'requisitionStoreClerk.html',
                dependencies: [
                    '../controller/RequisitionStoreClerkController'
                ]
            },
            '/adjustment': {
                templateUrl: 'adjustment.html',
                dependencies: [
                    '../controller/AdjustmentController'
                ]
            },
            '/adjustmentDetail': {
                templateUrl: 'adjustmentDetail.html',
                dependencies: [
                    '../controller/AdjustmentDetailController'
                ]
            },
            '/adjustmentNew': {
                templateUrl: 'adjustmentNew.html',
                dependencies: [
                    '../controller/AdjustmentNewController'
                ]
            },
            '/departmentStoreclerk': {
                templateUrl: 'departmentStoreclerk.html',
                dependencies: [
                    '../controller/DepartmentStoreclerkController'
                ]
            },
            '/disbursementDetailStoreClerk': {
                templateUrl: 'disbursementDetailStoreClerk.html',
                dependencies: [
                    '../controller/DisbursementDetailStoreClerkController'
                ]
            },
            '/disbursementStoreClerk': {
                templateUrl: 'disbursementStoreClerk.html',
                dependencies: [
                    '../controller/DisbursementStoreClerkController'
                ]
            },
            '/inventoryList': {
                templateUrl: 'inventoryList.html',
                dependencies: [
                    '../controller/InventoryListController'
                ]
            },
            '/inventoryNew': {
                templateUrl: 'inventoryNew.html',
                dependencies: [
                    '../controller/InventoryNewController'
                ]
            },
            '/inventoryTile': {
                templateUrl: 'inventoryTile.html',
                dependencies: [
                    '../controller/InventoryTileController'
                ]
            },
            '/notification': {
                templateUrl: '../EM/notification.html',
                dependencies: [
                    '../controller/NotificationController'
                ]
            },
            '/purchaseOrder': {
                templateUrl: 'purchaseOrder.html',
                dependencies: [
                    '../controller/PurchaseOrderController'
                ]
            },
            '/purchaseOrderDetail': {
                templateUrl: 'purchaseOrderDetail.html',
                dependencies: [
                    '../controller/PurchaseOrderDetailController'
                ]
            },
            '/purchaseOrderPropose': {
                templateUrl: 'purchaseOrderPropose.html',
                dependencies: [
                    '../controller/PurchaseOrderProposeController'
                ]
            },
            '/requisitionProcessed': {
                templateUrl: 'requisitionProcessed.html',
                dependencies: [
                    '../controller/RequisitionProcessedController'
                ]
            },
            '/retrieval': {
                templateUrl: 'retrieval.html',
                dependencies: [
                    '../controller/RetrievalController'
                ]
            },
            '/retrievalAllocation': {
                templateUrl: 'retrievalAllocation.html',
                dependencies: [
                    '../controller/RetrievalAllocationController'
                ]
            },
            '/retrievalDetailDept': {
                templateUrl: 'retrievalDetailDept.html',
                dependencies: [
                    '../controller/RetrievalDetailDeptController'
                ]
            },
            '/retrievalDetailReq': {
                templateUrl: 'retrievalDetailReq.html',
                dependencies: [
                    '../controller/RetrievalDetailReqController'
                ]
            },
            '/retrievalUpdateActual': {
                templateUrl: 'retrievalUpdateActual.html',
                dependencies: [
                    '../controller/RetrievalUpdateActualController'
                ]
            },
            '/stockcard': {
                templateUrl: 'stockcard.html',
                dependencies: [
                    '../controller/StockcardController'
                ]
            },
            '/supplierStoreClerk': {
                templateUrl: 'supplierStoreClerk.html',
                dependencies: [
                    '../controller/SupplierStoreClerkController'
                ]
            }
        }
    };
});