/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp");
var minify = require("gulp-minify");
var rename = require("gulp-rename");
var concat = require("gulp-concat");
var ts = require("gulp-typescript");
var tsProject = ts.createProject("tsconfig.json");

var browserify = require("browserify");
var source = require("vinyl-source-stream");
var tsify = require("tsify");
var paths = {
    pages: ["./app/**/*.html",],
    styles: ["./app/**/*.css",
             "./app/**/*.min.css"],
    js: ["./app/**/*.js",
         "./app/**/*.min.js"],
};

gulp.task("copy-html", function () {
    return gulp.src(paths.pages)
        .pipe(gulp.dest("dist"));
});

gulp.task("copy-lib-config", function () {
    return gulp.src(paths.js)
        .pipe(gulp.dest("dist"));
});

gulp.task("css", function () {
    return gulp.src(paths.styles)
        .pipe(concat("app.css"))
        .pipe(gulp.dest("dist/css"));
})

gulp.task("default", ["copy-html", "css", "copy-lib-config"], function () {
    return tsProject.src()
        .pipe(tsProject())
        .js
        //.pipe(concat('bundle.js'))
        .pipe(gulp.dest("dist/scripts"));

});