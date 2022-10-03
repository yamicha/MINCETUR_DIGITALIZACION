var Microforma_grilla = 'Microforma_grilla';
var Microforma_barra = 'Microforma_barra';

var Microforma_Lote_grilla = 'Microforma_Lote_grilla';
var Microforma_Lote_barra = 'Microforma_Lote_barra';

$(document).ready(function () {
    Microforma_ConfigurarGrilla();
    //Lote_ConfigurarGrilla(Microforma_Lote_grilla, Microforma_Lote_barra, false);
});

jQuery('#aTabMicroforma').click(function (e) {
    _ID_MODULO = 13;
    _ID_LOTE = 0;
    Microforma_CargarGrilla();
});

function Microforma_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Microforma_grilla + "," + Microforma_barra + ",\"Listado de documentos\", false, 13);", 500);
}

function Microforma_ConfigurarGrilla() {
    $("#" + Microforma_Lote_grilla).GridUnload();
    var colNames = ['1', '2', '3', '4',
        'Microforma', 'Fecha de Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', width: 1, hidden: true },
        { name: 'CODIGO_SOPORTE', index: 'CODIGO_SOPORTE', align: 'center', width: 1, hidden: true },
        { name: 'DESC_SOPORTE', index: 'DESC_SOPORTE', align: 'center', width: 150, hidden: true },

        { name: 'DESC_SOPORTE_X', index: 'DESC_SOPORTE_X', align: 'center', width: 150, hidden: false, formatter: Microforma_actionVerCodigo },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc',
    };
    SICA.Grilla(Microforma_Lote_grilla, Microforma_Lote_barra, '', '582', '', '', "", "", colNames, colModels, "", opciones);
    jqGridResponsive($(".jqGridLote"));
}

function Microforma_actionVerCodigo(cellvalue, options, rowObject) {
    var _btn = rowObject.CODIGO_SOPORTE;
    //if (_ID_MODULO == 13) {
    _btn += "<button title='Ver Microforma' onclick='Microforma_VerMicroforma(" + rowObject.ID_MICROFORMA + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-vynil\" style=\"color:#a01010;font-size:15px\"></i></button>";
    _btn += "<button title='Ver Documentos' onclick='Microforma_VerDocumentos(" + rowObject.ID_MICROFORMA + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;padding: 5px;\"> <i class=\"clip-search-3\" style=\"color:#a01010;font-size:15px\"></i></button>";
    //}
    return _btn;
}

function Microforma_VerMicroforma(CODIGO) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Microforma/Microforma/Microforma_Ver?ID_MICROFORMA=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_VerDocumentos(CODIGO) {
    _ID_MICROFORMA = CODIGO;
    Microforma_buscar();
}

function Microforma_CargarGrilla() {
    var item =
    {
        //FLG_FINALIZADO: _FLG_FINALIZADO
    };
    var url = baseUrl + "Microforma/Microforma/Microforma_Listar";
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + Microforma_Lote_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (!auditoria.RECHAZAR) {
                var x = 0;
                $.each(auditoria.OBJETO, function (i, v) {
                    x++;
                    var myData =
                    {
                        CODIGO: x,
                        ID_MICROFORMA: v.ID_MICROFORMA,
                        DESC_SOPORTE: v.DESC_SOPORTE,
                        CODIGO_SOPORTE: v.CODIGO_SOPORTE,
                        DESCRIPCION_LOTE: v.DESCRIPCION_LOTE,
                        STR_FEC_CREACION: v.STR_FEC_CREACION
                    };
                    jQuery("#" + Microforma_Lote_grilla).jqGrid('addRowData', x, myData);
                });
                jQuery("#" + Microforma_Lote_grilla).trigger("reloadGrid");
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