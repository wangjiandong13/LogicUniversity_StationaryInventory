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
                   '../../assets/global/plugins/jquery-mixitup/jquery.mixitup.min.js', '../controller/CatalogTileController'
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
            '/requisitionDetail/:reqid': {
                templateUrl: 'EM/requisitionDetail.html',
                dependencies: [
                    '../controller/ReDetailController'
                ]
            }
        }
    };
});