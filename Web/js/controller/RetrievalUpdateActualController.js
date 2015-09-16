define(['app'], function (app) {
    app.controller('RetUpdateActController', ['$scope', '$rootScope', "$routeParams", 'BaseService', RetUpdateActController]);

    function RetUpdateActController($scope, $rootScope, $routeParams, BaseService) {
        $rootScope.changehighlight(14);

        var retid = $routeParams.retid;
        $scope.retid = retid;
        console.log($scope.retid);

        var myBaseService = BaseService;
        
        BaseService.getRetrievalListBySC("null", "null", $scope.retid)
            .then(function (data) {
                console.log(data);
                $scope.RetrievalData = data[0];

            }, function (data) {
                alert(data);
            })

        BaseService.getRequisitionListByRetID($scope.retid)
            .then(function (data) {
                console.log(data);
                $scope.RequisitionData = data;
            }, function (data) {
                alert(data);
            })

        BaseService.getRetrievalDetail(retid)
            .then(function (data) {
                console.log(data);
                $scope.RetrievalDetails = data;
            }, function (data) {
                alert(data);
            }
            )
        //cancel btn
        $scope.cancel = function () {
            alert('Are you sure you want to leave this page? New input will not be saved.');
            location.href = "#/retrieval";
        }

        //save btn
        $scope.save = function () {
            var msg = [];
            $.each($scope.RetrievalDetails, function (index, value) {
                if (value.ActualQty == "") {
                    value.ActualQty = 0;
                }
                var each = {
                    RetID: retid,
                    ItemID: value.ItemID,
                    ActualQty: value.ActualQty,
                };
                msg.push(each);
            });
            console.log(angular.toJson(msg));
            BaseService.saveRetrieval(angular.toJson(msg))
            .then(function (data) {
                alert('Saved Successfully!');
                location.href = "#/retrieval";
            }, function (data) {
                alert(data);
            })
            
        }

        //submit btn
        $scope.submit = function () {
            var msg = [];
            $.each($scope.RetrievalDetails, function (index, value) {
                if (value.ActualQty == "") {
                    value.ActualQty = 0;
                }
                var each = {
                    RetID: retid,
                    ItemID: value.ItemID,
                    ActualQty: value.ActualQty,
                };
                msg.push(each);
            });
            console.log(angular.toJson(msg));
            BaseService.submitRetrieval(angular.toJson(msg))
            .then(function (data) {
                alert('Saved Successfully!');
                location.href = "#/retrievalDetailReq/" + retid;
            }, function (data) {
                alert(data);
            })
        }
    }
})