var Adjuntos_grilla = "Adjuntos_grilla";
var Adjuntos_barra = "Adjuntos_barra";

var DocumentoAdj_grilla = "DocumentoAdj_grilla";
var DocumentoAdj_barra = "DocumentoAdj_barra";

var Adjunto = new Array();
var IdAdjunto = 0;
$(document).ready(function () {
    $('#TIPO_ADJUNTO').change(function () {
        if ($(this).val() == 1) {
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
    });

    $('#BtnAgregarAdjunto').click(function () {
        Adjunto_Agregar();
    });
});

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
    $("#" + Adjuntos_grilla).jqGrid('delRowData', id);
}

function Adjunto_Agregar() {
    if ($('#FrmAdjunto').valid() && ValidarExtension($('#EXTENSION').val())) {
        IdAdjunto++;
        var CODIGO_ARCHIVO = "";
        if ($("#TIPO_ADJUNTO").val() == 0) {
            if (Adjunto.length > 0) {
                CODIGO_ARCHIVO = Adjunto[0].codigoArchivo;
            } else {
                jAlert('Por favor seleccione un archivo.', 'Atención');
            }
        }
        var myData =
        {
            CODIGO: IdAdjunto,
            NOMBRE_ARCHIVO: $('#NOMBRE_ARCHIVO').val(),
            CODIGO_ARCHIVO: CODIGO_ARCHIVO,
            STR_PESO_ARCHIVO: $('#PESO_ARCHIVO').val(), 
            PESO_ARCHIVO: $('#PESO_ARCHIVO').val(),
            EXTENSION: $('#EXTENSION').val(),
            FLG_ARCHIVO: $("#TIPO_ADJUNTO").val(),
        };
        Adjunto.pop();
        $('#NOMBRE_ARCHIVO').val(''); 
        $('#PESO_ARCHIVO').val(''); 
        $('#EXTENSION').val(''); 
        jQuery("#" + Adjuntos_grilla).jqGrid('addRowData', IdAdjunto, myData);
    }
}

function ValidarExtension(extension) {
    //var pattern = /.pdf|.zip|.rar/;
    if (!extensionValid.test(extension)) {
        jAlert('Ingrese una extensión valida.', 'Atención');
        return false;
    } else
        return true;

}

function ValidarArchivoTemporal(input) {
    var file = input.files[0];
    var nombre = "";
    if (file != undefined) {
        var PesodeArchivo = parseFloat(file.size);
        var ext = input.files[0].name.split('.').pop();
        nombre = input.files[0].name;
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
                    jAlert("La cantidad de el archivo que va adjuntar no pueden pesar más de " + Tamanio_Valido / 1024 / 1024 + "Mb", 'Atención');

                return false;
            } else {
                Adjunto_CargarTemporal();
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

function DocumentoAdj_ConfigurarGrilla() {
    $("#" + DocumentoAdj_grilla).GridUnload();
    var colNames = ['Codigo', 'ID_DOC', 'ID_LASER', 'Editar', 'Ver', 'DocumentoAdj', 'Observación', 'Peso', 'Extensión'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_DOC', index: 'ID_DOC', align: 'center', hidden: true, width: 0 },
        { name: 'ID_DOC_CMS', index: 'ID_DOC_CMS', align: 'center', hidden: true, width: 0, },
        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 90, hidden: false, formatter: DocumentoAdj_actionEditar },
        { name: 'VERDOCUMENTO', index: 'VERDOCUMENTO', align: 'center', width: 90, hidden: false, formatter: DocumentoAdj_actionver },
        { name: 'DES_NOM_ABR', index: 'DES_NOM_ABR', align: 'center', width: 200, hidden: false },
        { name: 'DES_OBS', index: 'DES_OBS', align: 'center', width: 200, hidden: false },
        { name: 'NUM_SIZE_ARCHIVO', index: 'NUM_SIZE_ARCHIVO', align: 'center', width: 100, hidden: false, editable: true },
        { name: 'EXTENSION', index: 'EXTENSION', align: 'center', width: 100, hidden: false, editable: true, },
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
    }
}
function DocumentoAdj_actionver(cellvalue, options, rowObject) {
    var Btn = "<button title=\"ver\" onclick='DownloadFile(" + rowObject.ID_DOC_CMS + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-file-pdf\" style=\"color:#e40613;font-size:17px\"></i></button>";
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
