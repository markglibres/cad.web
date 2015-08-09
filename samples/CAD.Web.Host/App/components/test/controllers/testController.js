
    'use strict';

   
    define(['app'], function (app) {

        var injectparams = ['$scope'];

        var _controller = function ($scope) {
            $scope.Title = "Testing with angularjs module";
        };

        _controller.$inject = injectparams;

        //This controller retrieves data from the customersService and associates it with the $scope
        //The $scope is ultimately bound to the customers view due to convention followed by the routeResolver
        app.register.controller('testController', _controller);
    });


