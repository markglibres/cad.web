'use strict';

define(['app'], function (app) {

    var injectParams = ['$http', '$q', '$log'];

    var formFactory = function ($http, $q, $log) {
        var serviceBase = '/api/formservice/',
            factory = {};
        
        factory.getForms = function () {
            return $http.get(serviceBase).then(
                function (response) {
                    return response.data;
                },
                function (error) {
                    console.log(error);
                    return [];
                });
        };

        return factory;
    };

    formFactory.$inject = injectParams;

   
    app.factory('formService', formFactory);

});