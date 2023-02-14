
let DocumentoAdjunto_grilla = "DocumentoAdjunto_grilla";
let DocumentoAdjunto_barra = "DocumentoAdjunto_barra";
var IdDocAdjunto = 0;

function DocumentoAdjuntos_ConfigurarGrilla(tipoProceso = "") {
    let btnAdjuntoHdd = false;
    if (tipoProceso != "Edit") {
        btnAdjuntoHdd = true;
    }
    $("#" + DocumentoAdjunto_grilla).GridUnload();
    var colNames = ['Codigo', 'ID_DOC', 'ID_LASER', 'Eliminar', 'Editar', 'Ver', 'Documento', 'Documento', 'Peso', 'Extensión', 'Link'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_DOC_ADJ', index: 'ID_DOC_ADJ', align: 'center', hidden: true, width: 50 },
        { name: 'ID_DOC_CMS', index: 'ID_DOC_CMS', align: 'center', hidden: true, width: 0, },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: btnAdjuntoHdd, formatter: DocumentoAdjunto_actionEliminar },
        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 90, hidden: btnAdjuntoHdd, formatter: DocumentoAdjunto_actionEditar },
        { name: 'VERDOCUMENTO', index: 'VERDOCUMENTO', align: 'center', width: 90, hidden: false, formatter: DocumentoAdjunto_actionver },
        { name: '_DES_NOM_ABR', index: '_DES_NOM_ABR', align: 'center', width: 450, hidden: false, formatter: DocumentoAdjunto_actionDocumento },
        { name: 'DES_NOM_ABR', index: 'DES_NOM_ABR', align: 'center', width: 200, hidden: true },
        { name: 'NUM_SIZE_ARCHIVO', index: 'NUM_SIZE_ARCHIVO', align: 'center', width: 150, hidden: false, editable: true },
        { name: 'EXTENSION', index: 'EXTENSION', align: 'center', width: 100, hidden: false, editable: true, },
        { name: 'FLG_LINK', index: 'FLG_LINK', align: 'center', width: 100, hidden: true },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: true,
    };
    SICA.Grilla(DocumentoAdjunto_grilla, DocumentoAdjunto_barra, '', '', '', '', "", "", colNames, colModels, "", opciones);
}
function DocumentoAdjunto_actionEditar(cellvalue, options, rowObject) {
    var Btn = "<button title=\"ver\" onclick='DocumentoAdjunto_MostrarEditar(" + rowObject.CODIGO + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" data-target=\"#MyModalEditarDocumento\" style=\"text-decoration: none !important;\"><i class=\"clip-pencil-2\" style=\"font-size:17px\"></i></button>";
    return Btn;
}
function DocumentoAdjunto_actionDocumento(cellvalue, options, rowObject) {
    let Link = rowObject.DES_NOM_ABR;
    if (rowObject.FLG_LINK == 1) {
        Link = "<a title=\"ver\" href=" + Link + " target=\"_blank\" class=\" btn-link\" type=\"button\" ><i class=\"clip-new-tab\"></i> " + Link + "</a>";
    }
    return Link;
}
function DocumentoAdjunto_actionver(cellvalue, options, rowObject) {
    let Btn
    if (rowObject.FLG_LINK == 0) {
        Btn = "<button title=\"ver\" onclick='DownloadFile(" + rowObject.ID_DOC_CMS + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-search-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    } else {
        Btn = "-";
    }
    return Btn;
}
function DocumentoAdjunto_MostrarEditar(rowKey) {
    jQuery("#MyModalEditarDocumento").html('');
    jQuery("#MyModalEditarDocumento").load(baseUrl + "Digitalizacion/reproceso/editar-adjunto", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#MyModalEditarDocumento'); 
        if (request.status == 200) {   
            var data = $('#' + DocumentoAdjunto_grilla).getRowData(rowKey);
            IdDocAdjunto = data.ID_DOC_ADJ;
            $('#EDIT_PESO_ARCHIVO').val(data.NUM_SIZE_ARCHIVO);
            $('#EDIT_EXTENSION').val(data.EXTENSION);

        }
    });
}
function DocumentoAdjunto_actionEliminar(cellvalue, options, rowObject) {
    var Btn = "<button title=\"Eliminar\" onclick='DocumentoAdjunto_Eliminar(" + rowObject.ID_DOC_ADJ + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return Btn;
}
function CalcularPesoAdjunto(_grilla) {
    var totalData = JSLINQ($("#" + _grilla).jqGrid('getGridParam', 'data')).Select(function (item) { return (item); });
    var peso = 0;
    $.each(totalData.items, function (i, v) {
        var valorCelda = v.NUM_SIZE_ARCHIVO;
        if (valorCelda == '' || valorCelda == null) {
            valorCelda = 0;
        }
        peso += valorCelda;
    });
    $("#" + _grilla).jqGrid('footerData', 'set', { NUM_SIZE_ARCHIVO: ' Peso: ' + formatBytes(peso) });
}
function DocumentoAdjuntos_CargarGrilla(ID_DOCUMENTO) {
    var url = `ventanilla/documento/get-adjuntos/${ID_DOCUMENTO}`;
    API.FetchGet("GET", url, function (auditoria) {
        jQuery("#" + DocumentoAdjunto_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $.each(auditoria.Objeto, function (i, v) {
                        i = i + 1;
                        v.CODIGO = i;
                        jQuery("#" + DocumentoAdjunto_grilla).jqGrid('addRowData', i, v);
                    });
                    jQuery("#" + DocumentoAdjunto_grilla).trigger("reloadGrid");
                    CalcularPesoAdjunto(DocumentoAdjunto_grilla);
                }
            }
        }
    });
}
function DocumentoAdjuntos_ProcesarFile(input) {
    let inputName = $('#NOMBRE_ARCHIVO');
    let inputPeso = $('#PESO_ARCHIVO');
    let inputEx = $('#EXTENSION');
    var file = input.files[0];
    if (file != undefined) {
        var PesodeArchivo = parseFloat(file.size);
        var ext = input.files[0].name.split('.').pop();
        ext = ext.toLowerCase();
        let nombre = input.files[0].name;
        if (nombre.length > 100) {
            jAlert("El nombre del documento es muy largo", 'Atención');
            $(this).val('');
            return false;
        }
        else {
            var valido = false;
            if (extensionValid.test(`.${ext}`))
                valido = true;
            if (PesodeArchivo > Tamanio_Valido || !valido) {
                $(this).val('');
                if (!valido)
                    jAlert("Solo se permite documentos en formato " + extensionValid, 'Atención');
                else
                    jAlert("El archivo que va a adjuntar no puede superar los " + Tamanio_Valido / 1024 / 1024 + "Mb de peso", 'Atención');
                    //jAlert("La cantidad de el archivo que va adjuntar no pueden pesar más de " + Tamanio_Valido / 1024 / 1024 + "Mb", 'Atención');
                return false;
            } else {
                var sumaPeso = 0;
                var rowKey = jQuery("#" + DocumentoAdjunto_grilla).getDataIDs();
                for (var i = 0; i < rowKey.length; i++) {
                    var data = jQuery("#" + DocumentoAdjunto_grilla).jqGrid('getRowData', rowKey[i]);
                    sumaPeso += parseFloat(data.NUM_SIZE_ARCHIVO);
                }
                sumaPeso += PesodeArchivo;
                if (sumaPeso > Tamanio_Valido) {
                    jAlert("El archivo que ha ingresado y el resto, supera los " + Tamanio_Valido / 1024 / 1024 + "Mb de peso", 'Atención');
                } else {
                    inputPeso.val(file.size);
                    inputName.val(file.name.split('.')[0]);
                    inputEx.val(`.${file.name.split('.')[1]}`);
                }
            }
        }
    }
}

