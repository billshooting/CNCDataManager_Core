System.register(["./HttpProxy", "./User"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function registerServices(app) {
        app.service('HttpProxy', HttpProxy_1.default);
        app.service('User', User_1.default);
    }
    exports_1("default", registerServices);
    var HttpProxy_1, User_1;
    return {
        setters: [
            function (HttpProxy_1_1) {
                HttpProxy_1 = HttpProxy_1_1;
            },
            function (User_1_1) {
                User_1 = User_1_1;
            }
        ],
        execute: function () {
        }
    };
});
