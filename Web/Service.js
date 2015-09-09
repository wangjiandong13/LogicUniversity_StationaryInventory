var myapp = angular.module("_", []);

var baseurl = "http://www.team5.com/api";

myapp.service("service", ["$http", "$rootScope", service]);

function service($http, $rootScope) {
    //load requisition List 
    this.getRequisitionList = function () {
        $http.get(baseurl + "/requisitionAPI.svc/getRequisition/null/null/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionListLoaded", result);
        })
        .fail()
    }

    //load catalog list
    this.getCatalogList = function () {
        $http.get(baseurl + "inventoryAPI.svc/getItem")
        .success(function (result) {
            $rootScope.$broadcast("CatalogListLoaded", result);
        })
        .fail()
    }

    //load department (one) page
    this.getDepartment = function () {
        $http.get(baseurl + "departmentAPI.svc/getDeptByID/" + $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("DepartmentLoaded", result);
        })
        .fail()
    }

    //load department (list) page
    this.getDepartmentList = function () {
        $http.get(baseurl + "departmentAPI.svc/getAllDepartment")
        .success(function (result) {
            $rootScope.$broadcast("DepartmentListLoaded", result);
        })
        .fail()
    }

    //load notification list
    this.getNotificationList = function () {
        $http.get(baseurl + "notificationAPI.svc/getnotification/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("NotificationListLoaded", result);
        })
        .fail()
    }

    //load request cart item list
    this.getRequestCart = function () {
        $http.get(baseurl + "requestcartAPI.svc/getItems/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("RequestCartLoaded", result);
        })
        .fail()
    }

    //load requisition detail
    this.getRequisitionDetail = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionDetail/" + $rootScope.ReqID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionDetailLoaded", result);
        })
        .fail()
    }




}