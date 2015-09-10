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


    //catalogList.hmtl OR catalogTile.html
    //load catalog 
    this.getCatalogList = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "inventoryAPI.svc/getItem")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load category bind to combobox
    this.getCategory = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "catalogAPI.svc/getCategory")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //Search Item Name
    this.getItemByName = function (ItemName) {
        var deferred = $q.defer();
        $http.get(baseurl + "catalogAPI.svc/getItemByName/" + ItemName)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //Add to request cart //POST
    this.addItemToCart = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "requestcartAPI.svc/addItem", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //department.html
    //load department (one) page
    this.getDepartment = function (DeptID) {
        var deferred = $q.defer();
        $http.get(baseurl + "departmentAPI.svc/getDeptByID/" + DeptID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //Edit department //POST
    this.updateDepartment = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "departmentAPI.svc/updateDept/", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load department (list) page
    this.getDepartmentList = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "departmentAPI.svc/getAllDepartment")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }




    ////// EMPLOYEE REPRESENTATIVE//////

    //disbursement.html
    //load disbursement by Dept for ER
    this.getDisbursementListByDept = function (DeptID) {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/" + DeptID + "/null/null/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //search disbursement by date range
    this.getDisbursementListByDate = function (startdate, enddate) {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/null/null/null/" + startdate + "/" + enddate)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //search disbursement by DisbID OR load disbursementDetail.html 
    this.getDisbursementByDisID = function (DisID) {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/null/null/" + DisID + "/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //disbursementDetail.html
    //load disbursement detail
    this.getDisbursementDetail = function (DisID) {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/getDisbursementDetail/" + DisID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //disbursementRequisition.html
    //load disbursement requisition list
    this.getDisbursementRequisition = function (DisID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionList/" + DisID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }



    ////// EMPLOYEE DELEGATE//////

    //approval.html OR DH's requisition.html
    //load employee bind to combobox
    this.getDeptEmployee = function (DeptID) {
        var deferred = $q.defer();
        $http.get(baseurl + "employeeAPI.svc/getemployeebyDeptID/" + DeptID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load requisition list pending approval
    this.getRequisitionApprovalList = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/1/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load requisition list by employee name (EmpID)
    this.getRequisitionByEmpName = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/null/null/" + EmpID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //requisitionApproval.html
    //approve requisition
    this.approveRequisition = function (ReqId, HandledBy, Remark) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/approve/" + ReqId + "/" + HandledBy + "/" + Remark)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //reject requisition
    this.rejectRequisition = function (ReqId, HandledBy, Remark) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/reject/" + ReqId + "/" + HandledBy + "/" + Remark)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }



    ////// DEPARTMENT HEAD //////

    //delegate.html
    // load Dept delegate
    this.getDeptDelegate = function (DeptID) {
        var deferred = $q.defer();
        $http.get(baseurl + "delegateAPI.svc/getDelegate/" + DeptID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //remove delegate
    this.removeDelegate = function (DelegateSN) {
        var deferred = $q.defer();
        $http.get(baseurl + "delegateAPI.svc/deleteDelegate/" + DelegateSN)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //delegatenew.html
    //add new delegate //POST
    this.addDelegate = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "delegateAPI.svc/createDelegate", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }



    ////// STORE CLERK //////

    //requisitionStoreClerk.html
    //load requisition list status 'Approved'
    this.getRequisitionApprovedList = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisition/2/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //process requisition //POST
    this.createRetrieval = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "retrievalAPI.svc/createRetrieval", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //requisitionProcessed.html
    //load requisition by RetID
    this.getRequisitionByRetID = function (RetID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionById/" + RetID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load retrieval detail OR load retrievalUpdateActual.html OR retrievalAllocation.html OR retrievalDetailReq.html OR retrievalDetailDept.html
    this.getRetrievalDetail = function (RetID) {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getRetrievalDetail/" + RetID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //retrieval.html
    //load store clerk bind to combo box
    this.getStoreClerk = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getStoreClerk")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load retrieval list by store clerk
    this.getRetrievalListBySC = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getRetrieval/" + EmpID + "/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //search retrieval list by status
    this.getRetrievalListByStatus = function (status) {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getRetrieval/null/" + status + "/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //search retrieval list by RetID
    this.getRetrievalListByRetID = function (RetID) {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getRetrieval/null/null/" + RetID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //retrievalUpdateActual.html
    //load requisition list by RetID
    this.getRequisitionListByRetID = function (RetID) {
        var deferred = $q.defer();
        $http.get(baseurl + "requisitionAPI.svc/getRequisitionById/" + RetID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //save retrieval //POST
    this.saveRetrieval = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "retrievalAPI.svc/save", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //submit retrieval //POST
    this.submitRetrieval = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "retrievalAPI.svc/submit", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //retrievalAllocation.html
    //load requisition allocation by RetID or load RetrievalDetailReq.html
    this.getReqAllocation = function (RetID) {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getReqAllocation/" + RetID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //confirm requisition allocation //POST
    this.confirmReqAllocation = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "retrievalAPI.svc/confirmAllocation", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //retrievalDetailDept.html
    //get retrieval breakdown by department
    this.getRetByDept = function (RetID) {
        var deferred = $q.defer();
        $http.get(baseurl + "retrievalAPI.svc/getRetByDept/" + RetID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //disbursementStoreClerk.html
    //load department list bind to combobox
    this.getAllDept = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "departmentAPI.svc/getAllDepartment")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load collection point list to combobox
    this.getAllCollectionPoint = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "collectionAPI.svc/getCollectionPoint")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //search by CPID
    this.getDisbursementByCPID = function (CPID) {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/null/"+ CPID +"/null/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //load all disbursement
    this.getAllDisbursement = function () {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/getDisbursement/null/null/null/null/null")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //generate disbursement
    this.createDisbursement = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "disbursementAPI.svc/createDisbursement/" + EmpID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //adjustment.html
    //load adjustment voucher list (all null) or search by date (startdate, enddate) or search by AdjID (adjID) //POST
    this.getAdjList = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "adjustvoucherAPI.svc/getAdjVoucher", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //adjustmentNew.html
    //create new adjustment voucher //POST
    this.createAdj = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "adjustvoucherAPI.svc/createVoucherAdj", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
    //create new adjustment voucher detail //POST
    this.createAdjDetail = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "adjustvoucherAPI.svc/createVoucherAdjDetail", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //adjustmentDetail.html
    //load adjustment voucher detail //POST
    this.getAdjDetail = function (msg) {
        var deferred = $q.defer();
        $http.post(baseurl + "adjustvoucherAPI.svc/getAdjVoucherDetail", msg)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //departmentStoreclerk.html
    //load department list
    this.getDeptList = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "departmentAPI.svc/getAllDepartment")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }


    //supplier.html
    //load supplier list
    this.getSupplierList = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "supplierAPI.svc/getSupplierList")
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }



    ////// FOR ALL //////

    //notification.html
    //load notification list
    this.getNotificationList = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "notificationAPI.svc/getnotification/" + EmpID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }



}






