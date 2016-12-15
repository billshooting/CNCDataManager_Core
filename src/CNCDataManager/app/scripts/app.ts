import * as $ from 'jquery';
import * as angular from 'angular';
import 'angular-animate';
import 'angular-cookie';
import 'angular-resource';
import 'angular-sanitize';
import 'angular-strap';


let app = angular.module('cncDataManager', [
    'ui.router',
    'ngAnimate',
    'ngResource',
    'ngSanitize',
    'mgcrea.ngStrap'
]);


import registerControllers from './cnc-data/controllers/index';
import registerRoute from './cnc-data/bases/Route';
import registerServices from './cnc-data/services/index';
import registerDirectives from './cnc-data/directives/index';
///* services register*/
registerServices(app);

///* directives register*/
registerDirectives(app);

///* controller register*/
registerControllers(app);

/* route config*/
registerRoute(app);










