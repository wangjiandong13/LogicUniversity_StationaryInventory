define(['app'], function (app) {
    app.controller('Nofiticationcontroller', ['$rootScope', '$scope', 'BaseService', Nofiticationcontroller]);
    function Nofiticationcontroller($rootScope, $scope, BaseService) {
        BaseService.getNotificationList(11233)
            .then(function (data) {
                $scope.NotificationList = data;
                $.each($scope.NotificationList, function (index, value) {
                    if (value.Status == "READ") {
                        value.isRead = true;
                    }
                    else {
                        value.isRead = false;
                    }
                })
            }
})