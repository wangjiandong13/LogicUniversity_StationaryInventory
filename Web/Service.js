var myapp = angular.module("_", []);

var baseurl = "http://www.team5.com/api";

myapp.service("service", ["$http", "$rootScope", service]);

function service($http, $rootScope) {
    this.getRequisitionList = function () {
        $http.get(baseurl + "/requisitionAPI.svc/getRequisition/null/null/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionListLoaded", result);
        })
        .fail()
    }

    this.getCatalogList = function () {
        $http.get(baseurl + "inventoryAPI.svc/getItem")
        .success(function (result) {
            $rootScope.$broadcast("CatalogListLoaded", result);
        })
        .fail()
    }

    this.getDepartment = function () {
        $http.get(baseurl + "departmentAPI.svc/getDeptByID/" + $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("CatalogListLoaded", result);
        })
        .fail()
    }

    this.getNotificationList = function () {
        $http.get(baseurl + "departmentAPI.svc/getDeptByID/" + $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("CatalogListLoaded", result);
        })
        .fail()
    }



}