var _ID_MODULO = 0;
var _ID_LOTE = 0;
var _ID_MICROFORMA = 0;
var _PREFIJO = "";

var Documento_Ver_Obs_grilla = "Documento_Ver_Obs_grilla";
var Documento_Ver_Obs_barra = "Documento_Ver_Obs_barra";

var Documento_Ver_Proceso_grilla = "Documento_Ver_Proceso_grilla";
var Documento_Ver_Proceso_barra = "Documento_Ver_Proceso_barra";


// _id_tab - Leyenda :
// 2 : Asignar
// 3 : Asignados
function Documento_Detalle_buscar(_Grilla, _Barra) {
    Documento_ConfigurarGrilla(_Grilla, _Barra, "Listado de documentos", false, 0);
}

function Documento_ConfigurarGrilla(_grilla, _barra, _titulo, _multiselect, _id_tab) {
    $("#Load_Busqueda").show();
    setTimeout(() => {
        _ID_MODULO = _id_tab;
        var VER_BOTON_IMAGEN = true;
        var VER_BOTON_OBS = true;
        var _NRO_REPROCESADOHidden = true;
        var NOMBRE_BOTON_IMAGEN = "";
        var url = BaseUrlApi + 'ventanilla/documento/listar-paginado';
        if (_ID_MODULO == 0) {
            _PREFIJO = "Detalle_";
        }
        if (_ID_MODULO == 2) {
            _PREFIJO = "Asignar_";
        } else if (_ID_MODULO == 3) {
            _PREFIJO = "Asignados_";
        } else if (_ID_MODULO == 4) {
            _PREFIJO = "Digitalizar_";
        } else if (_ID_MODULO == 5) {
            _PREFIJO = "Digitalizados_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            VER_BOTON_IMAGEN = false;
        } else if (_ID_MODULO == 6) {
            _PREFIJO = "Control_Calidad_";
            NOMBRE_BOTON_IMAGEN = 'Validar Expediente';
            _NRO_REPROCESADOHidden = false;
            VER_BOTON_IMAGEN = false;
        } else if (_ID_MODULO == 7) {
            _PREFIJO = "Aprobados_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            _NRO_REPROCESADOHidden = false;
            VER_BOTON_IMAGEN = false;
        } else if (_ID_MODULO == 8) { // Reprocesar
            _PREFIJO = "Reprocesar_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            VER_BOTON_OBS = false;
        } else if (_ID_MODULO == 9) { // Reprocesados
            _PREFIJO = "Reprocesados_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            VER_BOTON_IMAGEN = false;
            VER_BOTON_OBS = false;
        } else if (_ID_MODULO == 10) {
            _PREFIJO = "Fedatar_";
            NOMBRE_BOTON_IMAGEN = 'Validar Expediente';
            VER_BOTON_IMAGEN = false;
        } else if (_ID_MODULO == 11) {
            _PREFIJO = "Fedatados_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            VER_BOTON_IMAGEN = false;
        } else if (_ID_MODULO == 12) {
            _PREFIJO = "MicroformaGrabar_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            VER_BOTON_IMAGEN = false;
        } else if (_ID_MODULO == 13) {
            _PREFIJO = "Microforma_";
            NOMBRE_BOTON_IMAGEN = 'Ver Adjuntos';
            VER_BOTON_IMAGEN = false;
        }
        $("#" + _grilla).GridUnload();
        var colNames = [
            '0', '1', '2', '3',
            NOMBRE_BOTON_IMAGEN, 'Ver Obs', 'Digitalizador', 'Nro. Reprocesados', 'Estado de Expediente', 'Nro. Expediente','Tipo Expediente','Asunto','Clasificación',
            'Num. Doc','Folios','Observación','Persona','Usuario de Creación', 'Fecha de Creación', 'Usuario de Modificación', 'Fecha de Modificación', 'Peso Adjuntos']
        var colModels = [
            { name: _PREFIJO + 'ID_DOCUMENTO', index: _PREFIJO + 'ID_DOCUMENTO ', align: 'center', hidden: true, key: true }, //0
            { name: _PREFIJO + 'ID_DOCUMENTO_ASIGNADO', index: _PREFIJO + 'ID_DOCUMENTO_ASIGNADO ', align: 'center', hidden: true, key: true }, //1
            { name: _PREFIJO + 'ID_ESTADO_DOCUMENTO', index: _PREFIJO + 'ID_ESTADO_DOCUMENTO ', align: 'center', hidden: true }, //2
            { name: _PREFIJO + 'DESCRIPCION_ESTADO', index: _PREFIJO + 'DESCRIPCION_ESTADO', align: 'center', hidden: true }, //3

            { name: _PREFIJO + 'VER_IMAGEN', index: _PREFIJO + 'VER_IMAGEN', align: 'center', width: 110, hidden: VER_BOTON_IMAGEN, formatter: Documento_actionVerImagen, search: false, sortable: false }, //4
            { name: _PREFIJO + 'VER_OBS', index: _PREFIJO + 'VER_OBS', align: 'center', width: 110, hidden: VER_BOTON_OBS, formatter: Documento_actionVerObs, search: false, sortable: false }, //5
            { name: _PREFIJO + 'NOMBRE_USUARIO', index: _PREFIJO + 'NOMBRE_USUARIO', align: 'center', width: 180, hidden: false, editable: true }, //6
            { name: _PREFIJO + 'NRO_REPROCESADOS', index: _PREFIJO + 'NRO_REPROCESADOS', align: 'center', width: 150, hidden: _NRO_REPROCESADOHidden, editable: true }, //7
            { name: _PREFIJO + '_DESCRIPCION_ESTADO', index: _PREFIJO + '_DESCRIPCION_ESTADO', align: 'center', width: 180, hidden: false, formatter: Documento_actionEstadoVerObs, sortable: false }, //8
            { name: _PREFIJO + '_ID_DOCUMENTO', index: _PREFIJO + '_ID_DOCUMENTO', align: 'center', width: 150, hidden: false, formatter: Documento_actionCodVerProceso, sortable: false }, //9

            { name: _PREFIJO + 'DES_TIP_DOC', index: _PREFIJO + 'DES_TIP_DOC ', align: 'center', width: 200, hidden: false, sortable: false, sortable: false },// 10
            { name: _PREFIJO + 'DES_ASUNTO', index: _PREFIJO + 'DES_ASUNTO ', align: 'center', width: 200, hidden: false, sortable: false, sortable: false },// 11
            { name: _PREFIJO + 'DES_CLASIF', index: _PREFIJO + 'DES_CLASIF ', align: 'center', width: 200, hidden: false, sortable: false, sortable: false },// 12
            { name: _PREFIJO + 'NUM_DOC', index: _PREFIJO + 'NUM_DOC ', align: 'center', width: 100, hidden: false, sortable: false, sortable: false },// 13
            { name: _PREFIJO + 'NUM_FOLIOS', index: _PREFIJO + 'NUM_FOLIOS ', align: 'center', width: 100, hidden: false, sortable: false, sortable: false },// 14
            { name: _PREFIJO + 'DES_OBS', index: _PREFIJO + 'DES_OBS ', align: 'center', width: 200, hidden: false, sortable: false, sortable: false },// 15 
            { name: _PREFIJO + 'DES_PERSONA', index: _PREFIJO + 'DES_PERSONA ', align: 'center', width: 200, hidden: false, sortable: false, sortable: false },// 15

            { name: _PREFIJO + 'USU_CREACION', index: _PREFIJO + 'USU_CREACION ', align: 'center', width: 140, hidden: false, sortable: false, sortable: false },// 16
            { name: _PREFIJO + 'STR_FEC_CREACION', index: _PREFIJO + 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: false, sortable: false, sortable: false },// 17
            { name: _PREFIJO + 'USU_MODIFICACION', index: _PREFIJO + 'USU_MODIFICACION ', align: 'center', width: 160, hidden: false, sortable: false, sortable: false },// 18
            { name: _PREFIJO + 'STR_FEC_MODIFICACION', index: _PREFIJO + 'STR_FEC_MODIFICACION ', align: 'center', width: 150, hidden: false, sortable: false, sortable: false },// 19
            { name: _PREFIJO + 'PESO_ADJ', index: _PREFIJO + 'PESO_ADJ ', align: 'center', width: 150, hidden: true, sortable: false },// 20
        ];
        var opciones = {
            GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: _multiselect, rules: true, exportar: true, exportar: true,
            sort: 'desc', getrules: `GetRulesDoc()`,
            gridCompleteFunc: function () {
                $("#Load_Busqueda").hide();
                ConfigurarColor(_grilla);

                var allJQGridData = $("#" + _grilla).jqGrid('getRowData');
                if (allJQGridData.length == 0) {
                    $(".ui-jqgrid-hdiv").css("overflow-x", "auto");
                }
                else {
                    //
                    var e = $(".ui-jqgrid-hdiv");
                    var ex = $(".ui-jqgrid-bdiv");
                    //scrollHeight: 68
                    for (var ii = 0; ii < e.length; ii++) {
                        e[ii].scrollLeft = ex[ii].scrollLeft;
                        //e[1].scrollLeft = ex[1].scrollLeft;
                    }
                    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
                    //jQuery("#" + _grilla).trigger("reloadGrid");
                }
                jQuery("#" + _grilla).jqGrid('setLabel', 0, 'NewLabel');
            },
            exportarExcel: function () {
                Documento_Exportar(GetRules());
            }
        };
        SICA.Grilla(_grilla, _barra, '', '500', '', _titulo, url, _PREFIJO + 'ID_DOCUMENTO', colNames, colModels, 'ID_DOCUMENTO', opciones);
        $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
        jqGridResponsive($(".Tabla_jqGrid"));

        jQuery("#" + _grilla).jqGrid('setLabel', 0, 'NewLabel');
        $("#" + _grilla + "_cb").css("width", "30px");
        $("#" + _grilla + "_cb tbody tr").children().first("td").css("width", "30px");
    }, 500);
}

