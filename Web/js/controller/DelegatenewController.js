define(['app'], function (app) {
    app.controller('DelegateNewControllers', ['$rootScope', '$scope', 'BaseService', DelegateNewControllers]);
    function DelegateNewControllers($rootScope, $scope, BaseService) {
        //console.log(">>>enter DelegateNewControllers");
        $('.date-picker').datepicker({
            orientation: "left",
            autoclose: true
        });
        $scope.employeelist = {
            availableOptions: [],
            selectedOption: { 'EmpID': 0, 'EmpName': 'ALL' }
        };
        BaseService.getDeptEmployee($rootScope.UserInfo.DeptId)
            .then(function (data) {
                //console.log(data);
                $scope.employeelist.availableOptions = data;
                $scope.employeelist.selectedOption = { 'EmpID': data[0].EmpID, 'EmpName': data[0].EmpName }
                ////console.log($rootScope.employeelist.selectedOption);

            }, function (data) {
                alert(data);
                
            })
        $scope.cancel = function () {
            //console.log(">>>>enter cancel button");
            location.href = "#/delegate";
        }
        $scope.submit = function () {
            //console.log(">>>>enter submit button");
            if ($("#datestartdata").val() != "" && $("#datestartdata").val() != "" && $scope.Reason != "") {
                var msg = {
                    EmpID: $scope.employeelist.selectedOption.EmpID,
                    DeptID: $rootScope.UserInfo.DeptId,
                    StartDate: $("#datestartdata").val(),
                    EndDate: $("#datestartdata").val(),
                    Status: $scope.Reason
                };
                var msgjson = angular.toJson(msg);
                //console.log(">>>submit json:"+msgjson);
                BaseService.addDelegate(msgjson)
                    .then(function (data) {
                        alert("success");
                        location.href = "#/delegate"
                    }
                    )
            }
            else {
                alert("enter the right information");
            }
        }
    }
})