function postListController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get('/api/Post/List/' + $("#HdnUserId").val()).success(function (data) {
        $scope.posts = data;
        $scope.loading = false;
    });

    $scope.deletePost = function (idPost) {
        $http.get('/api/Post/Delete/' + idPost).success(function () {
            $scope.loading = false;
            $scope.loadList();
        }).error(function (data) {
            alert(data.Message);
        });
    }

    $scope.loadList = function () {
        $http.get('/api/Post/List/' + $("#HdnUserId").val()).success(function (data) {
            if (data.length > 0) {
                $scope.posts = data;
                $scope.loading = false;
                
            }else
            {
                var url = "/posts/listPosts/";
                $(location).attr('href', url);
            }
        });
    }
}


