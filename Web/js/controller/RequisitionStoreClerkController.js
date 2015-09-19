define(['app'], function (app) {
    app.controller('RequisitionSCControllers', ['$rootScope', '$scope', 'BaseService', RequisitionSCControllers]);

    function RequisitionSCControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(8);

        var myBaseService = BaseService;
        $scope.search = function () {
            var status = $scope.statusSelect.selectedOption.id;
            var ReqID = $scope.RequisitionNo;
            if (ReqID == null || ReqID == "") { ReqID = "null"; }
            ////console.log(ReqID);
            BaseService.getRequisitionList(status, ReqID, "null", "null")
            .then(function (data) {
                //console.log(data);
                $scope.Requisitions = data;
                $.each($scope.Requisitions, function (index, value) {
                    //console.log(value.EmpID);
                    myBaseService.getEmployee(value.EmpID)
                        .then(function (empdata) {
                            value.EmpName = empdata.EmpName;
                        }, function (data) {
                            alert(data);
                        })
                })
                $scope.ifprocess = true;
                if (data[0].StatusID != 2)
                    $scope.ifprocess = false;
            }, function (data) {
                alert(data);
            })
        }

        //requisition list
        BaseService.getRequisitionApprovedList()
                .then(function (data) {
                    //console.log(data);
                    $scope.Requisitions = data;
                    $.each($scope.Requisitions, function (index, value) {
                        //console.log(value.EmpID);
                        myBaseService.getEmployee(value.EmpID)
                            .then(function (empdata) {
                                value.EmpName = empdata.EmpName;
                            }, function (data) {
                                alert(data);
                            })
                    })
                    $scope.ifprocess = true;

                    if (data.length>0) {
                        if (data[0].StatusID != 2)
                            $scope.ifprocess = false;
                    }

                }, function (data) {
                    alert(data);
                }
                )

        //status combobox
        $scope.statusSelect = {
            availableOptions: [{ id: '2', name: 'Approved' },
                                { id: '3', name: 'Processed' },
                                { id: '4', name: 'Collected' }],
            selectedOption: { id: '2', name: 'Approved' }
        };

        //process btn
        $scope.process = function () {
            var msg = [];
            $.each($scope.Requisitions, function (index, value) {
                if (value.checkbox == true) {
                    var each = {
                        EmpID: $rootScope.UserInfo.EmpId,
                        ReqID: value.ReqID,
                    };
                    msg.push(each);
                }
            })
            //console.log(msg);
            BaseService.createRetrieval(msg)
                .then(function (data) {
                    alert('Success!');
                    var retid = data;
                    location.href = "#/requisitionProcessed/" + retid;
                },function (data) {
                    alert(data);
                }
                )
            
        };
    }
});