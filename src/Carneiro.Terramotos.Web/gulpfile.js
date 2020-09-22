"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    htmlmin = require("gulp-htmlmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream"),
    del = require("del"),
    sass = require("gulp-sass"),
    bundleconfig = require("./bundleconfig.json");

var paths = {
    scss: 'wwwroot/scss/',
    flags: 'wwwroot/flags/',
    fonts: 'wwwroot/webfonts/',
    css: 'wwwroot/css/'
};

var flags = [
    "node_modules/flag-icon-css/flags/**/*"
];

var fonts = [
    "node_modules/@fortawesome/fontawesome-free/webfonts/**/*"
];

var regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

gulp.task('vscode-codicons', function () {
    return gulp.src(["node_modules/vscode-codicons/dist/*.ttf"])
        .pipe(gulp.dest(paths.css));
});

gulp.task('flags', function () {
    return gulp.src(flags)
        .pipe(gulp.dest(paths.flags));
});

gulp.task('fonts', function () {
    return gulp.src(fonts)
        .pipe(gulp.dest(paths.fonts));
});

gulp.task("sass", function () {
    return gulp.src(paths.scss + '**/*.scss', ['!_variables.scss'])
        .pipe(sass())
        .pipe(gulp.dest(paths.css));
});

gulp.task("min:js", function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:css", function () {
    var tasks = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:html", function () {
    var tasks = getBundles(regex.html).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(htmlmin({ collapseWhitespace: true, minifyCSS: true, minifyJS: true }))
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("clean", function () {
    var files = bundleconfig.map(function (bundle) {
        return bundle.outputFileName;
    });

    return del(files);
});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}

gulp.task("default", gulp.series("clean", gulp.parallel("vscode-codicons", "min:js", gulp.series("sass", "min:css"))));
gulp.task("styles", gulp.series("sass", "min:css"));