var app = angular.module('multipleCtrlApp', []);

app.controller('userController', function ($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get('/api/User/' + $("#HdnUserId").val()).success(function (data) {
        $scope.user = data;
        $scope.loading = false;
    });

    $scope.post = function (isValid) {
        if (isValid) {
            $scope.loading = true;
            var user = this.user;

            $http.post('/api/User/', user).success(function () {
                showSucessSavePanel();
            }).error(function (data) {
                alert(data.Message);
                $scope.loading = false;

            });
        } else {
            showReuiqredFiledPanel();
        }
    };

    $scope.ressetPassword = function (isValid) {
        if (isValid) {
            $scope.loading = true;

            var changePasswordItem = new Object();
            changePasswordItem.IdUser = $('#HdnUserId').val();
            changePasswordItem.Password = $('#actualPassword').val();
            changePasswordItem.NewPassword = $('#pw1').val();

            $http.post('/api/User/ResetPassword/', changePasswordItem).success(function (data) {
                $scope.loading = false;
                if (data != null) {
                    $('#pw1').val("");
                    $('#pw2').val("");
                    $('#actualPassword').val("");
                    $("#ReuiqredFiledPasswordNotValidMsg").hide();
                    $("#SaveNewPassOk").show();
                    $('#SaveNewPassOk').delay(1000).fadeOut();
                }
            }).error(function (data, status) {
                $scope.loading = false;
                if (status == '412') {
                    $("#ReuiqredFiledPasswordNotValidMsg").show();
                }

                $('#pw1').val("");
                $('#pw2').val("");
                $('#actualPassword').val("");
            });
        } else {
            $("#ReuiqredFiledRecoverPasswordMsg").show();
        }
    };

    $scope.deleteImage = function (userId) {
        $http.get('/api/User/DeleteImage/' + userId + "?dlt=1").success(function () {
            $scope.loading = false;
            $("#imgUser").attr("src", "/Images/DefaultProfile.jpg?" + new Date());
            $("#ImgUserProfile").attr("src", "/Images/DefaultProfile.jpg?" + new Date());
        }).error(function (data) {
            alert(data.Message);
        });
    }
});

app.directive('pwCheck', [function () {
      return {
          require: 'ngModel',
          link: function (scope, elem, attrs, ctrl) {
              var firstPassword = '#' + attrs.pwCheck;
              elem.add(firstPassword).on('keyup', function () {
                  scope.$apply(function () {
                      var v = elem.val() === $(firstPassword).val();
                      ctrl.$setValidity('pwmatch', v);
                  });
              });
          }
      }
  }]);




