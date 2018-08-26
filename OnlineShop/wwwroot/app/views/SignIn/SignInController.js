myApp.controller('signInController', ['$scope', '$state', 'authorization',
    function ($scope, $state, authorization) {
        $scope.title = "Sign In";
        $scope.signIn = function () {
            authorization.signIn($scope.email, $scope.password, function (response) {
                $state.go('products');
            }, function (response) {
                $scope.errorMessage = response.data;
            });
        }
    }]);