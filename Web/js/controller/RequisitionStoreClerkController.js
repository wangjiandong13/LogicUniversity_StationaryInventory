define(['app'], function (app) {
    app.controller('RequisitionSCControllers', ['$rootScope', '$scope', 'BaseService', RequisitionSCControllers]);

    function RequisitionSCControllers($rootScope, $scope, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(8);

        var myBaseService = BaseService;
        $scope.search = function () {
            var status = $scope.optiondata.selectedOption.StatusID;
            var ReqID = $scope.RequisitionNo;
            if (ReqID == null || ReqID == "") { ReqID = "null"; }
            //console.log(ReqID);
            BaseService.getRequisitionList(status, ReqID, "null", "null")
            .then(function (data) {
                console.log(data);
                $scope.Requisitions = data;
            }, function (data) {
                alert(data);
            })
        }

        //requisition list
        BaseService.getRequisitionApprovedList()
                .then(function (data) {
                    console.log(data);
                    $scope.Requisitions = data;
                    $.each($scope.Requisitions, function (index, value) {
                        console.log(value.EmpID);
                        myBaseService.getEmployee(value.EmpID)
                            .then(function (empdata) {
                                value.EmpName = empdata.EmpName;
                            }, function (data) {
                                alert(data);
                            })
                    })

                }, function (data) {
                    alert(data);
                }
                )

        //status combobox
        $scope.data = {
            availableOptions: [{ 'StatusID': 2, 'StatusName': 'Approved' },
                                { 'StatusID': 3, 'StatusName': 'Processed' },
                                { 'StatusID': 4, 'StatusName': 'Collected' }],
            selectedOption: { 'StatusID': 2, 'StatusName': 'Approved' }
        };

    }
});