var app = angular.module('multipleCtrlApp', ['ui.bootstrap']);

app.controller('eventsListController', function ($scope, $http) {
    $scope.eventsList = [];

    $scope.loadList = function (date) {
        $http.post('/api/events/List/' + date).success(function (data) {
            $scope.eventsList = data;
            $scope.eventsInCalendar();
            $scope.loading = false;
        }).error(function (data) {
            alert(data.Message);
            $scope.loading = false;
        });
    }

    $scope.eventsInCalendar = function () {
        var listEvents = [];
        angular.forEach($scope.eventsList.ListEvents, function (item, key) {
            listEvents.push({
                title: item.Title,
                start: item.StartDate,
                end: item.EndDate,
                url: '/es/posts/postdetail?postId=2011'
            });
        });
        $('#datepicker').fullCalendar('removeEvents');
        $('#datepicker').fullCalendar('addEventSource', listEvents);
        $('#datepicker').fullCalendar('rerenderEvents');
    }

    $scope.loadDatepicker = (function () {

        $('#datepicker').fullCalendar({
            header: {
                left: '',
                center: 'title',
                right: ''
            },
            dayClick: function (date, jsEvent, view) {
                $(this).css('background-color', 'red');

            }
        });
    });

    $('#prevMonth').click(function () {
        $('#datepicker').fullCalendar('prev');
        var date = $('#datepicker').fullCalendar('getDate');
        $scope.loadList(date.format('YYYY-MM-D'));
    });

    $('#nextMonth').click(function () {
        $('#datepicker').fullCalendar('next');
        var date = $('#datepicker').fullCalendar('getDate');
        $scope.loadList(date.format('YYYY-MM-D'));
    });

    var fullDate = new Date();
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "-" + twoDigitMonth + "-" + fullDate.getFullYear();
    $scope.loadDatepicker();
    $scope.loadList(currentDate);
});

