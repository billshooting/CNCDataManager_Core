import * as angular from 'angular';

registerRoute.$inject = ['$routeProvider'];
export default function registerRoute(app: angular.IModule): void
{
    app.config(($routeProvider: angular.route.IRouteProvider) =>
    {
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