﻿var Aprobados_grilla = 'Aprobados_grilla';
var Aprobados_barra = 'Aprobados_barra';

$(document).ready(function () {
    //Aprobados_buscar();
});

jQuery('#aTabAprobados').click(function (e) {
    Aprobados_buscar();
});

function Aprobados_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla_CALIDAD(" + Aprobados_grilla + "," + Aprobados_barra + ",\"Listado de documentos aprobados\", false, 7);", 500);
}