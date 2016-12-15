import * as $ from 'jquery';
import * as angular from 'angular';

export class CNCDataDescription {

    public constructor($scope: angular.IScope & any) {
        $scope.toggleDesc = ($event: BaseJQueryEventObject, bodystr: string, iconstr: string): void => {
            let head = angular.element($event.currentTarget);
            let icon = angular.element(document.querySelector(iconstr));

            head.toggleClass('desc-header-open');

            angular.element(bodystr).animate({ height: 'toggle' }, 500);

            let classname = icon.attr('class').toString();
            if (classname.indexOf('glyphicon-menu-down') > 0) {
                setTimeout(function () {
                    icon.removeClass('glyphicon-menu-down').addClass('glyphicon-menu-right');
                }, 500);
            }
            else {
                icon.removeClass('glyphicon-menu-right').addClass('glyphicon-menu-down');
            }
        }
    }
    //如果在angular之前引入jquery，那么$event的类型是BaseJQueryEventObject
};
