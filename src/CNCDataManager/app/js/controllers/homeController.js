'use strict';

/**
 * @ngdoc function
 * @name cncdataManagerApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the cncdataManagerApp
 */
angular.module('cncdataManagerApp')
  .controller('HomeCtrl', function ($scope, $rootScope, $location) {
      $scope.path = '';

      $scope.$watch(function () {
          return $location.path();
      }, function (path) {
          if (_.includes(path, 'home/index')) {
              $rootScope.currentPage = 'background-home';
              $scope.path = 'index';
          }
          else if (_.includes(path, 'home/contact')) {
              $rootScope.currentPage = 'background-about';
              $scope.path = 'contact';
          }
          else if (_.includes(path, 'home/about')) {
              $rootScope.currentPage = 'background-about';
              $scope.path = 'about';
          }
          else {
              $rootScope.currentPage = 'background-home';
              $scope.path = 'index';
          }
      });
  });
