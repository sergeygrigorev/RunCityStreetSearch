ymaps.ready(init);
var map;
var marks = [];
var coords = {
	center: [59.936033, 30.320965],
	//center: [59.57, 30.20],
	zoom: 10
};

function init(){
	var str = document.location.search;
	var regex = /([^?=&]+)=([^?=&]*)/g;
	var params = {};
	var arr;
	while((arr = regex.exec(str)) !== null){
		params[arr[1]] = arr[2];
	}
	document.getElementById("map").style.width = params.w + "px";
	document.getElementById("map").style.height = params.h + "px";
	if (params.s){
		var geo = ymaps.geocode(params.s);
		geo.then(geoRes,geoErr);
	}
	else initMap();
}

function geoRes(res){
	initMap(res.geoObjects.get(0).geometry.getBounds());
}

function geoErr(err){
	initMap();
}

function initMap(bounds){
	map = new ymaps.Map ("map", {
		center: coords.center,
		zoom: coords.zoom,
		bounds: bounds,
		behaviors: ["default", "scrollZoom"]
	});
	if (map.getZoom() > 16)
		map.setZoom(16);
	coords.center = map.getCenter();
	coords.zoom = map.getZoom();
	saveData();
	map.events.add('click', addMark);
}

function addMark(event){
	var position = event.get('coordPosition');
	var pm = new ymaps.Placemark(position);
	map.geoObjects.add(pm);
	marks.push(pm);
	saveData();
}

function saveData(){
	var s = "";
	var i;
	
	for(i=0;i<marks.length;i++)
		s += "[" + marks[i].geometry.getCoordinates() + "]";
	
	
	
	document.title = s;
}






















