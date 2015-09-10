var baseurl = "http://www.team5.com/api";

var BaseServices = angular.module("BaseServices", []);

BaseServices.service("BaseService", ["$http", "$q", service]);

function service($http, $q) {
    this.getRequisitionList = function (EmpID) {
        var deferred = $q.defer();
        $http.get(baseurl + "/requisitionAPI.svc/getRequisition/null/null/" + EmpID)
            .success(function (data) {
                deferred.resolve(data)
            })
            .error(function () {
                deferred.reject('There was an error')
            })
        return deferred.promise;
    }
}