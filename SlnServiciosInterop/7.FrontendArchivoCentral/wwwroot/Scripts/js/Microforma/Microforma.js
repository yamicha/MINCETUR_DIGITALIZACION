var MicroEstado = {
    Grabado: 1,
    Conforme: 2,
    Observado: 3,
    Detalle: 0,
}
var MicroModulo = {
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

var _MICROMODULO = 0;
function Microforma_ConfigurarGrilla(_Grilla, _Barra, _GrillaDocumento, _BarraDocumento, _tab, _select = false) {
    debugger;
    _MICROMODULO = _tab;
    var EstadoHidden = false;
    var OpcionesHidden = true;
    if (_MICROMODULO >= MicroModulo.RevisionPend) {
        EstadoHidden = true;
        OpcionesHidden = false;
    }
    var fechaGrabado = true;
    var fechaCreacion = false;
    var usuCreacion = true;
    var nroReprocesado = true;
    var url = BaseUrlApi + "archivo-central/microforma/listado-paginado";
    if (_MICROMODULO == MicroModulo.Grabados) {
        fechaGrabado = false;
        fechaCreacion = true;
        usuCreacion = false;
        nroReprocesado = false;
        url = BaseUrlApi + "archivo-central/microforma/historial-paginado";
    }
    //else if (_MICROMODULO == MicroModulo.Control) {
    //    url = BaseUrlApi + "archivo-central/microforma/historial-paginado";
    //} 

    var urlsubgrid = BaseUrlApi + "archivo-central/microforma/lote-microforma";
    $("#" + _Grilla).GridUnload();
    var colNames = ['0', 'Opciones', 'Volumen', 'Revisiones', '2', '3',
        'Microforma', 'Estado', 'Fecha de Creación', 'idestado', 'FlgConforme', 'Fecha de Grabación', 'Operador Grabación', 'Nro. Reprocesados'];
    var colModels = [
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', hidden: true, width: 1, key: true }, // 0
        { name: 'OPCIONES', index: 'OPCIONES', align: 'center', width: 80, hidden: OpcionesHidden, formatter: Microforma_OpcionesFormatter, search: false , sortable: false },// 1
        { name: 'NRO_VOLUMEN', index: 'NRO_VOLUMEN', align: 'center', width: 100, hidden: false, search: true  },// 2
        { name: 'NRO_REVISIONES', index: 'NRO_REVISIONES', align: 'center', width: 80, hidden: OpcionesHidden, search: false}, // 3
        { name: 'CODIGO_SOPORTE', index: 'CODIGO_SOPORTE', align: 'center', width: 1, hidden: true }, // 4
        { name: 'DESC_SOPORTE', index: 'DESC_SOPORTE', align: 'center', width: 300, hidden: true }, // 5
        { name: 'DESC_SOPORTE_X', index: 'DESC_SOPORTE_X', align: 'center', width: 250, hidden: false, formatter: Microforma_actionVerCodigo, sortable: false }, // 7
        { name: 'DESC_ESTADO', index: 'DESC_ESTADO', align: 'center', width: 150, hidden: EstadoHidden }, // 8
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: true, search: true }, // 9
        { name: 'ID_ESTADO', index: 'ID_ESTADO', align: 'center', width: 250, hidden: true }, // 10
        { name: 'FLG_CONFORME', index: 'FLG_CONFORME', align: 'center', width: 250, hidden: true },// 11
        //{ name: 'STR_FEC_GRABACION', index: 'STR_FEC_GRABACION', align: 'center', width: 250, hidden: fechaGrabado, search: true }, // 12
        { name: 'STR_FEC_GRABACION', index: 'STR_FEC_GRABACION', align: 'center', width: 250, hidden: false, search: true }, // 12
        { name: 'STR_USUARIO_CREACION', index: 'STR_USUARIO_CREACION', align: 'center', width: 250, hidden: false, search: true }, // 13
        { name: 'NRO_REPROCESADOS', index: 'NRO_REPROCESADOS', align: 'center', width: 250, hidden: nroReprocesado, search: true }, // 14
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
        GridLocal: false, multiselect: _select, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc',
        estadoSubGrid: true, viewrecords: true, subGrid: opcionesSubgrid, getrules: `GetRulesMicroforma()`, rules: true,
        gridCompleteFunc: function () {
            //MicroformaColorRevision(_Grilla);
        }
    };
    SICA.Grilla(_Grilla, _Barra, '', '550', '', '', url, "", colNames, colModels, "", opciones);
    $("#" + _Grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
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
        var _STR_FEC_CREACION = $('#txtFechaInicio').val();
        var _STR_FEC_FIN = $('#txtFechaFin').val();
        rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _STR_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _STR_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    }
    if (_MICROMODULO == MicroModulo.Conforme) { // conformes
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2,5)', op: " in " });
        var _STR_FEC_CREACION = $('#txtFechaInicioConforme').val();
        var _STR_FEC_FIN = $('#txtFechaFinConforme').val();
        rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _STR_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _STR_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacen) { // control almacenamiento 5
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2)', op: " in " });
        rules.push({ field: 'FLG_MICROARCHIVO', data: '0', op: " = " });
        var _STR_FEC_CREACION = $('#txtFechaInicio').val();
        var _STR_FEC_FIN = $('#txtFechaFin').val();
        rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _STR_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _STR_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    }
    if (_MICROMODULO == MicroModulo.Grabados) { // cmicro grabados 1
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(1)', op: " in " });
        var _STR_FEC_CREACION = $('#txtFechaInicioGrabada').val();
        var _STR_FEC_FIN = $('#txtFechaFinGrabada').val();
        rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _STR_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _STR_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacenFin) { // control almacen 6
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2,5)', op: " in " });
        rules.push({ field: 'FLG_MICROARCHIVO', data: '1', op: " = " });
        var _STR_FEC_CREACION = $('#txtFechaInicioConforme').val();
        var _STR_FEC_FIN = $('#txtFechaFinConforme').val();
        rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _STR_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _STR_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    }
    if (_MICROMODULO == MicroModulo.RevisionPend) { // revision pendiente
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='1' OR FLG_CONFORME IS NULL)`, op: "" });
    }
    if (_MICROMODULO == MicroModulo.RevisionObs) { // revision Obs 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='0' AND FLG_ANULADO ='0')`, op: "" });
    }
    if (_MICROMODULO == MicroModulo.RevisionAnulada) { // revision anulada 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='0' AND FLG_ANULADO ='1')`, op: "" });
    }

    _gs_NRO_VOL = $('#gs_NRO_VOLUMEN').val() != undefined ? `'${$('#gs_NRO_VOLUMEN').val()}'` : `''`;
    _gs_DESC_SPORTE = $('#gs_DESC_SOPORTE_X').val() != undefined ? `'${$('#gs_DESC_SOPORTE_X').val()}'` : `''`;
    _gs_DESC_ESTADO = $('#gs_DESC_ESTADO').val() != undefined ? `'${$('#gs_DESC_ESTADO').val()}'` : `''`;
    _gs_FEC_CREACION = $('#gs_STR_FEC_CREACION').val() != undefined ? `'${$('#gs_STR_FEC_CREACION').val()}'` : `''`;

    rules.push({ field: 'NRO_VOLUMEN', data: POR + ' || ' + _gs_NRO_VOL + ' || ' + POR, op: " LIKE " }); 
    rules.push({ field: 'CODIGO_SOPORTE', data: POR + ' || ' + _gs_DESC_SPORTE + ' || ' + POR, op: " LIKE " }); 
    rules.push({ field: 'DESC_ESTADO', data: POR + ' || ' + _gs_DESC_ESTADO + ' || ' + POR, op: " LIKE " }); 
    rules.push({ field: 'STR_FEC_CREACION', data: POR + ' || ' + _gs_FEC_CREACION + ' || ' + POR, op: " LIKE " }); 
    return rules;
}

