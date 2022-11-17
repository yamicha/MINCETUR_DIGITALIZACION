var Aprobados_grilla = 'Aprobados_grilla';
var Aprobados_barra = 'Aprobados_barra';

$(document).ready(function () {
    //Aprobados_buscar();
});

jQuery('#aTabAprobados').click(function (e) {
    Aprobados_buscar();
});

function Aprobados_buscar() {
    Documento_ConfigurarGrilla(Aprobados_grilla ,Aprobados_barra ,"Listado de documentos aprobados", false, 7);
}