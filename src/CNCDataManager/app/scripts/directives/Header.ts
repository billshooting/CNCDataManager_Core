import * as angular from 'angular';
import User from '../services/User';

let Header: angular.IDirectiveFactory = (user: User): angular.IDirective => {
    return {
        templateUrl: './app/views/directives/header.html',
        restrict: 'E',
        scope: true,
        link: (scope: angular.IScope, ele: Element, attr: Attr) => {

        }
    };
};
Header.$inject = ['User'];
export default Header;
