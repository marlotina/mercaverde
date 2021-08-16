function brandListController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data
    $http.get('/api/Brand/List/1').success(function (data) {
        $scope.brands = data;
        $scope.loading = false;
    });
}


