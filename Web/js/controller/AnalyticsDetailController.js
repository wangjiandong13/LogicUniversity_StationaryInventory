define(['app'], function (app) {
    app.controller('AnalyticsDetailController', ['$scope', '$rootScope', '$routeParams', 'BaseService', AnalyticsDetailController]);
    function AnalyticsDetailController($scope, $rootScope,$routeParams, BaseService) {
        var rid = $routeParams.reportid;
        //var rid = 1;
        $scope.Qtyoptions = {
            chart: {
                type: 'multiBarChart',
                height: 550,
                margin: {
                    top: 30,
                    right: 20,
                    bottom: 100,
                    left: 45
                },
                clipEdge: true,
                staggerLabels: true,
                transitionDuration: 500,
                stacked: true,
                xAxis: {
                    axisLabel: 'Time (Month)',
                    showMaxMin: false,
                    tickFormat: function (d) {
                        return d;
                    }
                },
                yAxis: {
                    axisLabel: 'Y Axis',
                    axisLabelDistance: 40,
                    tickFormat: function (d) {
                        return d3.format(',.1f')(d);
                    }
                }
            }
        };
        BaseService.generateExistingReport(rid, "Qty")
            .then(function (data) {
                //console.log(data);
                //generateQtyData(data)
                $scope.Qtydata = data;
                //console.log($scope.data);
            })
        $scope.Priceoptions = {
            chart: {
                type: 'multiBarChart',
                height: 550,
                margin: {
                    top: 30,
                    right: 20,
                    bottom: 100,
                    left: 45
                },
                clipEdge: true,
                staggerLabels: true,
                transitionDuration: 500,
                stacked: true,
                xAxis: {
                    axisLabel: 'Time (Month)',
                    showMaxMin: false,
                    tickFormat: function (d) {
                        return d;
                    }
                },
                yAxis: {
                    axisLabel: 'Y Axis',
                    axisLabelDistance: 40,
                    tickFormat: function (d) {
                        return d3.format(',.1f')(d);
                    }
                }
            }
        };
        BaseService.generateExistingReport(rid, "Price")
            .then(function (data) {
                //console.log(data);
                //generateQtyData(data)
                $scope.Pricedata = data;
                //console.log($scope.data);
            })
        BaseService.getReportByID(rid)
            .then(function (data) {
                $scope.Report = data;
            })
    }
})
       
