myApp.factory('auth', ['system', '$cookies', function (system, $cookies) {
    var loggedOnUser;
    var setUser = function (user) {
        loggedOnUser = user;
    }
    return {

        isLoggedIn: function () {
            return (loggedOnUser) ? loggedOnUser : false;
        },
        signIn: function (email, password, successCallBack, failurCallBack) {
            system.doServerSideOp('api/users/signIn', { email: email, password: password }, function (response) {
                setUser(true);
                $cookies.put('key', response.data);
                if (successCallBack !== null && successCallBack !== typeof (undefined))
                    successCallBack();
            }, function (response) {
                setUser(true);
                if (failurCallBack !== null && failurCallBack !== typeof (undefined))
                    failurCallBack();
            });
        }
    }
}]);