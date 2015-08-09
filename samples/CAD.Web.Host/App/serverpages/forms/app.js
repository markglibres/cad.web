
    'use strict';

    //var app = angular.module('eforms', [
    //    // Angular modules 
    //    'ngRoute', 

    //    // Custom modules 
    //    'routeResolverServices'

    //    // 3rd Party Modules
        
    //]);

    define(['routeResolver'], function () {

        var app = angular.module('eforms', ['ngRoute','routeResolverServices']);

        app.config(['$routeProvider', 'routeResolverProvider', '$controllerProvider',
                    '$compileProvider', '$filterProvider', '$provide',
            function ($routeProvider, routeResolverProvider, $controllerProvider,
                      $compileProvider, $filterProvider, $provide) {

                //Change default views and controllers directory using the following:
                //routeResolverProvider.routeConfig.setBaseDirectories('/app/views', '/app/controllers');

                app.register =
                {
                    controller: $controllerProvider.register,
                    directive: $compileProvider.directive,
                    filter: $filterProvider.register,
                    factory: $provide.factory,
                    service: $provide.service
                };

                //Define routes - controllers will be loaded dynamically
                var route = routeResolverProvider.route;

                $routeProvider
                    .when('/', route.resolve('forms'))
                    .when('/test', route.resolve('test'))
                    .otherwise({ redirectTo: '/' });

            }]);


        return app;
    });

