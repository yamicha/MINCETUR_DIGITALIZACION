var Aprobar_grilla = 'Aprobar_grilla';
var Aprobar_barra = 'Aprobar_barra';

$(document).ready(function () {
    Aprobar_buscar();
});

jQuery('#aTabAprobar').click(function (e) {
    Aprobar_buscar();
});

function Aprobar_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Aprobar_grilla + "," + Aprobar_barra + ",\"Listado de documentos digitalizados\", false, 6);", 500);
}

function Aprobar_Cerrar() {
    $('#myModal_Documento_Ver_Imagen').modal('hide');
    jQuery("#myModal_Documento_Ver_Imagen").html('');
}

function Aprobar_Evaluar() {
    var _CONFORME = $("#VALIDAR_ID_CONFORME").val();
    var pregunta = "";
    if (_CONFORME == "") {
        jAlert("Seleccione su validación", "Atención");
        return;
    }
    if (_CONFORME == "0") {
        pregunta = "darle 'NO CONFORME'";
        var VALIDAR_ID_TIPO_OBS = $("#VALIDAR_ID_TIPO_OBS").val();

        if (VALIDAR_ID_TIPO_OBS == "") {
            jAlert("Seleccione Tipo de Observación", "Atención");
            return;
        }
    } else {
        pregunta = "dar un 'CONFORME'";
    }
    jConfirm(" ¿ Desea " + pregunta + " al documento digitalizado ? ", "Atención", function (r) {
        if (r) {
            var Aprobar_ListaDocumentos = new Array();
            var ID_TIPO_OBS = 0;
            if ($("#VALIDAR_ID_TIPO_OBS").val() != "")
                ID_TIPO_OBS = parseInt($("#VALIDAR_ID_TIPO_OBS").val())
            var item = {
                FlgConforme: parseInt(_CONFORME),
                //COD_DOCUMENTO: $("#COD_DOCUMENTO").val(),
                Comentario: $("#VALIDAR_OBSERVACION").val(),
                IdTipoObservacion: ID_TIPO_OBS,
                IdDocumento: parseInt($("#hd_Documento_Validar_ID_DOCUMENTO").val()),
                IdDocumentoAsignado: parseInt($("#hd_Documento_Validar_ID_DOCUMENTO_ASIGNADO").val()),
                UsuCreacion: $('#inputHddId_Usuario').val()
            }
            //Aprobar_ListaDocumentos.push(itemx);
            //var item = {
            //    lista: Aprobar_ListaDocumentos
            //}
            var url = "archivo-central/digitalizacion/digitalizado-calidad-validar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            jOkas("Documento evaluado correctamente", "Atención");
                            Aprobar_Cerrar();
                        } else {
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                        Aprobar_buscar();
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

