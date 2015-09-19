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
        BaseService.getReport(rid)
            .then(function (data) {
                $scope.Report = data;
            })
    }
    function Chatcontroller($scope, $rootScope,$routeParams, BaseService) {
        //var Pricedata = [];
        //var Qtydata = [];
        //var each = {
        //    key: "",
        //    values: []
        //};
        //var test = [];
        //var eachvalue = {
        //    x: "",
        //    y: 0
        //};
        
        //function generateQtyData(data) {
        //    $.each(data, function (index, value) {
        //        each.key = value.MonthYear;
        //        //console.log("value.ReportItems");
        //        //console.log(value.ReportItems);
        //        $.each(value.ReportItems, function (index, value) {
        //            //eachvalue.x = value.Subject;
        //            //eachvalue.y = value.Qty;
        //            var eachvalue1 = {
        //                x: value.Subject,
        //                y: value.Qty
        //            };
        //            //console.log(">>>> enter each");
        //            //console.log(eachvalue1);
        //            test.push(eachvalue1);
        //            //console.log(">>>> enter each.values");
        //            //console.log(test);
        //        });
        //        //Qtydata.push(each);
        //        ////console.log(each);
        //    })
        //    //console.log(Qtydata);
        //}
        //function generatePriceData(data) {
        //    //console.log(">>>>>>Pricedata");
        //    //console.log(Pricedata);
        //    $.each(data, function (index, value) {
        //        each.key = value.MonthYear;
        //        $.each(value.ReportItems, function (index, value) {
        //            eachvalue.x = value.Subject;
        //            eachvalue.y = value.Price;
        //            each.values.push(eachvalue);
        //        });
        //        Pricedata.push(each);
        //        //console.log(">>>>>>each");
        //        //console.log(each);
        //        //console.log(">>>>>>Pricedata");
        //        //console.log(Pricedata);
        //    })
        //    //console.log(Pricedata);
        //}
    }})
       
