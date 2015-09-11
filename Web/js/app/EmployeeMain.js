﻿require.config({
    paths: {
        'angular': '../../vendor/angular',
        'angular-route': '../../vendor/angular-route',
        'dependencyResoverFor': '../dependencyResoverFor',
        'app': 'App',
        'service':'../Service',
        'fitter': '../fitter/Seftfitter',
        'jQuery': '../../assets/global/plugins/jquery.min',
        'bootstrap': 'EmployeeMain',
        'routes': 'EmployeeRoute',
    },
    skim: {
        'app': {
            deps: ['angular', 'angular-route', 'bootstrap']
        },
        'angular-route': {
            deps: ['angular']
        },
        'EmployeeMain': {
            depos: ['jQuery']
        }
    }
});

require(
    [
        'app', 'service', 'fitter', 'jQuery'
    ], function (app, service, fitter) {
        angular.bootstrap(document, ['app', 'BaseServices', 'appfilter']);
    });
