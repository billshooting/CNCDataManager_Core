import * as angular from 'angular';
import Header from './Header';
import BackToTop from './BackToTop';

export default function registerDirective(app: angular.IModule): void {
    app.directive('appHeader', Header);
    app.directive('backToTop', BackToTop);
}