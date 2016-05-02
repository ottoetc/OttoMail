var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');

var config = {
    src: ['app/**/*.js', '!app/**/*.min.js']
}

gulp.task('clean', function () {
    return del(['app/all.min.js']);
});

gulp.task('scripts', ['clean'], function () {
    return gulp.src(config.src)
        .pipe(uglify())
        .pipe(concat('all.min.js'))
        .pipe(gulp.dest('app/'));
});

gulp.task('default', ['scripts'], function () {
   
});