﻿
import * as angular from 'angular';
import 'angular-animate';
import 'angular-cookie';
import 'angular-resource';
import 'angular-sanitize';
import 'angular-strap';


let app = angular.module('cncDataManager', [
    'ui.router',
    'ngAnimate',
   // 'ngCookies',
    'ngResource',
    'ngSanitize',
    'mgcrea.ngStrap',
]);


import registerControllers from './controllers/cnc-data/index';
import registerRoute from './bases/Route';
import registerServices from './services/index';
import registerDirectives from './directives/index';
import registerFilters from './filters/index';

import registerSelectionRoute from './bases/SelectionRoute';
import registerSelectionControllers from './controllers/cnc-selection/index';
///* services register*/
registerServices(app);

///* filters register */
registerFilters(app);

///* directives register*/
registerDirectives(app);

///* controller register*/
registerControllers(app);

/* route config*/
registerRoute(app);

registerSelectionRoute(app);
registerSelectionControllers(app);










