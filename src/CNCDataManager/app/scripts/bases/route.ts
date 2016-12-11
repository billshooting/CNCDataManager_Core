import * as angular from 'angular';
import 'angular-route';

registerRoute.$inject = ['$routeProvider'];
export default function registerRoute(app: angular.IModule): void
{
    app.config(($routeProvider: angular.route.IRouteProvider) =>
    {
        $routeProvider
            .when('/home/index', {
                templateUrl: './views/controller-tpls/home.html',
                controller: 'HomeCtrl'
            })
            .when('/home/about', {
                templateUrl: './views/controller-tpls/about.html',
                controller: 'AboutCtrl'
            })
            .when('/home/contact', {
                templateUrl: './views/controller-tpls/contact.html',
                controller: 'ContactCtrl'
            })
            .when('/cncdata/index', {
                templateUrl: './views/controller-tpls/cncdata.html',
                controller: 'CncIndexCtrl'
            })
            .when('/cncdata/list', {
                templateUrl: './views/controller-tpls/cncdata.html',
                controller: 'CncDataCtrl'
            })
            .otherwise({
                redirectTo: 'home/index'
            });
    });
}