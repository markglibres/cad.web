
    'use strict';

   
    define(['app'], function (app) {

        var injectparams = ['$scope', 'formService'];

        var _controller = function ($scope, formService) {
            $scope.Title = "Testing with angularjs module";
            $scope.formData = {};

            $scope.submitForm = function () {
                formService.post('/Forms/Create', $scope.formData, $scope.fileupload)
                .success(function (data) {
                    console.log(data);
                });

            };
        };

        _controller.$inject = injectparams;

        //This controller retrieves data from the customersService and associates it with the $scope
        //The $scope is ultimately bound to the customers view due to convention followed by the routeResolver
        app.register.controller('testController', _controller);
    });


