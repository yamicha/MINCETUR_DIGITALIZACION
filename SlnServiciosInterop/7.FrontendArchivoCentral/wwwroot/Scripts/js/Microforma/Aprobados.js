var Aprobados_grilla = 'Aprobados_grilla';
var Aprobados_barra = 'Aprobados_barra';

$(document).ready(function () {
    //Aprobados_buscar();
});

jQuery('#aTabAprobados').click(function (e) {
    Aprobados_buscar();
});

function Aprobados_buscar() {
    DocumentoProceso_ConfigurarGrilla(Aprobados_grilla, Aprobados_barra, "Listado de documentos aprobados/Observados", 7);
}