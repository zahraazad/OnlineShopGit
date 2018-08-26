myApp.service('authorization', ['system', '$cookies', '$rootScope',
    function (system, $cookies, $rootScope) {
        $rootScope.loggedIn = false;

        system.doServerSideOp('api/users/validateUser', {}, function (response) {
            $rootScope.loggedIn = response.data;
        }, function (response) {
            $rootScope.loggedIn = false;
        });
        /////////////////////// signIn //////////////////////
        this.signIn = function (email, password, successCallBack, failurCallBack) {
            system.doServerSideOp('api/users/signIn', { email: email, password: password }, function (response) {
                $rootScope.loggedIn = true;
                $cookies.put('key', response.data);
                if (successCallBack !== null && successCallBack !== typeof (undefined))
                    successCallBack(response);
            }, function (response) {
                $rootScope.loggedIn = false;
                if (failurCallBack !== null && failurCallBack !== typeof (undefined))
                    failurCallBack(response);
            });
        };
        this.signOut = function (successCallBack, failurCallBack) {
            system.doServerSideOp('api/users/signOut', {}, function () {
                $rootScope.loggedIn = false;
                if (successCallBack !== null && successCallBack !== typeof (undefined))
                    successCallBack();

            },
                function (response) {
                    $rootScope.loggedIn = true;
                    if (failurCallBack !== null && failurCallBack !== typeof (undefined))
                        failurCallBack();
                });
        };
        this.signUp = function (firstName, lastName, email, password, phone, address, successCallBack, failurCallBack) {
            system.doServerSideOp('api/users/signUp', {
                firstName: firstName,
                lastName: lastName,
                email: email,
                password: password,
                phone: phone,
                address: address
            }, function (response) {
                $rootScope.loggedIn = true;
                $cookies.put('key', response.data);
                if (successCallBack !== null && successCallBack !== typeof (undefined))
                    successCallBack();
            }, function (response) {
                $rootScope.loggedIn = false;
                if (failurCallBack !== null && failurCallBack !== typeof (undefined))
                    failurCallBack();
            });
        };
    }]);