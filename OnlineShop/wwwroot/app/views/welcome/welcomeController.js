myApp.controller("welcomeController", ["$scope", "$http", "$cookies", "authorization", function ($scope, $http, $cookies, authorization) {
    $scope.title = "";
    var key = $cookies.get('key');
    authorization.authorize(key, function () {
        $scope.loggedIn = authorization.loggedIn;
        if ($scope.loggedIn) $scope.title = "Welcome!";
    });

}]);