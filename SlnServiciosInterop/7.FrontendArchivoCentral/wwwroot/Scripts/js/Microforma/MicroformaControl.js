// tab 1
var MicroControl_grilla = 'MicroControl_grilla';
var MicroControl_barra = 'MicroControl_barra';

var MicroControl_Lote_grilla = 'MicroControl_Lote_grilla';
var MicroControl_Lote_barra = 'MicroControl_Lote_barra';

// tab 2
var MicroFin_grilla = 'MicroFin_grilla';
var MicroFin_barra = 'MicroFin_barra';

var MicroFin_Lote_grilla = 'MicroFin_Lote_grilla';
var MicroFin_Lote_barra = 'MicroFin_Lote_barra';


$(document).ready(function () {
    _MICROMODULO = MicroEstado.Grabado; 
    Microforma_ConfigurarGrilla(MicroControl_Lote_grilla, MicroControl_Lote_barra, MicroControl_grilla, MicroControl_barra);
    Microforma_ConfigurarGrilla(MicroFin_Lote_grilla, MicroFin_Lote_barra, MicroFin_grilla, MicroFin_barra);
    MicroformaControl_CargarGrilla(); 
    Documento_Detalle_buscar(MicroControl_grilla, MicroControl_barra);
    jQuery('#aTabMicroformaControl').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        _MICROMODULO = MicroEstado.Grabado; 
        MicroformaControl_CargarGrilla(); 
        Documento_Detalle_buscar(MicroControl_grilla, MicroControl_barra);
    });
    jQuery('#aTabMicroformaFinalizado').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        _MICROMODULO = 0; 
        Microforma_CargarGrilla(MicroFin_Lote_grilla, MicroEstado.Conforme);
        Documento_Detalle_buscar(MicroFin_grilla, MicroFin_barra);
    });

});

function MicroformaCerrar() {
    $('#myModal_Documento_Grabar').modal('hide');
    jQuery("#myModal_Documento_Grabar").html('');
}

function MicroformaEvaluar() {
    if ($('#FrmMicroEvaluar').valid()) {
        jConfirm(" ¿ Desea grabar esta evaluación de microforma ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                    FlgConforme: parseInt($("#MICROFORMA_FLG_CONFORME").val()),
                    Observacion: $("#MICROFORMA_OBSERVACION").val(),
                    UsuCreacion: $("#inputHddCod_usuario").val(),
                }
                var url = "archivo-central/microforma/evaluar";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                _ID_LOTE = 0;
                                Microforma_CargarGrilla(MicroControl_Lote_grilla, MicroEstado.Grabado);
                                Documento_Detalle_buscar(MicroControl_grilla, MicroControl_barra);
                                jOkas("Microforma evaluada correctamente.", "Atención");
                                MicroformaCerrar();
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
}

function MicroformaControl_CargarGrilla() {
    var item = {
    }
    var url = "archivo-central/microforma/listar-control";
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + MicroControl_Lote_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    var x = 0;
                    $.each(auditoria.Objeto, function (i, v) {
                        x++;
                        var myData =
                        {
                            CODIGO: x,
                            ID_MICROFORMA: v.ID_MICROFORMA,
                            DESC_SOPORTE: v.DESC_SOPORTE,
                            CODIGO_SOPORTE: v.CODIGO_SOPORTE,
                            DESCRIPCION_LOTE: v.DESCRIPCION_LOTE,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            DESC_ESTADO: v.DESC_ESTADO,
                            ID_ESTADO: v.ID_ESTADO
                        };
                        jQuery("#" + MicroControl_Lote_grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + MicroControl_Lote_grilla).trigger("reloadGrid");
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

//********************************************************** tab finalizados *********************************************************/



