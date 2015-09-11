require.config({
    paths: {
        'angular': '../../vendor/angular',
        'angular-route': '../../vendor/angular-route',
        'jquery': '../../vendor/jquery',
        'bootstrap': 'EmployeeMain',
        'dependencyResoverFor': '../dependencyResoverFor',
        'routes': 'EmployeeRoute',
        'app': 'EmployeeApp',
        'service':'../Service'
    },
    skim: {
        'app': {
            deps: ['angular', 'angular-route', 'bootstrap']
        },
        'angular-route': {
            deps: ['angular']
        },
        'EmployeeMain': {
            depos: ['jquery']
        }
    }
});

require(
    [
        'app',
        'service'
    ], function (app, service) {
        angular.bootstrap(document, ['app', 'BaseServices']);
    });
