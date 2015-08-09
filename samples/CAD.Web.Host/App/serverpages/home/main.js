require.config({
    baseUrl: '/app',
    urlArgs: 'v=1.0',
    paths: {
        app: 'serverpages/home/app'

    },
    shim: {
        'serverpages/home/app': {
            deps: ['routeResolver']
        },
        'shared/menu/controllers/menuController': {
            deps: ['services/formService']
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