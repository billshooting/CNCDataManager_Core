'use strict';

/**
 * @ngdoc directive
 * @name cncdataManagerApp.directive:cncdataIndexPanel
 * @description
 * # cncdataIndexPanel
 */
angular.module('cncdataManagerApp')
  .directive('cncdataIndexPanel', function () 
  {
    return {
      templateUrl: '/views/templates/cncdata-desc.html',
      restrict: 'E',
      link: function postLink(scope) 
      {
        // 1. 辅助方法
        var toggleDescBody = function (head, body, icon) 
        {
          head.toggleClass('desc-header-open');
          body.animate({ height: 'toggle' }, 500, function () {
            $(this).addClass('desc-body-open');
          });
          var classname = icon.attr('class').toString();
          if(classname.indexOf('glyphicon-menu-down') > 0)
          {
              setTimeout(function () {
                  icon.removeClass('glyphicon-menu-down').addClass('glyphicon-menu-right');
              }, 500);
          }
          else
          {
              icon.removeClass('glyphicon-menu-right').addClass('glyphicon-menu-down');
          }
        };

        // 2. ng-click的接口
        scope.toggleDesc = function(e, bodystr, iconstr)
        {
          var head = angular.element(e.currentTarget);
          var body = angular.element(document.querySelector(bodystr));
          var icon = angular.element(document.querySelector(iconstr));

          toggleDescBody(head, body, icon);
        };
      }
    };
  });
