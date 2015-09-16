define(['app'], function (app) {
    app.controller('RetrievalController', ['$scope', '$rootScope', "$routeParams", 'BaseService', RetrievalController]);

    function RetrievalController($scope, $rootScope, $routeParams, BaseService) {
        //sidebar highlight
        $rootScope.changehighlight(14);

        //store clerk combobox
        $scope.optiondata = {
            availableOptions: [],
            selectedOption: { 'EmpID': '0', 'EmpName': 'ALL' }
        };
        BaseService.getStoreClerk()
            .then(function (data) {
                $scope.optiondata.availableOptions = data;
                console.log(data);
                $scope.optiondata.availableOptions.unshift({ EmpID: '0', EmpName: 'ALL' });
            }, function (data) {
                alert(data);
            })

        //status combobox
        $scope.statusSelect = {
            availableOptions: [{ id: '0', name: 'ALL' },
                                { id: '1', name: 'PENDING' },
                                { id: '2', name: 'RETRIEVED' }],
            selectedOption: { id: '0', name: 'All' }
        };

        //search btn
        var myBaseService = BaseService;
        $scope.search = function () {
            var empid = $scope.optiondata.selectedOption.EmpID;
            if (empid == 0) { status = "null"; }
            var status = $scope.statusSelect.selectedOption.name;
            if (status == "ALL") { status = "null"; }
            var RetID = $scope.RetrievalNo;
            if (RetID == null || RetID == "") { RetID = "null"; }
            console.log(RetID);
            BaseService.getRetrievalListBySC(empid, status, RetID)
            .then(function (data) {
                console.log(data);
                $scope.Retrievals = data;
                //get employee name
                $.each($scope.Retrievals, function (index, value) {
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
            })
        }

        //Default : load retrieval list by EmpID
        BaseService.getRetrievalListBySC($rootScope.UserInfo.EmpId, "null", "null")
            .then(function (data) {
                console.log(data);
                $scope.Retrievals = data;
                //get employee name
                $.each($scope.Retrievals, function (index, value) {
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
            })

        $scope.retrievaldetail = function (Retrieval) {
            console.log(Retrieval.RetID);
            location.href = "#/retrievalUpdateActual/" + Retrieval.RetID;
        };

    }
})