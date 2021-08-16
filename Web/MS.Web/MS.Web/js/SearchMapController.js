
var app = angular.module('multipleCtrlApp', ['ui.bootstrap']);

app.controller('mapStoresController', function ($scope, $http) {
    $scope.currentPage = 1
  , $scope.numPerPage = 9
  , $scope.maxSize = 5;

    $scope.getStores = function(startItem, numItems) {

        var distrcits = [];
        $('#divDistricts input:checked').each(function() {
            distrcits.push($(this).attr('value'));
        });

        var categories = [];
        $('#divCategory input:checked').each(function() {
            categories.push($(this).attr('value'));
        });

        var labels = [];
        $('#divLabel input:checked').each(function () {
            labels.push($(this).attr('value'));
        });

        var filter = {
            IdLocation: $('#pLocationId').val(),
            LocationName: $('#pLocationName').val(),
            LanguageId: $('#pIdLanguage').val(),
            DistrictsList: distrcits,
            CategoryList: categories,
            LabelList: labels,
            StartItem: startItem,
            NumItems: numItems,
            Order: $("#pOrder").val()
        };

        UpdateQueryStringParameter("pLocationId", filter.IdLocation);
        UpdateQueryStringParameter("pLocationName", filter.LocationName);
        UpdateQueryStringParameter("pIdLanguage", filter.LanguageId);
        UpdateQueryStringParameter("pDistrictsList", filter.DistrictsList);
        UpdateQueryStringParameter("pCategoryList", filter.CategoryList);
        UpdateQueryStringParameter("pLabelList", filter.LabelList);

        $http.post('/api/Search/Map/', filter).success(function(data) {
            $scope.storeList = data;
            $scope.loadMap();
            $scope.loading = false;
        }).error(function(data) {
            alert(data.Message);
            $scope.loading = false;

        });
    };

    $scope.$watch('currentPage + numPerPage', function () {
        var startItem = (($scope.currentPage - 1) * $scope.numPerPage);
        $scope.getStores(startItem, $scope.numPerPage);
    });

    $scope.cleanFilters = function () {
        $('#searchForm input:checked').each(function () {
            $(this).attr('checked', false);
        });
    };

    $scope.changeOrder = function () {
        $("#pOrder").val($("#selectOrder option:selected").val());

        var startItem = (($scope.currentPage - 1) * $scope.numPerPage);
        $scope.getStores(startItem, $scope.numPerPage);
    };

    $scope.markers = [];

    var mapOptions = {
        zoom: 14,
        //center: new google.maps.LatLng($scope.storeList.CenterLatitude, $scope.storeList.CenterLongitude),
        center: new google.maps.LatLng(41.3850639, 2.1734034999999494),
        mapTypeId: google.maps.MapTypeId.TERRAIN
    }

    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

    $scope.loadMap = function () {
        clearMarkers();
        for (var i = 0; i < $scope.storeList.StoresPoints.length; i++) {
            createMarker($scope.storeList.StoresPoints[i], i);
        }

        $scope.openInfoWindow = function(e, selectedMarker) {
            e.preventDefault();
            google.maps.event.trigger(selectedMarker, 'click');
        };
    };

    var infoWindow = new google.maps.InfoWindow();

    var secondImage = {
        url: '/img/point.png',
        // This marker is 20 pixels wide by 32 pixels high.
        size: new google.maps.Size(20, 32),
        // The origin for this image is (0, 0).
        origin: new google.maps.Point(0, 0),
        // The anchor for this image is the base of the flagpole at (0, 32).
        anchor: new google.maps.Point(0, 32)
    };

    var principalImage = {
        url: '/img/marker.png',
        size: new google.maps.Size(20, 32),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(0, 32)
    };

    var createMarker = function(info, item) {
        var image;

        if (item >= $scope.storeList.StartItem && item <= $scope.storeList.StartItem + $scope.storeList.NumItems) {
            image = principalImage;
        } else {
            image = secondImage;
        }

        var marker = new google.maps.Marker({
            map: $scope.map,
            icon: image,
            position: new google.maps.LatLng(info.Latitude, info.Longitude),
            title: info.Name,
            zIndex: info.IdStore
        });
        marker.content = '<div class="infoWindowContent">' + info.desc + '</div>';

        google.maps.event.addListener(marker, 'click', function() {
            $http.get('/api/Search/Map/StoreInfo/' + marker.zIndex + '/' + $('#pIdLanguage').val()).success(function(data) {
                infoWindow.setContent('<h2><a href="' + data.Url + '">' + data.Name + '</a></h2>' + data.IdStore);
                infoWindow.open($scope.map, marker);
            });
        });

        $scope.markers.push(marker);

    };

    // Sets the map on all markers in the array.
    function setMapOnAll(map) {
        for (var i = 0; i < $scope.markers.length; i++) {
            $scope.markers[i].setMap(map);
        }
    }

    // Removes the markers from the map, but keeps them in the array.
    function clearMarkers() {
        setMapOnAll(null);
    }

});

function UpdateQueryStringParameter(key, value) {
    //actualiza url navegador
    var uri = window.location.href;
    var url = uri;
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";
    if (uri.match(re)) {
        if (value != "") {
            url = uri.replace(re, '$1' + key + "=" + value + '$2');
        } else {
            url = uri.replace(re, '');
        }
    }
    else {
        if (value != "") {
            url = uri + separator + key + "=" + value;
        }
    }

    window.history.pushState("", "", url);

    // url enlace busqueda mapa
    var uriSearchLink = $("#SearchToOtherViewLink").attr('href');
    var urlSearchLink = uriSearchLink;

    if (uriSearchLink.match(re)) {
        if (value != "") {
            urlSearchLink = uriSearchLink.replace(re, '$1' + key + "=" + value + '$2');
        } else {
            urlSearchLink = uriSearchLink.replace(re, '');
        }
    }
    else {
        if (value != "") {
            urlSearchLink = uriSearchLink + separator + key + "=" + value;
        }
    }

    $("#SearchToOtherViewLink").attr("href", urlSearchLink);
}

$("#DdlCities").change(function () {
    $("#pLocationName").val($("#DdlCities option:selected").text());
    $("#pLocationId").val($("#DdlCities option:selected").val());
});
