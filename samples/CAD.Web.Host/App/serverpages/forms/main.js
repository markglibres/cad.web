require.config({
    baseUrl: '/app',
    urlArgs: 'v=1.0',
    paths: {
        app: 'serverpages/forms/app'
    },
    shim: {
        'serverpages/forms/app': {
            deps: ['routeResolver']
        }
    }
});

require(
    [
        'app',
        'services/onlineformsService',
        'services/formService',
        'shared/menu/controllers/menuController',
        'directives/moduleDirectives',
        'directives/loaderDirective',
        'directives/uploadDirective',

    ],
    function () {
        angular.bootstrap(document, ['eforms']);
    });