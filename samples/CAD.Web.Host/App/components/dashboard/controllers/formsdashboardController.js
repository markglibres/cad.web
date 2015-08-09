
'use strict';


define(['app'], function (app) {

    var injectparams = ['$scope'];

    var formsdashboardController = function ($scope) {
        $scope.Title = "This is a testing";
    };

    formsdashboardController.$inject = injectparams;

    //This controller retrieves data from the customersService and associates it with the $scope
    //The $scope is ultimately bound to the customers view due to convention followed by the routeResolver
    app.register.controller('formsdashboardController', formsdashboardController);
});


