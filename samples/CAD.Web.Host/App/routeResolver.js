
'use strict';

define([], function () {

    var routeResolver = function () {

        this.$get = function () {
            return this;
        };

        this.routeConfig = function () {
            var componentsDirectory = '/app/components/',
                pagesDirectory = '/app/serverpages/',
                controllersSubDirectory = '/controllers/',
                servicesSubDirectory = '/services/',
                viewsSubDirectory = '/views/',

            setBaseDirectories = function (componentsDir, pagesDir) {
                componentsDirectory = componentsDir;
                pagesDirectory = sharedDir;

            },

            getComponentsDirectory = function () {
                return componentsDirectory;
            },

            getPagesDirectory = function () {
                return pagesDirectory;
            },

            getViewsSubDirectory = function () {
                return viewsSubDirectory;
            },

            getControllersSubDirectory = function () {
                return controllersSubDirectory;
            },

            getServicesSubDirectory = function () {
                return servicesSubDirectory;
            };

            return {
                setBaseDirectories: setBaseDirectories,
                getComponentsDirectory: getComponentsDirectory,
                getPagesDirectory: getPagesDirectory,
                getControllersSubDirectory: getControllersSubDirectory,
                getServicesSubDirectory: getServicesSubDirectory,
                getViewsSubDirectory: getViewsSubDirectory
            };
        }();

        this.route = function (routeConfig) {

            var resolve = function (componentName, controller) {

                var componentDirectory = routeConfig.getComponentsDirectory() + componentName;
                var componentViewDirectory = componentDirectory + routeConfig.getViewsSubDirectory();
                var componentControllerDirectory = componentDirectory + routeConfig.getControllersSubDirectory();
                var componentServiceDirectory = componentDirectory + routeConfig.getServicesSubDirectory();
                var controllerName = ((controller != null && controller != '') ? controller : componentName) + 'Controller';
                var serviceName = ((controller != null && controller != '') ? controller : componentName) + 'Service';
                var viewName = (controller != null && controller != '') ? controller : componentName;

                var routeDef = {};
                routeDef.templateUrl = componentViewDirectory + viewName + '.html';
                routeDef.controller = controllerName;
                //routeDef.secure = (secure) ? secure : false;
                //console.log(componentServiceDirectory + serviceName + '.js');
                routeDef.resolve = {
                    load: ['$q', '$rootScope', function ($q, $rootScope) {
                        var dependencies = [componentControllerDirectory + controllerName + '.js'];

                        //TODO: include dynamic loading of factories
                        //var dependencies = [componentServiceDirectory + serviceName + '.js',
                        //    componentControllerDirectory + controllerName + '.js'];

                        return resolveDependencies($q, $rootScope, dependencies);
                    }]
                };

                return routeDef;
            },

            resolveDependencies = function ($q, $rootScope, dependencies) {
                var defer = $q.defer();
                require(dependencies, function () {
                    defer.resolve();
                    $rootScope.$apply()
                });

                return defer.promise;
            };

            return {
                resolve: resolve
            }
        }(this.routeConfig);

    };

    var servicesApp = angular.module('routeResolverServices', []);

    //Must be a provider since it will be injected into module.config()    
    servicesApp.provider('routeResolver', routeResolver);
});
