var panorama;

function initializeMap() {
    var latlng = { lat: parseFloat($('#hdnLatitude').val()), lng: parseFloat($('#hdnLongitude').val()) };

    var map = new google.maps.Map(document.getElementById('map'), {
        center: latlng,
        zoom: 18,
        streetViewControl: false
    });

    var marker = new google.maps.Marker({
        position: latlng,
        map: map
        //icon: 

    });

    marker.setPosition(latlng);
    marker.setVisible(true);

    panorama = map.getStreetView();
    panorama.setPosition(latlng);
    panorama.setPov(({
        heading: 265,
        pitch: 0
    }));
}

function toggleStreetView() {
    var toggle = panorama.getVisible();
    if (toggle == false) {
        panorama.setVisible(true);
    } else {
        panorama.setVisible(false);
    }
}
