function savePostController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get('/api/Post/' + $("#HdnPostId").val()).success(function (data) {
        $scope.post = data;
        $scope.loading = false;
    });

    $scope.save = function (isValid) {
        if (isValid) {
            $scope.loading = true;
            var post = this.post;

            post.Text = tinyMCE.activeEditor.getContent();
            post.UserId = $("#HdnUserId").val();
            if (post.IsPublished && post.Text.length < 100) {
                $("#ReuiqredFiledTextLengthMsg").show();
            } else {
                $http.post('/api/Post/', post).success(function () {
                    $scope.loading = false;
                    showSucessSavePanel();
                }).error(function (data) {
                    alert(data.Message);
                    $scope.loading = false;
                });
            }
        } else {
            showReuiqredFiledPanel();
        }
    };
}


