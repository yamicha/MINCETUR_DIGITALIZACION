﻿var Adjuntos_grilla = "Adjuntos_grilla";
var Adjuntos_barra = "Adjuntos_barra";

var DocumentoAdj_grilla = "DocumentoAdj_grilla";
var DocumentoAdj_barra = "DocumentoAdj_barra";

var Adjunto = new Array();
var IdAdjunto = 0;
var files = [];
var filesDocPrincipal = [];

var MicroModulo = {
    Recepcion: 0,
    Grabados: 1,
    Reprocesar: 2,
    Control: 3,
    Conforme: 4,
    CAlmacen: 5,
    CAlmacenFin: 6,
    RevisionPend: 7,
    RevisionObs: 8,
    RevisionAnulada: 9,
}

$(document).ready(function () {
    $('#TIPO_ADJUNTO').val(0);
    TipoAdjuntoCambio(0);
    $('#TIPO_ADJUNTO').change(function () {
        TipoAdjuntoCambio($(this).val());
    });

    $('#BtnAgregarAdjunto').click(function () {
        Adjunto_Agregar();
    });
});

function TipoAdjuntoCambio(opcion) {
    if (opcion == 1) {
        $('#ControlFile').hide();
        $('#NOMBRE_ARCHIVO').prop("disabled", false);
        $('#PESO_ARCHIVO').prop("disabled", false);
        $('#EXTENSION').prop("disabled", false);
    } else {
        $('#ControlFile').show('slow');
        $('#NOMBRE_ARCHIVO').prop("disabled", true);
        $('#PESO_ARCHIVO').prop("disabled", true);
        $('#EXTENSION').prop("disabled", true);
    }
}

function Adjuntos_ConfigurarGrilla() {

    $("#" + Adjuntos_grilla).GridUnload();
    var colNames = [
        '', 'Eliminar', 'Adjunto',
        'Codigo', 'Peso', 'Peso', 'Extensión', 'Tipo'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 0, key: true },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: Adjunto_actionEliminar },
        { name: 'NOMBRE_ARCHIVO', index: 'NOMBRE_ARCHIVO', align: 'center', width: 350, hidden: false },
        { name: 'CODIGO_ARCHIVO', index: 'CODIGO_ARCHIVO', align: 'center', width: 100, hidden: true },
        { name: 'PESO_ARCHIVO', index: 'PESO_ARCHIVO', align: 'center', width: 100, hidden: true },
        { name: 'STR_PESO_ARCHIVO', index: 'STR_PESO_ARCHIVO', align: 'center', width: 100, hidden: false },
        { name: 'EXTENSION', index: 'EXTENSION', align: 'center', width: 100, hidden: false },
        { name: 'FLG_ARCHIVO', index: 'FLG_ARCHIVO', align: 'center', width: 100, hidden: true },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(Adjuntos_grilla, Adjuntos_barra, '', '', '', '', "", "", colNames, colModels, "", opciones);
}

function Adjunto_actionEliminar(cellvalue, options, rowObject) {
    var Btn = "<button title=\"Eliminar\" onclick='Adjunto_Eliminar(" + rowObject.CODIGO + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return Btn;
}

function Adjunto_Eliminar(id) {
    let data = $("#" + Adjuntos_grilla).getRowData(id);
    $("#" + Adjuntos_grilla).jqGrid('delRowData', id);
    if (data.FLG_ARCHIVO == 0) {
        files = files.filter(file => file.name != data.NOMBRE_ARCHIVO); 
    }
}

function Adjunto_Agregar() {
    if ($('#FrmAdjunto').valid() && ValidarExtension($('#EXTENSION').val())) {
        IdAdjunto++;
        var myData =
        {
            CODIGO: IdAdjunto,
            NOMBRE_ARCHIVO: $('#NOMBRE_ARCHIVO').val(),
            //CODIGO_ARCHIVO: CODIGO_ARCHIVO,
            STR_PESO_ARCHIVO: $('#PESO_ARCHIVO').val(), 
            PESO_ARCHIVO: $('#PESO_ARCHIVO').val(),
            EXTENSION: $('#EXTENSION').val(),
            FLG_ARCHIVO: $("#TIPO_ADJUNTO").val(),
        };
        $('#NOMBRE_ARCHIVO').val(''); 
        $('#PESO_ARCHIVO').val(''); 
        $('#EXTENSION').val(''); 
        jQuery("#" + Adjuntos_grilla).jqGrid('addRowData', IdAdjunto, myData);
    }
}

