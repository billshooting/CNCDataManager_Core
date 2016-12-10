'use strict';

/**
 * @ngdoc overview
 * @name cncdataManagerApp
 * @description
 * # cncdataManagerApp
 *
 * Main module of the application.
 */
angular
  .module('cncdataManagerApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'mgcrea.ngStrap'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/home/index', {
        templateUrl: '/views/home.html',
        controller: 'HomeCtrl',
        controllerAs: 'home'
      })
      .when('/home/about', {
          templateUrl: '/views/home.html',
          controller: 'HomeCtrl',
          controllerAs: 'home'
      })
      .when('/home/contact', {
          templateUrl: '/views/home.html',
          controller: 'HomeCtrl',
          controllerAs: 'home'
      })
      .when('/cncdata/index', {
        templateUrl: '/views/cncdata.html',
        controller: 'CNCdataCtrl',
        controllerAs: 'cncdata'
      })
      .when('/cncdata/list', {
        templateUrl: '/views/cncdata.html',
        controller: 'CNCdataCtrl',
        controllerAs: 'cncdata'
      })
      .otherwise({
        redirectTo: '/home/index'
      });
  });
