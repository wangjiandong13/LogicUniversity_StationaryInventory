define(['app'], function (app) {
    app.controller('AdjustmentNewController', ['$rootScope', '$scope', 'BaseService', AdjustmentNewController]);
    function AdjustmentNewController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(9);
        //status combobox
        $scope.reasonSelect = {
            availableOptions: [{ id: '0', name: '---Please select your reason---' },
                                { id: '1', name: 'Damaged' },
                                { id: '3', name: 'Oversight' },
                                { id: '4', name: 'Ad-hoc' }],
            selectedOption: { id: '0', name: '---Please select your reason---' }
        };
        $scope.readyforadd = {
            ItemID: "",
            Qty: 0,
            Reason: "",
            Remark:""
        }
        $scope.subimitlist = [];
        //get cataloglist
        BaseService.getCatalogList()
            .then(function (data) {
                $scope.items = data;
            })
        $scope.searchitem = function () {
            if ($scope.additem.ItemName == null || $scope.additem.ItemName == "") {
                BaseService.getCatalogList()
                    .then(function (data) {
                        $scope.items = data;
                    })
            }
            else {
                BaseService.getItemByName($scope.additem.ItemName)
                .then(function (data) {
                    $scope.items = data;
                })
            }
        }
        $scope.search = function () {
            //console.log(">>>>enter search button");
            //enter search codes here (JD)
            $('#SearchItem').modal('toggle');
        }
        $scope.addtoready = function (item) {
            //console.log(">>>>enter addtoready ");
            $scope.readyforadd.ItemID = item.ItemID;
            $('#SearchItem').modal('hide');
        }
        $scope.addtosumbitlist = function () {
            //console.log(">>>>enter addtosumbitlist");
            if ($scope.reasonSelect.selectedOption.id!="0") {
                if ($scope.readyforadd.Qty != 0) {
                    //validation: if reason is damaged, ensure qty is negative
                    if ($scope.reasonSelect.selectedOption.name == "Damaged") {
                        if ($scope.readyforadd.Qty > 0)
                            $scope.readyforadd.Qty = -$scope.readyforadd.Qty;
                    }
                    if ($scope.readyforadd.ItemID != "") {
                        $scope.readyforadd.Reason = $scope.reasonSelect.selectedOption.name;
                        $scope.subimitlist.push($scope.readyforadd);
                        $scope.readyforadd = {
                            ItemID: "",
                            Qty: 0,
                            Reason: "",
                            Remark: ""
                        };
                        $scope.reasonSelect.selectedOption = { id: '0', name: '---Please select your reason---' };
                    }
                    else {
                        alert("Please input your ItemID");
                    }
                }
                else {
                    alert("Qty cannot input 0");
                }
            }
            else {
                alert("Please select the reason");
            }
        }

        $scope.cancel = function () {
            //console.log(">>>>enter cancel button");
            location.href = "#/adjustment";
        }

        $scope.submit = function () {
            //console.log(">>>>enter submit button");
            if ($scope.subimitlist.length != 0) {
                var createAdj={
                    ReportedBy:$rootScope.UserInfo.EmpId,
                    Status:"PENDING"
                }
                BaseService.createAdj(angular.toJson(createAdj))
                    .then(
                        function (data) {
                            BaseService.createAdjDetail(angular.toJson($scope.subimitlist))
                                .then(
                                    function (data) {
                                        alert("success!");
                                        location.href = "#/adjustment";
                                    }, function (data) {
                                        alert("Failed!");
                                    }
                                 )
                        }, function (data) {
                        alert("Failed!");
                    })
            }
            else {
                alert("List is empty");
            }
        }
    }
});

        