System.register(["./Header"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function registerDirective(app) {
        app.directive('appHeader', Header_1.default);
    }
    exports_1("default", registerDirective);
    var Header_1;
    return {
        setters: [
            function (Header_1_1) {
                Header_1 = Header_1_1;
            }
        ],
        execute: function () {
        }
    };
});
