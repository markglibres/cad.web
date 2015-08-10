'use strict'

define(['app'], function (app) {

    //module links
    app.directive('loadingScreen', ['$http', function ($http) {

        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                
                var tagName = element[0].tagName;

                scope.loading = function () {
                    var queuelength = $http.pendingRequests.length;
                    return queuelength > 0;
                };

                scope.$watch(scope.loading, function (isLoading) {
                    if(isLoading){
                        element.removeClass('ng-hide');
                    }
                    else {
                        element.addClass('ng-hide');
                    }
                });
                
                //attrs.$set(urlAttrib, baseUrl + attrs.modUrl);
            }
        }
    }]);

});