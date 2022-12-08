var Digitalizados_grilla = 'Digitalizados_grilla';
var Digitalizados_barra = 'Digitalizados_barra';

$(document).ready(function () {
    clearInterval(Digitalizar_Int_Documento);
});

jQuery('#aTabDigitalizados').click(function (e) {
    clearInterval(Digitalizar_Int_Documento);
    Digitalizados_buscar();
});

function Digitalizados_buscar() {
    DocumentoProceso_ConfigurarGrilla(Digitalizados_grilla , Digitalizados_barra ,"Listado de documentos digitalizados",5);
}