var Reprocesados_grilla = 'Reprocesados_grilla';
var Reprocesados_barra = 'Reprocesados_barra';

$(document).ready(function () {

});

jQuery('#aTabReprocesados').click(function (e) {
    Reprocesados_buscar();
});

function Reprocesados_buscar() {
    //$("#Recepcion_busqueda").show();
    //setTimeout("Documento_ConfigurarGrilla(" + Reprocesados_grilla + "," + Reprocesados_barra + ",\"Listado de documentos reprocesados\", false, 9);", 500);
    DocumentoProceso_ConfigurarGrilla(Reprocesados_grilla, Reprocesados_barra, "Listado de documentos aprobados/Observados", 9);
}