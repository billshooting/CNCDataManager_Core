import * as angular from 'angular';
import Header from './Header';

export default function registerDirective(app: angular.IModule): void {
    app.directive('appHeader', Header);
}