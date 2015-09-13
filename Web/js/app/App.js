define(['routes', 'dependencyResoverFor'], function (config, dependencyResolverFor) {
    console.log("enter app");
    var app = angular.module('app', ['ngRoute', 'BaseServices']);
    app.controller('BodyCotroller', ['$rootScope', '$window', BodyCotroller]);
    function BodyCotroller($rootScope, $window) {
        $rootScope.mean = {
            Requistion: "",
            Catalog: "",
            Department: "",
            RequestCart: "",
            Disbursement: "",
            Approval: "",
            RequisitionSC: "",
            Adjustment: "",
            DepartmentSC: "",
            DisbursementSC: "",
            Inventory: "",
            PurchaseOrder: "",
            Retrieval: "",
            SupplierSC: "",
            Supplier: "",

            ifRequistion: "",
            ifCatalog: "",
            ifDepartment: "",
            ifRequestCart: "",
            ifDisbursement: "",
            ifApproval: "",
            ifRequisitionSC: "",
            ifAdjustment: "",
            ifDepartmentSC: "",
            ifDisbursementSC: "",
            ifInventory: "",
            ifPurchaseOrder: "",
            ifRetrieval: "",
            ifSupplierSC: "",
            ifSupplier: ""
        };
        $rootScope.UserInfo = {
            EmpId: $window.sessionStorage.EmpID,
            EmpName: $window.sessionStorage.EmpName,
            DeptId: $window.sessionStorage.DeptID,
            RoleId: $window.sessionStorage.RoleID
        }
        console.log($rootScope.UserInfo);
        $rootScope.side = {
            Requistion: false,
            Catalog: false,
            Department: false,
            RequestCart: false,
            Disbursement: false,
            Approval: false,
            Delegate: false,
            RequisitionSC: false,
            Adjustment: false,
            DepartmentSC: false,
            DisbursementSC: false,
            Inventory: false,
            PurchaseOrder: false,
            Retrieval: false,
            SupplierSC: false,
            Supplier: false,
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
            $rootScope.side.RequisitionSC = true;
            $rootScope.side.Retrieval = true;
            $rootScope.side.DisbursementSC = true;
            $rootScope.side.Adjustment = true;
            $rootScope.side.DepartmentSC = true;
            $rootScope.side.SupplierSC = true;
            $rootScope.side.Inventory = true;
            $rootScope.side.PurchaseOrder = true;
        }
        if ($rootScope.UserInfo.RoleId == "SMS") {
            $rootScope.side.RequisitionSC = true;
            $rootScope.side.Retrieval = true;
            $rootScope.side.DisbursementSC = true;
            $rootScope.side.Adjustment = true;
            $rootScope.side.DepartmentSC = true;
            $rootScope.side.Supplier = true;
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

            $locationProvider.html5Mode(true);

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