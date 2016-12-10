System.register(["angular"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var angular, $$injector, inject;
    return {
        setters: [
            function (angular_1) {
                angular = angular_1;
            }
        ],
        execute: function () {
            /**
             * inject方法可以作为一个注解，帮助类获得angular的内置的服务
             */
            exports_1("inject", inject = function (services) {
                if (!services || !services.length) {
                    return;
                }
                var service;
                return function (Target) {
                    angular.module('cncDataManager').run(['$injector', function ($injector) {
                            $$injector = $injector;
                            angular.forEach(services, function (name, index) {
                                try {
                                    service = $injector.get(name);
                                    Target.prototype[name] = service;
                                }
                                catch (error) {
                                    console.error(error);
                                }
                            });
                        }]);
                };
            });
        }
    };
});
