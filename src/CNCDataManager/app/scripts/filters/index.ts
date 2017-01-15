import * as angular from 'angular';
import PageBy from './PageBy';
import CNCSystemFiltrate from './CNCSystemFiltrate';
import SelectionGuidesFiltrateBy  from './SelectionGuidesFiltrateBy';
import SelectionScrewNutsFiltrateBy from './SelectionScrewNutsFiltrateBy';
import SelectionBearingsFiltrateBy from './SelectionBearingsFiltrateBy';
import SelectionCouplingsFiltrateBy from './SelectionCouplingsFiltrateBy';
import SelectionServoMotorFiltrateBy from './SelectionServoMotorFiltrateBy';
import SelectionServoDriverFiltrateBy from './SelectionServoDriverFiltrateBy';

export default function registerFilters(app: angular.IModule): void {
    app.filter('pageBy', PageBy);
    app.filter('cncSystemFiltrateBy', CNCSystemFiltrate);
    app.filter('selectionGuidesFiltrateBy', SelectionGuidesFiltrateBy);
    app.filter('selectionScrewNutsFiltrateBy', SelectionScrewNutsFiltrateBy);
    app.filter('selectionBearingsFiltrateBy', SelectionBearingsFiltrateBy);
    app.filter('selectionCouplingsFiltrateBy', SelectionCouplingsFiltrateBy);
    app.filter('selectionServoMotorFiltrateBy', SelectionServoMotorFiltrateBy);
    app.filter('SelectionServoDriverFiltrateBy', SelectionServoDriverFiltrateBy);
};