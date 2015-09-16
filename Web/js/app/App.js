define(['routes', 'dependencyResoverFor'], function (config, dependencyResolverFor) {
    //console.log("enter app");
    var app = angular.module('app', ['ngRoute', 'BaseServices']);
    app.controller('BodyCotroller', ['$rootScope','$scope', '$window', BaseService, BodyCotroller]);
    function BodyCotroller($rootScope,$scope, $window, BaseService) {
        $rootScope.mean = {
            Requistion: "",
            Catalog: "",
            Department: "",
            RequestCart: "",
            Disbursement: "",
            Approval: "",
            Delegate: "",
            RequisitionSC: "",
            Adjustment: "",
            DepartmentSC: "",
            DisbursementSC: "",
            Inventory: "",
            PurchaseOrder: "",
            Retrieval: "",
            SupplierSC: "",
            Supplier: "",
            Analytics: "",

            ifRequistion: false,
            ifCatalog: false,
            ifDepartment: false,
            ifRequestCart: false,
            ifDisbursement: false,
            ifApproval: false,
            ifDelegate: false,
            ifRequisitionSC:false,
            ifAdjustment: false,
            ifDepartmentSC: false,
            ifDisbursementSC: false,
            ifInventory: false,
            ifPurchaseOrder: false,
            ifRetrieval: false,
            ifSupplierSC: false,
            ifSupplier: false,
            ifAnalytics: false,
        };
        $rootScope.changehighlight=function(Nowpage){
            $rootScope.mean = {
                Requistion: "",
                Catalog: "",
                Department: "",
                RequestCart: "",
                Disbursement: "",
                Approval: "",
                Delegate: "",
                RequisitionSC: "",
                Adjustment: "",
                DepartmentSC: "",
                DisbursementSC: "",
                Inventory: "",
                PurchaseOrder: "",
                Retrieval: "",
                SupplierSC: "",
                Supplier: "",
                Analytics: "",

                ifRequistion: false,
                ifCatalog: false,
                ifDepartment: false,
                ifRequestCart: false,
                ifDisbursement: false,
                ifApproval: false,
                ifDelegate: false,
                ifRequisitionSC: false,
                ifAdjustment: false,
                ifDepartmentSC: false,
                ifDisbursementSC: false,
                ifInventory: false,
                ifPurchaseOrder: false,
                ifRetrieval: false,
                ifSupplierSC: false,
                ifSupplier: false,
                ifAnalytics: false
            };
            if (Nowpage == 1) {
                $rootScope.mean.Requistion = "active";
                $rootScope.mean.ifRequistion = true;
            }
            if (Nowpage == 2) {
                $rootScope.mean.Catalog = "active";
                $rootScope.mean.ifCatalog = true;
            }
            if (Nowpage == 3) {
                $rootScope.mean.Department = "active";
                $rootScope.mean.ifDepartment = true;
            }
            if (Nowpage == 4) {
                $rootScope.mean.RequestCart = "active";
                $rootScope.mean.ifRequestCart = true;
            }
            if (Nowpage == 5) {
                $rootScope.mean.Disbursement = "active";
                $rootScope.mean.ifDisbursement = true;
            }
            if (Nowpage == 6) {
                $rootScope.mean.Approval = "active";
                $rootScope.mean.ifApproval = true;
            }
            if (Nowpage == 7) {
                $rootScope.mean.Delegate = "active";
                $rootScope.mean.ifDelegate = true;
            }
            if (Nowpage == 8) {
                $rootScope.mean.RequisitionSC = "active";
                $rootScope.mean.ifRequisitionSC = true;
            }
            if (Nowpage == 9) {
                $rootScope.mean.Adjustment = "active";
                $rootScope.mean.ifAdjustment = true;
            }
            if (Nowpage == 10) {
                $rootScope.mean.DepartmentSC = "active";
                $rootScope.mean.ifDepartmentSC = true;
            }
            if (Nowpage == 11) {
                $rootScope.mean.DisbursementSC = "active";
                $rootScope.mean.ifDisbursementSC = true;
            }
            if (Nowpage == 12) {
                $rootScope.mean.Inventory = "active";
                $rootScope.mean.ifInventory = true;
            }
            if (Nowpage == 13) {
                $rootScope.mean.PurchaseOrder = "active";
                $rootScope.mean.ifPurchaseOrder = true;
            }
            if (Nowpage == 14) {
                $rootScope.mean.Retrieval = "active";
                $rootScope.mean.ifRetrieval = true;
            }
            if (Nowpage == 15) {
                $rootScope.mean.SupplierSC = "active";
                $rootScope.mean.ifSupplierSC = true;
            }
            if (Nowpage == 16) {
                $rootScope.mean.Supplier = "active";
                $rootScope.mean.ifSupplier = true;
            }
            if (Nowpage == 17) {
                $rootScope.mean.Analytics = "active";
                $rootScope.mean.ifAnalytics = true;
            }
        }
        $rootScope.UserInfo = {
            EmpId: $window.sessionStorage.EmpID,
            EmpName: $window.sessionStorage.EmpName,
            DeptId: $window.sessionStorage.DeptID,
            RoleId: $window.sessionStorage.RoleID
            //, 
            //EmpId: "11233",
            //EmpName: "Jenny Wong Mei Lin",
            //DeptId: "REGR",
            //RoleId: "EM"
        }
        //console.log($rootScope.UserInfo);
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
        if ($rootScope.UserInfo.RoleId == "DR") {
            $rootScope.side.Requistion = true;
            $rootScope.side.Catalog = true;
            $rootScope.side.Department = true;
            $rootScope.side.RequestCart = true;
            $rootScope.side.Disbursement = true;
        }
        if ($rootScope.UserInfo.RoleId == "DD") {
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
            $rootScope.side.Supplier = true;
            $rootScope.side.Inventory = true;
            $rootScope.side.PurchaseOrder = true;
        }
        if ($rootScope.UserInfo.RoleId == "SM" || $rootScope.UserInfo.RoleId == "SS") {
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
        $rootScope.logout = function () {
            $window.sessionStorage.removeItem("EmpID");
            $window.sessionStorage.removeItem("EmpName");
            $window.sessionStorage.removeItem("DeptID");
            $window.sessionStorage.removeItem("RoleID");
            location.href = "/";
        }
        BaseService.getNotificationList($rootScope.UserInfo.EmpId)
            .then(function (data) {
                $scope.NotificationList = data;
                $.each($scope.NotificationList, function (index, value) {
                    if (value.Status == "READ") {
                        value.isRead = true;
                    }
                    else {
                        value.isRead = false;
                    }
                })
            }
            )

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

            if (config.routes !== undefined) {
                angular.forEach(config.routes, function (route, path) {
                    $routeProvider.when(path, { templateUrl: route.templateUrl, resolve: dependencyResolverFor(route.dependencies) });
                });
            }

            if (config.defaultRoutePaths !== undefined) {
                $routeProvider.otherwise({ redirectTo: config.defaultRoutePaths });
            }
            //$locationProvider.html5Mode(true);
        }
    ]);

    return app;
});