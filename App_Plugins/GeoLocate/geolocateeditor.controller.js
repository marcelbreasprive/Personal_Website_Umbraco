angular.module("umbraco")
    .controller("Macel.Breas.GeoLocateController",
    function ($scope, $http) {
        
        if ($scope.model.value.length == 0)
            $scope.model.value = {
                Location: "Currently unknown"
            }
        //if ($scope.model.value.Location == '') $scope.model.value.Location = "Currently unknown"

        $scope.search = '';
        $scope.searched = false;
        $scope.foundlocations = [];

        $http({
            method: 'GET',
            url: '/umbraco/api/Utility/GetGoogleApiKey'
        }).then(function successCallback(response) {
            $scope.apiKey = response.data.slice(1, -1);;

        },
        function errorCallback(response) {
        });

        $scope.setLocation = function (location) {
            $scope.model.value.Location = location.formatted_address;
            $scope.model.value.Latitude = location.geometry.location.lat;
            $scope.model.value.Longitude = location.geometry.location.lng;
        }

        $scope.findLocations = function () {
            $http({
                method: 'GET',
                url: 'http://maps.googleapis.com/maps/api/geocode/json',
                params: {
                    address: $scope.search,
                    sensor: true,
                    key: $scope.apiKey
                }
            }).then(function successCallback(response) {
                $scope.foundlocations = response.data.results;
                $scope.searched = true;

            }, function errorCallback(response) {
                $scope.model.value.Location = "Unable to determine location"
                $scope.searched = true;
            });
        }
    });