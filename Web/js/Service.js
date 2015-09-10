var baseurl = "http://www.team5.com/api";

var BaseServices = angular.module("BaseServices", []);

BaseServices.service("BaseService", ["$http", "$q", service]);


function service($http, $q) {

    ////// EMPLOYEE //////

    //requisition.html
    //load requisition List 
    this.getRequisitionList = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "/requisitionAPI.svc/getRequisition/null/null/" + EmpID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load requisition status for combobox binding
    this.getRequisitionStatus = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "/requisitionAPI.svc/getStatus")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //Search Requisition by ReqID OR load requisitionDetail.html OR load requisitionApproval.html or load disbursementRequisition.html
    this.getRequisition = function (ReqID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/null/"+ ReqID +"/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //requisitionDetail.html
    //load requisition detail list OR load requisitionApproval.html
    this.getRequisitionDetailList = function (ReqID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionDetail/" + ReqID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //Cancel Request
    this.getRequisitionCancel = function (ReqID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/deleteRequisition/" + ReqID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //requestCart.html
    //load request cart items
    this.getRequestCart = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requestcartAPI.svc/getItems/" + EmpID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //remove item from request cart //POST
    this.removeRequestCart = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "requestcartAPI.svc/deleteItem", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //update request cart item qty //POST
    this.updateItem = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "requestcartAPI.svc/updateItem", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //create requisition //POST
    this.createRequisition = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "requestcartAPI.svc/createRequisition", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }



}




