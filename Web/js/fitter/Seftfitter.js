var appfilter = angular.module('appfilter', []);
appfilter.filter('datechange', datefilter);
appfilter.filter('statuschange', statuschange);
appfilter.filter('prioritychange', prioritychange);
appfilter.filter('CPIDchange', CPIDchange);
appfilter.filter('absolute', absolute);
appfilter.filter('Role', role);

function role() {
    return function (input) {
        if (input == "EM") {
            return "Employee"
        }
        if (input == "DR") {
            return "Department Representative"
        }
        if (input == "DD") {
            return "Department Delegate"
        }
        if (input == "DH") {
            return "Department Head"
        }
        if (input == "SC") {
            return "Store Clerk"
        }
        if (input == "SM") {
            return "Store Manager"
        }
        if (input == "SS") {
            return "Store Supervisor"
        }
    }
}

function datefilter() {
    return function (input) {
        //console.log(">>>filter"+input);
        if (input == ""||input==undefined) {
            return ""; 
        }
        return input.substr(6, 13);
    };
}
function statuschange() {
    return function (input) {
        if (input == 1) {
            return "Pending Approval";
        }
        if (input == 2) {
            return "Approved";
        }
        if (input == 3) {
            return "Processed";
        }
        if (input == 4) {
            return "Collected";
        }
        if (input == 5) {
            return "Rejected";
        }
        if (input == 6) {
            return "Cancelled";
        }
    };
}

function prioritychange() {
    return function (input) {
        if (input == 1) {
            return "High";
        }
        if (input == 2) {
            return "Low";
        }
    };
}

function CPIDchange() {
    return function (input) {
        if (input == 1) {
            return "LogicU Stationery Store - Administration Building (9:30am)";
        }
        if (input == 2) {
            return "LogicU Management School (11:00am)";
        }
        if (input == 3) {
            return "LogicU Medical School (9:30am)";
        }
        if (input == 4) {
            return "LogicU Engineering School (11:00am)";
        }
        if (input == 5) {
            return "LogicU Science School (9:30am)";
        }
        if (input == 6) {
            return "LogicU University Hospital (11:00am)";
        }
    };
}

function absolute() {
    return function (input) {
        if (input < 0) {
            return -input;
        }
        return input;
    };
}


//function datefilter22() {
//    return function (input, param1) {
//        var args = Array.prototype.slice.call(arguments);
//        //console.log("arguments=", args.length);
//        if (3 <= args.length) {
//            //console.log("param2(string)=", args[2]);
//        }
//        if (4 <= args.length) {
//            //console.log("param3(bool)=", args[3]);
//        }
//        //console.log("------------------------------------------------- end dump of custom parameters");
//        // filter  
//        if (5 <= args.length) {
//            return window[args[4]](input);
//        }
//        return input;
//    };
//}