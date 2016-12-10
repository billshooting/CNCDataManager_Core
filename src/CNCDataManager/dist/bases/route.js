System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function registerRoute(app) {
        app.config(function ($routeProvider) {
            $routeProvider
                .when('/home/index', {
                templateUrl: '/views/home.html',
                controller: 'HomeCtrl'
            })
                .when('/home/about', {
                templateUrl: '/views/about.html',
                controller: 'AboutCtrl'
            })
                .when('home/contact', {
                templateUrl: '/views/contact.html',
                controller: 'ContactCtrl'
            })
                .when('/cncdata/index', {
                templateUrl: 'views/cncdata.html',
                controller: 'CncIndexCtrl'
            })
                .when('/cncdata/list', {
                templateUrl: 'views/cncdata.html',
                controller: 'CncDataCtrl'
            })
                .otherwise({
                redirectTo: 'home/index'
            });
        });
    }
    exports_1("default", registerRoute);
    return {
        setters: [],
        execute: function () {
            registerRoute.$inject = ['$routeProvider'];
        }
    };
});
