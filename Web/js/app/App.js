define(['routes', 'dependencyResoverFor'], function (config, dependencyResolverFor) {
    console.log("enter app");
    var app = angular.module('app', ['ngRoute', 'BaseServices']);
    app.controller('BodyCotroller', ['$rootScope', BodyCotroller]);
    function BodyCotroller($rootScope) {
        $rootScope.mean = {
            Requistion: "",
            Catalog: "",
            Department: "",
            RequestCart: "",
            Disbursement: "",
            Approval: "",
            RequistionSC: "",
            Adjustment: "",
            DepartmentSC: "",
            DisbursementSC: "",
            Inventory: "",
            PurchaseOrder: "",
            Retrieval: "",
            StockCard: "",
            SupplierSC: "",
            Suppler: ""
        };
        $rootScope.UserInfo = {
            EmpId: aaa,
            DeptId:aa,
            RoleId:aa,
        }
        $rootScope.side = {
            Requistion: false,
            Catalog: false,
            Department: false,
            RequestCart: false,
            Disbursement: false,
            Approval: false,
            Delegate: false,
            RequistionSC: false,
            Adjustment: false,
            DepartmentSC: false,
            DisbursementSC: false,
            Inventory: false,
            PurchaseOrder: false,
            Retrieval: false,
            StockCard: false,
            SupplierSC: false,
            Suppler: false,
            Analytics: false

        }
        if ($rootScope.UserInfo.RoleId == "EM") {
            $rootScope.side.Requistion = true;
            $rootScope.side.Catalog = true;
            $rootScope.side.Department = true;
            $rootScope.side.RequestCart = true;
        }
        if ($rootScope.UserInfo.RoleId == "ER") {
            $rootScope.side.Requistion = true;
            $rootScope.side.Catalog = true;
            $rootScope.side.Department = true;
            $rootScope.side.RequestCart = true;
            $rootScope.side.Disbursement = true;
        }
        if ($rootScope.UserInfo.RoleId == "ED") {
            $rootScope.side.Requistion = true;
            $rootScope.side.Catalog = true;
            $rootScope.side.Department = true;
            $rootScope.side.RequestCart = true;
            $rootScope.side.Disbursement = true;
            $rootScope.side.Approval = true;
        }
        if ($rootScope.UserInfo.RoleId == "DH") {
            $rootScope.side.Requistion = true;
            $rootScope.side.Catalog = true;
            $rootScope.side.Department = true;
            $rootScope.side.RequestCart = true;
            $rootScope.side.Disbursement = true;
            $rootScope.side.Delegate = true;
        }
        if ($rootScope.UserInfo.RoleId == "SC") {
            $rootScope.side.RequistionSC = true;
            $rootScope.side.Retrieval = true;
            $rootScope.side.DisbursementSC = true;
            $rootScope.side.Adjustment = true;
            $rootScope.side.DepartmentSC = true;
            $rootScope.side.SupplierSC = true;
            $rootScope.side.Inventory = true;
            $rootScope.side.PurchaseOrder = true;
        }
        if ($rootScope.UserInfo.RoleId == "SMS") {
            $rootScope.side.RequistionSC = true;
            $rootScope.side.Retrieval = true;
            $rootScope.side.DisbursementSC = true;
            $rootScope.side.Adjustment = true;
            $rootScope.side.DepartmentSC = true;
            $rootScope.side.Suppler = true;
            $rootScope.side.Inventory = true;
            $rootScope.side.PurchaseOrder = true;
            $rootScope.side.Analytics = true;
        }
        
    }
    app.config(
    [
        '$routeProvider',
        '$locationProvider',
        '$controllerProvider',
        '$compileProvider',
        '$filterProvider',
        '$provide',

        function ($routeProvider, $locationProvider, $controllerProvider, $compileProvider, $filterProvider, $provide) {
            app.controller = $controllerProvider.register;
            app.directive = $compileProvider.directive;
            app.filter = $filterProvider.register;
            app.factory = $provide.factory;
            app.service = $provide.service;

            //$locationProvider.html5Mode(true);

            if (config.routes !== undefined) {
                angular.forEach(config.routes, function (route, path) {
                    $routeProvider.when(path, { templateUrl: route.templateUrl, resolve: dependencyResolverFor(route.dependencies) });
                });
            }

            if (config.defaultRoutePaths !== undefined) {
                $routeProvider.otherwise({ redirectTo: config.defaultRoutePaths });
            }
        }
    ]);

    return app;
});