import * as angular from 'angular';
import User from '../services/User';

let Header: angular.IDirectiveFactory = ($window: angular.IWindowService, user: User): angular.IDirective => {
    return {
        templateUrl: './views/directives/header.html',
        restrict: 'E',
        scope: true,
        link: (scope: angular.IScope, ele: Element, attr: Attr) => {
            angular.element($window).scroll(() => {
                if (angular.element($window).scrollTop() < 10) {
                    angular.element('#navbar').css({ background: 'none' });
                    angular.element('#back-to-top').fadeOut(500);
                }
                else {
                    angular.element('#navbar').css({ background: '#555' });
                    angular.element('#back-to-top').fadeIn(500);
                }
            });
        }
    };
};
Header.$inject = ['$window', 'User'];
export default Header;
