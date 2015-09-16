define(['app'], function (app) {
    app.controller('DepartmentStoreclerkController', ['$rootScope', '$scope', 'BaseService', DepartmentStoreclerkController]);
    function DepartmentStoreclerkController($rootScope, $scope, BaseService) {
        $rootScope.changehighlight(10);
        var MyBaseService = BaseService;
        BaseService.getDepartmentList()
            .then(function (data) {
                console.log(data);
                $scope.departmentlist = data;
                $.each($scope.departmentlist, function (index, value) {
                    //get contact name
                    if (value.Contact != "" || value.Contact != null) {
                        MyBaseService.getEmployee(value.Contact)
                            .then(function (data) {
                                value.ContactName = data.EmpName;
                            })
                    } else {
                        value.ContactName = "";
                    }
                    //get DeptHead name
                    if (value.DeptHead != "" || value.DeptHead != null) {
                        MyBaseService.getEmployee(value.DeptHead)
                            .then(function (data) {
                                value.DeptHeadName = data.EmpName;
                            })
                    } else {
                        value.DeptHeadName = "";
                    }
                    //get DeptRepName
                    if (value.DeptRep != "" || value.DeptRep != null) {
                        MyBaseService.getEmployee(value.Contact)
                            .then(function (data) {
                                value.DeptRepName = data.EmpName;
                            })
                    } else {
                        value.DeptRepName = "";
                    }
                    MyBaseService.getCollectionPointByID(value.CPID)
                        .then(function (data) {
                            value.CPName = data[0].CPName;
                        })

                })
            })
    }
});