function Microforma_actionVerCodigo(cellvalue, options, rowObject) {
    var _btn = rowObject[4];
    var _Revisiones = rowObject[10];
    if (_MICROMODULO == MicroModulo.Grabados || _MICROMODULO == MicroModulo.Conforme) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_GrabadaVer(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-vynil\" style=\"color:#a01010;font-size:15px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.Control) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_ValidarMicroforma(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-clipboard\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.Reprocesar) {
        _btn += "<br/><button title='Reprocesar Microforma' onclick='Microforma_EditarMicroforma(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-refresh\" style=\"color:;font-size:16px\"></i></button>";
        _btn += "<button title='Ver Observaciones' onclick='Microforma_VerObs(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.CAlmacen) {
        _btn += "<button title='Ingresar Micro Archivo' onclick='Microforma_MantenimientoMicroArchivo(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-folder-upload\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.CAlmacenFin) {
        _btn += "<button title='Ver Microarchivo' onclick='Microforma_VerMicroArchivo(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-paste\" style=\"color:#a01010;font-size:16px\"></i></button>";
    }

    return _btn;
}

function Microforma_OpcionesFormatter(cellvalue, options, rowObject) {
    var _btn = "";
    var _btnDevolver = "";
    var _btnReprocesar = "";
    if (_MICROMODULO == MicroModulo.RevisionObs || _MICROMODULO == MicroModulo.RevisionAnulada)
        _btnDevolver = "<li><a onclick=\"Microforma_DevolverRevision(" + rowObject[0] + ");\"  > <i class=\"clip-rotate-2\" style=\"color:;\"></i> Devolver a Revisión</a></li>";
    if (_MICROMODULO == MicroModulo.RevisionObs)
        _btnReprocesar = "<li><a onclick=\"Microforma_MostrarReprocesar(" + rowObject[0] + ");\" href='#'  data-toggle=\"modal\" data-target=\"#myModalNuevo\"  > <i class=\"clip-spinner-4\" style=\"color:#16A941;\"></i> Reprocesar Microforma</a></li>";

    _btn += "<div class=\"dropdown\" title=\"Opciones\"> " +
        " <button class=\"btn-link dropdown-toggle\" type =\"button\" data-toggle=\"dropdown\" style=\"text-decoration: none !important;\"> <i class=\"clip-list\" style=\"color:#212529;font-size:17px\"></i>" +
        "<span class=\"caret\" style=\"color:#212529;\" ></span></button>" +
        " <ul class=\"dropdown-menu\">" +
        "<li><a onclick=\"Microforma_VerRevisiones(" + rowObject[0] + ");\" data-toggle=\"modal\" data-target=\"#myModalNuevo\" > <i class=\"clip-stack\" style=\"color:#448aff;\"></i> Ver Revisiones</a></li>" +
        "<li><a onclick=\"Microforma_VerProceso(" + rowObject[0] + ");\" data-toggle=\"modal\" data-target=\"#myModalNuevo\" > <i class=\"clip-tree\" style=\"color:#448aff;\"></i> Ver Movimientos</a></li>" +
        "<li><a onclick=\"Microforma_VerMicroforma(" + rowObject[0] + ");\" data-toggle=\"modal\" data-target=\"#myModal_Documento_Grabar\" > <i class=\"clip-vynil\" style=\"color:#a01010;\"></i> Ver Microforma</a></li>" +
        _btnDevolver +
        _btnReprocesar +
        "</ul>" +
        "</div >";
    return _btn;
}

