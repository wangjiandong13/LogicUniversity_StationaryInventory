﻿define(['app'], function (app) {
    app.controller('DisbSCControllers', ['$rootScope', '$scope', 'BaseService', DisbSCControllers]);
    function RequisitionApprovalListControllers($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(11);
        $scope.optiondataDept = {
            availableOptions: [],
            selectedOption: { 'DeptID': 1, 'DeptName': 'All' }
        };
        $scope.optiondataCPID = {
            availableOptions: [],
            selectedOption: { 'CPID': 0, 'CPName': 'ALL' }
        };

        var myBaseService = BaseService;
        $scope.search = function () {
            var dept = $scope.optiondataDept.selectedOption.DeptID;
            if (dept == 0) { status = "null"; }
            var cpid = $rootScope.optiondataCPID.selectedOption.CPID;
            if (cpid == 0) { cpid = "null" }
            var disid = $scope.DisID;
            if (disid == "") { disid = "null" }
            BaseService.getDisbursementList(dept, cpid, disid, "null", "null")
                .then(function (data) {
                    console.log(data);
                    $scope.Disbursements = data;
                    $.each(data, function (index, value) {
                        //console.log(">>>>" + value);
                        //console.log(">>>>"+value.EmpID);
                        myBaseService.getEmployee(value.EmpID)
                            .then(function (data) {
                                value.ClerkName = data.EmpName;
                            }, function (data) {
                                alert(data);
                            }
                            )
                        myBaseService.getAllCollectionPoint()
                            .then(function (data) {
                                if(data.CPID == value.CPID)
                                value.Collection = data.CPName;
                            }, function (data) {
                                alert(data);
                            }
                            )
                    });
                }, function (data) {
                    alert(data);
                }
                )
        }

        BaseService.getAllDisbursement()
            .then(function (data) {
                console.log(data);
                $rootScope.Disbursements = data;
                $.each(data, function (index, value) {
                    //console.log(">>>>" + value);
                    //console.log(">>>>"+value.EmpID);
                    myBaseService.getEmployee(value.EmpID)
                        .then(function (data) {
                            value.ClerkName = data.EmpName;
                        }, function (data) {
                            alert(data);
                        }
                        )
                    myBaseService.getAllCollectionPoint()
                        .then(function (data) {
                            if (data.CPID == value.CPID)
                                value.Collection = data.CPName;
                        }, function (data) {
                            alert(data);
                        }
                        )
                });
            }, function (data) {
                alert(data);
            }
        )

        $scope.disbursementdetail = function (Disbursement) {
            location.href = "#/disbursementDetail/" + Disbursement.DisID;
        };


        BaseService.getAllDept()
            .then(function (data) {
                $scope.optiondataDept.availableOptions = data;
                //console.log(data);
                $scope.optiondataDept.availableOptions.unshift({ DeptID: 0, DeptName: 'ALL' });
            }, function (data) {
                alert(data);
            })

        BaseService.getAllCollectionPoint()
           .then(function (data) {
               $scope.optiondataCPID.availableOptions = data;
               //console.log(data);
               $scope.optiondataCPID.availableOptions.unshift({ CPID: 0, CPName: 'ALL' });
           }, function (data) {
               alert(data);
           })

    }

});