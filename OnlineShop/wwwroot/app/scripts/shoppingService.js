myApp.service('shoppingService', ['$http', '$rootScope', '$cookies', 'system'
    , function ($http, $rootScope, $cookies, system) {
        var cartKey = $cookies.get('cartKey');
        $rootScope.cartItems = {};
        ///////////////////////////////////////// onLoad /////////////////////////////////////////////////
        this.getAllCartItems = function (successCallBack, filurCallBack) {
            system.doServerSideOp('api/sales/getAllCartItems', { cartKey: cartKey }, function (response) {
                $rootScope.cartItems = response.data.products;
                if (successCallBack !== null && successCallBack !== undefined) {
                    successCallBack(response);
                }
            }, function (response) {
                if (filurCallBack !== null && filurCallBack !== undefined) {
                    filurCallBack(response);
                }
            });
        };
        this.getAllCartItems(null, null);
        //////////////////////////////////////////////////////////////////////////////////
        this.viewCartItems = function (successCallBack, filurCallBack) {
            system.doServerSideOp('api/sales/viewCartItems', { cartKey: cartKey }, function (response) {
                if (successCallBack !== null && successCallBack !== undefined) {
                    successCallBack(response);
                }
            }, function (response) {
                if (filurCallBack !== null && filurCallBack !== undefined) {
                    filurCallBack(response);
                }
            });
        };
        ///////////////////////////////////////// addToCart /////////////////////////////////////////////////
        this.addToCart = function (parameters, successCallBack, filurCallBack) {

            parameters.cartKey = cartKey;
            system.doServerSideOp('api/sales/addToCart', parameters,
                function (response) {
                    $cookies.put('cartKey', response.data.cartKey);
                    $rootScope.cartItems = response.data.products;
                    if (successCallBack !== null && successCallBack !== undefined) {
                        successCallBack(response);
                    }
                },
                function (response) {
                    if (filurCallBack !== null && filurCallBack !== undefined) {
                        filurCallBack(response);
                    }
                }
            );
        };
        ///////////////////////////////////////// addToCart /////////////////////////////////////////////////
        this.removeFromCart = function (parameters, successCallBack, filurCallBack) {
            var cartKey = $cookies.get('cartKey');
            parameters.cartKey = cartKey;
            system.doServerSideOp('api/sales/removeFromCart', parameters,
                function (response) {
                    $cookies.put('cartKey', response.data.cartKey);
                    $rootScope.cartItems = response.data.products;
                    if (successCallBack !== null && successCallBack !== undefined) {
                        successCallBack(response);
                    }
                },
                function (response) {
                    if (filurCallBack !== null && filurCallBack !== undefined) {
                        filurCallBack(response);
                    }
                }
            );
        };
        ///////////////////////////////////////// doPayment /////////////////////////////////////////////////
        this.placeOrder = function (parameters, successCallBack, filurCallBack) {
            var cartKey = $cookies.get('cartKey');
            parameters.cartKey = cartKey;
            system.doServerSideOp('api/sales/placeOrder', parameters,
                function (response) {
                    $cookies.put('cartKey', response.data.cartKey);
                    $rootScope.cartItems = {};
                    if (successCallBack !== null && successCallBack !== undefined) {
                        successCallBack(response);
                    }
                },
                function (response) {
                    if (filurCallBack !== null && filurCallBack !== undefined) {
                        filurCallBack(response);
                    }
                }
            );
        };

    }]);