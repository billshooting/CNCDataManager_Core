/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp");
var uglify = require("gulp-uglify");
var minifyCss = require("gulp-minify-css");
var minifyHtml = require("gulp-minify-html");
var rename = require("gulp-rename");
var concat = require("gulp-concat");
var ts = require("gulp-typescript");
var tsProject = ts.createProject("tsconfig.json");

var browserify = require("browserify");
var source = require("vinyl-source-stream");
var tsify = require("tsify");
var paths = {
    pages: [
            "./app/**/*.html"],
    styles: ["./app/css/**/*.css",
             "./app/css/**/*.min.css"],
    lib: ["./app/lib/**/*.*",
         "./app/lib/**/*.min.*"],
    config: ["./app/scripts/system.config.js"],
};

gulp.task("copy-html", function () {
    return gulp.src(paths.pages)
        .pipe(minifyHtml())
        .pipe(gulp.dest("../CNCDataManager_Publish"));
});

gulp.task("copy-lib", function () {
    return gulp.src(paths.lib)
        .pipe(gulp.dest("../CNCDataManager_Publish/lib"));
});

gulp.task("copy-config", function () {
    return gulp.src(paths.config)
        .pipe(uglify({ mangle: false }))
        .pipe(gulp.dest("../CNCDataManager_Publish/scripts"))
}); 

gulp.task("css", function () {
    return gulp.src(paths.styles)
        .pipe(concat("app.css"))
        .pipe(minifyCss())
        .pipe(gulp.dest("../CNCDataManager_Publish/css"));
})

gulp.task("default", ["copy-html", "copy-lib", "css", "copy-config"], function () {
    return tsProject.src()
        .pipe(tsProject())
        .js
        .pipe(uglify({ mangle: false }))
        .pipe(gulp.dest("../CNCDataManager_Publish/scripts"));

});