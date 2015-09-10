var myapp = angular.module("_", []);

var baseurl = "http://www.team5.com/api";

myapp.service("service", ["$http", "$rootScope", service]);

function service($http, $rootScope) {

    //requisition.html
    //load requisition List 
    this.getRequisitionList = function () {
        $http.get(baseurl + "/requisitionAPI.svc/getRequisition/null/null/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionListLoaded", result);
        })
        .fail()
    }
    //load requisition status for combobox binding
    this.getRequisitionStatus = function () {
        $http.get(baseurl + "/requisitionAPI.svc/getStatus")
        .success(function (result) {
            $rootScope.$broadcast("RequisitionStatusLoaded", result);
        })
        .fail()
    }
    //load Requisition for Search Request by ReqID OR load requisitionDetail.html
    this.getRequisition = function () {
        $http.get(baseurl + "/requisitionAPI.svc/getRequisitionById/" + $rootScope.RetID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionLoaded", result);
        })
        .fail()
    }


    //requisitionDetail.html
    //load requisition detail list
    this.getRequisitionDetailList = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionDetail/" + $rootScope.ReqID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionDetailListLoaded", result);
        })
        .fail()
    }


    //requestCart.html
    //load request cart items
    this.getRequestCart = function () {
        $http.get(baseurl + "requestcartAPI.svc/getItems/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("RequestCartLoaded", result);
        })
        .fail()
    }
    //remove item from request cart //POST
    this.removeRequestCart = function () {
        $http.post(baseurl + "requestcartAPI.svc/deleteItem", $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("ItemRemoved", result);
        })
        .fail()
    }
    //update request cart item qty //POST
    this.updateItem = function () {
        $http.post(baseurl + "requestcartAPI.svc/updateItem", $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("ItemUpdated", result);
        })
        .fail()
    }
    //create requisition //POST
    this.createRequisition = function () {
        $http.post(baseurl + "requestcartAPI.svc/createRequisition", $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionCreated", result);
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

    




}