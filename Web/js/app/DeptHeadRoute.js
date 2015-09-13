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
                    '../controller/CatalogTileController'
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
                    '../controller/RequestCartController'
                ]
            },
            '/requisitionDetail': {
                templateUrl: 'EM/requisitionDetail.html',
                dependencies: [
                    '../controller/ReDetailController'
                ]
            },
            '/disbursement': {
                templateUrl: 'ER/disbursement.html',
                dependencies: [
                    '../controller/DisbursementController'
                ]
            },
            '/disbursementDetail': {
                templateUrl: 'ER/disbursementDetail.html',
                dependencies: [
                    '../controller/DisbursementDetailController'
                ]
            },
            '/disbursementRequisition': {
                templateUrl: 'ER/disbursementRequisition.html',
                dependencies: [
                    '../controller/DisbursementRequisitionController'
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
                    '../controller/DelegatenewController'
                ]
            }
        }
    };
});