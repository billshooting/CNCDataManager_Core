'use strict';

/**
 * @ngdoc directive
 * @name cncdataManagerApp.directive:contenteditable
 * @description
 * # contenteditable
 */
angular.module('cncdataManagerApp')
  .directive('contenteditable', function ($sce) {
    return {
      restrict: 'A',
      require: 'ngModel',
      link: function postLink(scope, element, attrs, ngModelCtrl) {
        if(!ngModelCtrl) { return; }

        ngModelCtrl.$render = function () {
          element.html($sce.getTrustedHtml(ngModelCtrl.$viewValue || ''));
        };

        var read = function () {
          var value = element.html();
          if(attrs.type !== 'number' && attrs.type !== 'text')
          {
            ngModelCtrl.$render();
          }
          else
          {
            ngModelCtrl.$setViewValue(value);
          }
        };

        if(attrs.type === 'number')
        {
          ngModelCtrl.$parsers.push(function (value) { return parseFloat(value); });
        }
        if(attrs.type === 'text')
        {
          ngModelCtrl.$parsers.push(function (value) { return value.toString(); });
        }

        element.on('blur keyup change', function () {
          scope.$apply(read);
        });
      }
    };
  });
