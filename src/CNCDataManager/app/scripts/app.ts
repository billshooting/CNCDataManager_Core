import * as $ from 'jquery';
import * as angular from 'angular';
import 'angular-animate';
import 'angular-resource';
import 'angular-sanitize';
import 'angular-strap';


let app = angular.module('cncDataManager', [
    'ui.router',
    'ngAnimate',
    'ngResource',
    'ngSanitize',
    'mgcrea.ngStrap',
]);

import changeDefaultConfiguration from './bases/Configuration';
import registerControllers from './controllers/cnc-data/index';
import registerRoute from './bases/Route';
import registerServices from './services/index';
import registerDirectives from './directives/index';
import registerFilters from './filters/index';

import registerSelectionRoute from './bases/SelectionRoute';
import registerSelectionControllers from './controllers/cnc-selection/index';
import registerDefaultValue from './bases/DefaultValue';

import registerSimulationRoute from './bases/SimulationRoute';
import registerSimulationControllers from './controllers/cnc-simulation/index';
///* services register*/
registerServices(app);

///* filters register */
registerFilters(app);

///* directives register*/
registerDirectives(app);

///* controller register*/
registerControllers(app);

/** change default config */
changeDefaultConfiguration(app);

/* route config*/
registerRoute(app);

registerSelectionRoute(app);
registerSelectionControllers(app);
registerDefaultValue(app); 

registerSimulationRoute(app);
registerSimulationControllers(app);









