myApp.service('fileUploadService', ['system', '$q', function (system, $q) {

    this.uploadFileToUrl = function (file, uploadUrl, params) {
        //FormData, object of key/value pair for form fields and values
        var fileFormData = new FormData();
        fileFormData.append('file', file);
        var deffered = $q.defer();
        system.doServerSideOp(uploadUrl, params, function (response) {
            deffered.resolve(response);
        }, function (response) {
            deffered.reject(response);
        }, fileFormData);
        return deffered.promise;
    };
}]);
