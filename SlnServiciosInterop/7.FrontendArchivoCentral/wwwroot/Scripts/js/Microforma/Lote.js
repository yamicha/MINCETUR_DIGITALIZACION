
function Lote_ConfigurarGrilla(_grilla, _barra, _multiselect) {
    $("#" + _grilla).GridUnload();
    var colNames = ['1', '2', '3', '4',
        'Sub - Lote', 'Hora de Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_DOCUMENTO_LOTE', index: 'ID_DOCUMENTO_LOTE', align: 'center', width: 1, hidden: true },
        { name: 'STR_GROUP_FEC_CREACION', index: 'STR_GROUP_FEC_CREACION', align: 'center', width: 1, hidden: true },
        { name: 'STR_SUB_LOTE', index: 'STR_SUB_LOTE', align: 'center', width: 150, hidden: true },

        { name: 'STR_SUB_LOTE_X', index: 'STR_SUB_LOTE_X', align: 'center', width: 150, hidden: false, formatter: Lote_actionVerDocumentos },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: _multiselect, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
        grouping: true, groupingCampo: 'STR_GROUP_FEC_CREACION',
        selectRowFunc: function () {
            if (!_multiselect) {
                var rowKey = parseInt(jQuery("#" + _grilla).getGridParam('selrow'));
                var data = jQuery("#" + _grilla).jqGrid('getRowData', rowKey);

                if (_ID_MODULO == 3) {
                    _ID_LOTE = data.ID_DOCUMENTO_LOTE;
                    if (data.ID_DOCUMENTO_LOTE == undefined) _ID_LOTE = 0;
                    Asignados_buscar();
                }
            }
        },
        tituloGrupo: 'Sub Lote(s)'
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', '', "", "", colNames, colModels, "", opciones);
    jqGridResponsive($(".jqGridLote"));
}

function Lote_actionVerDocumentos(cellvalue, options, rowObject) {
    var _btn = rowObject.STR_SUB_LOTE;
    if (_ID_MODULO == 12) {
        _btn += "<button title='Ver Documentos' onclick='Lote_VerDocumentos(" + rowObject.ID_DOCUMENTO_LOTE + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;padding: 5px;\"> <i class=\"clip-search-3\" style=\"color:#a01010;font-size:15px\"></i></button>";
    }
    return _btn;
}

function Lote_VerDocumentos(CODIGO) {
    if (_ID_MODULO == 12) {
        _ID_LOTE = CODIGO;
        MicroformaGrabar_buscar();
    }
}

function Lote_CargarGrilla(_grilla, _FLG_FINALIZADO) {
    var item =
    {
        FLG_FINALIZADO: _FLG_FINALIZADO
    };
    var url = baseUrl + "Microforma/Lote/Lote_Listar";
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + _grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (!auditoria.RECHAZAR) {
                var x = 0;
                $.each(auditoria.OBJETO, function (i, v) {
                    x++;
                    var myData =
                    {
                        CODIGO: x,
                        ID_DOCUMENTO_LOTE: v.ID_DOCUMENTO_LOTE,
                        LOTE: v.LOTE,
                        STR_SUB_LOTE: v.STR_SUB_LOTE,
                        DESCRIPCION_LOTE: v.DESCRIPCION_LOTE,
                        STR_FEC_CREACION: v.STR_FEC_CREACION,
                        STR_GROUP_FEC_CREACION: v.STR_GROUP_FEC_CREACION
                    };
                    jQuery("#" + _grilla).jqGrid('addRowData', x, myData);
                });
                jQuery("#" + _grilla).trigger("reloadGrid");
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
