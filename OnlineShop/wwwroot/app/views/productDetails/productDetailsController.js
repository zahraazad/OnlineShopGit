myApp.controller('productDetailsController', ['$scope', '$state', '$stateParams', 'system', 'fileUploadService', 'shoppingService'
    , function ($scope, $state, $stateParams, system, fileUploadService, shoppingService) {
        //varriabels
        $scope.title = 'Product Details';
        ////////////////////////////////////////// getAllProducts /////////////////////////////////////
        system.doServerSideOp('api/products/getProductGroups', {},
            function (response) {
                $scope.productGroups = response.data.productGroups;

                if ($scope.product !== undefined && $scope.product.groupId !== undefined) {
                    var index = $scope.productGroups.findIndex(x => x.id === $scope.product.groupId);
                    $scope.product.groupId = $scope.productGroups[index];
                }
            },
            function (response) {
                $scope.errorMessage = response.data;
            });
        //////////////////////////// getProductInfo ////////////////////////////
        system.doServerSideOp('api/products/getProductInfo', { id: $stateParams.id },
            function (response) {
                $scope.product = response.data;
                if ($scope.productGroups !== undefined) {
                    var index = $scope.productGroups.findIndex(x => x.id === $scope.product.groupId);
                    $scope.product.groupId = $scope.productGroups[index];
                }
            },
            function (response) {
                $scope.errorMessage = response.data;
                //redirectToProducts();
            });

        //////////////////////////// redirectToProducts ////////////////////////////

        var redirectToProducts = function () {
            $state.go('products');
        };
        var updateProductSuccess = function (response) {
            //show success message if needed.
            $scope.successMessage = response.data;
            redirectToProducts();
        };
        var updateProductFailure = function (response) {
            //show failure message if needed.
            $scope.errorMessage = response.data;
        };
        /////////////////////////////////////// updateProduct //////////////////////////////////////////////////

        var updateProduct = function (product) {
            var productParams = {
                groupId: $scope.product.groupId,
                id: product.id,
                name: product.name,
                description: product.description,
                price: product.price,
                quantityOnHand: product.quantityOnHand,
                imagePath: product.imagePath
            };

            system.doServerSideOp('api/products/updateProduct', productParams, updateProductSuccess, updateProductFailure);
        };
        /////////////////////////////////////// uploadFile //////////////////////////////////////////////////
        $scope.uploadFile = function (file) {
            if (file !== null) {
                var uploadUrl = "api/products/uploadImage",
                    params = {
                    },
                    promise = fileUploadService.uploadFileToUrl(file, uploadUrl, params);

                promise.then(function (response) {
                    $scope.successMessage = 'File uploaded successfully, to persiste the changes please hit Save button.';
                    $scope.product.imagePath = null;
                    $scope.product.imagePath = response.data;
                }, function (response) {
                    $scope.serverResponse = 'An error has been occurred';
                });
            }
        };
        /////////////////////////////////////////////////////////// UserInterface //////////////////////////////////////////////////////////
        /////////////////////////////////////// addToCart //////////////////////////////////////////////////
        $scope.addToCart = function (productId) {
            shoppingService.addToCart({ productId: productId, productCount: 1 }, function (response) {
                $scope.successMessage = 'Item added to the cart successfully, to finish your shopping, please go to Checkout.';
            }, function (response) {
                $scope.errorMessage = response.data;
            }
            );
        };
        /////////////////////////////////////// saveChanges //////////////////////////////////////////////////
        $scope.saveChanges = function (isValid) {
            if (isValid)
                updateProduct($scope.product);
            else
                $scope.validate = true;
        };
        /////////////////////////////////////// cancelChanges //////////////////////////////////////////////////
        $scope.cancelChanges = function () {
            redirectToProducts();
        };

    }]);