function Documento_actionVerImagen(cellvalue, options, rowObject) {
    var _btn = "";
    if (_ID_MODULO == 6 || _ID_MODULO == 10) {
        _btn = "<button title='Ver Imagen' onclick='Documento_ValidarImagen(" + rowObject[0] + "," + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'> <i class=\"clip-images\" style=\"color:#a01010;font-size:20px\"></i></button>";
    } else {
        _btn = "<button title='Ver Imagen' onclick='Documento_VerImagen(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'> <i class=\"clip-images\" style=\"color:#a01010;font-size:20px\"></i></button>";
    }
    return _btn;
}

function Documento_actionVerObs(cellvalue, options, rowObject) {
    var _btn = "";
    _btn = "<button title='Ver Observaciones' onclick='Documento_Ver_Obs(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'><i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}

function Documento_actionEstadoVerObs(cellvalue, options, rowObject) {
    var _btn = rowObject[3];
    if (rowObject[2] == 6)
        _btn += " <button title='Ver Observaciones' onclick='Documento_Ver_Obs(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'><i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:15px\"></i></button>";
    return _btn;
}

function Documento_actionCodVerProceso(cellvalue, options, rowObject) {
    var _btn = rowObject[0];
    if (_ID_MODULO != 2)
        _btn += " <br/> <button title='Ver Movimientos' onclick='Documento_Ver_Proceso(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen' style=\"color:#a01010;font-size:12px\"><i class=\"clip-stack\"></i> Movimientos</button>";
    return _btn;
}

function Documento_VerImagen(ID_DOCUMENTO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Digitalizacion/documento/ver-imagen?ID_DOCUMENTO=" + ID_DOCUMENTO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function Documento_Ver_Obs(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Digitalizacion/documento/ver-Obs?ID_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function Documento_Ver_Proceso(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Digitalizacion/documento/ver-proceso?ID_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function Documento_ValidarImagen(ID_DOCUMENTO, ID_ASIGNADO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Digitalizacion/documento/validar-imagen?ID_DOCUMENTO=" + ID_DOCUMENTO + "&ID_DOCUMENTO_ASIGNADO=" + ID_ASIGNADO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function GetRulesDoc() {
    var rules = new Array();
    var _ID_CONTROL_CARGA = null;
    var _ID_ESTADO_DOCUMENTO = null;
    //if (_ID_MODULO == 1) { // Carga temporales
    //    _ID_CONTROL_CARGA = jQuery('#ID_CONTROL_CARGA').val() == '' ? '0' : "'" + jQuery('#ID_CONTROL_CARGA').val() + "'";
    //} else
    if (_ID_MODULO == 2) { // Asignar
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 1;
    } else if (_ID_MODULO == 3) { // Asignados
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 1;
    } else if (_ID_MODULO == 4) { // Digitalizar
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 2;
    } else if (_ID_MODULO == 5) { // Digitalizados
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 3;
    } else if (_ID_MODULO == 6) { // Aprobar
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 3;
    } else if (_ID_MODULO == 7) { // Aprobados
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 4;
    } else if (_ID_MODULO == 8) { // Reprocesar
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 5;
    } else if (_ID_MODULO == 9) { // Reprocesados
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 6;
    } else if (_ID_MODULO == 10) { // Fedatar
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 4;
    } else if (_ID_MODULO == 11) { // Fedatados
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 7;
    } else if (_ID_MODULO == 12) { // Grabar 
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 1;
    } else if (_ID_MODULO == 13) { // Microforma 
        _ID_CONTROL_CARGA = null;
        _ID_ESTADO_DOCUMENTO = 9;
    }
    _gs_NOMBRE_USUARIO = jQuery('#gs_' + _PREFIJO + 'NOMBRE_USUARIO').val();
    _gs_DESCRIPCION_ESTADO = "";
    _gs_COD_DOCUMENTO = "";
    if (_ID_MODULO != 1) {
        _gs_DESCRIPCION_ESTADO = jQuery('#gs_' + _PREFIJO + '_DESCRIPCION_ESTADO').val();
        //_gs_COD_DOCUMENTO = jQuery('#gs_' + _PREFIJO + '_COD_DOCUMENTO').val();
    } else {
        _gs_DESCRIPCION_ESTADO = jQuery('#gs_' + _PREFIJO + 'DESCRIPCION_ESTADO').val();
        //_gs_COD_DOCUMENTO = jQuery('#gs_' + _PREFIJO + 'COD_DOCUMENTO').val();
    }
    //_gs_DESC_FONDO = jQuery('#gs_' + _PREFIJO + 'DES_FONDO').val();
    //_gs_DESC_LARGA_SECCION = jQuery('#gs_' + _PREFIJO + 'DES_LARGA_SECCION').val();
    //_gs_DESC_SERIE = jQuery('#gs_' + _PREFIJO + 'DES_SERIE').val();

    //_gs_NOM_DOCUMENTO = jQuery('#gs_' + _PREFIJO + '_NOM_DOCUMENTO').val();
    //_gs_DESCRIPCION = jQuery('#gs_' + _PREFIJO + 'DESCRIPCION').val();
    //_gs_ANIO = jQuery('#gs_' + _PREFIJO + 'ANIO').val();
    //_gs_FOLIOS = jQuery('#gs_' + _PREFIJO + 'FOLIOS').val();
    //_gs_OBSERVACION = jQuery('#gs_' + _PREFIJO + 'OBSERVACION').val();

    _gs_USU_CREACION = jQuery('#gs_' + _PREFIJO + 'USU_CREACION').val();
    _gs_USU_MODIFICACION = jQuery('#gs_' + _PREFIJO + 'USU_MODIFICACION').val();

    _gs_STR_FEC_CREACION = jQuery('#gs_' + _PREFIJO + 'STR_FEC_CREACION').val();
    _gs_STR_FEC_MODIFICACION = jQuery('#gs_' + _PREFIJO + 'STR_FEC_MODIFICACION').val();


    //
    var _NOMBRE_USUARIO = _gs_NOMBRE_USUARIO == '' || _gs_NOMBRE_USUARIO == undefined ? null : "UPPER('" + _gs_NOMBRE_USUARIO + "')";
    var _DESCRIPCION_ESTADO = _gs_DESCRIPCION_ESTADO == '' || _gs_DESCRIPCION_ESTADO == undefined ? null : "'" + _gs_DESCRIPCION_ESTADO + "'";
    //var _DESC_FONDO = _gs_DESC_FONDO == '' || _gs_DESC_FONDO == undefined ? null : "UPPER('" + _gs_DESC_FONDO + "')";
    //var _DESC_LARGA_SECCION = _gs_DESC_LARGA_SECCION == '' || _gs_DESC_LARGA_SECCION == undefined ? null : "UPPER('" + _gs_DESC_LARGA_SECCION + "')";
    //var _DESC_SERIE = _gs_DESC_SERIE == '' || _gs_DESC_SERIE == undefined ? null : "UPPER('" + _gs_DESC_SERIE + "')";

    //var _NOM_DOCUMENTO = _gs_NOM_DOCUMENTO == '' || _gs_NOM_DOCUMENTO == undefined ? null : "UPPER('" + _gs_NOM_DOCUMENTO + "')";
    //var _DESCRIPCION = _gs_DESCRIPCION == '' || _gs_DESCRIPCION == undefined ? null : "UPPER('" + _gs_DESCRIPCION + "')";
    //var _ANIO = _gs_ANIO == '' || _gs_ANIO == undefined ? null : "'" + _gs_ANIO + "'";
    //var __FOLIOS = _gs_FOLIOS == '' || _gs_FOLIOS == undefined ? null : "UPPER('" + _gs_FOLIOS + "')";
    //var _OBSERVACION = _gs_OBSERVACION == '' || _gs_OBSERVACION == undefined ? null : "UPPER('" + _gs_OBSERVACION + "')";

    var POR = "'%'";

    rules = [
        //{ field: 'V.ID_CONTROL_CARGA', data: 'NVL(' + _ID_CONTROL_CARGA + ',V.ID_CONTROL_CARGA)', op: " = " },
        //{ field: 'V.DES_FONDO', data: POR + ' || ' + _DESC_FONDO + ' || ' + POR, op: " LIKE " },
        //{ field: 'V.DES_LARGA_SECCION', data: POR + ' || ' + _DESC_LARGA_SECCION + ' || ' + POR, op: " LIKE " },
        //{ field: 'V.DES_SERIE', data: POR + ' || ' + _DESC_SERIE + ' || ' + POR, op: " LIKE " },
        //{ field: 'V.NOM_DOCUMENTO', data: POR + ' || ' + _NOM_DOCUMENTO + ' || ' + POR, op: " LIKE " },
        //{ field: 'V.DESCRIPCION', data: POR + ' || ' + _DESCRIPCION + ' || ' + POR, op: " LIKE " },
        //{ field: 'V.ANIO', data: 'NVL(' + _ANIO + ',V.ANIO)', op: " = " },
        //{ field: 'V.FOLIOS', data: POR + ' || ' + __FOLIOS + ' || ' + POR, op: " LIKE " },
        //{ field: 'V.OBSERVACION', data: POR + ' || ' + _OBSERVACION + ' || ' + POR, op: " LIKE " },

    ];

    if (_ID_MODULO != 1) {
        rules.push({ field: 'V.DESCRIPCION_ESTADO', data: POR + ' || ' + _DESCRIPCION_ESTADO + ' || ' + POR, op: " LIKE " });
        if (_ID_MODULO != 2)
            rules.push({ field: 'UPPER(V.NOMBRE_USUARIO)', data: POR + ' || ' + _NOMBRE_USUARIO + ' || ' + POR, op: " LIKE " });
    }
    if (_ID_MODULO == 0) { // detalle
        //rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '' + _ID_ESTADO_DOCUMENTO + '', op: " != " });
        rules.push({ field: 'V.ID_LOTE', data: 'NVL(' + _ID_LOTE + ',V.ID_LOTE)', op: " = " });
    }
    if (_ID_MODULO == 2 || _ID_MODULO == 4 || _ID_MODULO == 5 || _ID_MODULO == 7 || _ID_MODULO == 9 || _ID_MODULO == 10 || _ID_MODULO == 11 || _ID_MODULO == 13) {
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: 'NVL(' + _ID_ESTADO_DOCUMENTO + ',V.ID_ESTADO_DOCUMENTO)', op: " = " });
    }
    if (_ID_MODULO == 3) { // Asignados
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '' + _ID_ESTADO_DOCUMENTO + '', op: " != " });
        rules.push({ field: 'V.ID_LOTE', data: 'NVL(' + _ID_LOTE + ',V.ID_LOTE)', op: " = " });
    }
    if (_ID_MODULO == 12) { // Grabar 
        rules.push({ field: 'V.ID_LOTE', data: 'NVL(' + _ID_LOTE + ',V.ID_LOTE)', op: " = " });
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: 'NVL(' + _ID_ESTADO_DOCUMENTO + ',V.ID_ESTADO_DOCUMENTO)', op: " != " });
    }
    if (_ID_MODULO == 13) { // Grabados
        rules.push({ field: 'V.ID_MICROFORMA', data: 'NVL(' + _ID_MICROFORMA + ',V.ID_MICROFORMA)', op: " = " });
    }
    if (_ID_MODULO == 6) { // Aprobar
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '(' + _ID_ESTADO_DOCUMENTO + ',6,10)', op: " in " });
    }
    if (_ID_MODULO == 8) { // Reprocesar
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '(' + _ID_ESTADO_DOCUMENTO + ',8)', op: " in " });
    }
    if (_ID_MODULO == 8) { // Reprocesar
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '(' + _ID_ESTADO_DOCUMENTO + ',8)', op: " in " });
    }
    if (_ID_MODULO == 1 || _ID_MODULO == 2) {
        rules.push({ field: 'V.USU_CREACION', data: `${$('#inputHddId_Usuario').val()}`, op: " = " });
    }
    if (_ID_MODULO != 1 && _ID_MODULO != 2 && _ID_MODULO != 3) {
        rules.push({ field: 'V.ID_USUARIO', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    return rules;
}

function Documento_Ver_Obs_CargarGrilla() {
    ID_DOCUMENTO = $("#hd_Documento_Ver_ID_DOCUMENTO").val()
    var url = `ventanilla/documento/listado-obs-documento/${ID_DOCUMENTO}`;
    API.FetchGet("GET", url, function (auditoria) {
        jQuery("#" + Documento_Ver_Obs_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $.each(auditoria.Objeto, function (i, v) {
                        var rowKey = jQuery("#" + Documento_Ver_Obs_grilla).getDataIDs();
                        var ix = rowKey.length;
                        ix++;
                        var myData =
                        {
                            CODIGO: ix,
                            ID_DOCUMENTO_OBS: v.ID_DOCUMENTO_OBS,
                            ID_DOCUMENTO: v.ID_DOCUMENTO,
                            ID_TIPO_OBSERVACION: v.ID_TIPO_OBSERVACION,
                            DESC_TIPO_OBSERVACION: v.DESC_TIPO_OBSERVACION,
                            OBSERVACION: v.OBSERVACION,
                            USU_CREACION: v.USU_CREACION,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                        };
                        jQuery("#" + Documento_Ver_Obs_grilla).jqGrid('addRowData', ix, myData);
                    });
                    jQuery("#" + Documento_Ver_Obs_grilla).trigger("reloadGrid");
                }
            }
        }
    });
}

