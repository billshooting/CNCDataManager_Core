System.register(["angular", "angular-route", "./controllers/index", "./bases/route", "./services/index", "./directives/index"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var angular, app, index_1, route_1, index_2, index_3;
    return {
        setters: [
            function (angular_1) {
                angular = angular_1;
            },
            function (_1) {
            },
            function (index_1_1) {
                index_1 = index_1_1;
            },
            function (route_1_1) {
                route_1 = route_1_1;
            },
            function (index_2_1) {
                index_2 = index_2_1;
            },
            function (index_3_1) {
                index_3 = index_3_1;
            }
        ],
        execute: function () {
            angular.module('cncDataManager', [
                'ngRoute'
            ]);
            app = angular.module('cncDataManager');
            /* services register*/
            index_2.default(app);
            /* directives register*/
            index_3.default(app);
            /* controller register*/
            index_1.default(app);
            /* route config*/
            route_1.default(app);
        }
    };
});
