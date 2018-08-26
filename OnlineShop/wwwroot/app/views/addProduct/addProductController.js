myApp.controller('addProductController', ['$scope', '$state', '$stateParams', 'system', 'fileUploadService'
    , function ($scope, $state, $stateParams, system, fileUploadService) {
        //////////////////////////// varriabels ///////////////////////////////////
        $scope.title= 'Add Product Details';
        $scope.submitted = false;
        $scope.product = {
            name: '',
            description: '',
            price: 0,
            groupId: null,
            quantityOnHand: 0,
            imagePath: $stateParams.key
        };
        //////////////////////////// redirectToProducts ///////////////////////////////////
        var redirectToProducts = function () {
            $state.go('products');
        };
        ////////////////////////////////////////// getAllProducts /////////////////////////////////////
        system.doServerSideOp('api/products/getProductGroups', {},
            function (response) {
                $scope.productGroups = response.data.productGroups;
            },
            function (response) {
                $scope.errorMessage = response.data;
            });
        //////////////////////////// productUploadSuccess ///////////////////////////////////
        var addProductSuccess = function (response) {
            //show success message if needed.
            $scope.successMessage = "";
            redirectToProducts();
        };
        //////////////////////////// productUploadFailure ///////////////////////////////////
        var addProductFailure = function (response) {
            //show failure message if needed.
            $scope.errorMessage = response;
        };
        //////////////////////////// getProductGroup ///////////////////////////////////
        var getProductGroup = function (groupId) {
            angular.forEach($scope.productGroups, function (value, key) {
                if (value.id === parseInt(groupId))
                    return value;
            });
        };
        //////////////////////////// addProduct ///////////////////////////////////
        var addProduct = function (product) {
            var productParams = {
                groupId: $scope.product.groupId,
                name: product.name,
                description: product.description,
                price: product.price,
                quantityOnHand: product.quantityOnHand,
                imagePath: product.imagePath
            };
            //#region FlatWorkingCode
            //{
            //Name: product.name,
            //Description: product.description,
            //Price: product.price,
            //QuantityOnHand: product.quantityOnHand,
            //ImagePath: product.imagePath,
            //GroupId: selectedGroup.id
            //};
            //$http({
            //    url: "api/products/addProduct",
            //    //dataType: 'json',
            //    method: 'POST',
            //    params: productParams
            //    //,headers: {
            //    //    "Content-Type": "application/json"
            //    //}
            //}).success(function (response) {
            //    $scope.value = response;
            //})
            //    .error(function (error) {
            //        alert(error);
            //    });
            //#endregion
            system.doServerSideOp('api/products/addProduct', productParams, addProductSuccess, addProductFailure);
        };
        //////////////////////////// uploadFile ///////////////////////////////////
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
                    $stateParams.key = $scope.product.imagePath;
                }, function (response) {
                    $scope.serverResponse = response.data;
                });
            }
        };
        //////////////////////////// saveChanges ///////////////////////////////////
        $scope.saveChanges = function (isValid) {
            if (isValid)
                addProduct($scope.product);
            else
                $scope.validate = true;
        };
        $scope.cancelChanges = function () {
            redirectToProducts();
        };

    }]);