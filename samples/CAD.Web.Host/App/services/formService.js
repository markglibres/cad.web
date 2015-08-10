'use strict';

define(['app'], function (app) {

    var injectParams = ['$http', '$q', '$log'];

    var _factory = function ($http, $q, $log) {
        var factory = {};

        factory.post = function (url, formData, file) {

            var data = factory.formatData(formData, file);

            return (
                $http.post(url, data, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                })
            );
        };

        factory.formatData = function (dataToFormat, file) {
            var data = new FormData();
            angular.forEach(dataToFormat, function (value, key) {
                data.append(key, value);
            });
            data.append('file', file);
            return data;
        };

        return factory;
    };

    _factory.$inject = injectParams;

    app.factory('formService', _factory);

});