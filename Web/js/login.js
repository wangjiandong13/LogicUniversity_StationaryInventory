var loginApp = angular.module('loginAPP', ['angular-md5']);

loginApp.controller('logincontrollers', ['$scope','$http', 'md5', logincontroller]);
function logincontroller($scope, $http, md5) {
    $scope.empID = "";
    $scope.password = "";
    $scope.message = false;
    $scope.loginclick = function () {
        if ($scope.empID!=""&&$scope.password!=""){
        var msg = {
            EmpID: $scope.empID,
            Password:""
        }
        msg.password = md5.createHash($scope.password);
        
        jsonmsg = angular.toJson(msg);
        console.log(jsonmsg);
        $http.post("http://www.team5.com/API/employeeAPI.svc/login", jsonmsg)
            .success(function (data) {
                console.log(data);
            })
            .error(function () {
                console.log('There was an error');
            })
        }
        else {
            $scope.message = true;
        }
    }
}