var app = app || {};
app.Layout = (function () {
    'use strict';

    var themeButton;

    var setTheme = function (theme) {

        var themeClass = "theme-" + theme;
        $("body").attr('class', '');
        $("body").addClass(themeClass);
    };

    var bindEvents = function() {
        themeButton.on('click', function() {
            var themeClass = $("body").attr('class');
            var theme;
            if (themeClass === 'theme-light') {
                theme = 'dark';
            } else {
                theme = 'light';
            }
            setTheme(theme);
            $.cookie('theme', theme, { expires: 365 });
        });
    };

    var init = function () {
        //$.removeCookie('theme');
        themeButton = $("#themeButton");

        var themeCookie = $.cookie('theme');
        if (themeCookie) {
            setTheme(themeCookie);
        }

        bindEvents();

    };

    return {
        init: init
    };
})();

$(function () {
    app.Layout.init();
});
