var map;
var circle;
var infowindow; 

function geocodeLocations() {
    var setbounds = true;
    var bounds = new google.maps.LatLngBounds();

    if (locations.length > 0)
        map.setCenter(locations[locations.length-1]);
    try {
        var journeyPath = new google.maps.Polyline({
            path: locations,
            strokeColor: '#0000FF',
            strokeOpacity: 1.0,
            strokeWeight: 2,
            geodesic: true,
        });
        journeyPath.setMap(map);

        for (var i = 0; i < locations.length; i++) {
            var markerOptions = {
                icon: {
                    url: '/assets/img/drawingpin1_blue.png',
                    size: new google.maps.Size(32, 32),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(8, 29)
                },
                map: map,
                position: { lat: locations[i].lat, lng: locations[i].lng },
                title: locations[i].title,
				html: "<div class=\"infowindow\"><strong style=\"font-weight: bold;\">" + locations[i].title + "</strong><br />" + locations[i].shortdescription + "</div>"
            };

            var marker = new google.maps.Marker(markerOptions);

            marker.addListener('click', function () {
				infowindow.setContent(this.html);
                infowindow.open(map, this);
            });

            if (i > 0 || locations.length == 1) {
                bounds.extend(marker.getPosition());
            }
        }

        map.fitBounds(bounds);

    }
    catch (ex) {
        console.log(ex);
    }
}

function initialize() {
    geocoder = new google.maps.Geocoder();
    var mapOptions = {
        zoom: 3,
        center: new google.maps.LatLng(50, 20),
        mapTypeId: google.maps.MapTypeId.HYBRID,
        mapTypeControl: false,
        streetViewControl: false,
        zoomControl: true,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.SMALL
        }
    };

    map = new google.maps.Map(document.getElementById('travel-chart'), mapOptions);
    infowindow = new google.maps.InfoWindow({
		content: ""
	});

	
    geocodeLocations();
}


var timeout;
var width = isNaN(window.innerWidth) ? window.clientWidth : window.innerWidth;
window.onresize = function (event) {
	//console.log("orgw: " + width);
	//console.log("neww: " + (isNaN(window.innerWidth) ? window.clientWidth : window.innerWidth));
	if(width != (isNaN(window.innerWidth) ? window.clientWidth : window.innerWidth))
	{
		clearTimeout(timeout);
		timeout = setTimeout(initialize, 500);
	}
};