function ValidarExtension(extension) {
    if (!extensionValid.test(extension)) {
        jAlert('Ingrese una extensión válida.', 'Atención');
        return false;
    } else
        return true;

}

function ValidarArchivoTemporal(input) {
    debugger;
    var file = input.files[0];
    var nombre = "";
    if (file != undefined) {
        var PesodeArchivo = parseFloat(file.size);
        nombre = input.files[0].name;
        var c = nombre.substring(nombre.length - 5);
        var ext = c.slice((c.lastIndexOf(".") - 1) + 2);
        if (nombre.length > 100) {
            jAlert("El nombre del documento es muy largo", 'Atención');
            $(this).val('');
            return false;
        }
        else {
            var valido = false;
            if (extensionValid.test(`${ext}`))
                valido = true;
            if (PesodeArchivo > Tamanio_Valido || !valido) {
                $(this).val('');
                if (!valido)
                    jAlert("Solo se permite documentos en formato " + extensionValid, 'Atención');
                else
                    jAlert("El archivo que va a adjuntar no puede superar los " + Tamanio_Valido / 1024 / 1024 + "Mb de peso", 'Atención');

                return false;
            } else {
                var sumaPeso = 0;
                sumaPeso = SumaPesoAnexos() + SumaPesoDocPrincipal() + PesodeArchivo;
                if (sumaPeso > Tamanio_Valido) {
                    jAlert("El total de archivos supera los " + Tamanio_Valido / 1024 / 1024 + "Mb de peso, ingresar otro archivo de menos peso", 'Atención');
                } else {
                    //Adjunto_CargarTemporal();
                    files.push(file);
                    $('#NOMBRE_ARCHIVO').val(file.name);
                    $('#PESO_ARCHIVO').val(file.size);
                    $('#EXTENSION').val(ext);
                }
            }
        }
    }
}

function SumaPesoAnexos() {
    var sumaPeso = 0;
    var rowKey = jQuery("#" + Adjuntos_grilla).getDataIDs();
    for (var i = 0; i < rowKey.length; i++) {
        var data = jQuery("#" + Adjuntos_grilla).jqGrid('getRowData', rowKey[i]);
        sumaPeso += parseFloat(data.PESO_ARCHIVO);
    }
    return sumaPeso;
}

function SumaPesoDocPrincipal() {
    var sumaPeso = 0;
    var rowKey = jQuery("#" + DocumentoAdj_grilla).getDataIDs();
    for (var i = 0; i < rowKey.length; i++) {
        var data = jQuery("#" + DocumentoAdj_grilla).jqGrid('getRowData', rowKey[i]);
        sumaPeso += parseFloat(data.NUM_SIZE_ARCHIVO);
    }
    return sumaPeso;
}

