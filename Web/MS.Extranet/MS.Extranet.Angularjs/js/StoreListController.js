function storeListController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get('/api/Store/List/' + $("#HdnUserId").val()).success(function (data) {
        $scope.stores = data;
        $scope.loading = false;
    });

    $scope.deleteStore = function (idStore) {
        $http.get('/api/Store/Delete/' + idStore).success(function () {
            $scope.loading = false;
            $scope.loadList();
        }).error(function (data) {
            alert(data.Message);
        });
    }

    $scope.loadList = function () {
        $http.get('/api/Store/List/' + $("#HdnUserId").val()).success(function (data) {
            if (data.length > 0) {
                $scope.stores = data;
                $scope.loading = false;
            } else {
                var url = "/stores/listStores/";
                $(location).attr('href', url);
            }
        });
    }
}