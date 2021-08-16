function saveBrandController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data
    $http.get('/api/Brand/' + $("#HdnBrandId").val()).success(function (data) {
        $scope.brand = data;
        $scope.loading = false;
    });

    //Used to save a record after edit
    $scope.save = function (isValid) {
        if (isValid) {
            $scope.loading = true;
            var brand = this.brand;
            //alert(emp);
            $http.put('/api/Brand/', brand).success(function (data) {
                $scope.loading = false;
            }).error(function(data) {
                $scope.error = "An Error has occured while Saving Brand! " + data;
                $scope.loading = false;

            });
        } else {
            $scope.showValidationMessages = true;
        }
    };
}


