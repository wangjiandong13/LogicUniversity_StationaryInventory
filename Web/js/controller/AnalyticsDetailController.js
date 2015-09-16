define(['app'], function (app) {
    app.controller('AnalyticsDetailController', ['$scope', '$rootScope', 'BaseService', AnalyticsDetailController]);
    app.controller('Chatcontroller', ['$scope', '$rootScope', 'BaseService', Chatcontroller]);
    function AnalyticsDetailController($scope, $rootScope, BaseService) {

    }
    function Chatcontroller($scope, $rootScope, BaseService) {
        var Pricedata = [];
        var Qtydata = [];
        var each = {
            key: "",
            values: []
        };
        var test = [];
        var eachvalue = {
            x: "",
            y: 0
        };
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
        //$scope.data = [{
        //    key: "红笔",
        //    values: [{ x: "Jan 2015", y: 10 }, { x: "Feb 2015", y: 25 }]
        //}, {
        //    key: "蓝笔",
        //    values: [{ x: "Jan 2015", y: 15 }, { x: "Feb 2015", y: 500 }]
        //}];
        BaseService.generateExistingReport(1,"Qty")
            .then(function (data) {
                console.log(data);
                //generateQtyData(data)
                $scope.data = data;
                console.log($scope.data);
            })
        //function generateQtyData(data) {
        //    $.each(data, function (index, value) {
        //        each.key = value.MonthYear;
        //        console.log("value.ReportItems");
        //        console.log(value.ReportItems);
        //        $.each(value.ReportItems, function (index, value) {
        //            //eachvalue.x = value.Subject;
        //            //eachvalue.y = value.Qty;
        //            var eachvalue1 = {
        //                x: value.Subject,
        //                y: value.Qty
        //            };
        //            console.log(">>>> enter each");
        //            console.log(eachvalue1);
        //            test.push(eachvalue1);
        //            console.log(">>>> enter each.values");
        //            console.log(test);
        //        });
        //        //Qtydata.push(each);
        //        //console.log(each);
        //    })
        //    console.log(Qtydata);
        //}
        //function generatePriceData(data) {
        //    console.log(">>>>>>Pricedata");
        //    console.log(Pricedata);
        //    $.each(data, function (index, value) {
        //        each.key = value.MonthYear;
        //        $.each(value.ReportItems, function (index, value) {
        //            eachvalue.x = value.Subject;
        //            eachvalue.y = value.Price;
        //            each.values.push(eachvalue);
        //        });
        //        Pricedata.push(each);
        //        console.log(">>>>>>each");
        //        console.log(each);
        //        console.log(">>>>>>Pricedata");
        //        console.log(Pricedata);
        //    })
        //    console.log(Pricedata);
        //}
    }})
       
