'use strict';
(function () {
    //create the controller
    function NotificationController($scope, $routeParams, $http, notificationsService, navigationService, contentResource) {
        //set a property on the scope equal to the current route id
        $scope.nodeId = $scope.dialogOptions.currentAction.metaData.nodeId;
        $scope.isMap = $scope.dialogOptions.currentAction.metaData.isMap;
        $scope.Name = "";
        $scope.title = "A new location was added";
        $scope.message = "Location was added the to map";
        
        $scope.pushNotification = function () {
            $http.get("/Umbraco/backoffice/Api/Notification/PushNotification", { params: { title: $scope.title, message: $scope.message }})
                .then(function (response) {
                    notificationsService.success("Success", "Notifcation has been sent!");
                    navigationService.hideNavigation();
                });
        }

        function init()
        {
            $scope.title = $scope.isMap ? "A new location was added" : "A new timeline item was added";

            contentResource.getById($scope.nodeId)
                .then(function (content) {
                    var myDoc = content;
                    $scope.Name = myDoc.name;
                });

            contentResource.getChildren($scope.nodeId)
                .then(function (contentArray) {
                    var children = contentArray;
                    var order = 0;
                    console.log(children.items);
                    angular.forEach(children.items, function (child) {
                        if (child["sortOrder"] > order) {
                            $scope.message = child.name + ($scope.isMap ? " was added the to the map" : " was added to the timeline");
                            order = child["sortOrder"];
                        }
                    });
                });

        }
        init();
    };
    //register the controller
    angular.module("umbraco").controller('MandMOnTheRoad.NotificationController', NotificationController);

})();