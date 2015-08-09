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
        'services/formService',
        'shared/menu/controllers/menuController',
        'directives/moduleDirectives',
    ],
    function () {
        angular.bootstrap(document, ['eforms']);
    });