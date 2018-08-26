myApp.controller('mainController', ['authorization', 'shoppingService', function (authorization, shoppingService) {
    this.signOut = function () {
        authorization.signOut(function () {
            $state.go("signIn");
        });
    }
}]);