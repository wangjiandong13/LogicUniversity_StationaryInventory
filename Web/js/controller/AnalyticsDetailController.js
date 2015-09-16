define(['app'], function (app) {
    app.controller('AnalyticsDetailController', ['$scope', '$rootScope', 'BaseService', AnalyticsDetailController]);
    app.controller('Chatcontroller', ['$scope', '$rootScope', 'BaseService', Chatcontroller]);
    function AnalyticsDetailController($scope, $rootScope, BaseService) {

    }
    function Chatcontroller($scope, $rootScope, BaseService) {
        var Pricedata = [];
        var Qtydata = [];
        $scope.options = {
            chart: {
                type: 'multiBarChart',
                height: 450,
                margin: {
                    top: 20,
                    right: 20,
                    bottom: 60,
                    left: 45
                },
                clipEdge: true,
                staggerLabels: true,
                transitionDuration: 500,
                stacked: true,
                xAxis: {
                    axisLabel: 'Time (ms)',
                    showMaxMin: false,
                    tickFormat: function (d) {
                        return d3.format(',f')(d);
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

        //$scope.data = 
        var each = {
            key: "",
            values: []
        };
        var eachvalue = {
            label: "",
            value: ""
        };

        function generateQtyData(data) {
            $.each(data, function (index,value) {
                each.key=value.MonthYear;
                $.each(value.ReportItems, function (index, value) {
                    eachvalue.label=value.Subject,
                    eachvalue.value = value.Qty
                    each.values.push(eachvalue);
                });
                Qtydata.push(each);
            })
        }
        function generatePriceData(data) {
            $.each(data, function (index, value) {
                each.key = value.MonthYear;
                $.each(value.ReportItems, function (index, value) {
                    eachvalue.label = value.Subject,
                    eachvalue.value = value.Price
                    each.values.push(eachvalue);
                });
                Pricedata.push(each);
            })
        }

        //$scope.data = [{
        //    key: "Cumulative Return",
        //    values: [
        //        { "label" : "A" , "value" : -29.765957771107 },
        //        { "label" : "B" , "value" : 0 },
        //        { "label" : "C" , "value" : 32.807804682612 },
        //        { "label" : "D" , "value" : 196.45946739256 },
        //        { "label" : "E" , "value" : 0.19434030906893 },
        //        { "label" : "F" , "value" : -98.079782601442 },
        //        { "label" : "G" , "value" : -13.925743130903 },
        //        { "label" : "H" , "value" : -5.1387322875705 }
        //    ]
        //}];

        /////* Random Data Generator (took from nvd3.org) */
        ////function generateData() {
        ////    return stream_layers(3, 50 + Math.random() * 50, .1).map(function (data, i) {
        ////        return {
        ////            key: 'Stream' + i,
        ////            values: data
        ////        };
        ////    });
        ////}

        /////* Inspired by Lee Byron's test data generator. */
        ////function stream_layers(n, m, o) {
        ////    if (arguments.length < 3) o = 0;
        ////    function bump(a) {
        ////        var x = 1 / (.1 + Math.random()),
        ////            y = 2 * Math.random() - .5,
        ////            z = 10 / (.1 + Math.random());
        ////        for (var i = 0; i < m; i++) {
        ////            var w = (i / m - y) * z;
        ////            a[i] += x * Math.exp(-w * w);
        ////        }
        ////    }
        ////    return d3.range(n).map(function () {
        ////        var a = [], i;
        ////        for (i = 0; i < m; i++) a[i] = o + o * Math.random();
        ////        for (i = 0; i < 5; i++) bump(a);
        ////        return a.map(stream_index);
        ////    });
        ////}

        /////* Another layer generator using gamma distributions. */
        ////function stream_waves(n, m) {
        ////    return d3.range(n).map(function (i) {
        ////        return d3.range(m).map(function (j) {
        ////            var x = 20 * j / m - i / 3;
        ////            return 2 * x * Math.exp(-.5 * x);
        ////        }).map(stream_index);
        ////    });
        ////}

        ////function stream_index(d, i) {
        ////    return { x: i, y: Math.max(0, d) };
        ////}
    }
})
