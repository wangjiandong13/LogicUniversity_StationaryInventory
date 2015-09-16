define(['app'], function (app) {
    app.controller('SuppliernewController', ['$rootScope', '$scope', 'BaseService', SuppliernewController]);
    function SuppliernewController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(16);

        var supplierid = $routeParams.supplierid;
        $scope.supplierid = supplierid;

        //New Page
        if (supplierid == 0) {
            $scope.Title = "New";

            $scope.save = function () {
                msg = {SupplierID: $scope.Supplier.SupplierID, SupplierName: $scope.Supplier.SupplierName, Contact: $scope.Supplier.Contact, RegNo: $scope.Supplier.RegNo, Phone: $scope.Supplier.Phone, Address: $scope.Supplier.Address, Fax: $scope.Supplier.Fax}
                BaseService.createSupplier(angular.toJson(msg))
                .then(function (data) {
                    alert('Success!');
                }, function(data){
                    alert(data);
                })
            }
        }
        //Edit Page
        else {
            $scope.Title = "Edit";

            BaseService.getBySupplierID(supplierid)
            .then(function (data) {
                $scope.Supplier = data;
                console.log(data);
            }, function (data) {
                alert(data);
            })

            $scope.save = function () {
                msg = { SupplierID: $scope.Supplier.SupplierID, SupplierName: $scope.Supplier.SupplierName, Contact: $scope.Supplier.Contact, RegNo: $scope.Supplier.RegNo, Phone: $scope.Supplier.Phone, Address: $scope.Supplier.Address, Fax: $scope.Supplier.Fax }
                BaseService.updateSupplier(angular.toJson(msg))
                .then(function (data) {
                    alert('Success!');
                }, function (data) {
                    alert(data);
                })
            }
        }
        var myBaseService = BaseService;
        console.log($scope.reqid);
        BaseService.getRequisitionByReqID($scope.reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data;
                if ($scope.RequisitionData.StatusID == 1) {
                    $scope.cancelbtn = true;
                } else {
                    $scope.cancelbtn = false;
                }
                myBaseService.getEmployee(data.EmpID)
                       .then(function (data) {
                           //console.log("getEmployee");
                           $scope.RequisitionData.EmpName = data.EmpName;
                       })
                if (data.HandledBy != null) {
                    myBaseService.getEmployee(data.HandledBy)
                           .then(function (data) {
                               //console.log("getEmployee");
                               $scope.RequisitionData.HandledByName = data.EmpName;
                           })
                } else {
                    $scope.RequisitionData.HandledByName = "";
                }
                if (data.RetID != null) {
                    myBaseService.getRetrievalListBySC("null", "null", data.RetID)
                           .then(function (data) {
                               if (data.EmpID != null) {
                                   myBaseService.getEmployee(data.EmpID)
                                       .then(function (data) {
                                           $scope.RequisitionData.ProcessedByName = data.EmpName;
                                       })
                               }
                           })
                } else {
                    data.ProcessedByName = "";
                }
            }, function (data) {
                alert(data);
            }
            )
        $scope.reorderbtn = false;
        BaseService.getRequisitionDetailList(reqid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionDetailLists = data;
                $.each($scope.RequisitionDetailLists, function (index, value) {
                    console.log(value.ItemID);
                    if (value.RequestQty != value.IssueQty && $scope.RequisitionData.StatusID == 4) {
                        $scope.reorderbtn = true;
                    }
                    myBaseService.getItemDetail(value.ItemID)
                        .then(function (data) {
                            value.Description = data.ItemName;
                            value.Measurement = data.UOM;
                        }, function (data) {
                            alert(data);
                        }
                        )
                });
            }, function (data) {
                alert(data);
            }
            )
        $scope.back = function () {
            if ($rootScope.backTo == 0) {
                location.href = "#/requisition";
            }
            else {
                location.href = "#/disbursementRequisition/" + $rootScope.disid;
            }

        }
        $scope.Cancel = function () {
            BaseService.getRequisitionCancel($scope.reqid)
                .then(function (data) {
                    alert("success!");
                    location.href = "#/requisition";
                }, function (data) {
                    alert(data);
                })
        }
        $scope.Reorder = function () {

        }
    }
});