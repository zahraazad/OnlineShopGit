myApp.controller('signUpController', ['$scope', '$state', 'authorization',
    function ($scope, $state, authorization) {
        $scope.title= "Sign Up";
        $scope.notMatchedPasswordMessage = 'Not matched password.';
        $scope.passwordMatched = true;
        $scope.matchPassword = function () {
            if ($scope.password !== $scope.confirmPassword) {
                $scope.passwordMatched = false;
            }
            else {
                $scope.passwordMatched = true;
            }

        };
        $scope.signUp = function (isValid) {
            if (isValid) {
                authorization.signUp(
                    $scope.firstName,
                    $scope.lastName,
                    $scope.email,
                    $scope.password,
                    $scope.phone,
                    $scope.address
                    , function (response) {
                        console.log('success');
                        $state.go('products');
                    }, null
                    //function (response) {
                    //    console.log('failed');
                    //    $scope.errorMessage = response.data;
                    //}
                );
            }
            else {
                $scope.validate = true;
            }
        };
    }]);