var Aprobar_grilla = 'Aprobar_grilla';
var Aprobar_barra = 'Aprobar_barra';
var ControlCalidad_ListaDocumentos = new Array();

$(document).ready(function () {
    Aprobar_buscar();
});

jQuery('#aTabAprobar').click(function (e) {
    Aprobar_buscar();
    
});

$('#ControlCalidad_btn_Conforme').click(function () {
    var rowKey = $("#" + Aprobar_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    if (rowKey != null) {
        if (rowKey.length > 0) {
            ControlCalidad_ConformeMasivo();
        }
        else {
            jAlert("Debe seleccionar por lo menos un documento.", "Atención");
        }
    }
    else {
        jAlert("Debe seleccionar por lo menos un documento.", "Atención");
    }
});

jQuery('#aTabAprobar').click(function (e) {
    Aprobar_buscar();
});

function Aprobar_buscar() {
    Documento_ConfigurarGrilla(Aprobar_grilla, Aprobar_barra, "Listado de documentos digitalizados", true, 6); 
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
                UsuCreacion: $('#inputHddId_Usuario').val(),
                IdSistema: idSis
            }
            //Aprobar_ListaDocumentos.push(itemx);
            //var item = {
            //    lista: Aprobar_ListaDocumentos
            //}
            var url = "ventanilla/digitalizacion/digitalizado-calidad-validar";
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



function ControlCalidad_ConformeMasivo() {
    jConfirm(" ¿ Desea dar CONFORME a los documentos seleccionados ? ", "Atención", function (r) {
        if (r) {
            ControlCalidad_ListaDocumentos = new Array();
            var rowKey = $("#" + Aprobar_grilla).jqGrid('getGridParam', 'selarrrow'); //
            for (var i = 0; i < rowKey.length; i++) {
                var data = jQuery("#" + Aprobar_grilla).jqGrid('getRowData', rowKey[i]);
                var itemDoc = {
                    FlgConforme: 1,// conforme
                    IdDocumento: parseInt(data.Control_Calidad_ID_DOCUMENTO),
                    IdDocumentoAsignado: parseInt(data.Control_Calidad_ID_DOCUMENTO_ASIGNADO),
                    UsuCreacion: $('#inputHddId_Usuario').val(),
                    IdTipoObservacion: 0,
                    IdSistema: idSis
                };
                ControlCalidad_ListaDocumentos.push(itemDoc);
            }
            var itemx = {
                LisIdDocumento: ControlCalidad_ListaDocumentos,
            }
            var url = "ventanilla/digitalizacion/control-calidad-masivo";
            API.Fetch("POST", url, itemx, function (auditoria) {
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