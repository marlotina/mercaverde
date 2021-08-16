angular.module('multipleCtrlApp', [])
    .controller('suggestingController', ['$scope', '$http', function ($scope, $http) {
        $scope.submit = function (isValid) {
            if (isValid) {
                $scope.loading = true;
                var suggesting = {
                    text: $("#TxtText").val(),
                    UserId: $("#HdnUserId").val(),
                    Subject: $("#TxtSubject").val()
                }

                $http.post('/api/User/Contact/', suggesting).success(function() {
                    $scope.loading = false;
                    showSucessSavePanel();
                }).error(function(data) {
                    alert(data.Message);
                    $scope.loading = false;
                });
            } else {
                showReuiqredFiledPanel();
            } 
        };
    }]);




