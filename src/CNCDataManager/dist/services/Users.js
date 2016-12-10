System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Users;
    return {
        setters: [],
        execute: function () {
            Users = (function () {
                function Users() {
                }
                return Users;
            }());
            exports_1("default", Users);
            Users.$inject = ['HttpProxy'];
        }
    };
});
