System.config({
    defaultJSExtensions: true,

    paths: {
        "npm:*": "../node_modules/*"
    },
    // map tells the System loader where to look for things
    map: {
        "angular": "npm:angular/angular.js",
        "angular-route": "npm:angular-route/angular-route.js",
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