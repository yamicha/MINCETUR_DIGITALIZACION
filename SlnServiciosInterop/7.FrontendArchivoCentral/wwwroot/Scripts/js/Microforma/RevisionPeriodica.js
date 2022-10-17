// tab 1
var MicroPendiente_grilla = 'MicroPendiente_grilla';
var MicroPendiente_barra = 'MicroPendiente_barra';

var MicroPendiente_Lote_grilla = 'MicroPendiente_Lote_grilla';
var MicroPendiente_Lote_barra = 'MicroPendiente_Lote_barra';

// tab 2
var MicroObs_grilla = 'MicroObs_grilla';
var MicroObs_barra = 'MicroObs_barra';

var MicroObs_Lote_grilla = 'MicroObs_Lote_grilla';
var MicroObs_Lote_barra = 'MicroObs_Lote_barra';
var MicroForma_Lista = new Array();

// tab 3 
var MicroAnuladas_grilla = 'MicroAnuladas_grilla';
var MicroAnuladas_barra = 'MicroAnuladas_barra';

var MicroAnuladas_Lote_grilla = 'MicroAnuladas_Lote_grilla';
var MicroAnuladas_Lote_barra = 'MicroAnuladas_Lote_barra';

$(document).ready(function () {
    RevisionPendienteBuscar();
    jQuery('#aTabRevisionPend').click(function (e) {
        _ID_LOTE = 0;
        RevisionPendienteBuscar();
    });
    jQuery('#aTabRevisionObservadas').click(function (e) {
        _ID_LOTE = 0;
        RevisionObservadoBuscar();
    });
    jQuery('#aTabRevisionAnuladas').click(function (e) {
        _ID_LOTE = 0;
        RevisionAnuladasBuscar();
    });

    $('#Microforma_BtnRevision').click(function () {
        var rowKey = $("#" + MicroPendiente_Lote_grilla).jqGrid('getGridParam', 'selarrrow');
        if (rowKey != null) {
            if (rowKey.length > 0) {
                Revision_MostrarEvaluar();
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
    Microforma_ConfigurarGrilla(MicroPendiente_Lote_grilla, MicroPendiente_Lote_barra,
        MicroPendiente_grilla, MicroPendiente_barra, MicroModulo.RevisionPend, true);
    Documento_Detalle_buscar(MicroPendiente_grilla, MicroPendiente_barra);
}
function RevisionObservadoBuscar() {
    Microforma_ConfigurarGrilla(MicroObs_Lote_grilla, MicroObs_Lote_barra,
        MicroObs_grilla, MicroObs_barra, MicroModulo.RevisionObs, true);
    Documento_Detalle_buscar(MicroObs_grilla, MicroObs_barra);
}
function RevisionAnuladasBuscar() {
    Microforma_ConfigurarGrilla(MicroAnuladas_Lote_grilla, MicroAnuladas_Lote_barra,
        MicroAnuladas_grilla, MicroAnuladas_barra, MicroModulo.RevisionAnulada, false);
    Documento_Detalle_buscar(MicroAnuladas_grilla, MicroAnuladas_barra);
}

function Revision_MostrarEvaluar() {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").modal('show');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/revision-periodica/evaluar", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

async function Revision_Grabar() {
    MicroForma_Lista.pop();
    var IdDocRevision = 0;
    var TipoPruebaText = "";
    $('#MsgValidActa').hide();
    var _CONFORME = $("#MICROFORMA_FLG_CONFORME").val();
    if (_CONFORME == "0") {
        pregunta = "darle 'NO CONFORME'";
    } else {
        pregunta = "dar un 'CONFORME'";
    }
    if ($('#fileActaRevision').prop('files')[0] != undefined) {
        jConfirm(" ¿ Desea " + pregunta + " a los registros seleccionados  ? ", "Atención", async function (r) {
            if (r) {
                var rowKey = $("#" + MicroPendiente_Lote_grilla).jqGrid('getGridParam', 'selarrrow');
                for (i_ = 0; i_ < rowKey.length; i_++) {
                    var data = jQuery("#" + MicroPendiente_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
                    var _item = {
                        IdMicroforma: parseInt(data.ID_MICROFORMA)
                    }
                    MicroForma_Lista.push(_item);
                }

                var formdataFile = new FormData();
                formdataFile.append('fileArchivo', $('#fileActaRevision').prop('files')[0]);
                IdDocRevision = await UploadFileService(formdataFile);
                $("#TIPO_PRUEBA option:selected").each(function () {
                    var $this = $(this);
                    if ($this.length) {
                        TipoPruebaText += `[${$this.text()}] `;
                    }
                });
                var item = {
                    ListaIdsMicroforma: MicroForma_Lista,
                    FlgConforme: parseInt($("#FLG_CONFORME").val()),
                    FlgAccion: parseInt($("#FLG_ACCION").val()),
                    //TipoPrueba: $("#TIPO_PRUEBA").val().join(','),
                    TipoPrueba: TipoPruebaText,
                    IdUsuario: parseInt($("#ID_USUARIO").val()),
                    IdDocRevision: parseInt(IdDocRevision),
                    FecRevision: $("#FECHA").val(),
                    Observacion: $("#OBSERVACION").val(),
                    UsuCreacion: $("#inputHddCod_usuario").val(),
                }
                var url = "archivo-central/microforma/revision-periodica";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                _ID_LOTE = 0;
                                RevisionPendienteBuscar();
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
    } else {
        $('#MsgValidActa').show();
    }
}

function Microforma_DevolverRevision() {

}
//********************************************************** tab OBSERVADOS *********************************************************/

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


//********************************************************** tab ANULADOS *********************************************************/