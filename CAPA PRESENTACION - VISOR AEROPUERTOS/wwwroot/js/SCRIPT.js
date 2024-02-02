var OSM = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
    maxZoom: 18
});
GoogleRoads = L.tileLayer('https://{s}.google.com/vt/lyrs=h&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
GoogleStandarRoadMap = L.tileLayer('https://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
GoogleTerrain = L.tileLayer('https://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
GoogleAlteredRoadMap = L.tileLayer('https://{s}.google.com/vt/lyrs=r&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
GoogleSatelite = L.tileLayer('https://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
GoogleTerrainOnly = L.tileLayer('https://{s}.google.com/vt/lyrs=t&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
GoogleHybrid = L.tileLayer('https://{s}.google.com/vt/lyrs=y&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});
var Mapa = L.map('Mapa', {
    center: [4.891755551493253, -74.09641176500115],
    layers: [OSM, GoogleRoads, GoogleStandarRoadMap, GoogleTerrain, GoogleAlteredRoadMap, GoogleSatelite, GoogleTerrainOnly, GoogleHybrid],
    zoom: 5
});
L.control.scale().addTo(Mapa);
var title = L.control();
title.onAdd = function (Mapa) {
    var div = L.DomUtil.create('div', 'info');
    div.innerHTML += '<h1>AEROPUERTOS DEL MUNDO</h1>'; return div;
};
title.addTo(Mapa);

var Paises = L.tileLayer.wms("http://localhost:8085/geoserver/wms", {
    layers: 'PAIS',
    format: 'image/png',
    transparent: true,
    tiled: true,
}).addTo(Mapa);
var CAPAS_BASES = [
    {
        groupName: "OSM",
        layers: {
            "OPEN STREET MAPS": OSM
        }
    },
    {
        groupName: "GOOGLE",
        layers: {
            "SOLO CARRETERAS": GoogleRoads,
            "CARRETRAS ESTANDAR": GoogleStandarRoadMap,
            "TERRENOS": GoogleTerrain,
            "CARRETRAS MODIFICADO": GoogleAlteredRoadMap,
            "SATELITE": GoogleSatelite,
            "SOLO TERRENOS": GoogleTerrainOnly,
            "HÍBRIDO": GoogleHybrid,
        }
    }
];
var VECTORIALES = [
    {
        groupName: "VECTORIALES",
        layers: {
            "PAISES": Paises
        }
    }
];
var ESTILOS = {
    container_width: "400px",
    container_maxHeight: "550px",
    group_maxHeight: "150px",
    exclusive: false
};
ControlDeCapas = L.Control.styledLayerControl(CAPAS_BASES, VECTORIALES, ESTILOS);
Mapa.addControl(ControlDeCapas);
var OSM_MINI = L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: 'Map data &copy; OpenStreetMap contributors',
    minZoom: 0,
    maxZoom: 13
});
var MiniMapa = new L.Control.MiniMap(OSM_MINI, { toggleDisplay: true }).addTo(Mapa);
const URLGeoServer = 'http://localhost:8085/geoserver/ows';
var ParametrosCapaAeropuertos = {
    service: 'WFS',
    version: '1.0.0',
    request: 'GetFeature',
    typeName: 'AEROPUERTOS:AEROPUERTO',
    outputFormat: 'application/json'
};
var ParametrosAeropuertos = L.Util.extend(ParametrosCapaAeropuertos);
var LinkAeropuertos = URLGeoServer + L.Util.getParamString(ParametrosAeropuertos);
function EstiloAeropuerto(feature, latlng) {
    var SVG_Aeropuerto = '<svg id="IconoAeropuerto" xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-plane-tilt" width="32" height="32" viewBox="0 0 24 24" stroke-width="1.5" stroke="#000000" fill="#00bfd8" stroke-linecap="round" stroke-linejoin="round">'
        + '<path stroke="none" d="M0 0h24v24H0z" fill="none" />'
        + '<path d="M14.5 6.5l3 -2.9a2.05 2.05 0 0 1 2.9 2.9l-2.9 3l2.5 7.5l-2.5 2.55l-3.5 -6.55l-3 3v3l-2 2l-1.5 -4.5l-4.5 -1.5l2 -2h3l3 -3l-6.5 -3.5l2.5 -2.5l7.5 2.5z" />'
        + '</svg>';
    return L.marker(latlng, { icon: L.divIcon({ html: SVG_Aeropuerto, className: 'Icon' }) });
}
$.ajax({
    url: LinkAeropuertos,
    success: function (data) {
        function Eventos(feature, layer) {
            layer.on({
                click: function () {
                    document.getElementById('IdAeropuertoSalida').value = feature.properties.ID_AEROPUERTO;
                    console.log(feature.properties.ID_AEROPUERTO);
                    console.log("----------");
                    var DivFotoAeropuertoSalida = document.getElementById("DivFotoAeropuertoSalida");
                    var FotoAeropuerto = document.createElement("img");
                    FotoAeropuerto.src = feature.properties.FOTO;
                    FotoAeropuerto.id = "FotoAeropuertoSalida";
                    FotoAeropuerto.style.width = "100%";
                    FotoAeropuerto.style.height = "100%";
                    DivFotoAeropuertoSalida.appendChild(FotoAeropuerto);
                    var PaisAeropuerto = document.getElementById("PaisAeropuertoSalida");
                    PaisAeropuerto.innerText = "PAÍS: " + feature.properties.PAIS;
                    var CiudadAeropuerto = document.getElementById("CiudadAeropuertoSalida");
                    CiudadAeropuerto.innerText = "CIUDAD: " + feature.properties.CIUDAD;
                    var NombreAeropuerto = document.getElementById("NombreAeropuertoSalida");
                    NombreAeropuerto.innerText = "NOMBRE: " + feature.properties.NOMBRE;
                    var Formulario = document.getElementById("DivFormulario");
                    Formulario.style.display = "flex";
                    Formulario.style.flexDirection = "column";
                    Formulario.style.justifyContent = "space-evenly";
                    Formulario.style.alignItems = "center";
                }
            })
        };
        var Capa_Aeropuertos = new L.geoJson(data, { onEachFeature: Eventos, pointToLayer: EstiloAeropuerto });
        var AeropuertosCluster = L.markerClusterGroup();
        var Buscar = new L.Control.Search({
            layer: AeropuertosCluster,
            propertyName: 'NOMBRE',
            marker: false,
            moveToLocation: function (latlng, title, Mapa) {
                Mapa.setView(latlng, 14);
            }
        });
        AeropuertosCluster.addLayer(Capa_Aeropuertos);
        ControlDeCapas.addOverlay(AeropuertosCluster, "AEROPUERTOS", { groupName: "VECTORIALES", expanded: false });
        Mapa.addControl(Buscar);
    }
});

var legend = L.control({ position: 'bottomleft' });
legend.onAdd = function (map) {
    var div = L.DomUtil.create('div', 'Leyenda');
    div.innerHTML += '<svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-plane-tilt" width="60" height="60" viewBox="0 0 24 24" stroke-width="1.5" stroke="#000000" fill="#00bfd8" stroke-linecap="round" stroke-linejoin="round">'
        + '<path stroke="none" d="M0 0h24v24H0z" fill="none" />'
        + '<path d="M14.5 6.5l3 -2.9a2.05 2.05 0 0 1 2.9 2.9l-2.9 3l2.5 7.5l-2.5 2.55l-3.5 -6.55l-3 3v3l-2 2l-1.5 -4.5l-4.5 -1.5l2 -2h3l3 -3l-6.5 -3.5l2.5 -2.5l7.5 2.5z" />'
        + '</svg><span>AEROPUERTOS</span>';
    return div;
};
legend.addTo(Mapa);

function TraerCiudadesLleada() {
    var Pais = document.getElementById("PaisLlegada").value;
    var PaisAeropuerto = document.getElementById("PaisAeropuertoLlegada");
    PaisAeropuerto.innerText = "PAÍS: " + Pais;
    $.getJSON("/Aeropuerto/TraerCiudades", { Pais: Pais }, function (data) {
        var ListaCiudades = document.getElementById("CiudadLlegada");
        ListaCiudades.innerHTML = "";
        var OpcionNull = document.createElement("option");
        OpcionNull.value = 0;
        OpcionNull.text = "SELECCIONAR CIUDAD";
        OpcionNull.selected = true;
        OpcionNull.disabled = true;
        ListaCiudades.add(OpcionNull);
        data.forEach(function (Ciudad) {
            var option = document.createElement("option");
            option.value = Ciudad;
            option.text = Ciudad;
            ListaCiudades.add(option);
        });
    });
}
function TraerAeropuertosLleada() {
    var Ciudad = document.getElementById("CiudadLlegada").value;
    var CiudadAeropuerto = document.getElementById("CiudadAeropuertoLlegada");
    CiudadAeropuerto.innerText = "CIUDAD: " + Ciudad;
    $.getJSON("/Aeropuerto/TraerAeropuertos", { Ciudad: Ciudad }, function (data) {
        var ListaAeropuertos = document.getElementById("AeropuertoLlegada");
        ListaAeropuertos.innerHTML = "";
        var OpcionNull = document.createElement("option");
        OpcionNull.value = 0;
        OpcionNull.text = "SELECCIONAR AEROPUERTO";
        OpcionNull.selected = true;
        OpcionNull.disabled = true;
        ListaAeropuertos.add(OpcionNull);
        data.forEach(function (Aeropuerto) {
            var option = document.createElement("option");
            option.value = Aeropuerto.id;
            option.text = Aeropuerto.nombre;
            ListaAeropuertos.add(option);
        });
    });
}
function TraerFoto() {
    var Aeropuerto = document.getElementById("AeropuertoLlegada").value;
    var Opcion = document.getElementById("AeropuertoLlegada");
    $.getJSON("/Aeropuerto/TraerFoto", { Aeropuerto: Aeropuerto }, function (data) {
        var DivFotoAeropuertoLlegada = document.getElementById("DivFotoAeropuertoLlegada");
        if (document.getElementById("ImagenAeropuertoLlegada")) {
            DivFotoAeropuertoLlegada.removeChild(document.getElementById("ImagenAeropuertoLlegada"));
        }
        var FotoAeropuerto = document.createElement("img");
        FotoAeropuerto.id = "ImagenAeropuertoLlegada"
        FotoAeropuerto.src = data;
        FotoAeropuerto.style.width = "100%";
        FotoAeropuerto.style.height = "100%";
        DivFotoAeropuertoLlegada.appendChild(FotoAeropuerto);
        var NombreAeropuerto = document.getElementById("NombreAeropuertoLlegada");
        NombreAeropuerto.innerText = "NOMBRE: " + Opcion.options[Opcion.selectedIndex].text;
    });
}
function CerrarFormulario() {
    var Formulario = document.getElementById("DivFormulario");
    Formulario.style.display = "none";
    var DivFotoAeropuertoSalida = document.getElementById("DivFotoAeropuertoSalida");
    if (document.getElementById("FotoAeropuertoSalida")) {
        DivFotoAeropuertoSalida.removeChild(document.getElementById("FotoAeropuertoSalida"));
    }
}


function AbrirReporte() {
    var hrefValor = "/Principal/Reporte";
    window.open(hrefValor, '_blank');
}