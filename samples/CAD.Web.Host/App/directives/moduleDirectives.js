'use strict'

define(['app'], function (app) {

    //module links
    app.directive('modUrl', ['$location',function ($location) {

        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var baseUrl = $location.absUrl();
                var urlAttrib = 'href';

                if (element[0].tagName != 'A') {
                    urlAttrib = 'src';
                }
                attrs.$set(urlAttrib, baseUrl + attrs.modUrl);
            }
        }
    }]);

    //module links
    app.directive('serverUrl', ['$location', function ($location) {
        
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                
                var urlAttrib = 'href';

                if (element[0].tagName != 'A') {
                    urlAttrib = 'src';
                }
                attrs.$set(urlAttrib, attrs.serverUrl);
            }
        }
    }]);

});