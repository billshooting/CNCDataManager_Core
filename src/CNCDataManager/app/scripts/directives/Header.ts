import * as angular from 'angular';
import Users from '../services/Users';

let Header: angular.IDirectiveFactory = (user: Users, $modal: mgcrea.ngStrap.modal.IModal): angular.IDirective => {
    return {
        templateUrl: './views/directives/header.html',
        restrict: 'E',
        scope: true,
        link: (scope: angular.IScope, ele: Element, attr: Attr) => {

        }
    };
};

export default Header;
