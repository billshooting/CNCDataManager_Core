import angular from 'angular';
import 'angular-animate';
import 'angular-resource';
import 'angular-sanitize';

let app = angular.module('cncDataManager', [
    'ui.router',
    'ngAnimate',
    'ngResource',
    'ngSanitize',
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

import registerAccountRoute from './bases/AccountRoute';
import registerAccountControllers from './controllers/account/index';
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

registerAccountRoute(app);
registerAccountControllers(app);









