import * as $ from 'jquery';
import * as angular from 'angular';

export class CNCDataLeftSide {
    public constructor($scope: angular.IScope & any)
    {
        $scope.log = () => { console.log('1'); };
        $scope.toggleNav = this.toggleNavBar;
        $scope.toggleSecondNav = this.toggleSecondNavBar;

        angular.element(window).bind('scroll', () => {
            let nav = angular.element('#side-nav-container');
            if (angular.element(window).scrollTop() > 280) {
                nav.addClass('side-nav-container-fixed');
            }
            else {
                nav.removeClass('side-nav-container-fixed');
            }
        });
    }

    private toggleNavBar($event: BaseJQueryEventObject, bodystr: string) {
        let body = angular.element(bodystr);
        let icon = angular.element($event.currentTarget);

        let classname = icon.attr('class').toString();
        if (classname.indexOf('plus') > 0) {
            icon.removeClass('glyphicon-plus').addClass('glyphicon-minus');
        }
        else {
            icon.removeClass('glyphicon-minus').addClass('glyphicon-plus');
        }
        body.animate({ height: 'toggle' }, 300, function () {
            angular.element(body).addClass('side-nav-head-2');
        });
    };

    private toggleSecondNavBar($event: BaseJQueryEventObject, bodystr: string) {
        let body = angular.element(bodystr);
        let icon = angular.element($event.currentTarget);

        let classname = icon.attr('class').toString();
        if (classname.indexOf('plus') > 0) {
            icon.removeClass('glyphicon-plus').addClass('glyphicon-minus');
        }
        else {
            icon.removeClass('glyphicon-minus').addClass('glyphicon-plus');
        }
        body.animate({ height: 'toggle' }, 300, function () {
            angular.element(body).addClass('side-nav-head-3');
        });
    };
};
//疑似bug，直接注入$window服务会导致控制器失效，所以直接用BOM window，感谢万能的jQuery!!
//CNCDataLeftSide.$inject = ['$window'];