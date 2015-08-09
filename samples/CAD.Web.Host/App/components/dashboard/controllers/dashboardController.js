
    'use strict';

   
    define(['app'], function (app) {

        var injectparams = ['$scope'];

        var dashboardController = function ($scope) {
            $scope.Title = "This is a testing";
        };

        dashboardController.$inject = injectparams;

        //This controller retrieves data from the customersService and associates it with the $scope
        //The $scope is ultimately bound to the customers view due to convention followed by the routeResolver
        app.register.controller('dashboardController', dashboardController);
    });