function Microforma_VerMicroArchivo(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/control-almacenamiento/Ver-microarchivo?ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_MantenimientoMicroArchivo(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/control-almacenamiento/mantenimiento-microarchivo?ID_MICROFORMA=" + ID_MICROFORMA + "&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_ActaConformidad(ID_MICROFORMA) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/mantenimiento-microarchivo?ID_MICROFORMA=" + ID_MICROFORMA + "&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_CloseModal() {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").modal('hide');
}

function Microforma_VerMicroforma(CODIGO) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/microforma-ver?ID_MICROFORMA=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}

function Microforma_GrabadaVer(CODIGO) {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/microforma-GrabadaVer?ID_MICROFORMA=" + CODIGO, function (responseText, textStatus, request) {
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
        'Usuario Observación', 'Fecha Observación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 300, hidden: false, sorttype: 'number', sortable: true },
        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 170, hidden: false, sortable: true },
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

function MicroformaColorRevision(_Grilla) {
    var rowKey = jQuery("#" + _Grilla).getDataIDs();
    for (var i = 0; i < rowKey.length; i++) {
        var data = jQuery("#" + _Grilla).jqGrid('getRowData', rowKey[i]);
        var _FLG_REPETIDO = data.FLG_CONFORME;
        if (_FLG_REPETIDO == 1 && _MICROMODULO == MicroModulo.RevisionPend) {
            $("#" + _Grilla).jqGrid('setRowData', rowKey[i], true, { background: "rgba(35, 173, 0, 0.54)" });
        } else if (_FLG_REPETIDO == 0 && _MICROMODULO == MicroModulo.RevisionPend) {
            $("#" + _Grilla).jqGrid('setRowData', rowKey[i], true, { background: "#EE6B6F" });
        }
    }
}

// proceso
function Microforma_VerProceso(ID_MICROFORMA) {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Digitalizacion/microformas/proceso?ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}
function Microforma_ProcesoConfigurarGrilla(_Grilla, _barra) {
    $("#" + _Grilla).GridUnload();
    var colNames = [
        '1', '2', '3', 'Proceso', 'Observación',
        'Usuario Creación', 'Fecha'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'ID_MICROFORMA_PROCESO', index: 'ID_MICROFORMA_PROCESO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'DESC_ESTADO', index: 'DESC_ESTADO', align: 'center', width: 200, hidden: false, sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 300, hidden: false, sortable: true },
        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 120, hidden: false, sortable: true },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false,
        search: false, sort: 'asc',
        exportarExcel: function (_grilla_base) {
            //ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(_Grilla, _barra, '', '300', '', "Procesos", '', 'ID_MICROFORMA_PROCESO', colNames, colModels, 'ID_MICROFORMA_PROCESO', opciones);
}

function Microforma_ProcesoCargarGrilla(_Grilla) {
    var item = {
        IdMicroforma: parseInt($('#hd_ID_MICROFORMA').val()),
        //IdEstado: MicroEstado.Observado
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
                            ID_MICROFORMA_PROCESO: v.ID_MICROFORMA_PROCESO,
                            DESC_ESTADO: v.DESC_ESTADO,
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

// revision 
function Microforma_VerRevisiones(ID_MICROFORMA) {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Digitalizacion/revision-periodica/ver-revisiones?ID_MICROFORMA=" + ID_MICROFORMA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function Revision_ConfigurarGrilla(_Grilla, _Barra) {
    $("#" + _Grilla).GridUnload();
    var colNames = [
        '1', '2', 'Acta', 'Fecha Revisión', 'Responsable',
        'Conforme', 'Accion', 'Tipo Pruebas', 'Observación', 'ID_DOC'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_REVISION', index: 'ID_REVISION', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'ACTA', index: 'ACTA', align: 'center', width: 80, hidden: false, formatter: Revision_ActaFormatter, sortable: false },// 1
        { name: 'FEC_REVISION', index: 'FEC_REVISION', align: 'center', width: 150, hidden: false, sortable: true },
        { name: 'RESPONSABLE', index: 'RESPONSABLE', align: 'center', width: 200, hidden: false, sorttype: 'number', sortable: true },
        { name: 'STR_FLG_CONFORME', index: 'STR_FLG_CONFORME', align: 'center', width: 100, hidden: false, sortable: true },
        { name: 'STR_FLG_ACCION', index: 'STR_FLG_ACCION', align: 'center', width: 100, hidden: false, sortable: true },
        { name: 'TIPO_PRUEBA', index: 'TIPO_PRUEBA', align: 'center', width: 300, hidden: false, sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 200, hidden: false, sortable: true },
        { name: 'ID_DOC_REVISION', index: 'ID_DOC_REVISION', align: 'center', width: 200, hidden: true, sortable: true },


    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false, search: false, sort: 'desc',
        exportarExcel: function (_grilla_base) {
            //ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(_Grilla, _Barra, '', '300', '', "Revisiones", '', 'ID_REVISION', colNames, colModels, 'ID_REVISION', opciones);
}
function Revision_ActaFormatter(cellvalue, options, rowObject) {
    var _btn = "<button title='Descargar Formato Revisión' onclick='DownloadFile(" + rowObject.ID_DOC_REVISION + ");' class=\"btn btn-link\" type=\"button\"  style=\"text-decoration: none !important;cursor: pointer;\"> <i class=\"clip-file-pdf\" style=\"color:#a01010;font-size:15px\"></i></button>";
    return _btn;
}

function Revision_CargarGrilla(_Grilla) {
    IdMicroforma = parseInt($('#hd_ID_MICROFORMA').val());
    var url = `archivo-central/microforma/get-revision/${IdMicroforma}`;
    API.FetchGet("GET", url, function (auditoria) {
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
                            ID_REVISION: v.ID_REVISION,
                            RESPONSABLE: v.RESPONSABLE,
                            STR_FLG_CONFORME: v.STR_FLG_CONFORME,
                            STR_FLG_ACCION: v.STR_FLG_ACCION,
                            TIPO_PRUEBA: v.TIPO_PRUEBA,
                            OBSERVACION: v.OBSERVACION,
                            FEC_REVISION: v.FEC_REVISION,
                            ID_DOC_REVISION: v.ID_DOC_REVISION

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

// extras
function Microforma_GetOne(id) {
    var url = `archivo-central/microforma/get-microforma/${id}`;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $('#MICROFORMA_DESC_SOPORTE').val(auditoria.Objeto.DESC_SOPORTE);
                    $('#MICROFORMA_CODIGO_FEDATARIO').val(auditoria.Objeto.CODIGO_FEDATARIO);
                    $('#MICROFORMA_FECHA').val(auditoria.Objeto.FECHA);
                    $('#MICROFORMA_HORA').val(auditoria.Objeto.HORA);
                    $('#MICROFORMA_ACTA').val(auditoria.Objeto.NRO_ACTA);
                    $('#MICROFORMA_COPIAS').val(auditoria.Objeto.NRO_COPIAS);
                    $('#MICROFORMA_OBSERVACION').val(auditoria.Objeto.OBSERVACION);
                    $('#MICROFORMA_CODIGO_SOPORTE').val(auditoria.Objeto.CODIGO_SOPORTE);
                    $('#MICROFORMA_NROVOLUMEN').val(auditoria.Objeto.NRO_VOLUMEN);
                    $('#MicroActaApertura').attr('data-file', auditoria.Objeto.ID_DOC_APERTURA);
                    $('#MicroActaCierre').attr('data-file', auditoria.Objeto.ID_DOC_CIERRE);
                    if (auditoria.Objeto.ID_DOC_CONFORMIDAD != 0) {
                        $('#Conten_ActaConform').show();
                        $('#MicroActaConformidad').attr('data-file', auditoria.Objeto.ID_DOC_CONFORMIDAD);
                    }
                    $('a[download-file="yes"]').click(function () {
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

function MicroformaFinalizado_GetOne(id) {
    var url = `archivo-central/microforma/get-microforma/${id}`;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $('#MICROFORMA_DESC_SOPORTE').val(auditoria.Objeto.DESC_SOPORTE);
                    $('#MICROFORMA_CODIGO_FEDATARIO').val(auditoria.Objeto.CODIGO_FEDATARIO);
                    $('#MICROFORMA_FECHA').val(auditoria.Objeto.FECHA);
                    $('#MICROFORMA_HORA').val(auditoria.Objeto.HORA);
                    $('#MICROFORMA_ACTA').val(auditoria.Objeto.NRO_ACTA);
                    $('#MICROFORMA_COPIAS').val(auditoria.Objeto.NRO_COPIAS);
                    $('#MICROFORMA_OBSERVACION').val(auditoria.Objeto.OBSERVACION);
                    $('#MICROFORMA_CODIGO_SOPORTE').val(auditoria.Objeto.CODIGO_SOPORTE);
                    $('#MICROFORMA_NROVOLUMEN').val(auditoria.Objeto.NRO_VOLUMEN);
                    $('#MicroActaApertura').attr('data-file', auditoria.Objeto.ID_DOC_APERTURA);
                    $('#MicroActaCierre').attr('data-file', auditoria.Objeto.ID_DOC_CIERRE);
                    $('#MA_TIPO_ARCHIVO').val(auditoria.Objeto.MicroArchivo.TIPO_ARCHIVO);
                    $('#MA_RESPONSABLE').val(auditoria.Objeto.MicroArchivo.RESPONSABLE);
                    $('#MICROFORMA_FECHA').val(auditoria.Objeto.MicroArchivo.FECHA);
                    $('#MA_OBSERVACION').val(auditoria.Objeto.MicroArchivo.OBSERVACION);
                    $('#MA_DIRECCION').val(auditoria.Objeto.MicroArchivo.DIRECCION);
                    $('#MA_FECHA').val(auditoria.Objeto.MicroArchivo.FECHA);
                    $('#MA_HORA').val(auditoria.Objeto.MicroArchivo.HORA);
                    $('#MicroArchivoActa').attr('data-file', auditoria.Objeto.MicroArchivo.ID_DOC_ALMACENAMIENTO);
                    if (auditoria.Objeto.ID_DOC_CONFORMIDAD != 0) {
                        $('#Conten_ActaConform').show();
                        $('#MicroActaConformidad').attr('data-file', auditoria.Objeto.ID_DOC_CONFORMIDAD);
                    }
                    $('a[download-file="yes"]').click(function () {
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

//MODULO REVISION PERIODICA
function MicroformaRevisionPeriodica_ConfigurarGrilla(_Grilla, _Barra, _GrillaDocumento, _BarraDocumento, _tab, _select = false) {
    _MICROMODULO = _tab;
    var EstadoHidden = false;
    var OpcionesHidden = true;
    if (_MICROMODULO >= MicroModulo.RevisionPend) {
        EstadoHidden = true;
        OpcionesHidden = false;
    }
    var url = BaseUrlApi + "archivo-central/microforma/listado-paginado";
    var urlsubgrid = BaseUrlApi + "archivo-central/microforma/lote-microforma";
    $("#" + _Grilla).GridUnload();
    var colNames = ['0', 'Opciones', 'Volumen', 'Revisiones', '2', '3',
        'Microforma', 'Estado', 'Fecha de Grabación', 'idestado', 'FlgConforme'];
    var colModels = [
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', hidden: true, width: 1, key: true }, // 0
        { name: 'OPCIONES', index: 'OPCIONES', align: 'center', width: 80, hidden: OpcionesHidden, formatter: Microforma_OpcionesFormatter, search: false, sortable: false },// 1
        { name: 'NRO_VOLUMEN', index: 'NRO_VOLUMEN', align: 'center', width: 100, hidden: false, search: true },// 2
        { name: 'NRO_REVISIONES', index: 'NRO_REVISIONES', align: 'center', width: 80, hidden: OpcionesHidden, search: false }, // 3
        { name: 'CODIGO_SOPORTE', index: 'CODIGO_SOPORTE', align: 'center', width: 1, hidden: true }, // 4
        { name: 'DESC_SOPORTE', index: 'DESC_SOPORTE', align: 'center', width: 300, hidden: true }, // 5
        { name: 'DESC_SOPORTE_X', index: 'DESC_SOPORTE_X', align: 'center', width: 250, hidden: false, formatter: Microforma_actionVerCodigo, sortable: false }, // 6
        { name: 'DESC_ESTADO', index: 'DESC_ESTADO', align: 'center', width: 150, hidden: EstadoHidden }, // 7
        { name: 'STR_FEC_GRABACION', index: 'STR_FEC_GRABACION', align: 'center', width: 250, hidden: false, search: false }, // 8
        { name: 'ID_ESTADO', index: 'ID_ESTADO', align: 'center', width: 250, hidden: true }, // 10
        { name: 'FLG_CONFORME', index: 'FLG_CONFORME', align: 'center', width: 250, hidden: true },// 11

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
        GridLocal: false, multiselect: _select, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc',
        estadoSubGrid: true, viewrecords: true, subGrid: opcionesSubgrid, getrules: `GetRulesMicroformaRevisionPeriodica()`, rules: true,
        gridCompleteFunc: function () {
            //MicroformaColorRevision(_Grilla);
        }
    };
    SICA.Grilla(_Grilla, _Barra, '', '550', '', '', url, "", colNames, colModels, "", opciones);
    $("#" + _Grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
    jqGridResponsive($(".jqGridLote"));
}

function GetRulesMicroformaRevisionPeriodica() {
    var rules = new Array();
    var POR = "'%'";
    if (_MICROMODULO == MicroModulo.Reprocesar) { // Reprocesar
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(3)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.Control) { // Reprocesador, grabados
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(1,4)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.Conforme) { // conformes
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2,5)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacen) { // control almacen
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2)', op: " in " });
        rules.push({ field: 'FLG_MICROARCHIVO', data: '0', op: " = " });
    }
    if (_MICROMODULO == MicroModulo.Grabados) { // cmicro grabados
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(1)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacenFin) { // control almacen
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2,5)', op: " in " });
        rules.push({ field: 'FLG_MICROARCHIVO', data: '1', op: " = " });
    } if (_MICROMODULO == MicroModulo.RevisionPend) { // revision pendiente 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='1' OR FLG_CONFORME IS NULL)`, op: "" });
    }
    if (_MICROMODULO == MicroModulo.RevisionObs) { // revision Obs 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='0' AND FLG_ANULADO ='0')`, op: "" });
    }
    if (_MICROMODULO == MicroModulo.RevisionAnulada) { // revision anulada 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='0' AND FLG_ANULADO ='1')`, op: "" });
    }

    _gs_NRO_VOL = $('#gs_NRO_VOLUMEN').val() != undefined ? `'${$('#gs_NRO_VOLUMEN').val()}'` : `''`;
    _gs_DESC_SPORTE = $('#gs_DESC_SOPORTE_X').val() != undefined ? `'${$('#gs_DESC_SOPORTE_X').val()}'` : `''`;
    _gs_DESC_ESTADO = $('#gs_DESC_ESTADO').val() != undefined ? `'${$('#gs_DESC_ESTADO').val()}'` : `''`;
    //_gs_FEC_CREACION = $('#gs_STR_FEC_CREACION').val() != undefined ? `'${$('#gs_STR_FEC_CREACION').val()}'` : `''`;
    debugger;
    if (_MICROMODULO == 7) {
        _gs_FEC_CREACION = $('#txtFechaInicio').val();
        _gs_FEC_FIN = $('#txtFechaFin').val();
    } else if (_MICROMODULO == 8) {
        _gs_FEC_CREACION = $('#txtFechaInicioObservado').val();
        _gs_FEC_FIN = $('#txtFechaFinObservado').val();
    } else if (_MICROMODULO == 9) {
        _gs_FEC_CREACION = $('#txtFechaInicioAnulada').val();
        _gs_FEC_FIN = $('#txtFechaFinAnulada').val();
    }
    

    rules.push({ field: 'NRO_VOLUMEN', data: POR + ' || ' + _gs_NRO_VOL + ' || ' + POR, op: " LIKE " });
    rules.push({ field: 'CODIGO_SOPORTE', data: POR + ' || ' + _gs_DESC_SPORTE + ' || ' + POR, op: " LIKE " });
    rules.push({ field: 'DESC_ESTADO', data: POR + ' || ' + _gs_DESC_ESTADO + ' || ' + POR, op: " LIKE " });
    //rules.push({ field: 'STR_FEC_CREACION', data: POR + ' || ' + _gs_FEC_CREACION + ' || ' + POR, op: " LIKE " });
    rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _gs_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _gs_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    return rules;
}
