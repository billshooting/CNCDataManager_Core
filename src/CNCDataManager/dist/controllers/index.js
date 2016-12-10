System.register(["./home/home", "./home/about", "./home/contact"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function registerControllers(app) {
        app.controller('HomeCtrl', home_1.HomeController);
        app.controller('AboutCtrl', about_1.AboutController);
        app.controller('ContactCtrl', contact_1.ContactController);
    }
    exports_1("default", registerControllers);
    var home_1, about_1, contact_1;
    return {
        setters: [
            function (home_1_1) {
                home_1 = home_1_1;
            },
            function (about_1_1) {
                about_1 = about_1_1;
            },
            function (contact_1_1) {
                contact_1 = contact_1_1;
            }
        ],
        execute: function () {
        }
    };
});
