System.config({
    defaultJSExtensions: true,

    paths: {
        "lib:*": "./lib/*"
    },
    // map tells the System loader where to look for things
    map: {
        "jquery":"lib:jquery/jquery.min.js",
        //    [
        //    "http://cdn.bootcss.com/jquery/3.1.1/jquery.min.js",
        //    "./lib/jquery/jquery.min.js",
        //],
        "bootstrap": "lib:bootstrap/bootstrap.min.js",
        "lodash": "lib:lodash/lodash.min.js",
        //    [
        //    "http://cdn.bootcss.com/lodash.js/4.17.2/lodash.min.js",
        //    "lib:lodash/lodash.min.js",
        //],
        "angular": "lib:angular/angular.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular.min.js",
        //    "lib:angular/angular.min.js",
        //],
        "angular-animate": "lib:angular-animate/angular-animate.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-animate.min.js",
        //    "lib:angular-animate/angular-animate.min.js",
        //],
        "angular-route": "lib:angular-route/angular-route.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-route.min.js",
        //    "lib:angular-route/angular-route.js",
        //],
        "angular-sanitize": "lib:angular-sanitize/angular-sanitize.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-sanitize.min.js",
        //    "lib:angular-sanitize/angular-sanitize.min.js",
        //],
        "angular-cookie": "lib:angular-cookie/angular-cookie.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-cookies.min.js",
        //    "lib:angular-cookie/angular-cookie.min.js",
        //],
        "angular-resource": "lib:angular-resource/angular-resource.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-resource.min.js",
        //    "lib:angular-resource/angular-resource.min.js",
        //],
        "angular-ui-router": "lib:angular-ui-router/angular-ui-router.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular-ui-router/0.3.2/angular-ui-router.min.js",
        //    "lib:angular-ui-router/angular-ui-router.min.js",
        //],
        "angular-strap": "lib:angular-strap/angular-strap.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular-strap/2.3.10/angular-strap.min.js",
        //    "lib:angular-strap/angular-strap.min.js",
        //],
        "angular-strap-tpl": "lib:angular-strap/angular-strap.tpl.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular-strap/2.3.10/angular-strap.tpl.min.js",
        //    "lib:angular-strap/angular-strap.tpl.min.js",
        //]
    },
    meta: {
        'angular': {
            format: 'global',
            deps: ["jquery",
                "bootstrap"
            ]
        }
    }
});