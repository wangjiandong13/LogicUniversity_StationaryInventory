define(['app'], function (app) {
    app.controller('departmentCtrl', ['$rootScope', '$scope', 'BaseService', departmentCtrl]);
    app.controller('depSelectoptionControllers', ['$rootScope', 'BaseService', depSelectoptionControllers]);
    function departmentCtrl($rootScope, $scope, BaseService) {
        //get from session
        $rootScope.dptID = "REGR";
        $rootScope.roleid = "DD";
        $rootScope.positionx = 1.298160;
        $rootScope.positiony = 103.776284;
        //set mean highlight
        $rootScope.mean = {
            Requistion: "",
            Catalog: "",
            Department: "active",
            RequestCart: "",
            ifRequistion: false,
            ifCatalog: false,
            ifDepartment: true,
            ifRequestCart: false
        };
        var selfBaseService = BaseService;
        if ($rootScope.roleid == "EM") {
            //cannot edit hide button
            $scope.setting = {
                textbox: true,
                btnSave: false,
                btnEdit: false,
                btnMapEdit:false,
                map:true
            };
        }
        if ( $rootScope.roleid == "DR") {
            //cannot edit hide button
            $scope.setting = {
                textbox: true,
                btnSave: false,
                btnEdit: false,
                btnMapEdit: true,
                map:true
            };
        }
        if ($rootScope.roleid == "DH" || $rootScope.roleid == "DD") {
            $scope.setting = {
                textbox: true,
                btnSave: false,
                btnEdit: true,
                btnMapEdit: false,
                map:false
            };
        }
        $scope.edit = function () {
            $scope.setting = {
                textbox: false,
                btnSave: true,
                btnEdit: false,
                btnMapEdit: false,
                map:false
            };
        }
        $scope.editmap = function () {
            $scope.setting = {
                textbox: true,
                btnSave: true,
                btnEdit: false,
                btnMapEdit: false,
                map: false
            };
        }
        $scope.save = function () {
            $scope.updatemodel = {
                DeptID: $scope.Department.DeptID,
                DeptName: $scope.Department.DeptName,
                CPID: $scope.collectiondata.selectedOption.CPID,
                Contact: $scope.Department.Contact,
                DeptHead: $scope.Department.DeptHead,
                DeptRep: $scope.optiondata.selectedOption.EmpID,
                Phone: $scope.Department.Phone,
                Fax: $scope.Department.Fax
            }
            console.log(angular.toJson($scope.updatemodel));
            selfBaseService.updateDepartment(angular.toJson($scope.updatemodel))
                .then(function (data) {
                    alert("success");
                }, function (data) { alert("fail");})

            if ($rootScope.roleid == "DR") {
                $scope.setting = {
                    textbox: true,
                    btnSave: false,
                    btnEdit: false,
                    btnMapEdit: true,
                    map: true
                };
            } else {
                $scope.setting = {
                    textbox: true,
                    btnSave: false,
                    btnEdit: true,
                    btnMapEdit: false,
                    map: true
                };
            }
        }
        $rootScope.collectiondata = {
            availableOptions: [],
            selectedOption: { 'CPID': 0, 'CPName': 'ALL' }
        };
        BaseService.getAllCollectionPoint()
            .then(function (data) {
                console.log(data);
                $rootScope.collectiondata.availableOptions = data;
                $rootScope.collectiondata.selectedOption = { 'CPID': data[0].CPID, 'CPName': data[0].CPName };
            })
        $scope.change = function () {
            var cpid = $rootScope.collectiondata.selectedOption.CPID;
            $.each($rootScope.collectiondata.availableOptions, function (index, value) {
                if (value.CPID == cpid) {
                    $rootScope.positionx = value.CPLat;
                    $rootScope.positiony = value.CPLgt;
                }
            })
        }

        
        console.log("enter  departmentCtrl");
        BaseService.getDepartment($rootScope.dptID)
                   .then(function (data) {
                       $scope.Department = data;
                       depth = data.DeptHead;
                       selfBaseService.getEmployee(depth)
                           .then(function (data) {
                               console.log(data.EmpName);
                               $scope.DeptHeadName = data.EmpName;
                           }, function (data) {
                               alert(data);
                           }
                           );
                   }, function (data) {
                       alert(data);
                   }
                   );
            }

    function depSelectoptionControllers($rootScope, BaseService) {
        $rootScope.optiondata = {
            availableOptions: [],
            selectedOption: { 'EmpID': 0, 'EmpName': 'ALL' }
        };
        BaseService.getDeptEmployee($rootScope.dptID)
            .then(function (data) {
                console.log(data);
                $rootScope.optiondata.availableOptions = data;
                $.each(data, function (index, value) {
                    if (value.RoleID == "DR") {
                            console.log("enter");
                            $rootScope.optiondata.selectedOption = { 'EmpID': value.EmpID, 'EmpName': value.EmpName }
                        }
                })
                console.log($rootScope.optiondata.selectedOption);
                
            },function(data){
                alert(data);
            })
        
    }
    app.controller('MapCoordinatesCtrl', function ($scope, $compile) {
        var TILE_SIZE = 256;

        function bound(value, opt_min, opt_max) {
            if (opt_min != null) value = Math.max(value, opt_min);
            if (opt_max != null) value = Math.min(value, opt_max);
            return value;
        }

        function degreesToRadians(deg) {
            return deg * (Math.PI / 180);
        }

        function radiansToDegrees(rad) {
            return rad / (Math.PI / 180);
        }

        function MercatorProjection() {
            this.pixelOrigin_ = new google.maps.Point(TILE_SIZE / 2, TILE_SIZE / 2);
            this.pixelsPerLonDegree_ = TILE_SIZE / 360;
            this.pixelsPerLonRadian_ = TILE_SIZE / (2 * Math.PI);
        }

        MercatorProjection.prototype.fromLatLngToPoint = function (latLng,
            opt_point) {
            var me = this;
            var point = opt_point || new google.maps.Point(0, 0);
            var origin = me.pixelOrigin_;

            point.x = origin.x + latLng.lng() * me.pixelsPerLonDegree_;

            // Truncating to 0.9999 effectively limits latitude to 89.189. This is
            // about a third of a tile past the edge of the world tile.
            var siny = bound(Math.sin(degreesToRadians(latLng.lat())), -0.9999,
                0.9999);
            point.y = origin.y + 0.5 * Math.log((1 + siny) / (1 - siny)) *
                -me.pixelsPerLonRadian_;
            return point;
        };

        MercatorProjection.prototype.fromPointToLatLng = function (point) {
            var me = this;
            var origin = me.pixelOrigin_;
            var lng = (point.x - origin.x) / me.pixelsPerLonDegree_;
            var latRadians = (point.y - origin.y) / -me.pixelsPerLonRadian_;
            var lat = radiansToDegrees(2 * Math.atan(Math.exp(latRadians)) -
                Math.PI / 2);
            return new google.maps.LatLng(lat, lng);
        };

        $scope.$on('mapInitialized', function (event, map) {
            var numTiles = 1 << map.getZoom();
            var projection = new MercatorProjection();
            $scope.chicago = map.getCenter();
            $scope.worldCoordinate = projection.fromLatLngToPoint($scope.chicago);
            $scope.pixelCoordinate = new google.maps.Point(
                $scope.worldCoordinate.x * numTiles,
                $scope.worldCoordinate.y * numTiles);
            $scope.tileCoordinate = new google.maps.Point(
                Math.floor($scope.pixelCoordinate.x / TILE_SIZE),
                Math.floor($scope.pixelCoordinate.y / TILE_SIZE));
        });
    });
})
