
function initialize(latitude, longitude) {
    var latlng = new google.maps.LatLng(latitude, longitude);
    var mapOptions = {
        center: latlng,
        zoom: 15,
        disableDefaultUI: true
    };

    var map = new google.maps.Map(document.getElementById('map-canvas'),
      mapOptions);

    var input = (document.getElementById('txtStreet'));
    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.setTypes(['address']);
    autocomplete.bindTo('bounds', map);
    
    var marker = new google.maps.Marker({
        position: latlng,
        map: map
    });

    google.maps.event.addListener(autocomplete, 'place_changed', function () {
        marker.setVisible(false);
        var place = autocomplete.getPlace();
        if (!place.geometry) {
            window.alert("Autocomplete's returned place contains no geometry");
            return;
        }

        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);  // Why 17? Because it looks good.
        }

        marker.setPosition(new google.maps.LatLng(place.geometry.location.lat(), place.geometry.location.lng()));
        marker.setVisible(true);

        $('#hdnLatitude').val(place.geometry.location.lat());
        $('#hdnLongitude').val(place.geometry.location.lng());
    });
}