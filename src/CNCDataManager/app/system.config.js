System.config({
    defaultJSExtensions: true,

    paths: {
        "npm:*": "../node_modules/*"
    },
    // map tells the System loader where to look for things
    map: {
        "angular": "npm:angular/angular.js",
        "angular-route": "npm:angular-route/angular-route.js",
        "lodash": "//cdn.bootcss.com/lodash.js/4.17.2/lodash.min.js",
        "angular-strap": "//cdn.bootcss.com/angular-strap/2.3.10/angular-strap.min.js",
        "angular-strap-tpl": "//cdn.bootcss.com/angular-strap/2.3.10/angular-strap.tpl.min.js",
    },
    meta: {
        'angular': {
            format: 'global',
        },
        'angular-route': {
            format: 'global',
        },
    }
});