System.config({
    defaultJSExtensions: true,

    paths: {
        "lib:*": "./lib/*"
    },
    // map tells the System loader where to look for things
    map: {
        "jquery": "http://cdn.bootcss.com/jquery/3.1.1/jquery.min.js",
        //    [
        //    "http://cdn.bootcss.com/jquery/3.1.1/jquery.min.js",
        //    "./lib/jquery/jquery.min.js",
        //],
        "bootstrap": "http://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js",
        "lodash": "http://cdn.bootcss.com/lodash.js/4.17.2/lodash.min.js",
        //    [
        //    "http://cdn.bootcss.com/lodash.js/4.17.2/lodash.min.js",
        //    "lib:lodash/lodash.min.js",
        //],
        "angular": "http://cdn.bootcss.com/angular.js/1.6.0/angular.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular.min.js",
        //    "lib:angular/angular.min.js",
        //],
        "angular-animate": "http://cdn.bootcss.com/angular.js/1.6.0/angular-animate.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-animate.min.js",
        //    "lib:angular-animate/angular-animate.min.js",
        //],
        "angular-route": "http://cdn.bootcss.com/angular.js/1.6.0/angular-route.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-route.min.js",
        //    "lib:angular-route/angular-route.js",
        //],
        "angular-sanitize": "http://cdn.bootcss.com/angular.js/1.6.0/angular-sanitize.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-sanitize.min.js",
        //    "lib:angular-sanitize/angular-sanitize.min.js",
        //],
        "angular-cookie": "http://cdn.bootcss.com/angular.js/1.6.0/angular-cookies.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-cookies.min.js",
        //    "lib:angular-cookie/angular-cookie.min.js",
        //],
        "angular-resource": "http://cdn.bootcss.com/angular.js/1.6.0/angular-resource.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular.js/1.6.0/angular-resource.min.js",
        //    "lib:angular-resource/angular-resource.min.js",
        //],
        "angular-ui-router": "http://cdn.bootcss.com/angular-ui-router/0.3.2/angular-ui-router.min.js",
        //    [
        //    "http://cdn.bootcss.com/angular-ui-router/0.3.2/angular-ui-router.min.js",
        //    "lib:angular-ui-router/angular-ui-router.min.js",
        //],

        "highcharts": "//cdn.bootcss.com/highcharts/5.0.9/highcharts.js",
        "highchart-exporting": "//cdn.bootcss.com/highcharts/5.0.9/js/modules/exporting.js",
    },
    meta: {

        'angular': {
            format: 'global',
            exports: 'angular',
            deps: ["jquery",
                "bootstrap"
            ]
        },
        'bootstrap':{
            deps:[
                'jquery'
            ]
        }
    }
});

//System.import('./scripts/app.js');
System.import('./scripts/bundle.min.js');
