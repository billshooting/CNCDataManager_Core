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
        "angular-strap": "npm:angular-strap/dist/angular-strap.js",
        "angular-strap-tpl": "npm:angular-strap/dist/angular-strap.tpl.js",
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