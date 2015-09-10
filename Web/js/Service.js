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
    //load Requisition for Search Request by ReqID OR load requisitionDetail.html OR load requisitionApproval.html
    this.getRequisition = function () {
        $http.get(baseurl + "/requisitionAPI.svc/getRequisitionById/" + $rootScope.RetID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionLoaded", result);
        })
        .fail()
    }


    //requisitionDetail.html
    //load requisition detail list OR load requisitionApproval.html
    this.getRequisitionDetailList = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionDetail/" + $rootScope.ReqID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionDetailListLoaded", result);
        })
        .fail()
    }
    //Cancel Request
    this.getRequisitionCancel = function () {
        $http.get(baseurl + "requisitionAPI.svc/deleteRequisition/" + $rootScope.ReqID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionCancelled", result);
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

    
    //catalogList.hmtl OR catalogTile.html
    //load catalog 
    this.getCatalogList = function () {
        $http.get(baseurl + "inventoryAPI.svc/getItem")
        .success(function (result) {
            $rootScope.$broadcast("CatalogListLoaded", result);
        })
        .fail()
    }
    //load category bind to combobox
    this.getCategory = function () {
        $http.get(baseurl + "catalogAPI.svc/getCategory")
        .success(function (result) {
            $rootScope.$broadcast("CategoryLoaded", result);
        })
        .fail()
    }
    //Search Item Name
    this.getItemByName = function () {
        $http.get(baseurl + "catalogAPI.svc/getItemByName/" + $rootScope.ItemName)
        .success(function (result) {
            $rootScope.$broadcast("ItemByNameLoaded", result);
        })
        .fail()
    }
    //Add to request cart
    this.addItemToCart = function () {
        $http.post(baseurl + "requestcartAPI.svc/addItem", $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("ItemAddedToCart", result);
        })
        .fail()
    }


    //department.html
    //load department (one) page
    this.getDepartment = function () {
        $http.get(baseurl + "departmentAPI.svc/getDeptByID/" + $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("DepartmentLoaded", result);
        })
        .fail()
    }
    //Edit department //POST
    this.updateDepartment = function () {
        $http.post(baseurl + "departmentAPI.svc/updateDept/" + $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("DepartmentUpdated", result);
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

    //approval.html OR DH's requisition.html
    //load employee bind to combobox
    this.getDeptEmployee = function () {
        $http.get(baseurl + "employeeAPI.svc/getemployeebyDeptID/" + $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("DeptEmployeeLoaded", result);
        })
        .fail()
    }
    //load requisition list pending approval
    this.getRequisitionApprovalList = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/1/null/null")
        .success(function (result) {
            $rootScope.$broadcast("RequisitionApprovalListLoaded", result);
        })
        .fail()
    }
    //load requisition list by employee name (EmpID)
    this.getRequisitionByEmpName = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/null/null/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionByNameLoaded", result);
        })
        .fail()
    }


    //requisitionApproval.html
    //approve requisition
    this.approveRequisition = function () {
        $http.get(baseurl + "requisitionAPI.svc/approve/" + $rootScope.ReqId + "/" + $rootScope.HandledBy + "/"+ $rootScope.Remark)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionApproved", result);
        })
        .fail()
    }
    //reject requisition
    this.rejectRequisition = function () {
        $http.get(baseurl + "requisitionAPI.svc/reject/" + $rootScope.ReqId + "/" + $rootScope.HandledBy + "/" + $rootScope.Remark)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionRejected", result);
        })
        .fail()
    }


    //disbursement.html



    //notification.html
    //load notification list
    this.getNotificationList = function () {
        $http.get(baseurl + "notificationAPI.svc/getnotification/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("NotificationListLoaded", result);
        })
        .fail()
    }

    




}