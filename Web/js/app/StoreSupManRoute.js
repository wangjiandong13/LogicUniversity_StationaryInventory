define([], function () {
    return {
        defaultRoutePath: '/',
        routes: {
            '/': {
                templateUrl: '../SC/requisitionStoreClerk.html',
                dependencies: [
                    '../controller/RequisitionStoreClerkController'
                ]
            },
            '/requisitionStoreClerk': {
                templateUrl: '../SC/requisitionStoreClerk.html',
                dependencies: [
                    '../controller/RequisitionStoreClerkController'
                ]
            },
            '/adjustment': {
                templateUrl: '../SC/adjustment.html',
                dependencies: [
                    '../controller/AdjustmentController'
                ]
            },
            '/adjustmentDetail': {
                templateUrl: '../SC/adjustmentDetail.html',
                dependencies: [
                    '../controller/AdjustmentDetailController'
                ]
            },
            '/adjustmentNew': {
                templateUrl: '../SC/adjustmentNew.html',
                dependencies: [
                    '../controller/AdjustmentNewController'
                ]
            },
            '/departmentStoreclerk': {
                templateUrl: '../SC/departmentStoreclerk.html',
                dependencies: [
                    '../controller/DepartmentStoreclerkController'
                ]
            },
            '/disbursementDetailStoreClerk': {
                templateUrl: '../SC/disbursementDetailStoreClerk.html',
                dependencies: [
                    '../controller/DisbursementDetailStoreClerkController'
                ]
            },
            '/disbursementStoreClerk': {
                templateUrl: '../SC/disbursementStoreClerk.html',
                dependencies: [
                    '../controller/DisbursementStoreClerkController'
                ]
            },
            '/inventoryList': {
                templateUrl: '../SC/inventoryList.html',
                dependencies: [
                    '../controller/InventoryListController'
                ]
            },
            '/inventoryNew': {
                templateUrl: '../SC/inventoryNew.html',
                dependencies: [
                    '../controller/InventoryNewController'
                ]
            },
            '/inventoryTile': {
                templateUrl: '../SC/inventoryTile.html',
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
                templateUrl: '../SC/purchaseOrder.html',
                dependencies: [
                    '../controller/PurchaseOrderController'
                ]
            },
            '/purchaseOrderDetail': {
                templateUrl: '../SC/purchaseOrderDetail.html',
                dependencies: [
                    '../controller/PurchaseOrderDetailController'
                ]
            },
            '/purchaseOrderPropose': {
                templateUrl: '../SC/purchaseOrderPropose.html',
                dependencies: [
                    '../controller/PurchaseOrderProposeController'
                ]
            },
            '/requisitionProcessed': {
                templateUrl: '../SC/requisitionProcessed.html',
                dependencies: [
                    '../controller/RequisitionProcessedController'
                ]
            },
            '/retrieval': {
                templateUrl: '../SC/retrieval.html',
                dependencies: [
                    '../controller/RetrievalController'
                ]
            },
            '/retrievalAllocation': {
                templateUrl: '../SC/retrievalAllocation.html',
                dependencies: [
                    '../controller/RetrievalAllocationController'
                ]
            },
            '/retrievalDetailDept': {
                templateUrl: '../SC/retrievalDetailDept.html',
                dependencies: [
                    '../controller/RetrievalDetailDeptController'
                ]
            },
            '/retrievalDetailReq': {
                templateUrl: '../SC/retrievalDetailReq.html',
                dependencies: [
                    '../controller/RetrievalDetailReqController'
                ]
            },
            '/retrievalUpdateActual': {
                templateUrl: '../SC/retrievalUpdateActual.html',
                dependencies: [
                    '../controller/RetrievalUpdateActualController'
                ]
            },
            '/stockcard': {
                templateUrl: '../SC/stockcard.html',
                dependencies: [
                    '../controller/StockcardController'
                ]
            },
            '/supplier': {
                templateUrl: 'supplier.html',
                dependencies: [
                    '../controller/SupplierController'
                ]
            },
            '/supplierdetail': {
                templateUrl: 'supplierdetail.html',
                dependencies: [
                    '../controller/SupplierdetailController'
                ]
            },
            '/suppliernew': {
                templateUrl: 'suppliernew.html',
                dependencies: [
                    '../controller/SuppliernewController'
                ]
            },
            '/adjustmentApproval': {
                templateUrl: 'adjustmentApproval.html',
                dependencies: [
                    '../controller/AdjustmentApprovalController'
                ]
            }
        }
    };
});