function ValidarArchivoPrincipalTemporal(input) {
    var file = input.files[0];
    var nombre = "";
    if (file != undefined) {
        var PesodeArchivo = parseFloat(file.size);
        //var ext = input.files[0].name.split('.').pop();
        nombre = input.files[0].name;
        var c = nombre.substring(nombre.length - 5);
        var ext = c.slice((c.lastIndexOf(".") - 1) + 2);
        if (nombre.length > 100) {
            jAlert("El nombre del documento es muy largo", 'Atención');
            $(this).val('');
            return false;
        }
        else {
            var valido = false;
            if (extensionValid.test(`${ext}`))
                valido = true;
            if (PesodeArchivo > Tamanio_Valido || !valido) {
                $(this).val('');
                if (!valido)
                    jAlert("Solo se permite documentos en formato " + extensionValid, 'Atención');
                else
                    jAlert("El archivo que va a adjuntar no puede superar los " + Tamanio_Valido / 1024 / 1024 + "Mb de peso", 'Atención');

                return false;
            } else {
                debugger;
                //var rowKey = $("#" + Adjuntos_grilla).jqGrid('getGridParam', 'selarrrow');
                //var data = jQuery("#" + Aprobar_grilla).jqGrid('getRowData', rowKey[0]);
                //if (nombre != data.DES_NOM_ABR) {
                //    jAlert("Adjunte el archivo correspondiente", 'Atención');
                //} else {
                //    if (filesDocPrincipal.length > 0) {
                //        if (filesDocPrincipal.indexOf(nombre) != -1) {
                //            return false;
                //        } else {
                //            filesDocPrincipal.push(file);
                //        }

                //    } else {
                //        filesDocPrincipal.push(file);
                //    }
                //}
                if ($("#EXTENSION").val().toLowerCase() == "." + ext.toLowerCase()) {
                    var sumaPeso = 0;
                    sumaPeso = SumaPesoAnexos() + SumaPesoDocPrincipal() - parseFloat($('#PESO_ARCHIVO').val());
                    sumaPeso += PesodeArchivo;
                    if (sumaPeso > Tamanio_Valido) {
                        jAlert("El total de archivos supera los " + Tamanio_Valido / 1024 / 1024 + "Mb de peso, ingresar otro archivo de menos peso", 'Atención');
                    } else {
                        $('#PESO_ARCHIVO').val(file.size);
                        filesDocPrincipal.push(file);
                        var rowKey = parseInt($('#HDF_ID_DOC').val());
                        jQuery("#" + DocumentoAdj_grilla).jqGrid('setRowData', rowKey, { "NUEVO_DOCUMENTO": nombre});
                        jQuery("#" + DocumentoAdj_grilla).jqGrid('setRowData', rowKey, { "ESTADO_CARGADO": "CARGADO" });
                        jQuery("#" + DocumentoAdj_grilla).jqGrid('setRowData', rowKey, { "FLG_CARGADO": "1" });
                        jQuery("#" + DocumentoAdj_grilla).trigger("reloadGrid");
                        jAlert("Archivo cargado correctamente ", 'Atención');
                    }
                    
                } else {
                    jAlert("Adjunte el archivo correspondiente", 'Atención');
                }
                

            }
        }
    }
}

