'use strict';

define(['app'], function (app) {

    var injectParams = ['$scope', 'formService'];

    var menuController = function ($scope, formService) {

        var mainMenus = [
           {
               'Text': 'Home',
               'Baseurl': '/',
               'Action' : ''
           },
           {
               'Text': 'Forms',
               'Baseurl': '/Forms',
               'Action': ''
           }
        ];

        $scope.menus = mainMenus;
        
        formService.getForms().then(function (data) {
            //$scope.menus = data;
        });
    };

    menuController.$inject = injectParams;


    //Loaded normally since the script is loaded upfront 
    //Dynamically loaded controller use app.register.controller
    app.controller('menuController', menuController);

});