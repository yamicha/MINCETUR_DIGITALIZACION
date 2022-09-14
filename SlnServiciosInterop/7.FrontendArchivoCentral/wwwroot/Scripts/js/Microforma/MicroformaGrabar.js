var MicroformaGrabar_grilla = 'MicroformaGrabar_grilla';
var MicroformaGrabar_barra = 'MicroformaGrabar_barra';

var MicroformaGrabar_Lote_grilla = 'MicroformaGrabar_Lote_grilla';
var MicroformaGrabar_Lote_barra = 'MicroformaGrabar_Lote_barra';
var MicroformaGrabar_ListaLotes = new Array();

$(document).ready(function () {
    MicroformaGrabar_ListaLotes = new Array();
    _ID_MODULO = 12;
    Lote_ConfigurarGrilla(MicroformaGrabar_Lote_grilla, MicroformaGrabar_Lote_barra, true);
    Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, 0);
    MicroformaGrabar_buscar();
});

jQuery('#aTabMicroformaGrabar').click(function (e) {
    _ID_LOTE = 0;
    _ID_MODULO = 12;
    Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, 0);
    MicroformaGrabar_buscar();
});

function MicroformaGrabar_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + MicroformaGrabar_grilla + "," + MicroformaGrabar_barra + ",\"Listado de documentos\", false, 12);", 500);
}

function MicroformaGrabar_Cerrar() {
    $('#myModal_Documento_Grabar').modal('hide');
    jQuery("#myModal_Documento_Grabar").html('');
}

function Documento_MostrarGrabar(ID_LOTE) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Microforma/Microforma/Microforma_Grabar?ID_LOTE=" + ID_LOTE, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

jQuery('#MicroformaGrabar_btn_Nuevo').click(function (e) {
    var rowKey = $("#" + MicroformaGrabar_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    if (rowKey != null) {
        if (rowKey.length > 0) {
            $("#Microforma_Div_validar").show();
            setTimeout("MicroformaGrabar_IniciarProceso();", 500);
        }
        else {
            jAlert("Debe seleccionar por lo menos un sub lote.", "Atención");
        }
    }
    else {
        jAlert("Debe seleccionar por lo menos un sub lote.", "Atención");
    }
});

jQuery('#MicroformaGrabar_btn_X').click(function (e) {
    Documento_MostrarGrabar(0);
});

function MicroformaGrabar_IniciarProceso() {
    var rowKey = $("#" + MicroformaGrabar_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    if (rowKey != null) {
        if (MicroformaGrabar_ValidarLote()) {
            jQuery('#MicroformaGrabar_btn_X').click();
        } else {
            jAlert("Se detectaron documentos no finalizados en el [sub - lote] seleccionado. ", "Atención");
        }
    } else {
        jAlert("Debe seleccionar por lo menos un sub lote.", "Atención");
    }
}

function MicroformaGrabar_ValidarLote() {
    var VALIDO = false;
    var rowKey = $("#" + MicroformaGrabar_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    if (rowKey != null) {
        MicroformaGrabar_ListaLotes = new Array();
        for (i_ = 0; i_ < rowKey.length; i_++) {
            var data = jQuery("#" + MicroformaGrabar_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
            var _item = {
                ID_DOCUMENTO_LOTE: data.ID_DOCUMENTO_LOTE
            }
            MicroformaGrabar_ListaLotes.push(_item);
        }
        var item = {
            lista: MicroformaGrabar_ListaLotes
        }
        var url = baseUrl + "Microforma/Microforma/Microforma_Validar_Lote";
        var auditoria = SICA.Ajax(url, item, false);
        if (auditoria != null && auditoria != "") {
            if (auditoria.EJECUCION_PROCEDIMIENTO) {
                if (!auditoria.RECHAZAR) {
                    VALIDO = auditoria.OBJETO;
                } else {
                    jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                }
                $("#Microforma_Div_validar").hide();
            } else {
                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                $("#Microforma_Div_validar").hide();
            }
        } else {
            jAlert("No se encontraron registros", "Atención");
            $("#Microforma_Div_validar").hide();
        }

    }
    return VALIDO;
}

function MicroformaGrabar_Grabar() { 
    //if ($("#FrmMicroformaGrabarbnn").valid()) {
        jConfirm(" ¿ Desea grabar esta microforma ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    LOTES: MicroformaGrabar_ListaLotes,
                    FECHA: $("#MICROFORMA_FECHA").val() + " " + $("#MICROFORMA_HORA").val(),
                    CODIGO_SOPORTE: $("#MICROFORMA_CODIGO_SOPORTE").val(),
                    ID_TIPO_SOPORTE: $("#MICROFORMA_ID_TIPO_SOPORTE").val(),
                    NRO_ACTA: $("#MICROFORMA_ACTA").val(),
                    NRO_COPIAS: $("#MICROFORMA_COPIAS").val(),
                    CODIGO_FEDATARIO: $("#MICROFORMA_CODIGO_FEDATARIO").val(),
                    OBSERVACION: $("#MICROFORMA_OBSERVACION").val()
                }
                var url = baseUrl + "Microforma/Microforma/Microforma_Registrar";
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            _ID_LOTE = 0;
                            Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, 0);
                            MicroformaGrabar_buscar();
                            MicroformaGrabar_Cerrar();
                        } else {
                            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                        }
                    } else {
                        jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                    }
                } else {
                    jAlert("No se encontraron registros", "Atención");
                }
            }
        });
    //}
}