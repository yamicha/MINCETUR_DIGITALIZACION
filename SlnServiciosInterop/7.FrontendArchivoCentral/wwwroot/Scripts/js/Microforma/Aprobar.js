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
            var itemx = { 
                FLG_CONFORME: _CONFORME,
                COD_DOCUMENTO: $("#COD_DOCUMENTO").val(),
                OBSERVACION: $("#VALIDAR_OBSERVACION").val(),
                ID_TIPO_OBSERVACION: $("#VALIDAR_ID_TIPO_OBS").val(),
                ID_DOCUMENTO: $("#hd_Documento_Validar_ID_DOCUMENTO").val(),
                ID_DOCUMENTO_ASIGNADO: $("#hd_Documento_Validar_ID_DOCUMENTO_ASIGNADO").val()
            }
            Aprobar_ListaDocumentos.push(itemx);
            var item = {
                lista: Aprobar_ListaDocumentos
            }
            var url = baseUrl + "Microforma/ControlCalidad/Documento_Asignado_Validar";
            var auditoria = SICA.Ajax(url, item, false);
            if (auditoria != null && auditoria != "") {
                if (auditoria.EJECUCION_PROCEDIMIENTO) {
                    if (!auditoria.RECHAZAR) {
                        jOkas("Documento evaluado correctamente", "Atención");
                        Aprobar_Cerrar();
                    } else {
                        jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                    }
                    Aprobar_buscar();
                } else {
                    jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                }
            } else {
                jAlert("No se encontraron registros", "Atención");
            }
        }
    });
} 