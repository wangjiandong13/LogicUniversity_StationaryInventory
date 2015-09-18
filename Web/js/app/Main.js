require.config({
    paths: {
        'angular': '../../vendor/angular',
        'angular-route': '../../vendor/angular-route',
        'dependencyResoverFor': '../dependencyResoverFor',
        'app': 'App',
        'service':'../Service',
        'fitter': '../fitter/Seftfitter',
        'bootstrap': 'Main',
        'routes': 'Route',
        'nvd3': '../../vendor/nv.dv.min'
    },
    skim: {
        'app': {
            deps: ['angular', 'angular-route', 'bootstrap', 'nvd3']
        },
        'angular-route': {
            deps: ['angular']
        },
    }
});

require(
    ['app', 'service', 'fitter'
    ], function (app, service, fitter) {
        angular.bootstrap(document, ['app', 'BaseServices', 'appfilter', 'ngMap', 'nvd3']);
    });
