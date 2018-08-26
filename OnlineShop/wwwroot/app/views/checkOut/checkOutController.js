myApp.controller('checkOutController', ['$scope', '$stateParams', 'shoppingService',
    function ($scope, $stateParams, shoppingService) {
        $scope.title = "Check Out";
        $scope.cartNumber = null;
        $scope.securityCode = null;
        $scope.amount = parseInt($stateParams.amount);
        $scope.placeOrder = function () {
            shoppingService.placeOrder({ BankCartKey: $scope.cartNumber, SecurityKey: $scope.securityCode }, function (response) {
                $scope.successMessage = "Thank you for shopping from us, your order number is: " + response.data.order.orderNumber + " \
                . Your order will be delivered to your address within 3 to 5 bussinuss days.";
            }, function (response) {
                $scope.errorMessage = response.data;
            });
        };
    }]);