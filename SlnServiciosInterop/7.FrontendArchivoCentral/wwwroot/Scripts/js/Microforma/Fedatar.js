var Fedatar_grilla = 'Fedatar_grilla';
var Fedatar_barra = 'Fedatar_barra';
var Fedatar_ListaDocumentos = new Array();

$(document).ready(function () {
    Fedatar_buscar();
});

jQuery('#aTabFedatar').click(function (e) {
    Fedatar_buscar();
});

function Fedatar_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Fedatar_grilla + "," + Fedatar_barra + ",\"Listado de documentos aprobados\", false, 10);", 500);
}

function Aprobar_Cerrar() {
    $('#myModal_Documento_Ver_Imagen').modal('hide');
    jQuery("#myModal_Documento_Ver_Imagen").html('');
}

$("#Fedatar_btn_Conforme").click(function (e) {
    Fedatar_ListaDocumentos = new Array();
    var rowKey = $("#" + Fedatar_grilla).jqGrid('getGridParam', 'selarrrow'); // esta opcion permite traer los indices de cada fila seleccionada
    if (rowKey.length > 0) {
        for (var i = 0; i < rowKey.length; i++) {
            var data = jQuery("#" + Fedatar_grilla).jqGrid('getRowData', rowKey[i]);
            var itemDoc = {
                FLG_CONFORME: 1,
                OBSERVACION: '-',
                COD_DOCUMENTO: data.Fedatar_COD_DOCUMENTO, //$("#COD_DOCUMENTO").val(),
                ID_TIPO_OBSERVACION: 0,
                ID_DOCUMENTO: data.Fedatar_ID_DOCUMENTO,
                ID_DOCUMENTO_ASIGNADO: data.Fedatar_ID_DOCUMENTO_ASIGNADO
            };
            Fedatar_ListaDocumentos.push(itemDoc);
        }
        jConfirm("¿ Desea dar CONFORME a los documentos seleccionados ?", "Atención", function (r) {
            if (r) {
                var item = {
                    lista: Fedatar_ListaDocumentos
                }
                var url = baseUrl + "Microforma/Fedatario/Documento_Fedatario_Validar";
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            jOkas("Documento(s) evaluado(s) correctamente", "Atención");
                        } else {
                            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                        }
                        Fedatar_buscar();
                    } else {
                        jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                    }
                } else {
                    jAlert("No se encontraron registros", "Atención");
                }
            }
        });
    } else {
        jAlert("Seleccione al menos un registro para dar CONFORME.", "Atención");
    }
});

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
            Fedatar_ListaDocumentos = new Array();
            var ID_TIPO_OBS = 0;
            if ($("#VALIDAR_ID_TIPO_OBS").val() != "")
                ID_TIPO_OBS = parseInt($("#VALIDAR_ID_TIPO_OBS").val())
            var itemx = {
                FlgConforme: parseInt(_CONFORME),
                Comentario: $("#VALIDAR_OBSERVACION").val(),
                IdTipoObservacion: parseInt(ID_TIPO_OBS),
                IdDocumento: parseInt($("#hd_Documento_Validar_ID_DOCUMENTO").val()),
                IdDocumentoAsignado: parseInt($("#hd_Documento_Validar_ID_DOCUMENTO_ASIGNADO").val()),
                UsuCreacion: $('#inputHddCod_usuario').val()
            }
            debugger; 
            //Fedatar_ListaDocumentos.push(itemx);
            //var item = {
            //    lista: Fedatar_ListaDocumentos
            //}
            var url = "archivo-central/digitalizacion/digitalizado-fedatario-validar";
            API.Fetch("POST", url, itemx, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            jOkas("Documento evaluado correctamente", "Atención");
                            Aprobar_Cerrar();
                        } else {
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                        Fedatar_buscar();
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