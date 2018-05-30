/// <binding BeforeBuild='sass-compile, jquery-copy, bootstrap-copy' ProjectOpened='watch-sass' />
var gulp = require('gulp');
var sass = require('gulp-sass');
var rename = require('gulp-rename');

var paths = {
    wwwroot: './wwwroot/'
}

paths.css = paths.wwwroot + 'css/'
paths.js = paths.wwwroot + 'js/'

gulp.task('sass-compile', function () {
    gulp.src('./assets/sass/master.scss')
        .pipe(sass())
        .pipe(rename('styles.css'))
        .pipe(gulp.dest(paths.css));
});

gulp.task('jquery-copy', function () {
    gulp.src('./node_modules/jquery/dist/jquery.js')
        .pipe(gulp.dest(paths.js));
})

gulp.task('bootstrap-copy', function () {
    gulp.src('./node_modules/bootstrap/dist/js/bootstrap.js')
        .pipe(gulp.dest(paths.js));
    //gulp.src('./node_modules/bootstrap/dist/css/bootstrap.css')
    //    .pipe(gulp.dest(paths.css));
})

gulp.task('watch-sass', function () {
    gulp.watch('./Content/*.scss', ['sass-compile']);
});