var myapp = angular.module("_", []);

var baseurl = "http://www.team5.com/api";

myapp.service("service", ["$http", "$rootScope", service]);

function service($http, $rootScope) {

    ////// EMPLOYEE //////

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
    //Search Requisition by ReqID OR load requisitionDetail.html OR load requisitionApproval.html or load disbursementRequisition.html
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
    //Add to request cart //POST
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
        $http.get(baseurl + "departmentAPI.svc/getDeptByID/", $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("DepartmentLoaded", result);
        })
        .fail()
    }
    //Edit department //POST
    this.updateDepartment = function () {
        $http.post(baseurl + "departmentAPI.svc/updateDept/", $rootScope.data)
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



    ////// EMPLOYEE REPRESENTATIVE//////

    //disbursement.html
    //load disbursement by Dept for ER
    this.getDisbursementListByDept = function () {
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/" + $rootScope.DeptID + "/null/null/null/null")
        .success(function (result) {
            $rootScope.$broadcast("DisbursementListByDeptLoaded", result);
        })
        .fail()
    }
    //search disbursement by date range
    this.getDisbursementListByDate = function () {
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/null/null/null/" + $rootScope.startdate + "/" + $rootScope.enddate)
        .success(function (result) {
            $rootScope.$broadcast("DisbursementListByDateLoaded", result);
        })
        .fail()
    }
    //search disbursement by DisbID OR load disbursementDetail.html
    this.getDisbursementByDisID = function () {
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/null/null/" + $rootScope.DisID + "/null/null")
        .success(function (result) {
            $rootScope.$broadcast("DisbursementByDisIDLoaded", result);
        })
        .fail()
    }
    //create disbursement
    this.createDisbursement = function () {
        $http.get(baseurl + "disbursementAPI.svc/createDisbursement/" + $rootScope.EmpID)
        .success(function (result) {
            $rootScope.$broadcast("DisbursementCreated", result);
        })
        .fail()
    }


    //disbursementDetail.html
    this.getDisbursementDetail = function () {
        $http.get(baseurl + "disbursementAPI.svc/getDisbursementDetail/" + $rootScope.DisID)
        .success(function (result) {
            $rootScope.$broadcast("DisbursementDetailLoaded", result);
        })
        .fail()
    }


    //disbursementRequisition.html
    this.getDisbursementRequisition = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionList/" + $rootScope.DisID)
        .success(function (result) {
            $rootScope.$broadcast("DisbursementRequisitionLoaded", result);
        })
        .fail()
    }



    ////// EMPLOYEE DELEGATE//////

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


    
    ////// DEPARTMENT HEAD //////

    //delegate.html
    // load Dept delegate
    this.getDeptDelegate = function () {
        $http.get(baseurl + "delegateAPI.svc/getDelegate/" + $rootScope.DeptID)
        .success(function (result) {
            $rootScope.$broadcast("DeptDelegateLoaded", result);
        })
        .fail()
    }
    //remove delegate
    this.removeDelegate = function () {
        $http.get(baseurl + "delegateAPI.svc/deleteDelegate/" + $rootScope.DelegateSN)
        .success(function (result) {
            $rootScope.$broadcast("DelegateRemoved", result);
        })
        .fail()
    }


    //delegatenew.html
    //add new delegate //POST
    this.addDelegate = function () {
        $http.post(baseurl + "delegateAPI.svc/createDelegate", $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("DelegateAdded", result);
        })
        .fail()
    }


    
    ////// STORE CLERK //////

    //requisitionStoreClerk.html
    //load requisition list status 'Approved'
    this.getRequisitionApprovedList = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/2/null/null")
        .success(function (result) {
            $rootScope.$broadcast("RequisitionApprovedListLoaded", result);
        })
        .fail()
    }
    //process requisition //POST
    this.createRetrieval = function () {
        $http.post(baseurl + "retrievalAPI.svc/createRetrieval", $rootScope.data)
        .success(function (result) {
            $rootScope.$broadcast("RetrievalCreated", result);
        })
        .fail()
    }


    //requisitionProcessed.html
    //load requisition by RetID
    this.getRequisitionByRetID = function () {
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionById/" + $rootScope.RetID)
        .success(function (result) {
            $rootScope.$broadcast("RequisitionByRetIDLoaded", result);
        })
        .fail()
    }
    //load retrieval detail
    this.getRetrievalDetail = function () {
        $http.get(baseurl + "retrievalAPI.svc/getRetrievalDetail/" + $rootScope.RetID)
        .success(function (result) {
            $rootScope.$broadcast("RetrievalDetailLoaded", result);
        })
        .fail()
    }

    //retrieval.html
    //load store clerk bind to combo box
    this.getStoreClerk = function () {
        $http.get(baseurl + "retrievalAPI.svc/getStoreClerk")
        .success(function (result) {
            $rootScope.$broadcast("RetrievalDetailLoaded", result);
        })
        .fail()
    }
    //



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