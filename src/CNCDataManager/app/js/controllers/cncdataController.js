'use strict';

/**
 * @ngdoc function
 * @name cncdataManagerApp.controller:CncdataCtrl
 * @description
 * # CncdataCtrl
 * Controller of the cncdataManagerApp
 */
angular.module('cncdataManagerApp')
  .controller('CNCdataCtrl', function ($scope, $location, $rootScope, $window) {
    //辅助方法
    var _hideError = function () { 
      angular.element(document.querySelector('#update-msg')).text('');
      angular.element(document.querySelector('#error-msg')).text('');
      $scope.ifError = false;
    };
    var _showError = function (msg) {
      var _selector = document.querySelector('#errorMsg');
      angular.element(_selector).text(msg);
      $scope.ifError = true;
    };
    var _showLoading = function () { $scope.ifLoading = true; };
    var _hideLoading = function () { 
      angular.element(document.querySelector('#update-msg')).text('');
      angular.element(document.querySelector('#error-msg')).text('');
      $scope.ifLoading = false; 
    };
    var _showUpdate = function (i, count, msg){
      console.log('showupdate called');
      var _updateMsg = document.querySelector('#update-msg');
      var message = i.toString() + '/' + count.toString() + ' success';
      angular.element(_updateMsg).text(message);
      if(msg)
      {
        var _errorMsg = document.querySelector('#error-msg');
        angular.element(_errorMsg).text(msg);
      }
    };
    $rootScope.currentPage = 'background-cncdata';
    // 1. 变量声明
    $scope.ifIndex = true;
    $scope.ifError = false;
    $scope.ifLoading = false;
    $scope.listName = '';
    //$scope.ITEMNAME = '';


    // 2. 监视URL，根据URL不同显示不同的
    $scope.$watch(function () 
    {
      return $location.path();
    }, function (path) 
    {
      $scope.ifIndex = _.includes(path, 'cncdata/index') ? true : false;
      $scope.listName = $location.search().listname;
    });

    // 3. 隐藏loading画面的方法
    $scope.messageTips = {
      showLoading: _showLoading,
      hideLoading: _hideLoading,
      showError: _showError,
      hideError: _hideError,
      showUpdate: _showUpdate
    };

    // 4. 辅助方法，原JQuery操作DOM的部分，使用Augular的DOM封装层来调用这些方法
    var toggleNavBar = function (icon, body) {
        var classname = icon.attr('class').toString();
        if (classname.indexOf('plus') > 0) {
            icon.removeClass('glyphicon-plus').addClass('glyphicon-minus');
        }
        else {
            icon.removeClass('glyphicon-minus').addClass('glyphicon-plus');
        }
        body.animate({ height: 'toggle' }, 300, function () {
            $(this).addClass('side-nav-head-2');
        });
    };

    var toggleSecondNavBar = function (icon, body) {
        var classname = icon.attr('class').toString();
        if (classname.indexOf('plus') > 0) {
            icon.removeClass('glyphicon-plus').addClass('glyphicon-minus');
        }
        else {
            icon.removeClass('glyphicon-minus').addClass('glyphicon-plus');
        }
        body.animate({ height: 'toggle' }, 300, function () {
            $(this).addClass('side-nav-head-3');
        });
    };

    // 5. 导航栏的ng-click调用
    $scope.toggleNav  = function(e, selector)
    {
      var body = angular.element(document.querySelector(selector));
      var icon = angular.element(e.currentTarget);
      toggleNavBar(icon, body);
    };
    $scope.toggleSecondNav = function (e, selector)
    {
      var body = angular.element(document.querySelector(selector));
      var icon = angular.element(e.currentTarget);
      toggleSecondNavBar(icon, body);
    };


    // 初始化
    angular.element($window).bind('scroll', function ()
    {
        var selector = document.querySelector('#side-nav-container');
        var nav = angular.element(selector);
        if(angular.element($window).scrollTop() > 280)
        {
          nav.addClass('side-nav-container-fixed');
        }
        else
        {
          nav.removeClass('side-nav-container-fixed');
        }
    });
  });
