define(['app'], function (app) {
    app.controller('DisbReqControllers', ['$rootScope', '$scope', 'BaseService', '$routeParams', DisbReqControllers]);
    function DisbReqControllers($rootScope, $scope, BaseService, $routeParams) {
        $rootScope.changehighlight(5);

        var disid = $routeParams.disid;
        $scope.disid = disid;
        
        var myBaseService = BaseService;
        BaseService.getDisbursementRequisition(disid)
            .then(function (data) {
                console.log(data);
                $scope.DisbReq = data;
                $.each($scope.DisbReq, function (index, value) {
                    //console.log(">>>>" + value);
                    //console.log(">>>>"+value.EmpID);
                    myBaseService.getEmployee(value.EmpID)
                        .then(function (data) {
                            value.EmpName = data.EmpName;
                        }, function (data) {
                            alert(data);
                        }
                        )
                });
            }, function (data) {
                alert(data);
            }
        )
        $scope.back = function (Disbursement) {
            location.href = "#/disbursementDetail/" + Disbursement.DisID;
        };
   
    }
        
});