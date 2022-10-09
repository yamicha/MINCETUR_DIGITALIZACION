// tab 1
var MicroPendiente_grilla = 'MicroPendiente_grilla';
var MicroPendiente_barra = 'MicroPendiente_barra';

var MicroPendiente_Lote_grilla = 'MicroPendiente_Lote_grilla';
var MicroPendiente_Lote_barra = 'MicroPendiente_Lote_barra';

// tab 2
var MicroFin_grilla = 'MicroFin_grilla';
var MicroFin_barra = 'MicroFin_barra';

var MicroFin_Lote_grilla = 'MicroFin_Lote_grilla';
var MicroFin_Lote_barra = 'MicroFin_Lote_barra';
var MicroForma_Lista = new Array(); 

$(document).ready(function () {
    RevisionPendienteBuscar(); 
    jQuery('#aTabRevisionPend').click(function (e) {
        _ID_LOTE = 0;
        RevisionPendienteBuscar(); 
    });
    jQuery('#aTabRevisionFin').click(function (e) {
        _ID_LOTE = 0;
        RevisionFinalizadoBuscar(); 
    });

    $('#Microforma_BtnMicroArchivo').click(function () {
        var rowKey = $("#" + MicroFin_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); 
        if (rowKey != null) {
            if (rowKey.length > 0) {
                //$("#Microforma_Div_validar").show();
                Microforma_VolverGrabarMicroArchivo(); 
            }
            else {
                jAlert("Debe seleccionar por lo menos un registo.", "Atención");
            }
        }
        else {
            jAlert("Debe seleccionar por lo menos un registo.", "Atención");
        }

    });   
});

function RevisionPendienteBuscar() {
    Microforma_ConfigurarGrilla(MicroPendiente_Lote_grilla, MicroPendiente_Lote_barra, MicroPendiente_grilla, MicroPendiente_barra, MicroModulo.RevisionPend);
    Documento_Detalle_buscar(MicroPendiente_grilla, MicroPendiente_barra);
}
function RevisionFinalizadoBuscar() {
    Microforma_ConfigurarGrilla(MicroFin_Lote_grilla, MicroFin_Lote_barra,
        MicroFin_grilla, MicroFin_barra, MicroModulo.CPendienteFin, true);
    Documento_Detalle_buscar(MicroFin_grilla, MicroFin_barra);
}
function Microforma_MicroArchivoGrabar() {
    jConfirm(" ¿ Desea guardar datos de micro archivo ingresados ? ", "Atención", function (r) {
        if (r) {
            var item = {
                IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                TipoArchivo: parseInt($("#MA_TIPO_ARCHIVO").val()),
                Direccion: $("#MA_DIRECCION").val(),
                Observacion: $("#MA_OBSERVACION").val(),
                IdUsuario: parseInt($("#inputHddId_Usuario").val()),
                UsuCreacion: $("#inputHddCod_usuario").val(),
            }
            var url = "archivo-central/microforma/micro-archivo-insertar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            ControlBuscar(); 
                            Microforma_CloseModal();
                            jOkas("Datos guardados correctamente.", "Atención");             
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
function MicroformaPendiente_CargarGrilla() {
    var item = {
    }
    var url = "archivo-central/microforma/listar-control";
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + MicroPendiente_Lote_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
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
                        jQuery("#" + MicroPendiente_Lote_grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + MicroPendiente_Lote_grilla).trigger("reloadGrid");
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

function Microforma_VolverGrabarMicroArchivo() {
    jConfirm(" ¿ Desea enviar a pendientes de grabación de micro archivos todos los registros seleccionados  ? ", "Atención", function (r) {
        if (r) {
            var rowKey = $("#" + MicroFin_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); 
            for (i_ = 0; i_ < rowKey.length; i_++) {
                var data = jQuery("#" + MicroFin_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
                var _item = {
                    IdMicroforma: parseInt(data.ID_MICROFORMA)
                }
                MicroForma_Lista.push(_item);
            }
            var item = {
                ListaIdsMicroforma: MicroForma_Lista
            }
            var url = "archivo-central/microforma/micro-archivo-estado";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            ControlFinalizadoBuscar();
                            jOkas("Datos guardados correctamente.", "Atención");
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


