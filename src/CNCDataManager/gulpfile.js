/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

let gulp = require("gulp");
let minify = require("gulp-minify");
let rename = require("gulp-rename");
let concat = require("gulp-concat");
let ts = require("gulp-typescript");
let tsProject = ts.createProject("tsconfig.json");

var browserify = require("browserify");
var source = require('vinyl-source-stream');
var tsify = require("tsify");
var paths = {
    pages: ['./app/*.html']
};

gulp.task("copy-html", function () {
    return gulp.src(paths.pages)
        .pipe(gulp.dest("dist"));
});

gulp.task("default", ["copy-html"], function () {
    return tsProject.src()
        .pipe(tsProject())
        .js
        //.pipe(concat('bundle.js'))
        .pipe(gulp.dest("dist"));

});