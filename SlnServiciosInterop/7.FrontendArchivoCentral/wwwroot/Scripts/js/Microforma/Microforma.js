var MicroEstado = {
    Grabado: 1,
    Conforme: 2,
    Observado: 3,
    Todos : 0, 
}

var _MICROMODULO = 0; 
function Microforma_ConfigurarGrilla(_Grilla, _Barra, _GrillaDocumento, _BarraDocumento) {
    var urlsubgrid = BaseUrlApi + "archivo-central/microforma/lote-microforma";
    $("#" + _Grilla).GridUnload();
    var colNames = ['1', '2', '3', '4',
        'Microforma', 'Estado', 'Fecha de Creación', 'idestado'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, },
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', width: 1, hidden: true, key: true },
        { name: 'CODIGO_SOPORTE', index: 'CODIGO_SOPORTE', align: 'center', width: 1, hidden: true },
        { name: 'DESC_SOPORTE', index: 'DESC_SOPORTE', align: 'center', width: 250, hidden: true },
        { name: 'DESC_SOPORTE_X', index: 'DESC_SOPORTE_X', align: 'center', width: 200, hidden: false, formatter: Microforma_actionVerCodigo },
        { name: 'DESC_ESTADO', index: 'DESC_ESTADO', align: 'center', width: 150, hidden: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'ID_ESTADO', index: 'ID_ESTADO', align: 'center', width: 250, hidden: true }
    ];
    var colNames_2 = ['ID', 'Lote', 'Fecha de Creación'];
    var colModels_2 = [
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 1, hidden: true, sortable: false, key: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 200, hidden: false, sortable: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false },
    ];
    var opcionesSubgrid = {
        ColNames: colNames_2, Url: urlsubgrid, ColModels: colModels_2, Width: 595, Height: '',
        selectRowFunc: function (rowkey) {
            if (rowkey == undefined) _ID_LOTE = 0;
            _ID_LOTE = parseInt(rowkey);
            Documento_Detalle_buscar(_GrillaDocumento, _BarraDocumento);
        }
    }
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc',
        estadoSubGrid: true, viewrecords: true, subGrid: opcionesSubgrid,
    };
    SICA.Grilla(_Grilla, _Barra, '', '582', '', '', "", "", colNames, colModels, "", opciones);
    jqGridResponsive($(".jqGridLote"));
}

function Microforma_actionVerCodigo(cellvalue, options, rowObject) {
    var _btn = rowObject.CODIGO_SOPORTE;
    if (_MICROMODULO == 0) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_VerMicroforma(" + rowObject.ID_MICROFORMA + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-vynil\" style=\"color:#a01010;font-size:15px\"></i></button>";
    } else if (_MICROMODULO == 1) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_ValidarMicroforma(" + rowObject.ID_MICROFORMA + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-clipboard\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == 3) {
        _btn += "<br/><button title='Ver Microforma' onclick='Microforma_EditarMicroforma(" + rowObject.ID_MICROFORMA + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-refresh\" style=\"color:;font-size:16px\"></i></button>";
        _btn += "<button title='Ver Observaciones' onclick='Microforma_VerObs(" + rowObject.ID_MICROFORMA + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:16px\"></i></button>";
    }
    return _btn;
}

function Microforma_VerMicroforma(CODIGO) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/microforma-ver?ID_MICROFORMA=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_ValidarMicroforma(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/microforma-validar?ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_EditarMicroforma(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/mantenimiento?accion=M&ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_VerObs(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/ver-observaciones?accion=M&ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_Ver_Obs_ConfigurarGrilla() {
    var Microforma_Ver_Obs_grilla = "Microforma_Ver_Obs_grilla"; 
    var Microforma_Ver_Obs_barra = "Microforma_Ver_Obs_barra"; 
    $("#" + Microforma_Ver_Obs_grilla).GridUnload();
    var colNames = [
        '1', '2','Observación',
        'Usuario Creación', 'Fecha Observación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 300, hidden: false, sorttype: 'number', sortable: true },
        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 120, hidden: false, sortable: true },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false, search: false,
        exportarExcel: function (_grilla_base) {
            //ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(Microforma_Ver_Obs_grilla, Microforma_Ver_Obs_barra, '', '300', '', "Listado de observaciones", '', '', colNames, colModels, '', opciones);
}

function Microforma_Ver_Obs_CargarGrilla() {
    var _Grilla = "Microforma_Ver_Obs_grilla"; 
    var item = {
        IdMicroforma: parseInt($('#hd_Microforma_Ver_ID_MICROFORMA').val()),
        IdEstado: MicroEstado.Observado 
    }
    var url = `archivo-central/microforma/get-procesos`;
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + _Grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
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
                            OBSERVACION: v.OBSERVACION,
                            USU_CREACION: v.USU_CREACION,
                            FEC_CREACION: v.FEC_CREACION,

                        };
                        jQuery("#" + _Grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + _Grilla).trigger("reloadGrid");
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

function Microforma_CargarGrilla(_Grilla, _Estado) {
    var item = {
        IdEstado: _Estado  
    }
    var url = "archivo-central/microforma/listar";
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + _Grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
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
                        jQuery("#" + _Grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + _Grilla).trigger("reloadGrid");
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