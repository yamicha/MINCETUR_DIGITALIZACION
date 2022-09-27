//var number = [-2, 4, 6, 7, 8]; 
//calcular(number, 12); 
//function calcular(number, rst) {
//    var resultado = [];
//    var valido = false; 
//    for (i = 0; i < number.length; i++) {
//        var nu = number[i];
//        if (valido)
//            break; 
//        for (j = 0; j < number.length; j++) {
//            var nu2 = number[j];
//            if (nu + nu2 == rst) {
//                resultado.push(nu);
//                resultado.push(nu2);
//                valido = true; 
//                break; 
//            }
//        }
//    }
//    debugger; 
//    return resultado;
//}

function Lote_ConfigurarGrilla(_grilla, _barra, _multiselect) {
    $("#" + _grilla).GridUnload();
    var colNames = ['1', '2',
        'Lote', 'Fecha de Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 1, hidden: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false },
        //{ name: 'STR_SUB_LOTE_X', index: 'STR_SUB_LOTE_X', align: 'center', width: 150, hidden: false, formatter: Lote_actionVerDocumentos },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: _multiselect, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
        grouping: false,
        //groupingCampo: 'STR_GROUP_FEC_CREACION',
        selectRowFunc: function () {
            if (!_multiselect) {
                var rowKey = parseInt(jQuery("#" + _grilla).getGridParam('selrow'));
                var data = jQuery("#" + _grilla).jqGrid('getRowData', rowKey);

                if (_ID_MODULO == 3) {
                    _ID_LOTE = data.ID_LOTE;
                    if (data.ID_LOTE == undefined) _ID_LOTE = 0;
                    Asignados_buscar();
                }
            }
        },
        //tituloGrupo: 'Sub Lote(s)'
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
    id = 0; 
    var url =  `archivo-central/recepcion/listar-lotes/${id}`;
    //var auditoria = SICA.Ajax(url, item, false);
    API.FetchGet("GET", url, function (auditoria) {
        jQuery("#" + _grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    var x = 0;
                    $.each(auditoria.Objeto, function (i, v) {
                        x++;
                        var myData =
                        {
                            CODIGO: x,
                            ID_LOTE: v.ID_LOTE,
                            NRO_LOTE: v.NRO_LOTE,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            //USU_CREACION: v.USU_CREACION
                        };
                        jQuery("#" + _grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + _grilla).trigger("reloadGrid");
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
