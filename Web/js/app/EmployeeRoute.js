define([], function () {
    return {
        defaultRoutePath: '/',
        routes: {
            '/': {
                templateUrl: 'requisition.html',
                dependencies: [
                    '../controller/RequisitionController'
                ]
            },
            '/requisition': {
                templateUrl: 'requisition.html',
                dependencies: [
                    '../controller/RequisitionController'
                ]
            },
            '/catalogList': {
                templateUrl: 'catalogList.html',
                dependencies: [
                    '../controller/CatalogListController'
                ]
            },
            '/catalogTile': {
                templateUrl: 'catalogTile.html',
                dependencies: [
                    '../controller/CatalogTileController'
                ]
            },
            '/department': {
                templateUrl: 'department.html',
                dependencies: [
                    '../controller/DepartmentController'
                ]
            },
            '/notification': {
                templateUrl: 'notification.html',
                dependencies: [
                    '../controller/NotificationController'
                ]
            },
            '/requestCart': {
                templateUrl: 'requestCart.html',
                dependencies: [
                    '../controller/RequestCartController'
                ]
            },
            '/requisitionDetail:reqId': {
                templateUrl: 'requisitionDetail.html',
                dependencies: [
                    '../controller/ReDetailController'
                ]
            }
        }
    };
});