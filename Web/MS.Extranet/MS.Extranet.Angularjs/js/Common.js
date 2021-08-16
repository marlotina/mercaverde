function showSucessSavePanel() {
    $("#AlertSaveOk").show();
    $('#AlertSaveOk').delay(1000).fadeOut();
    GoUpTop();
}

function showReuiqredFiledPanel() {
    $("#ReuiqredFiledPanel").show();
    $('#ReuiqredFiledPanel').delay(2000).fadeOut();
    GoUpTop();
}

function GoUpTop() {
    var body = $("html, body");
    body.stop().animate({ scrollTop: 0 }, '500', 'swing');
}

angular.module('app', [])
.directive('preventEnterSubmit', function () {
    return function (scope, el, attrs) {
        el.bind('keydown', function (event) {
            if (13 == event.which) {
                event.preventDefault(); // Doesn't work at all
                window.stop(); // Works in all browsers but IE...
                document.execCommand('Stop'); // Works in IE
                return false; // Don't even know why it's here. Does nothing.
            }
        });
    };
});
