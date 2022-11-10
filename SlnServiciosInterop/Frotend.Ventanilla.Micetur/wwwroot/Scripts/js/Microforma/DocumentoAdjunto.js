let DocumentoAdjunto_grilla = "DocumentoAdjunto_grilla";
let DocumentoAdjunto_barra = "DocumentoAdjunto_barra";


function DocumentoAdjuntos_ConfigurarGrilla(tipoProceso = "") {
    let btnAdjuntoDelete = false;
    let btnAdjuntoEdit = false;
    if (tipoProceso != "Edit") {
        btnAdjuntoDelete = true;
        btnAdjuntoEdit = true;
    }
    $("#" + DocumentoAdjunto_grilla).GridUnload();
    var colNames = ['Codigo', 'ID_DOC', 'ID_LASER', 'Eliminar', 'Editar', 'Ver', 'Documento','Documento', 'Peso', 'Extensión','Link'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_DOC', index: 'ID_DOC', align: 'center', hidden: true, width: 0 },
        { name: 'ID_DOC_CMS', index: 'ID_DOC_CMS', align: 'center', hidden: true, width: 0, },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: btnAdjuntoEdit, formatter: DocumentoAdjunto_actionEliminar },
        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 90, hidden: btnAdjuntoEdit, formatter: DocumentoAdjunto_actionEditar },
        { name: 'VERDOCUMENTO', index: 'VERDOCUMENTO', align: 'center', width: 90, hidden: false, formatter: DocumentoAdjunto_actionver },
        { name: '_DES_NOM_ABR', index: '_DES_NOM_ABR', align: 'center', width: 450, hidden: false, formatter: DocumentoAdjunto_actionDocumento },
        { name: 'DES_NOM_ABR', index: 'DES_NOM_ABR', align: 'center', width: 200, hidden: true},
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
    var Btn = "<button title=\"ver\" onclick='DocumentoAdj_MostrarEditar(" + rowObject.CODIGO + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" data-target=\"#MyModalDoc\" style=\"text-decoration: none !important;\"><i class=\"clip-pencil-2\" style=\"font-size:17px\"></i></button>";
    return Btn;
}
function DocumentoAdjunto_actionDocumento(cellvalue, options, rowObject) {
    let Link = rowObject.DES_NOM_ABR; 
    if (rowObject.FLG_LINK == 1) {
        Link = "<a title=\"ver\" href=" + Link+" target=\"_blank\" class=\" btn-link\" type=\"button\" ><i class=\"clip-new-tab\"></i> " + Link+"</a>";
    }  
    return Link;
}
function DocumentoAdjunto_actionver(cellvalue, options, rowObject) {
    let Btn 
    if (rowObject.FLG_LINK == 0) {
         Btn = "<button title=\"ver\" onclick='DownloadFile(" + rowObject.ID_DOC_CMS + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-file-pdf\" style=\"color:#e40613;font-size:17px\"></i></button>";
    } else {
        Btn = "-"; 
    }
    return Btn;
}
function DocumentoAdjunto_actionEliminar(cellvalue, options, rowObject) {
    var Btn = "<button title=\"Eliminar\" onclick='Adjunto_Eliminar(" + rowObject.CODIGO + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
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
    $("#" + _grilla).jqGrid('footerData', 'set', { NUM_SIZE_ARCHIVO: ' Peso: ' + formatBytes(peso, TypeSize.MB) +" MB" });
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
