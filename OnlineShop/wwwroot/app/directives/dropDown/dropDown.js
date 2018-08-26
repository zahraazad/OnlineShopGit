myApp.directive('dropDown', function ($parse) {
    return {
        restrict: 'E',
        templateUrl: '/app/directives/dropDown/dropDown.html',
        scope: {
            ngModel: '=',
            text: '@',
            options: '=',
            icon: '@',
            textClass: '@'
        }
    };
});