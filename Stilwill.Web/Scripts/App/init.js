var app = (function () {
    'use strict';
    var self = this;

    var _basePath;
    var _controllerPath;

    var basePath = function (newPath) {
        if (newPath) {
            _basePath = newPath;
        }
        return _basePath;
    };

    var controllerPath = function (newPath) {
        if (newPath) {
            _controllerPath = newPath;
        }
        return _controllerPath;
    };

    var eventHandlers = {};

    var success = function (text) {
        toastr.success(text);
    };

    var error = function (text) {
        toastr.error(text);
    };

    var confirm = function (message, callback) {
        toastr.clear();
        bootbox.confirm(message, callback);
    };


    var pageLoad = function () {
        //$('.date-time-picker').datetimepicker({ pickTime: false });

        var successMessage = $("#Message").val();

        if (successMessage !== null && successMessage !== "") {
            success(successMessage);
        }
    };

    var dialog = function (content, title) {
        var options = {
            message: content,
            title: title || "",
            buttons: null
        };
        bootbox.dialog(options);
    };

    var actiondialog = function (url, args, title) {

        return $.ajax({
            type: "GET",
            data: args,
            dataType: 'html',
            async: false,
            cache: false,
            url: url
        }).done(function (result) {
            var options = {
                message: result,
                title: title || "",
                buttons: null,
                className: "large-dialog"
            };
            bootbox.dialog(options);
        });
    };

    var registerEvents = function () {

        $.EventBus = function (topic) {
            var callbacks;
            var eventHandler = topic && eventHandlers[topic];

            if (!eventHandler) {
                callbacks = $.Callbacks('unique');
                eventHandler = {
                    publish: callbacks.fire,
                    subscribe: callbacks.add,
                    unsubscribe: callbacks.remove,
                    empty: callbacks.empty,
                    has: callbacks.has
                };
                if (topic) {
                    eventHandlers[topic] = eventHandler;
                }
            }
            return eventHandler;
        };
    };

    var init = function () {

        registerEvents();

        toastr.options = {
            positionClass: 'toast-top-center',
            fadeOut: 10
        };

        pageLoad();
    };

    return {
        init: init,
        basePath: basePath,
        controllerPath: controllerPath,
        success: success,
        error: error,
        confirm: confirm,
        dialog: dialog,
        actiondialog: actiondialog
    };
})();

$(function () {
    app.init();
});

//
//    var ajax = function (options) {
//        var settings = $.extend({
//            beforeSend: $.noop,
//            fail: $.noop,
//            validationFail: $.noop,
//            done: $.noop,
//            always: $.noop,
//            contentType: "application/json",
//            data: {},
//            type: "POST",
//            url: "",
//            showMask: true,
//            showMaskFunction: rateCard.mask.show,
//            async: true,
//            cache: true,
//            traditional: false
//        }, options);
//
//        return $.ajax({
//            beforeSend: function (jqXHR, ajaxSettings) {
//                if (settings.showMask) {
//                    settings.showMaskFunction();
//                }
//                settings.beforeSend(jqXHR, ajaxSettings);
//            },
//            contentType: settings.contentType,
//            data: settings.data,
//            type: settings.type,
//            url: settings.url,
//            async: settings.async,
//            traditional: settings.traditional
//        }).fail(function (jqXHR, textStatus, errorThrown) {
//            var replaceNewLines = function (input) {
//                return input.replace(/(\r\n|\n|\r)/g, '<br />');
//            };
//            var message = jqXHR.responseText !== '' ? JSON.parse(jqXHR.responseText) : {Message: jqXHR.statusText, Title: 'Error ' + jqXHR.status.toString()};
//            var $toast;
//            var errorToast = function () {
//                $toast = toastr.error(replaceNewLines(message.Message), message.Title);
//            };
//            var warningToast = function () {
//                $toast = toastr.warning(replaceNewLines(message.Message), message.Title);
//            };
//            var actions = {
//                '500': errorToast, // System Error - do NOT delete this fella
//                '503': errorToast, // Service Unavailable
//                '403': errorToast, // Authorization
//                '404': warningToast, // Not Found
//                '409': errorToast, // Conflict
//                '400': function () { // Validation errors are returned with a 400 code, just delegate to the callers
//                    settings.validationFail(jqXHR, textStatus, errorThrown);
//                }
//            };
//
//            if (actions[jqXHR.status]) {
//                actions[jqXHR.status]();
//            } else {
//                errorToast();
//            }
//
//            if ($toast) {
//                $toast
//                    .on('click', '.ad-exception-details-toggle', function (e) {
//                        var $stackTrace = $toast.find('.ad-exception-stack-trace');
//
//                        if ($stackTrace.is(':visible')) {
//                            $stackTrace.hide();
//                        } else {
//                            $stackTrace.show();
//                        }
//
//                        e.stopPropagation();
//                    }).on('click', '.ad-exception-stack-trace', function (e) {
//                        e.stopPropagation();
//                    });
//            }
//            settings.fail(jqXHR, textStatus, errorThrown);
//        })
//            .done(function (data, textStatus, jqXHR) {
//                settings.done(data, textStatus, jqXHR);
//            })
//            .always(function ( jqXHR, ajaxSettings) {
//                settings.always(jqXHR, ajaxSettings);
//            });
//    };