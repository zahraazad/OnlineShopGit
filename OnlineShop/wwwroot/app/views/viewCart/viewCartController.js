myApp.controller('viewCartController', ['$scope', '$state', 'system', 'shoppingService'
    , function ($scope, $state, system, shoppingService) {
        $scope.title = 'Your Shopping Cart';
        $scope.loading = false;
        $scope.total = 0;
        ////////////////////////////////////////// itemQuantityChanged /////////////////////////////////////
        $scope.itemQuantityChanged = function (id, newValue, oldValue) {
            $scope.loading = true;
            if (newValue > oldValue) {
                shoppingService.addToCart({ ProductId: id, ProductCount: newValue - oldValue },
                    function (response) {
                        if (response.data.products === null || response.data.products.length === 0) {
                            $scope.errorMessage = "Your shopping bag cantains 0 item and comes to total $0.00";
                        }
                        else {
                            getAllCartItems();
                            $scope.loading = false;
                        }
                    },
                    null);
            }
            else {
                shoppingService.removeFromCart({ ProductId: id, ProductCount: oldValue - newValue },
                    function (response) {
                        if (response.data.products === null || response.data.products.length === 0) {
                            $scope.errorMessage = "Your shopping bag cantains 0 item and comes to total $0.00";
                        }
                        else {
                            getAllCartItems();
                            $scope.loading = false;
                        }
                    },
                    null);
            }
        };
        ////////////////////////////////////////// rmoveItem ///////////////////////////////////
        $scope.rmoveItem = function (id, count) {
            shoppingService.removeFromCart({ ProductId: id, ProductCount: count },
                function (response) {
                    if (response.data.products === null || response.data.products.length === 0) {
                        $scope.cartItems = null;
                        $scope.errorMessage = "Your shopping bag cantains 0 item and comes to total $0.00";
                    }
                    else {
                        getAllCartItems();
                        $scope.loading = false;
                    }
                },
                null);
        };
        ////////////////////////////////////////// goToCheckOut ///////////////////////////////////
        $scope.goToCheckOut = function () {
            $state.go("checkOut", { amount: $scope.total });
        };
        ////////////////////////////////////////// itemDetails ///////////////////////////////////
        $scope.itemDetails = function (id) {
            $state.go("productDetails", { id: id });
        };
        ////////////////////////////////////////// pageLoad /////////////////////////////////////
        var getAllCartItems = function () {
            shoppingService.viewCartItems(
                function (response) {
                    if (response.data.products === null || response.data.products.length === 0) {
                        $scope.cartItems = null;
                        $scope.errorMessage = "Your shopping bag cantains 0 item and comes to total $0.00";
                    }
                    else {
                        $scope.cartItems = response.data.products;
                        for (var i = 0; i < $scope.cartItems.length; i++) {
                            var item = $scope.cartItems[i];
                            $scope.total += (item.productPrice * item.productCount);
                        }
                    }
                },
                function (response) {
                    $scope.errorMessage = response.data;
                });
        };
        getAllCartItems();
    }]);
