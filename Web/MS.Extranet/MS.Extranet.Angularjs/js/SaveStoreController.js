
var app = angular.module('multipleCtrlApp', []);

app.controller('saveStoreController', function ($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;
    
    $http.get('/api/Store/' + $("#HdnStoreId").val()).success(function (data) {
        $scope.store = data;
        $scope.loading = false;
        var latitude = data.Latitude;
        var longitude = data.Longitude;

        initialize(latitude, longitude);
    });

    $scope.save = function (isValid) {
        if (isValid) {
            $scope.loading = true;
            var store = this.store;
            store.Street = $('#txtStreet').val();
            store.Latitude = $('#hdnLatitude').val();
            store.Longitude = $('#hdnLongitude').val();
            store.UserId = $("#HdnUserId").val();
            $http.post('/api/Store/Save', store).success(function (data) {
                $scope.loading = false;
                if (store.IdStore == 0) {
                    var url = "/Stores/SaveStore?StoreId=" + data;
                    $(location).attr('href', url);
                } else {
                    showSucessSavePanel();
                }
            }).error(function(data) {
                alert(data.Message);
                $scope.loading = false;

            });
        } else {
            showReuiqredFiledPanel();
        }
    };

    
});

app.controller('saveStoreDescriptionController', function($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get('/api/Store/Description/' + $("#HdnStoreId").val()).success(function (data) {
        $scope.storeDescriptions = data;
        $scope.loading = false;
    });

    $scope.save = function () {
        $scope.loading = true;
        var storeDescriptions = this.storeDescriptions;
            
        $http.post('/api/Store/Description/Save', storeDescriptions).success(function () {
            $scope.loading = false;
            showSucessSavePanel();
        }).error(function (data) {
            alert(data.Message);
            $scope.loading = false;

        });
    };
});

app.controller('saveStoreImagesController', function ($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;
    
    $http.get('/api/Store/Image/' + $("#HdnStoreId").val()).success(function (data) {
        $scope.storeImages = data;
        $scope.loading = false;
    });

    $scope.save = function (isValid) {
        if (isValid) {
            $scope.loading = true;
            var storeImages = this.storeImages;
            
            $http.put('/api/Store/Image/', storeImages).success(function () {
                $scope.loading = false;

            }).error(function (data) {
                alert(data.Message);
            });
        } else {
            $scope.showValidationMessages = true;
        }
    };

    $scope.getImages = function () {
        $http.get('/api/Store/Image/' + $("#HdnStoreId").val()).success(function (data) {
            $scope.storeImages = data;
            $scope.loading = false;
        });
    }

    $scope.deleteImage = function (idStoreImage) {
        $http.get('/api/Store/DeleteImage/' + idStoreImage).success(function () {
            $scope.loading = false;
            $scope.getImages();
        }).error(function (data) {
            alert(data.Message);
        });
    }

    $scope.saveOrderImage = function () {
        var imagesOrderArray = [];
        $("#sortable li").each(function (indice, elemento) {
            imagesOrderArray[indice] = $(elemento).attr("id");
        });

        var url = "/api/Store/SaveImagesOrder?storeId= " + $("#HdnStoreId").val() + "&storeImagesOrderList=" + imagesOrderArray.join();
        $http.get(url).success(function () {
            $scope.loading = false;
            showSucessSavePanel();
        }).error(function (data) {
            alert(data.Message);
            $scope.loading = false;

        });
    }
});

app.controller('saveStoreClassificationController', function ($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    var url = '/api/Store/CLassification/' + $("#HdnStoreId").val() + '/' + $("#HdnLanguageId").val();
    $http.get(url).success(function (data) {
        $scope.storeCLassification = data;
        $scope.loading = false;
    });

    $scope.save = function () {
        $scope.loading = true;
        var storeCLassification = this.storeCLassification;

        storeCLassification.StoreId = $("#HdnStoreId").val();
        $http.post('/api/Store/CLassification/Save', storeCLassification).success(function () {
            $scope.loading = false;
            showSucessSavePanel();
        }).error(function (data) {
            alert(data.Message);
            $scope.loading = false;

        });
    };
});

app.controller('saveStorePublishController', function ($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    var url = '/api/Store/Publish/' + $("#HdnStoreId").val() + '/' + $("#HdnLanguageId").val();
    $http.get(url).success(function (data) {
        $scope.storePublish = data;
        $scope.loading = false;
    });

    $scope.save = function () {
        $scope.loading = true;
        var storePublish = this.storePublish;
        storePublish.StoreId = $("#HdnStoreId").val();

        $http.post('/api/Store/Publish/Save', storePublish).success(function () {
            $scope.loading = false;
            showSucessSavePanel();
        }).error(function (data) {
            alert(data.Message);
            $scope.loading = false;
        });
    };
});

