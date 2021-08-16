var app = angular.module('multipleCtrlApp', ['ui.bootstrap']);

app.controller('postsListController', function ($scope, $http) {
    $scope.postsList = []
  , $scope.currentPage = 1
  , $scope.numPerPage = 10
  , $scope.maxSize = 5;

    $scope.loadList = function (startItem, numItems) {
        var filter = {
            LanguageId: $('#hdnIdLanguage').val(),
            StartItem: startItem,
            NumItems: numItems
        };

        $http.post('/api/posts/List/', filter).success(function (data) {
            $scope.postsList = data;
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

    $scope.to_trusted = function (html_code) {
        return $sce.trustAsHtml(html_code);
    }
});