async function DocumentoAdjunto_Insertar() {
    if ($('#FrmAdjunto').valid()) {
        jConfirm(" ¿ Desea agregar este adjunto para el expediente ? ", "Atención", async function (r) {
            if (r) {
                let IdExpediente = parseInt($('#hd_ID_DOCUMENTO').val());
                let flgLink = parseInt($('#FLG_LINK').val());
                var fileform = new FormData();
                var idAdjunto = 0;
                if (flgLink == 0) {
                    fileform.append('filearchivo', $('#filearchivo').prop('files')[0]);
                    fileform.append('ID_EXPE', IdExpediente);
                    idAdjunto = await UploadFileLaserService(fileform);
                }
                //if (idAdjunto != 0 && flgLink == 0) {
                if (true) {
                    var item = {
                        IdExpediente: IdExpediente,
                        IdArchivo: parseInt(idAdjunto),
                        NombreArchivo: $("#NOMBRE_ARCHIVO").val(),
                        PesoArchivo: parseInt($("#PESO_ARCHIVO").val()),
                        Extension: $("#EXTENSION").val(),
                        FlgLink: flgLink,
                        FlgTipo: 1,// principales
                        UsuCreacion: $('#inputHddId_Usuario').val()
                    }
                    var url = "ventanilla/documento/adjuntos-insertar";
                    API.Fetch("POST", url, item, function (auditoria) {
                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    $("#NOMBRE_ARCHIVO").val(''); 
                                    $("#PESO_ARCHIVO").val(''); 
                                    $("#EXTENSION").val(''); 
                                    DocumentoAdjuntos_CargarGrilla($('#hd_ID_DOCUMENTO').val());
                                    jOkas("Adjunto agregado correctamente.", "Atención");
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
                } else {
                    jAlert("Ocurrio un error al intentar subir el archivo digital, por favor comuniquese con el administrador del sistema", "Ocurrio un error.")
                }
            }
        });
    }
}
function DocumentoAdjunto_Eliminar(id) {
    jConfirm("¿Desea eliminar este adjunto ?", "Atención", function (r) {
        if (r) {
            var url = `ventanilla/documento/adjuntos-eliminar/${id}`;
            API.FetchGet("DELETE", url, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            DocumentoAdjuntos_CargarGrilla($('#hd_ID_DOCUMENTO').val());
                            jAlert("adjunto eliminado", "Proceso");
                        } else {
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                }
            });
        }
    });

}
function DocumentoAdjunto_Actualizar() {
    if ($('#FrmAdjunto').valid()) {
        jConfirm(" ¿ Desea actualizar este registro? ", "Atención", function (r) {
            if (r) {
                var item = {
                    IdocAdjunto: parseInt(IdDocAdjunto),
                    PesoArchivo: parseInt($("#EDIT_PESO_ARCHIVO").val()),
                    Extension: $("#EDIT_EXTENSION").val(),
                    UsuCreacion: $('#inputHddId_Usuario').val()
                }
                var url = "ventanilla/documento/adjuntos-actualizar";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                IdDocAdjunto = 0;              
                                DocumentoAdjuntos_CargarGrilla($('#hd_ID_DOCUMENTO').val());
                                $('#MyModalEditarDocumento').modal('hide'); 
                                jOkas("Adjunto actualizado correctamente.", "Atención");
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