function Adjunto_CargarTemporal() {
    var url = baseUrl + "Base/guardarTemporalArchivo";
    var options = {
        type: "POST",
        dataType: "json",
        contentType: false,
        url: url,
        resetForm: false,
        beforeSubmit: function (formData, jqForm, options) {
            fetchload.init();
        },
        success: function (response) {
            fetchload.close();
            if (response.ejecucionProceso) {
                Adjunto = new Array();
                Adjunto.push(response.objeto);
                $('#NOMBRE_ARCHIVO').val(response.objeto.nombreArchivo);
                $('#PESO_ARCHIVO').val(response.objeto.pesoArchivo);
                $('#EXTENSION').val(response.objeto.extension);
            }
            else {
                alert(response.mensajeSalida, 'Atención');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) { fetchload.close(); }
    };
    $("#FrmArchivo").ajaxForm(options);
    $("#FrmArchivo").submit();
}

/////////////////////////////////// documentos ///////////////////////////

function DocumentoAdj_ConfigurarGrilla(_tab) {
    _MICROMODULO = _tab;
    var verBotonEditar = false;
    if (_MICROMODULO == MicroModulo.Grabados) {
        verBotonEditar = true;
    }
    $("#" + DocumentoAdj_grilla).GridUnload();
    var colNames = ['Codigo', 'ID_DOC', 'ID_LASER', 'Editar', 'Ver', 'Archivo', 'Peso', 'Extensión', 'Documento Cargado', 'Estado Cargado','Flg_Cargado'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_DOC', index: 'ID_DOC', align: 'center', hidden: true, width: 0 },
        { name: 'ID_DOC_CMS', index: 'ID_DOC_CMS', align: 'center', hidden: true, width: 0, },
        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 90, hidden: verBotonEditar, formatter: DocumentoAdj_actionEditar },
        { name: 'VERDOCUMENTO', index: 'VERDOCUMENTO', align: 'center', width: 90, hidden: false, formatter: DocumentoAdj_actionver },
        { name: 'DES_NOM_ABR', index: 'DES_NOM_ABR', align: 'center', width: 200, hidden: false },
        //{ name: 'DES_OBS', index: 'DES_OBS', align: 'center', width: 200, hidden: false },
        { name: 'NUM_SIZE_ARCHIVO', index: 'NUM_SIZE_ARCHIVO', align: 'center', width: 100, hidden: false, editable: true },
        { name: 'EXTENSION', index: 'EXTENSION', align: 'center', width: 100, hidden: false, editable: true, },
        { name: 'NUEVO_DOCUMENTO', index: 'NUEVO_DOCUMENTO', align: 'center', width: 150, hidden: false, editable: true, },
        { name: 'ESTADO_CARGADO', index: 'ESTADO_CARGADO', align: 'center', width: 150, hidden: false, editable: true, },
        { name: 'FLG_CARGADO', index: 'FLG_CARGADO', align: 'center', width: 100, hidden: true, editable: true, },
        
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(DocumentoAdj_grilla, DocumentoAdj_barra, '', '', '', '', "", "", colNames, colModels, "", opciones);
}
function DocumentoAdj_actionEditar(cellvalue, options, rowObject) {
    var Btn = "<button title=\"ver\" onclick='DocumentoAdj_MostrarEditar(" + rowObject.CODIGO + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" data-target=\"#MyModalDoc\" style=\"text-decoration: none !important;\"><i class=\"clip-pencil-2\" style=\"font-size:17px\"></i></button>";
    return Btn;
}
function DocumentoAdj_MostrarEditar(id) {
    jQuery("#MyModalDoc").html('');
    jQuery("#MyModalDoc").load(baseUrl + "Digitalizacion/Recepcion/editar-documento?id=" + id, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#MyModalDoc');
        if (request.status == 200) {
            var data = $('#' + DocumentoAdj_grilla).getRowData(id);
            $('#PESO_ARCHIVO').val(data.NUM_SIZE_ARCHIVO);
            $('#EXTENSION').val(data.EXTENSION);
        }
    });
}
function DocumentoAdj_Editar() {
    if ($('#FrmDocumentoAdj').valid() && ValidarExtension($('#EXTENSION').val())) {
        var rowKey = parseInt($('#HDF_ID_DOC').val());
        $("#" + DocumentoAdj_grilla).jqGrid('setCell', rowKey, 'NUM_SIZE_ARCHIVO', $('#PESO_ARCHIVO').val());
        $("#" + DocumentoAdj_grilla).jqGrid('setCell', rowKey, 'EXTENSION', $('#EXTENSION').val());
        jQuery("#" + DocumentoAdj_grilla).trigger("reloadGrid");
        $('#MyModalDoc').modal('hide');
        $('#MyModalDoc').html('');
    }
}
function DocumentoAdj_actionver(cellvalue, options, rowObject) {
    var Btn = "<button title=\"ver\" onclick='DownloadFile(" + rowObject.ID_DOC_CMS + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-search-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return Btn;
}
function DocumentoAdj_CargarGrilla(ID_EXPE) {
    var url = "ventanilla/DocRecepcion/listado-doc-expediente/" + ID_EXPE;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            jQuery("#" + DocumentoAdj_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $.each(auditoria.Objeto, function (i, v) {
                        i = i + 1;
                        v.CODIGO = i;
                        jQuery("#" + DocumentoAdj_grilla).jqGrid('addRowData', i, v);
                    });
                    jQuery("#" + DocumentoAdj_grilla).trigger("reloadGrid");
                } else {
                    jAlert(auditoria.MensajeSalida, "Ocurrio un Error");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Ocurrio un Error");
            }
        }
    });
}
