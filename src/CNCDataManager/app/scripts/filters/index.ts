import * as angular from 'angular';
import PageBy from './PageBy';
import CNCSystemFiltrate from './CNCSystemFiltrate';

export default function registerFilters(app: angular.IModule): void {
    app.filter('pageBy', PageBy);
    app.filter('cncSystemFiltrateBy', CNCSystemFiltrate);
};