var Fedatados_grilla = 'Fedatados_grilla';
var Fedatados_barra = 'Fedatados_barra';

$(document).ready(function () {
    //Fedatados_buscar();
    jQuery('#aTabFedatados').click(function (e) {
        Fedatados_buscar();
    });
});

function Fedatados_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Fedatados_grilla + "," + Fedatados_barra + ",\"Listado de documentos fedatados\", false, 11);", 500);
}