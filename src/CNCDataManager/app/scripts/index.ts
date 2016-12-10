
import * as angular from 'angular';
import 'angular-route';

angular.module('cncDataManager',
    [
        'ngRoute'
    ]);

let app: angular.IModule = angular.module('cncDataManager');

import registerControllers from './controllers/index';
import registerRoute from './bases/route';
import registerServices from './services/index';
import registerDirectives from './directives/index';

/* services register*/
registerServices(app);

/* directives register*/
registerDirectives(app);

/* controller register*/
registerControllers(app);

/* route config*/
registerRoute(app);








