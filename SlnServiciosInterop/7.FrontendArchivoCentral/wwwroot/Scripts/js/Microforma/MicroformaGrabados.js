
var Microforma_grilla = 'Microforma_grilla';
var Microforma_barra = 'Microforma_barra';

var Microforma_Lote_grilla = 'Microforma_Lote_grilla';
var Microforma_Lote_barra = 'Microforma_Lote_barra';

/// tab2 

var MicroformaRepro_grilla = 'MicroformaRepro_grilla';
var MicroformaRepro_barra = 'MicroformaRepro_barra';

var MicroformaRepro_Lote_grilla = 'MicroformaRepro_Lote_grilla';
var MicroformaRepro_Lote_barra = 'MicroformaRepro_Lote_barra';

$(document).ready(function () {
    _MODULOMICRO = 0; 
    Microforma_ConfigurarGrilla(Microforma_Lote_grilla, Microforma_Lote_barra, Microforma_grilla, Microforma_barra);
    Microforma_ConfigurarGrilla(MicroformaRepro_Lote_grilla, MicroformaRepro_Lote_barra, MicroformaRepro_grilla, MicroformaRepro_barra);
    jQuery('#aTabMicroforma').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        _MODULOMICRO = 0; 
        Microforma_CargarGrilla(Microforma_Lote_grilla, 0);
        Documento_Detalle_buscar(Microforma_grilla, Microforma_barra);
    });

    jQuery('#aTabMicroReprocesar').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        _MODULOMICRO = 1; 
        Microforma_CargarGrilla(MicroformaRepro_Lote_grilla, EstadoMicroforma.Observado);
        Documento_Detalle_buscar(MicroformaRepro_grilla, MicroformaRepro_barra);
    });
});


/******************************* TAB REPROCESADOR ********************************/


function Microforma_Editar() {
    jConfirm(" ¿ Desea reprocesar esta microforma ? ", "Atención", function (r) {
        if (r) {
            var item = {
                IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                Fecha: $("#MICROFORMA_FECHA").val() ,
                Hora: $("#MICROFORMA_HORA").val(),
                CodigoSoporte: $("#MICROFORMA_CODIGO_SOPORTE").val(),
                IdSoporte: parseInt($("#MICROFORMA_ID_TIPO_SOPORTE").val()),
                NroActa: $("#MICROFORMA_ACTA").val(),
                NroCopias: $("#MICROFORMA_COPIAS").val(),
                CodigoFedatario: $("#MICROFORMA_CODIGO_FEDATARIO").val(),
                Observacion: $("#MICROFORMA_OBSERVACION").val(),
                UsuModificacion: $("#inputHddCod_usuario").val(),
            }
            var url = "archivo-central/microforma/editar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            Microforma_CargarGrilla(MicroformaRepro_Lote_grilla, EstadoMicroforma.Observado);
                            jOkas("Microforma reprocesada correctamente.", "Atención");
                            MicroformaGrabar_Cerrar();
                        } else {
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                } else {
                    jAlert("No se encontraron registros", "Atención");
                }
            });
        }
    });

}