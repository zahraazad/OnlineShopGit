var myApp = angular.module("myApp", ['ui.router', 'ngCookies'])
    .config(['$stateProvider', '$locationProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider'
        , function ($stateProvider, $locationProvider, $urlRouterProvider, $urlMatcherFactoryProvider) {
            //$urlMatcherFactoryProvider.caseInsensitive(true);
            //$locationProvider.html5Mode(true);
            $urlRouterProvider.otherwise('/home');
            $stateProvider
                .state('products', {
                    url: '/products',
                    templateUrl: 'app/views/products/products.html',
                    controller: 'productsController'
                })
                .state('addProduct', {
                    url: '/addProduct/:key',
                    templateUrl: 'app/views/addProduct/addProduct.html',
                    controller: 'addProductController'
                })
                .state('productDetails', {
                    url: '/productDetails/:id',
                    templateUrl: 'app/views/productDetails/productDetails.html',
                    controller: 'productDetailsController'
                })
                .state('home', {
                    url: '/home',
                    templateUrl: 'app/views/home/home.html',
                    controller: 'homeController'
                })
                .state('aboutUs', {
                    url: '/about',
                    templateUrl: 'app/views/about/about.html',
                    controller: 'aboutController'
                })
                .state('checkOut', {
                    url: '/checkOut/:amount',
                    templateUrl: 'app/views/checkOut/checkOut.html',
                    controller: 'checkOutController'
                })
                .state('viewCart', {
                    url: '/viewCart',
                    templateUrl: 'app/views/viewCart/viewCart.html',
                    controller: 'viewCartController'
                })
                .state('signUp', {
                    url: '/signUp',
                    templateUrl: 'app/views/signUp/signUp.html',
                    controller: 'signUpController'
                })
                .state('signIn', {
                    url: '/signIn',
                    templateUrl: 'app/views/signIn/signIn.html',
                    controller: 'signInController'
                })
                .state('welcome', {
                    url: '/welcome',
                    templateUrl: 'app/views/welcome/welcome.html',
                    controller: 'welcomeController'
                })
                .state('error', {
                    url: '/error',
                    templateUrl: 'app/views/error/error.html',
                    controller: 'errorController'
                });

        }]);