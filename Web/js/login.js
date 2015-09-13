var loginApp = angular.module('loginAPP', ['angular-md5']);

loginApp.controller('logincontrollers', ['$scope','$http', 'md5', logincontroller]);
function logincontroller($scope, $http, md5) {
    $scope.empID = "";
    $scope.password = "";
    $scope.message = false;
    $scope.loginclick = function () {
        $scope.message = false;
        if ($scope.empID!=""&&$scope.password!=""){
        var msg = {
            EmpID: $scope.empID,
            Password:""
        }
        msg.Password = md5.createHash($scope.password);
        
        jsonmsg = angular.toJson(msg);
        console.log(jsonmsg);
        $http.post("http://www.team5.com/API/employeeAPI.svc/login", jsonmsg)
            .success(function (data) {
                alert("sucess!");
                console.log(data);
                $.session.set('EmpID', data.EmpID);
                $.session.set('EmpName', data.EmpName);
                $.session.set('RoleID', data.RoleID);
                $.session.set('DeptID', data.DeptID);
            })
            .error(function () {
                $scope.loginerrormessage = true;
            })
        }
        else {
            $scope.message = true;
        }
    }
}