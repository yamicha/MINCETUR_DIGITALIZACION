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
    jQuery('#aTabMicroformas').click(function (e) {
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
    MicroformaRevisionPeriodica_ConfigurarGrilla(MicroPendiente_Lote_grilla, MicroPendiente_Lote_barra,
        MicroPendiente_grilla, MicroPendiente_barra, MicroModulo.RevisionPend, true);
    Documento_Detalle_buscar(MicroPendiente_grilla, MicroPendiente_barra);
}
function RevisionObservadoBuscar() {
    MicroformaRevisionPeriodica_ConfigurarGrilla(MicroObs_Lote_grilla, MicroObs_Lote_barra,
        MicroObs_grilla, MicroObs_barra, MicroModulo.RevisionObs, false);
    Documento_Detalle_buscar(MicroObs_grilla, MicroObs_barra);
}
function RevisionAnuladasBuscar() {
    MicroformaRevisionPeriodica_ConfigurarGrilla(MicroAnuladas_Lote_grilla, MicroAnuladas_Lote_barra,
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
function Revision_CargarConboUsuario() {
    var OptionsCboUsu = {
        KeyVal: { value: "ID_USUARIO", name: "NOMBRE_USUARIO" },
        paramters: null,
        method: "GET"
    }
    LoadComboApi("archivo-central/usuario/listar", "ID_USUARIO", OptionsCboUsu);
}
async function Revision_Grabar() {
    MicroForma_Lista.pop();
    var IdDocRevision = 0;
    var TipoPruebaText = "";
    $('#MsgValidActa').hide();
    var _CONFORME = $("#FLG_CONFORME").val();
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
                    UsuCreacion: $("#inputHddId_Usuario").val(),
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

function Microforma_DevolverRevision(IdMicroforma) {
    jConfirm(" ¿ Desea devolver esta microforma para revisión ?", "Atención", async function (r) {
        if (r) {
            var item = {
                IdMicroforma: IdMicroforma,
            }
            var url = "archivo-central/microforma/desarchivar-microforma";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            if (_MICROMODULO == MicroModulo.RevisionObs)
                                RevisionObservadoBuscar();
                            if (_MICROMODULO == MicroModulo.RevisionAnulada)
                                RevisionAnuladasBuscar();
                            jOkas("Microforma devuelta para revisión correctamente.", "Atención");
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

//********************************************************** tab OBSERVADOS *********************************************************/
function Microforma_MostrarReprocesar(ID_MICROFORMA) {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Digitalizacion/revision-periodica/mantenimiento-reprocesar?ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

async function Microforma_ReprocesoGetOne(id) {
    var OptionsCboSoporte = {
        KeyVal: { value: "ID_SOPORTE", name: "DESC_SOPORTE" },
        paramters: { FlgEstado: "1" },
        method: "POST"
    }
    if (await LoadComboApi("archivo-central/soporte/listar", "MICROFORMA_ID_TIPO_SOPORTE", OptionsCboSoporte)) {
        var url = `archivo-central/microforma/get-microforma/${id}`;
        API.FetchGet("GET", url, function (auditoria) {
            if (auditoria != null && auditoria != "") {
                if (auditoria.EjecucionProceso) {
                    if (!auditoria.Rechazo) {
                        $('#MICROFORMA_ID_TIPO_SOPORTE').val(auditoria.Objeto.ID_TIPO_SOPORTE);
                        $('#MICROFORMA_CODIGO_FEDATARIO').val(auditoria.Objeto.CODIGO_FEDATARIO);
                        $('#MICROFORMA_FECHA').val(auditoria.Objeto.FECHA);
                        $('#MICROFORMA_HORA').val(auditoria.Objeto.HORA);
                        $('#MICROFORMA_ACTA').val(auditoria.Objeto.NRO_ACTA);
                        $('#MICROFORMA_COPIAS').val(auditoria.Objeto.NRO_COPIAS);
                        $('#MICROFORMA_OBSERVACION').val(auditoria.Objeto.OBSERVACION);
                        $('#MICROFORMA_CODIGO_SOPORTE').val(auditoria.Objeto.CODIGO_SOPORTE);
                        $('#MICROFORMA_NROVOLUMEN').val(auditoria.Objeto.NRO_VOLUMEN);
                        $('#MA_TIPO_ARCHIVO').val(auditoria.Objeto.MicroArchivo.TIPO_ARCHIVO);
                        $('#MA_RESPONSABLE').val(auditoria.Objeto.MicroArchivo.RESPONSABLE);
                        $('#MICROFORMA_FECHA').val(auditoria.Objeto.MicroArchivo.FECHA);
                        $('#MA_OBSERVACION').val(auditoria.Objeto.MicroArchivo.OBSERVACION);
                        $('#MA_DIRECCION').val(auditoria.Objeto.MicroArchivo.DIRECCION);
                        $('#MA_FECHA').val(auditoria.Objeto.MicroArchivo.FECHA);
                        $('#MA_HORA').val(auditoria.Objeto.MicroArchivo.HORA);
                        $('#MicroArchivoActa').attr('data-file', auditoria.Objeto.MicroArchivo.ID_DOC_ALMACENAMIENTO);
                        //files download
                        if (auditoria.Objeto.ID_DOC_APERTURA != 0) {
                            $('#DownloadApertura').show();
                            $('#DownloadApertura').attr('data-file', auditoria.Objeto.ID_DOC_APERTURA);
                        }
                        if (auditoria.Objeto.ID_DOC_CIERRE != 0) {
                            $('#DownloadCierre').show();
                            $('#DownloadCierre').attr('data-file', auditoria.Objeto.ID_DOC_APERTURA);
                        }
                        if (auditoria.Objeto.ID_DOC_CONFORMIDAD != 0) {
                            $('#DownloadConformidad').show();
                            $('#DownloadConformidad').attr('data-file', auditoria.Objeto.ID_DOC_CONFORMIDAD);
                        }
                        if (auditoria.Objeto.MicroArchivo.ID_DOC_ALMACENAMIENTO != 0) {
                            $('#DownloadAlmacenamiento').show();
                            $('#DownloadAlmacenamiento').attr('data-file', auditoria.Objeto.MicroArchivo.ID_DOC_ALMACENAMIENTO);
                        }
                        $('label[download-file="yes"]').click(function () {
                            var IdFile = $(this).data('file');
                            DownloadFile(IdFile);
                        });
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            }
        });
    }
}

async function Revision_ReprocesoGrabar() {
    jConfirm(" ¿ Desea reprocesar esta microforma  ? ", "Atención", async function (r) {
        if (r) {
            var IdDocApertura = $('#DownloadApertura').data('file');
            var IdDocCierre = $('#DownloadCierre').data('file');
            var IdDocConformidad = $('#DownloadConformidad').data('file');
            var IdDocAlmacenamiento = $('#DownloadAlmacenamiento').data('file');
            if ($('#fileActaApertura').prop('files')[0] != undefined) {
                var formdataFileApertura = new FormData();
                formdataFileApertura.append('fileArchivo', $('#fileActaApertura').prop('files')[0]);
                IdDocApertura = await UploadFileService(formdataFileApertura);
            }
            if ($('#fileActaCierre').prop('files')[0] != undefined) {
                var formdataFileCierre = new FormData();
                formdataFileCierre.append('fileArchivo', $('#fileActaCierre').prop('files')[0]);
                IdDocCierre = await UploadFileService(formdataFileCierre);
            }
            if ($('#fileActaConformidad').prop('files')[0] != undefined) {
                var formdataFileConformidad = new FormData();
                formdataFileConformidad.append('fileArchivo', $('#fileActaConformidad').prop('files')[0]);
                IdDocConformidad = await UploadFileService(formdataFileConformidad);
            }
            if ($('#fileActaAlmacenamiento').prop('files')[0] != undefined) {
                var formdataFileAlma = new FormData();
                formdataFileAlma.append('fileArchivo', $('#fileActaAlmacenamiento').prop('files')[0]);
                IdDocAlmacenamiento = await UploadFileService(formdataFileAlma);
            }
            var item = {
                IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                Fecha: $("#MICROFORMA_FECHA").val(),
                Hora: $("#MICROFORMA_HORA").val(),
                NroVolumen: $("#MICROFORMA_NROVOLUMEN").val(),
                CodigoSoporte: $("#MICROFORMA_CODIGO_SOPORTE").val(),
                IdSoporte: parseInt($("#MICROFORMA_ID_TIPO_SOPORTE").val()),
                IdDocApertura: parseInt(IdDocApertura),
                IdDocCierre: parseInt(IdDocCierre),
                IdDocConformidad: parseInt(IdDocConformidad),
                NroActa: $("#MICROFORMA_ACTA").val(),
                NroCopias: $("#MICROFORMA_COPIAS").val(),
                CodigoFedatario: $("#MICROFORMA_CODIGO_FEDATARIO").val(),
                Observacion: $("#MICROFORMA_OBSERVACION").val(),
                UsuCreacion: $("#inputHddId_Usuario").val(),
                MicroArchivo: {
                    TipoArchivo: parseInt($("#MA_TIPO_ARCHIVO").val()),
                    Direccion: $("#MA_DIRECCION").val(),
                    Observacion: $("#MA_OBSERVACION").val(),
                    IdUsuario: parseInt($("#comboUsuario").val()),
                    UsuCreacion: $("#inputHddId_Usuario").val(),
                    IdDocAlmacenamiento: parseInt(IdDocAlmacenamiento),
                    Fecha: $("#MA_FECHA").val(),
                    Hora: $("#MA_HORA").val(),
                }
            }
            var url = "archivo-central/microforma/revision-reprocesar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            RevisionObservadoBuscar();
                            jQuery("#myModalNuevo").html('');
                            jQuery("#myModalNuevo").modal('hide');
                            jOkas("Datos guardados correctamente.", "Atención");
                        } else {
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                } else {
                    jAlert("Sin respuesta del servidor):", "Atención");
                }
            });
        }
    });
}

//********************************************************** tab ANULADOS *********************************************************/

