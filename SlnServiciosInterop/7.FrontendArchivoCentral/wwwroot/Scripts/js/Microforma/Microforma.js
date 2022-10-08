var MicroEstado = {
    Grabado: 1,
    Conforme: 2,
    Observado: 3,
    Detalle: 0,
}
var MicroModulo = {
    Detalle: 1,
    Reprocesar: 2,
    Control: 3,
    Conforme: 4,
    CAlmacen: 5,
}

var _MICROMODULO = 0;
function Microforma_ConfigurarGrilla(_Grilla, _Barra, _GrillaDocumento, _BarraDocumento, _tab) {
    debugger;
    _MICROMODULO = _tab;
    var url = BaseUrlApi + "archivo-central/microforma/listado-paginado";
    var urlsubgrid = BaseUrlApi + "archivo-central/microforma/lote-microforma";
    $("#" + _Grilla).GridUnload();
    var colNames = ['1', '2', '3', '4',
        'Microforma', 'Estado', 'Fecha de Creación', 'idestado'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, }, // 0
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', width: 1, hidden: true, key: true },// 1
        { name: 'CODIGO_SOPORTE', index: 'CODIGO_SOPORTE', align: 'center', width: 1, hidden: true }, // 2
        { name: 'DESC_SOPORTE', index: 'DESC_SOPORTE', align: 'center', width: 250, hidden: true }, // 3
        { name: 'DESC_SOPORTE_X', index: 'DESC_SOPORTE_X', align: 'center', width: 200, hidden: false, formatter: Microforma_actionVerCodigo }, // 4
        { name: 'DESC_ESTADO', index: 'DESC_ESTADO', align: 'center', width: 150, hidden: false }, // 5
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false }, // 6
        { name: 'ID_ESTADO', index: 'ID_ESTADO', align: 'center', width: 250, hidden: true } // 7
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
        GridLocal: false, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc',
        estadoSubGrid: true, viewrecords: true, subGrid: opcionesSubgrid, getrules: GetRulesMicroforma(), rules: true,
    };
    SICA.Grilla(_Grilla, _Barra, '', '582', '', '', url, "", colNames, colModels, "", opciones);
    jqGridResponsive($(".jqGridLote"));
}


function GetRulesMicroforma() {
    var rules = new Array();
    var POR = "'%'";
    if (_MICROMODULO == MicroModulo.Reprocesar) { // Reprocesar
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(3)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.Control) { // Reprocesador, grabados
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(1,4)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.Conforme) { // conformes
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacen) { // control almacen
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2)', op: " in " });
    }
    return rules;
}

function Microforma_actionVerCodigo(cellvalue, options, rowObject) {
    var _btn = rowObject[2];
    if (_MICROMODULO == 1 || _MICROMODULO == 4) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_VerMicroforma(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-vynil\" style=\"color:#a01010;font-size:15px\"></i></button>";
    } else if (_MICROMODULO == 3) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_ValidarMicroforma(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-clipboard\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == 2) {
        _btn += "<br/><button title='Ver Microforma' onclick='Microforma_EditarMicroforma(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-refresh\" style=\"color:;font-size:16px\"></i></button>";
        _btn += "<button title='Ver Observaciones' onclick='Microforma_VerObs(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == 5) {
        _btn += "<button title='Ingresar Micro Archivo' onclick='Microforma_MantenimientoMicroArchivo(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-folder-upload\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    }
    return _btn;
}

function Microforma_MantenimientoMicroArchivo(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/mantenimiento-microarchivo?ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
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
        '1', '2', 'Observación',
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