function Documento_Ver_Obs_ConfigurarGrilla() {
    $("#" + Documento_Ver_Obs_grilla).GridUnload();
    var colNames = [
        '1', '2', '3', '4',
        'Tipo', 'Observación',
        'Usuario Creación', 'Fecha Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_DOCUMENTO_OBS', index: 'ID_DOCUMENTO_OBS', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//2
        { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'ID_TIPO_OBSERVACION', index: 'ID_TIPO_OBSERVACION', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },

        { name: 'DESC_TIPO_OBSERVACION', index: 'DESC_TIPO_OBSERVACION', align: 'center', width: 200, hidden: false, sorttype: 'number', sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 400, hidden: false, sorttype: 'number', sortable: true },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 120, hidden: false, sortable: true },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 120, hidden: false, sortable: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false, search: false,
        exportarExcel: function (_grilla_base) {
            ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(Documento_Ver_Obs_grilla, Documento_Ver_Obs_barra, '', '300', '', "Listado de observaciones", '', '', colNames, colModels, '', opciones);
}

function Documento_Ver_Proceso_ConfigurarGrilla() {
    $("#" + Documento_Ver_Proceso_grilla).GridUnload();
    var colNames = [
        '1', '2', '3',
        'Proceso', 'Inicio', 'Fin', 'Comentario',
        'Usuario Creación', 'Fecha Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },
        { name: 'ID_DOCUMENTO_PROCESO', index: 'ID_DOCUMENTO_PROCESO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },
        { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },

        { name: 'DESCRIPCION_ESTADO', index: 'DESCRIPCION_ESTADO', align: 'center', width: 160, hidden: false, sorttype: 'number', sortable: true },
        { name: 'HORA_INICIO', index: 'HORA_INICIO', align: 'center', width: 100, hidden: false, sorttype: 'number', sortable: true },
        { name: 'HORA_FIN', index: 'HORA_FIN', align: 'center', width: 100, hidden: false, sorttype: 'number', sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 300, hidden: false, sorttype: 'number', sortable: true },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 120, hidden: false, sortable: true },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 120, hidden: false, sortable: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false, search: false,
        exportarExcel: function (_grilla_base) {
            ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(Documento_Ver_Proceso_grilla, Documento_Ver_Proceso_barra, '', '300', '', "Listado de movimientos", '', '', colNames, colModels, '', opciones);
}

function Documento_Ver_Proceso_CargarGrilla() {
    var ID_DOCUMENTO = $("#hd_Documento_Ver_ID_DOCUMENTO").val()
    var url = `ventanilla/digitalizacion/listar-documento-proceso/${ID_DOCUMENTO}`;
    API.FetchGet("GET", url, function (auditoria) {
        jQuery("#" + Documento_Ver_Proceso_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $.each(auditoria.Objeto, function (i, v) {
                        var rowKey = jQuery("#" + Documento_Ver_Proceso_grilla).getDataIDs();
                        var ix = rowKey.length;
                        ix++;
                        var myData =
                        {
                            CODIGO: ix,
                            ID_DOCUMENTO_PROCESO: v.ID_DOCUMENTO_PROCESO,
                            ID_DOCUMENTO: v.ID_DOCUMENTO,
                            DESCRIPCION_ESTADO: v.DESCRIPCION_ESTADO,
                            HORA_INICIO: v.HORA_INICIO,
                            HORA_FIN: v.HORA_FIN,
                            OBSERVACION: v.OBSERVACION,

                            USU_CREACION: v.USU_CREACION,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,

                        };
                        jQuery("#" + Documento_Ver_Proceso_grilla).jqGrid('addRowData', ix, myData);
                    });
                    jQuery("#" + Documento_Ver_Proceso_grilla).trigger("reloadGrid");
                }
            }
        }
    });
}

function Digitalizar_ValidIdLaser(IdLaserMin, idlaser) {
    if (isNaN(idlaser) || idlaser == "") {
        jAlert("El <b>ID LASERFICHER</b> no puede ser (0 - vacío o de tipo carácter).", "Atención");
        return false;
    }
    if (IdLaserMin > idlaser) {
        jAlert(`El <b>ID LASERFICHER</b> debe ser un numero mayor a ${IdLaserMin}.`, "Atención");
        return false;
    }

    return true;
}

function Documento_Exportar(Rules) {
    var params = new Object;
    params.rules = Rules;
    var url = BaseUrlApi + 'ventanilla/documento/documento-exportar';
    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(params),
        success: function (data) {
            if (data != null || data != "")
                window.location = BaseUrlApi + 'ventanilla/get-file/' + data
        }, failure: function (msg) {
            alert(msg);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

/*  ------------------------------
    |  Carga data para editar    |
    ------------------------------ */


async function Documento_EditValidarImagen(id) {
    var OptionsCbo = {
        KeyVal: { value: "ID_OBSERVACION", name: "DESC_OBSERVACION" },
        paramters: { FlgEstado: "1" },
        method: "POST"
    }
    await LoadComboApi("ventanilla/observacion/listar", "VALIDAR_ID_TIPO_OBS", OptionsCbo)
    //{
    //    var url = `ventanilla/documento/get-documento/${id}`;
    //    API.FetchGet("GET", url, function (auditoria) {
    //        if (auditoria != null && auditoria != "") {
    //            if (auditoria.EjecucionProceso) {
    //                if (!auditoria.Rechazo) {
    //                    $('#hd_Documento_Validar_ID_DOCUMENTO_ASIGNADO').val(auditoria.Objeto.ID_DOCUMENTO_ASIGNADO);
    //                    $('#NOM_DOCUMENTO').val(auditoria.Objeto.NOM_DOCUMENTO);
    //                    $('#DESC_FONDO').val(auditoria.Objeto.DES_FONDO);
    //                    $('#DESC_LARGA_SECCION').val(auditoria.Objeto.DES_LARGA_SECCION);
    //                    $('#DESC_SERIE').val(auditoria.Objeto.DES_SERIE);
    //                    $('#ANIO').val(auditoria.Objeto.ANIO);
    //                    $('#FOLIOS').val(auditoria.Objeto.FOLIOS);
    //                    $('#OBSERVACION').val(auditoria.Objeto.OBSERVACION);
    //                    $('#DESCRIPCION').val(auditoria.Objeto.DESCRIPCION);
    //                    $('#VALIDAR_NOMBRE_DIGITALIZADOR').val(auditoria.Objeto.VALIDAR_NOMBRE_DIGITALIZADOR);
    //                    $('#VALIDAR_NOMBRE_DIGITALIZADOR').val(auditoria.Objeto.NOMBRE_USUARIO);
    //                    $('#DESCRIPCION').val(auditoria.Objeto.DESCRIPCION);
    //                } else {
    //                    jAlert(auditoria.MensajeSalida, "Atención");
    //                }
    //            } else {
    //                jAlert(auditoria.MensajeSalida, "Atención");
    //            }
    //        }
    //    });
    //}
}