myApp.service('system', ['$http', '$cookies', '$rootScope', '$state', function ($http, $cookies, $rootScope, $state) {
    this.doServerSideOp = function (url, parameters, successCallBack, filurCallBack, data) {
        var key = $cookies.get('key');
        parameters.key = key;
        var request = {
            url: url,
            method: 'POST',
            params: parameters,
            //headers: {
            //    'contentType': "application/json",
            //    'dataType': 'JSON'
            //},
            headers: { 'Content-Type': undefined },
            data: (data !== undefined ? data : null)
        };
        $http(request).then(function (response) {
            if (successCallBack !== null && successCallBack !== typeof (undefined))
                successCallBack(response);
        }, function (response) {
            setError(response.data);
            if (filurCallBack !== null && filurCallBack !== typeof (undefined))
                filurCallBack(response);
            else
                $state.go('error');
        });
    };
    var setError = function (error) {
        $rootScope.error = {};
        $rootScope.error.message = error.Message;
        $rootScope.error.statusCode = error.StatusCode;
    };
    this.displayErrorMessage = function (errorMessage) {

    };
}]);