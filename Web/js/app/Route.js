define([], function () {
    return {
        defaultRoutePath: '/',
        routes: {
            '/': {
                templateUrl: 'EM/requisition.html',
                dependencies: [
                    '../controller/RequisitionController'
                ]
            },
            '/requisition': {
                templateUrl: 'EM/requisition.html',
                dependencies: [
                    '../controller/RequisitionController'
                ]
            },
            '/catalogList': {
                templateUrl: 'EM/catalogList.html',
                dependencies: [
                    '../controller/CatalogListController'
                ]
            },
            '/catalogTile': {
                templateUrl: 'EM/catalogTile.html',
                dependencies: [
                   '../../assets/global/plugins/jquery-mixitup/jquery.mixitup.min', '../controller/CatalogTileController'
                ]
            },
            '/department': {
                templateUrl: 'EM/department.html',
                dependencies: [
                    '../controller/DepartmentController'
                ]
            },
            '/notification': {
                templateUrl: 'EM/notification.html',
                dependencies: [
                    '../controller/NotificationController'
                ]
            },
            '/requestCart': {
                templateUrl: 'EM/requestCart.html',
                dependencies: [
                    '../../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min',
                    '../controller/RequestCartController'
                ]
            },
            '/requisitionDetail/:reqid': {
                templateUrl: 'EM/requisitionDetail.html',
                dependencies: [
                    '../controller/ReDetailController'
                ]
            },
            '/disbursement': {
                templateUrl: 'ER/disbursement.html',
                dependencies: [
                    '../../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min', '../controller/DisbursementController'
                ]
            },
            '/disbursementDetail/:disid': {
                templateUrl: 'ER/disbursementDetail.html',
                dependencies: [
                     '../controller/DisbursementDetailController'
                ]
            },
            '/disbursementRequisition/:disid': {
                templateUrl: 'ER/disbursementRequisition.html',
                dependencies: [
                    '../controller/DisbursementRequisitionController'
                ]
            },
            '/Approval': {
                templateUrl: 'ED/requisitionApprovalList.html',
                dependencies: [
                    '../controller/RequisitionApprovalListController'
                ]
            },
            '/requisitionApproval/:reqid': {
                templateUrl: 'ED/requisitionApproval.html',
                dependencies: [
                    '../controller/RequisitionApprovalController'
                ]
            },
            '/delegate': {
                templateUrl: 'DH/delegate.html',
                dependencies: [
                    '../controller/DelegateController'
                ]
            },
            '/delegatenew': {
                templateUrl: 'DH/delegatenew.html',
                dependencies: [
                    '../../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min', '../controller/DelegatenewController'
                ]
            },
            '/requisitionStoreClerk': {
                templateUrl: 'SC/requisitionStoreClerk.html',
                dependencies: [
                    '../controller/RequisitionStoreClerkController'
                ]
            },
            '/adjustment': {
                templateUrl: 'SC/adjustment.html',
                dependencies: [
                    '../controller/AdjustmentController'
                ]
            },
            '/adjustmentDetail': {
                templateUrl: 'SC/adjustmentDetail.html',
                dependencies: [
                    '../controller/AdjustmentDetailController'
                ]
            },
            '/adjustmentNew': {
                templateUrl: 'SC/adjustmentNew.html',
                dependencies: [
                    '../controller/AdjustmentNewController'
                ]
            },
            '/departmentStoreclerk': {
                templateUrl: 'SC/departmentStoreclerk.html',
                dependencies: [
                    '../controller/DepartmentStoreclerkController'
                ]
            },
            '/disbursementDetailStoreClerk': {
                templateUrl: 'SC/disbursementDetailStoreClerk.html',
                dependencies: [
                    '../controller/DisbursementDetailStoreClerkController'
                ]
            },
            '/disbursementStoreClerk': {
                templateUrl: 'SC/disbursementStoreClerk.html',
                dependencies: [
                    '../controller/DisbursementStoreClerkController'
                ]
            },
            '/inventoryList': {
                templateUrl: 'SC/inventoryList.html',
                dependencies: [
                    '../controller/InventoryListController'
                ]
            },
            '/inventoryNew/:itemid': {
                templateUrl: 'SC/inventoryNew.html',
                dependencies: [
                    '../controller/InventoryNewController'
                ]
            },
            '/inventoryTile': {
                templateUrl: 'SC/inventoryTile.html',
                dependencies: [
                    '../controller/InventoryTileController'
                ]
            },
            '/notification': {
                templateUrl: 'EM/notification.html',
                dependencies: [
                    '../controller/NotificationController'
                ]
            },
            '/purchaseOrder': {
                templateUrl: 'SC/purchaseOrder.html',
                dependencies: [
                    '../../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min', '../controller/PurchaseOrderController'
                ]
            },
            '/purchaseOrderDetail': {
                templateUrl: 'SC/purchaseOrderDetail.html',
                dependencies: [
                    '../controller/PurchaseOrderDetailController'
                ]
            },
            '/purchaseOrderPropose': {
                templateUrl: 'SC/purchaseOrderPropose.html',
                dependencies: [
                    '../controller/PurchaseOrderProposeController'
                ]
            },
            '/requisitionProcessed': {
                templateUrl: 'SC/requisitionProcessed.html',
                dependencies: [
                    '../controller/RequisitionProcessedController'
                ]
            },
            '/retrieval': {
                templateUrl: 'SC/retrieval.html',
                dependencies: [
                    '../controller/RetrievalController'
                ]
            },
            '/retrievalAllocation': {
                templateUrl: 'SC/retrievalAllocation.html',
                dependencies: [
                    '../controller/RetrievalAllocationController'
                ]
            },
            '/retrievalDetailDept': {
                templateUrl: 'SC/retrievalDetailDept.html',
                dependencies: [
                    '../controller/RetrievalDetailDeptController'
                ]
            },
            '/retrievalDetailReq': {
                templateUrl: 'SC/retrievalDetailReq.html',
                dependencies: [
                    '../controller/RetrievalDetailReqController'
                ]
            },
            '/retrievalUpdateActual': {
                templateUrl: 'SC/retrievalUpdateActual.html',
                dependencies: [
                    '../controller/RetrievalUpdateActualController'
                ]
            },
            '/stockcard': {
                templateUrl: 'SC/stockcard.html',
                dependencies: [
                    '../controller/StockcardController'
                ]
            },
            '/supplierStoreClerk': {
                templateUrl: 'SC/supplierStoreClerk.html',
                dependencies: [
                    '../controller/SupplierStoreClerkController'
                ]
            },
            '/supplier': {
                templateUrl: 'SMS/supplier.html',
                dependencies: [
                    '../controller/SupplierController'
                ]
            },
            '/supplierdetail': {
                templateUrl: 'SMS/supplierdetail.html',
                dependencies: [
                    '../controller/SupplierdetailController'
                ]
            },
            '/suppliernew': {
                templateUrl: 'SMS/suppliernew.html',
                dependencies: [
                    '../controller/SuppliernewController'
                ]
            },
            '/adjustmentApproval': {
                templateUrl: 'SMS/adjustmentApproval.html',
                dependencies: [
                    '../controller/AdjustmentApprovalController'
                ]
            }
        }
    };
});