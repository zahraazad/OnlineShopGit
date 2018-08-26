myApp.controller('productsController', ['$scope', 'system', '$state',
    function ($scope, system, $state) {
        $scope.title = 'Products';
        $scope.selectedGroupId = null;

        ////////////////////////////////////////// addProduct /////////////////////////////////////
        $scope.addProduct = function () {
            $state.go('addProduct');
        };

        ////////////////////////////////////////// updateProduct /////////////////////////////////////
        $scope.updateProduct = function (id) {
            $state.go('productDetails', { id: id });
        };

        ////////////////////////////////////////// getProductGroups /////////////////////////////////////
        var getProductGroups = function () {
            system.doServerSideOp('api/products/getProductGroups', {},
                function (response) {
                    $scope.productGroups = response.data.productGroups;
                    $scope.productGroups.push({ id: null, name: 'All', description: 'All Product Groups' });
                    $scope.selectedGroupId = $scope.productGroups[$scope.productGroups.length - 1];
                },
                function (response) {
                    $scope.errorMessage = response.data;
                });
        };

        ////////////////////////////////////////// getAllProducts /////////////////////////////////////
        var getAllProducts = function () {
            system.doServerSideOp('api/products/getAllProducts', { groupId: $scope.selectedGroupId },
                function (response) {
                    $scope.products = response.data.products;

                }, null
            );

        };

        //////////////////////////////// deleteProduct ///////////////////////////////
        $scope.deleteProduct = function (id) {

            if (confirm("You're about DELETE the product with Id: " + id + ", are you sure?")) {
                system.doServerSideOp('api/products/deleteProduct', { id: id }, function (response) {
                    alert("Product with id: " + id + ", deeted successfully." + response.data);
                    //$state.reload();
                    getAllProducts();
                }, function (response) {
                    $scope.errorMessage = response.data;
                }
                );
            }
        };

        //////////////////////////////// pageLoad ///////////////////////////////
        getProductGroups();
        getAllProducts();
    }]);
