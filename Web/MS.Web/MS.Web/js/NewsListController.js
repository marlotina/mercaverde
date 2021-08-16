var app = angular.module('multipleCtrlApp', ['ui.bootstrap']);

app.controller('newsListController', function ($scope, $http) {
    $scope.newsList = []
  , $scope.currentPage = 1
  , $scope.numPerPage = 10
  , $scope.maxSize = 5;

    $scope.loadList = function (startItem, numItems) {
        var filter = {
            LanguageId: $('#hdnIdLanguage').val(),
            StartItem: startItem,
            NumItems: numItems
        };

        $http.post('/api/News/List/', filter).success(function (data) {
            $scope.newsList = data;
            $scope.loading = false;
        }).error(function (data) {
            alert(data.Message);
            $scope.loading = false;

        });
    }

    $scope.$watch('currentPage + numPerPage', function () {
        var startItem = (($scope.currentPage - 1) * $scope.numPerPage);
        $scope.loadList(startItem, $scope.numPerPage);
    }); 
});