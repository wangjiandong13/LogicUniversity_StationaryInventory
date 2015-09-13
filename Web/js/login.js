var loginApp = angular.module('loginAPP', ['angular-md5']);

loginApp.controller('logincontrollers', ['$scope', '$http', '$window', 'md5', logincontroller]);
function logincontroller($scope, $http, $window, md5) {
    $scope.empID = "";
    $scope.password = "";
    $scope.message = false;
    $scope.loginclick = function () {
        $scope.message = false;
        if ($scope.empID != "" && $scope.password != "") {
            var msg = {
                EmpID: $scope.empID,
                Password: ""
            }
            msg.Password = md5.createHash($scope.password);

            jsonmsg = angular.toJson(msg);
            console.log(jsonmsg);
            $http.post("http://www.team5.com/API/employeeAPI.svc/login", jsonmsg)
                .success(function (data) {
                    alert("sucess!");
                    console.log(data);
                    $window.sessionStorage.setItem('EmpID', data.EmpID);
                    $window.sessionStorage.setItem('EmpName',data.EmpName);
                    $window.sessionStorage.setItem('RoleID', data.RoleID);
                    $window.sessionStorage.setItem('DeptID', data.DeptID);

                    if (data.RoleID == "EM" || data.RoleID == "DR" || data.RoleID == "DD" || data.RoleID == "DH")
                    {
                        location.href="#/templete/requisition"
                    }
                    else
                    {
                        location.href = "#/templete/requisitionStoreClerk"
                    }
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