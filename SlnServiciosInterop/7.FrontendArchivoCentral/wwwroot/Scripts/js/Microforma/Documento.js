var _ID_MODULO = 0;
var _ID_LOTE = 0;
var _ID_MICROFORMA = 0;
var _PREFIJO = "";

var Documento_Ver_Obs_grilla = "Documento_Ver_Obs_grilla";
var Documento_Ver_Obs_barra = "Documento_Ver_Obs_barra";

var Documento_Ver_Proceso_grilla = "Documento_Ver_Proceso_grilla";
var Documento_Ver_Proceso_barra = "Documento_Ver_Proceso_barra";

function Documento_Temporal_ConfigurarGrilla(_grilla, _barra, _titulo) {
    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    _ID_MODULO = 1;
    _PREFIJO = "";
    var url = BaseUrlApi + 'archivo-central/recepcion/documento-temporal-paginado';
    $("#" + _grilla).GridUnload();
    var colNames = [
        '1', '2', '3', '4', '5',
         'Fondo', 'Nombre Documento', 'Sección', 'Serie', 'Descripción', 'Anio', 'Folios', 'Obervación',
        'Usuario de Creación', 'Fecha de Creación','Usuario de Modificación', 'Fecha de Modificación'
    ]
    var colModels = [
        { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO ', align: 'center', hidden: true, key: true }, //1
        { name: 'ID_CONTROL_CARGA', index: 'ID_CONTROL_CARGA ', align: 'center', hidden: true }, //2
        { name: 'ID_FONDO', index: 'ID_FONDO ', align: 'center', hidden: true }, //3
        { name: 'ID_SECCION', index: 'ID_SECCION ', align: 'center', hidden: true }, //4
        { name: 'ID_SERIE', index: 'ID_SERIE ', align: 'center', hidden: true }, //5

        { name: 'DES_FONDO', index: 'DES_FONDO', align: 'center', width: 200, hidden: false },
        { name: 'NOM_DOCUMENTO', index: 'NOM_DOCUMENTO', align: 'center', width: 200, hidden: false },
        { name: 'DES_LARGA_SECCION', index: 'DES_LARGA_SECCION', align: 'center', width: 150, hidden: false },
        { name: 'DES_SERIE', index: 'DES_SERIE', align: 'center', width: 150, hidden: false },
        { name: 'DESCRIPCION', index: 'DESCRIPCION', align: 'center', width: 200, hidden: false },
        { name: 'ANIO', index: 'ANIO', align: 'center', width: 80, hidden: false },
        { name: 'FOLIOS', index: 'FOLIOS', align: 'center', width: 100, hidden: false },
        { name: 'OBSERVACION', index: 'OBSERVACION ', align: 'center', width: 300, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION ', align: 'center', width: 140, hidden: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION ', align: 'center', width: 160, hidden: false },
        { name: 'STR_FEC_MODIFICACION', index: 'STR_FEC_MODIFICACION ', align: 'center', width: 150, hidden: false },
    ];
    var opciones = {
        GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: false, rules: true, sort: 'desc',
        gridCompleteFunc: function () {

            var allJQGridData = $("#" + _grilla).jqGrid('getRowData');
            if (allJQGridData.length == 0) {
                $(".ui-jqgrid-hdiv").css("overflow-x", "auto");
            }
            else {
               // debugger;
                var e = $(".ui-jqgrid-hdiv");// document.getElementsByClassName(".ui-jqgrid-hdiv");
                var ex = $(".ui-jqgrid-bdiv");
                //scrollHeight: 68
                e[0].scrollLeft = ex[0].scrollLeft;
                $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
                //jQuery("#" + _grilla).trigger("reloadGrid");
            }
        },
    };
    SICA.Grilla(_grilla, _barra, '', '400', '', _titulo, url, 'ID_DOCUMENTO', colNames, colModels, 'ID_DOCUMENTO', opciones);
    $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
    jqGridResponsive($(".Tabla_jqGrid"));

    jQuery("#" + _grilla).jqGrid('setLabel', 0, 'NewLabel');
    $("#Recepcion_busqueda").hide();
}

// _id_tab - Leyenda :
// 2 : Asignar
// 3 : Asignados
function Documento_ConfigurarGrilla(_grilla, _barra, _titulo, _multiselect, _id_tab) {
    //$(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    _ID_MODULO = _id_tab;
    var VER_BOTON_IMAGEN = true;
    var VER_BOTON_OBS = true;
    var NOMBRE_BOTON_IMAGEN = "";
    var url = baseUrl + 'Microforma/Documento/Documento_Listar_Todo';
    if (_ID_MODULO == 2) {
        _PREFIJO = "Asignar_";
    } else if (_ID_MODULO == 3) {
        _PREFIJO = "Asignados_";
    } else if (_ID_MODULO == 4) {
        _PREFIJO = "Digitalizar_";
    } else if (_ID_MODULO == 5) {
        _PREFIJO = "Digitalizados_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_IMAGEN = false;
    } else if (_ID_MODULO == 6) {
        _PREFIJO = "Control_Calidad_";
        NOMBRE_BOTON_IMAGEN = 'Validar Imagen';
        VER_BOTON_IMAGEN = false;
    } else if (_ID_MODULO == 7) {
        _PREFIJO = "Aprobados_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_IMAGEN = false;
    } else if (_ID_MODULO == 8) { // Reprocesar
        _PREFIJO = "Reprocesar_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_OBS = false;
    } else if (_ID_MODULO == 9) { // Reprocesados
        _PREFIJO = "Reprocesados_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_IMAGEN = false;
        VER_BOTON_OBS = false;
    } else if (_ID_MODULO == 10) {
        _PREFIJO = "Fedatar_";
        NOMBRE_BOTON_IMAGEN = 'Validar Imagen';
        VER_BOTON_IMAGEN = false;
    } else if (_ID_MODULO == 11) {
        _PREFIJO = "Fedatados_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_IMAGEN = false;
    } else if (_ID_MODULO == 12) {
        _PREFIJO = "MicroformaGrabar_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_IMAGEN = false;
    } else if (_ID_MODULO == 13) {
        _PREFIJO = "Microforma_";
        NOMBRE_BOTON_IMAGEN = 'Ver Imagen';
        VER_BOTON_IMAGEN = false;
    }
    $("#" + _grilla).GridUnload();
    var colNames = [
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10',
        NOMBRE_BOTON_IMAGEN, 'Ver Obs', 'Digitalizador', 'Estado de Documento', 'Código de Documento', 'Fondo', 'Sección', 'Sub-Sección', 'Serie', 'Tipo Documental', 'N° Registro', 'N° Expediente', 'Volumen', 'Desc. A', 'Desc. B', 'Desc. C', 'Fecha Inicio', 'Fecha Fin', 'Folios', 'Imagenes', 'Caja', 'Observación',
        'Usuario de Creación', 'Fecha de Creación', 'IP de Creación', 'Usuario de Modificación', 'Fecha de Modificación', 'IP de Modificación'
    ]
    var colModels = [
        { name: _PREFIJO + 'ID_DOCUMENTO', index: _PREFIJO + 'ID_DOCUMENTO ', align: 'center', hidden: true, key: true }, //0
        { name: _PREFIJO + 'ID_DOCUMENTO_ASIGNADO', index: _PREFIJO + 'ID_DOCUMENTO_ASIGNADO ', align: 'center', hidden: true, key: true }, //1
        { name: _PREFIJO + 'ID_CONTROL_CARGA', index: _PREFIJO + 'ID_CONTROL_CARGA ', align: 'center', hidden: true }, //2
        { name: _PREFIJO + 'ID_FONDO', index: _PREFIJO + 'ID_FONDO ', align: 'center', hidden: true }, //3
        { name: _PREFIJO + 'ID_SECCION', index: _PREFIJO + 'ID_SECCION ', align: 'center', hidden: true }, //4
        { name: _PREFIJO + 'ID_SUB_SECCION', index: _PREFIJO + 'ID_SUB_SECCION ', align: 'center', hidden: true }, //5
        { name: _PREFIJO + 'ID_SERIE', index: _PREFIJO + 'ID_SERIE ', align: 'center', hidden: true }, //6
        { name: _PREFIJO + 'ID_TIPO_DOCUMENTO', index: _PREFIJO + 'ID_TIPO_DOCUMENTO ', align: 'center', hidden: true }, //7
        { name: _PREFIJO + 'ID_ESTADO_DOCUMENTO', index: _PREFIJO + 'ID_ESTADO_DOCUMENTO ', align: 'center', hidden: true, key: true }, //8
        { name: _PREFIJO + 'DESCRIPCION_ESTADO', index: _PREFIJO + 'DESCRIPCION_ESTADO', align: 'center', hidden: true }, //9
        { name: _PREFIJO + 'COD_DOCUMENTO', index: _PREFIJO + 'COD_DOCUMENTO', align: 'center', width: 150, hidden: true }, //10

        { name: _PREFIJO + 'VER_IMAGEN', index: _PREFIJO + 'VER_IMAGEN', align: 'center', width: 110, hidden: VER_BOTON_IMAGEN, formatter: Documento_actionVerImagen, search: false }, //11
        { name: _PREFIJO + 'VER_OBS', index: _PREFIJO + 'VER_OBS', align: 'center', width: 110, hidden: VER_BOTON_OBS, formatter: Documento_actionVerObs, search: false }, //12
        { name: _PREFIJO + 'NOMBRE_USUARIO', index: _PREFIJO + 'NOMBRE_USUARIO', align: 'center', width: 180, hidden: false, editable: true }, //13
        { name: _PREFIJO + '_DESCRIPCION_ESTADO', index: _PREFIJO + '_DESCRIPCION_ESTADO', align: 'center', width: 180, hidden: false, formatter: Documento_actionEstadoVerObs }, //14
        { name: _PREFIJO + '_COD_DOCUMENTO', index: _PREFIJO + '_COD_DOCUMENTO', align: 'center', width: 150, hidden: false, formatter: Documento_actionCodVerProceso }, //15
        { name: _PREFIJO + 'DESC_FONDO', index: _PREFIJO + 'DESC_FONDO', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'DESC_LARGA_SECCION', index: _PREFIJO + 'DESC_LARGA_SECCION', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'DESC_LARGA_SUBSECCION', index: _PREFIJO + 'DESC_LARGA_SUBSECCION', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'DESC_SERIE', index: _PREFIJO + 'DESC_SERIE', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'DESC_TIPO_DOCUMENTO', index: _PREFIJO + 'DESC_TIPO_DOCUMENTO', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'NUM_REGISTRO', index: _PREFIJO + 'NUM_REGISTRO ', align: 'center', width: 180, hidden: false },
        { name: _PREFIJO + 'NUM_EXPEDIENTE', index: _PREFIJO + 'NUM_EXPEDIENTE ', align: 'center', width: 180, hidden: false },
        { name: _PREFIJO + 'VOLUMEN', index: _PREFIJO + 'VOLUMEN ', align: 'center', width: 90, hidden: false },
        { name: _PREFIJO + 'DESCR_A', index: _PREFIJO + 'DESCR_A ', align: 'center', width: 350, hidden: false },
        { name: _PREFIJO + 'DESCR_B', index: _PREFIJO + 'DESCR_B ', align: 'center', width: 350, hidden: false },
        { name: _PREFIJO + 'DESCR_C', index: _PREFIJO + 'DESCR_C ', align: 'center', width: 350, hidden: false },
        { name: _PREFIJO + 'FECHA_INI', index: _PREFIJO + 'FECHA_INI ', align: 'center', width: 90, hidden: false },
        { name: _PREFIJO + 'FECHA_FIN', index: _PREFIJO + 'FECHA_FIN ', align: 'center', width: 90, hidden: false },
        { name: _PREFIJO + 'FOLIOS', index: _PREFIJO + 'FOLIOS ', align: 'center', width: 60, hidden: false },
        { name: _PREFIJO + 'TOT_IMAGENES', index: _PREFIJO + 'TOT_IMAGENES ', align: 'center', width: 120, hidden: false },
        { name: _PREFIJO + 'CAJA', index: _PREFIJO + 'CAJA ', align: 'center', width: 60, hidden: false },
        { name: _PREFIJO + 'OBSERVACION', index: _PREFIJO + 'OBSERVACION ', align: 'center', width: 120, hidden: false },

        { name: _PREFIJO + 'USU_CREACION', index: _PREFIJO + 'USU_CREACION ', align: 'center', width: 140, hidden: false },
        { name: _PREFIJO + 'STR_FEC_CREACION', index: _PREFIJO + 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'IP_CREACION', index: _PREFIJO + 'IP_CREACION ', align: 'center', width: 120, hidden: false },
        { name: _PREFIJO + 'USU_MODIFICACION', index: _PREFIJO + 'USU_MODIFICACION ', align: 'center', width: 160, hidden: false },
        { name: _PREFIJO + 'STR_FEC_MODIFICACION', index: _PREFIJO + 'STR_FEC_MODIFICACION ', align: 'center', width: 150, hidden: false },
        { name: _PREFIJO + 'IP_MODIFICACION', index: _PREFIJO + 'IP_MODIFICACION ', align: 'center', width: 130, hidden: false }
    ];
    var opciones = {
        GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: _multiselect, rules: true, sort: 'desc',
        gridCompleteFunc: function () {
            ConfigurarColor(_grilla);

            var allJQGridData = $("#" + _grilla).jqGrid('getRowData');
            if (allJQGridData.length == 0) {
                $(".ui-jqgrid-hdiv").css("overflow-x", "auto");
            }
            else {
                //debugger;
                var e = $(".ui-jqgrid-hdiv");// document.getElementsByClassName(".ui-jqgrid-hdiv");
                var ex = $(".ui-jqgrid-bdiv");
                //scrollHeight: 68
                for (var ii = 0; ii < e.length;ii++) {
                    e[ii].scrollLeft = ex[ii].scrollLeft;
                    //e[1].scrollLeft = ex[1].scrollLeft;
                }
                
                //scrollTop: 0
                //scrollWidth: 3845

                //e.scrollTop = 0;
                //e.scrollTop = 0;
                $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
                //jQuery("#" + _grilla).trigger("reloadGrid");
            }

            //var allJQGridData = $("#" + _grilla).jqGrid('getRowData');
            //if (allJQGridData.length == 0) {
            //    $(".ui-jqgrid-hdiv").css("overflow-x", "auto");
            //} else
            //    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
        },
    };
    SICA.Grilla(_grilla, _barra, '', '500', '', _titulo, url, _PREFIJO + 'ID_DOCUMENTO', colNames, colModels, 'ID_DOCUMENTO', opciones);
    $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
    jqGridResponsive($(".Tabla_jqGrid"));

    jQuery("#" + _grilla).jqGrid('setLabel', 0, 'NewLabel');
    $("#" + _grilla + "_cb").css("width", "30px");
    $("#" + _grilla + "_cb tbody tr").children().first("td").css("width", "30px");
    $("#Recepcion_busqueda").hide();
}

function Documento_actionVerImagen(cellvalue, options, rowObject) {
    var _btn = "";
    var COD_DOCUMENTO = rowObject[10];
    if (_ID_MODULO == 6 || _ID_MODULO == 10) {
        _btn = "<button title='Ver Imagen' onclick='Documento_ValidarImagen(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'> <i class=\"clip-pictures\" style=\"color:#a01010;font-size:20px\"></i></button>";
    } else {
        _btn = "<button title='Ver Imagen' onclick='Documento_VerImagen(" + COD_DOCUMENTO + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'> <i class=\"clip-pictures\" style=\"color:#a01010;font-size:20px\"></i></button>";
    }
    return _btn;
}

function Documento_actionVerObs(cellvalue, options, rowObject) {
    var _btn = "";
    _btn = "<button title='Ver Observaciones' onclick='Documento_Ver_Obs(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'><i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}

function Documento_actionEstadoVerObs(cellvalue, options, rowObject) {
    var _btn = rowObject[9];
    if (rowObject[8] == 6)
        _btn += " <button title='Ver Observaciones' onclick='Documento_Ver_Obs(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'><i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:15px\"></i></button>";
    return _btn;
}

function Documento_actionCodVerProceso(cellvalue, options, rowObject) {
    var _btn = rowObject[10];
    if (_ID_MODULO != 2)
        _btn += " <br/> <button title='Ver Movimientos' onclick='Documento_Ver_Proceso(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen' style=\"color:#a01010;font-size:12px\"><i class=\"clip-stack\"></i> Movimientos</button>";
    return _btn;
}

function Documento_VerImagen(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Microforma/Documento/Documento_Ver_Imagen?COD_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function Documento_Ver_Obs(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Microforma/Documento/Documento_Ver_Obs?ID_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function Documento_Ver_Proceso(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Microforma/Documento/Documento_Ver_Proceso?ID_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function Documento_ValidarImagen(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Microforma/Documento/Documento_Validar_Imagen?ID_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}

function GetRules(grilla) {
    var rules = new Array();
    //var _ID_CONTROL_CARGA = null;
    //var _ID_ESTADO_DOCUMENTO = null;
    //if (_ID_MODULO == 1) { // Carga temporales
    //    _ID_CONTROL_CARGA = jQuery('#ID_CONTROL_CARGA').val() == '' ? '0' : "'" + jQuery('#ID_CONTROL_CARGA').val() + "'";
    //} else if (_ID_MODULO == 2) { // Asignar
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 1;
    //} else if (_ID_MODULO == 3) { // Asignados
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 1;
    //} else if (_ID_MODULO == 4) { // Digitalizar
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 2;
    //} else if (_ID_MODULO == 5) { // Digitalizados
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 3;
    //} else if (_ID_MODULO == 6) { // Aprobar
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 3;
    //} else if (_ID_MODULO == 7) { // Aprobados
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 4;
    //} else if (_ID_MODULO == 8) { // Reprocesar
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 5;
    //} else if (_ID_MODULO == 9) { // Reprocesados
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 6;
    //} else if (_ID_MODULO == 10) { // Fedatar
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 4;
    //} else if (_ID_MODULO == 11) { // Fedatados
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 7;
    //} else if (_ID_MODULO == 12) { // Grabar 
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 1;
    //} else if (_ID_MODULO == 13) { // Microforma 
    //    _ID_CONTROL_CARGA = null;
    //    _ID_ESTADO_DOCUMENTO = 9;
    //}
    //_gs_NOMBRE_USUARIO = jQuery('#gs_' + _PREFIJO + 'NOMBRE_USUARIO').val();
    //_gs_DESCRIPCION_ESTADO = "";
    //_gs_COD_DOCUMENTO = "";
    //if (_ID_MODULO != 1) {
    //    _gs_DESCRIPCION_ESTADO = jQuery('#gs_' + _PREFIJO + '_DESCRIPCION_ESTADO').val();
    //    _gs_COD_DOCUMENTO = jQuery('#gs_' + _PREFIJO + '_COD_DOCUMENTO').val();
    //} else {
    //    _gs_DESCRIPCION_ESTADO = jQuery('#gs_' + _PREFIJO + 'DESCRIPCION_ESTADO').val();
    //    _gs_COD_DOCUMENTO = jQuery('#gs_' + _PREFIJO + 'COD_DOCUMENTO').val();
    //}
    //_gs_DESC_FONDO = jQuery('#gs_' + _PREFIJO + 'DESC_FONDO').val();
    //_gs_DESC_LARGA_SECCION = jQuery('#gs_' + _PREFIJO + 'DESC_LARGA_SECCION').val();
    //_gs_DESC_LARGA_SUBSECCION = jQuery('#gs_' + _PREFIJO + 'DESC_LARGA_SUBSECCION').val();
    //_gs_DESC_SERIE = jQuery('#gs_' + _PREFIJO + 'DESC_SERIE').val();
    //_gs_DESC_TIPO_DOCUMENTO = jQuery('#gs_' + _PREFIJO + 'DESC_TIPO_DOCUMENTO').val();
    //_gs_NUM_REGISTRO = jQuery('#gs_' + _PREFIJO + 'NUM_REGISTRO').val();
    //_gs_NUM_EXPEDIENTE = jQuery('#gs_' + _PREFIJO + 'NUM_EXPEDIENTE').val();
    //_gs_VOLUMEN = jQuery('#gs_' + _PREFIJO + 'VOLUMEN').val();
    //_gs_DESCR_A = jQuery('#gs_' + _PREFIJO + 'DESCR_A').val();
    //_gs_DESCR_B = jQuery('#gs_' + _PREFIJO + 'DESCR_B').val();
    //_gs_DESCR_C = jQuery('#gs_' + _PREFIJO + 'DESCR_C').val();

    //_gs_FOLIOS = jQuery('#gs_' + _PREFIJO + 'FOLIOS').val();
    //_gs_TOT_IMAGENES = jQuery('#gs_' + _PREFIJO + 'TOT_IMAGENES').val();
    //_gs_CAJA = jQuery('#gs_' + _PREFIJO + 'CAJA').val();
    //_gs_OBSERVACION = jQuery('#gs_' + _PREFIJO + 'OBSERVACION').val();


    //_gs_FECHA_INI = jQuery('#gs_' + _PREFIJO + 'FECHA_INI').val();
    //_gs_FECHA_FIN = jQuery('#gs_' + _PREFIJO + 'FECHA_FIN').val();

    //_gs_USU_CREACION = jQuery('#gs_' + _PREFIJO + 'USU_CREACION').val();
    //_gs_IP_CREACION = jQuery('#gs_' + _PREFIJO + 'IP_CREACION').val();
    //_gs_USU_MODIFICACION = jQuery('#gs_' + _PREFIJO + 'USU_MODIFICACION').val();
    //_gs_IP_MODIFICACION = jQuery('#gs_' + _PREFIJO + 'IP_MODIFICACION').val();

    //_gs_STR_FEC_CREACION = jQuery('#gs_' + _PREFIJO + 'STR_FEC_CREACION').val();
    //_gs_STR_FEC_MODIFICACION = jQuery('#gs_' + _PREFIJO + 'STR_FEC_MODIFICACION').val();


    ////debugger;
    //var _NOMBRE_USUARIO = _gs_NOMBRE_USUARIO == '' || _gs_NOMBRE_USUARIO == undefined ? null : "UPPER('" + _gs_NOMBRE_USUARIO + "')";
    //var _DESCRIPCION_ESTADO = _gs_DESCRIPCION_ESTADO == '' || _gs_DESCRIPCION_ESTADO == undefined ? null : "'" + _gs_DESCRIPCION_ESTADO + "'";
    //var _COD_DOCUMENTO = _gs_COD_DOCUMENTO == '' || _gs_COD_DOCUMENTO == undefined ? null : "'" + _gs_COD_DOCUMENTO + "'";
    //var _DESC_FONDO = _gs_DESC_FONDO == '' || _gs_DESC_FONDO == undefined ? null : "UPPER('" + _gs_DESC_FONDO + "')";
    //var _DESC_LARGA_SECCION = _gs_DESC_LARGA_SECCION == '' || _gs_DESC_LARGA_SECCION == undefined ? null : "UPPER('" + _gs_DESC_LARGA_SECCION + "')";
    //var _DESC_LARGA_SUBSECCION = _gs_DESC_LARGA_SUBSECCION == '' || _gs_DESC_LARGA_SUBSECCION == undefined ? null : "UPPER('" + _gs_DESC_LARGA_SUBSECCION + "')";
    //var _DESC_SERIE = _gs_DESC_SERIE == '' || _gs_DESC_SERIE == undefined ? null : "UPPER('" + _gs_DESC_SERIE + "')";
    //var _DESC_TIPO_DOCUMENTO = _gs_DESC_TIPO_DOCUMENTO == '' || _gs_DESC_TIPO_DOCUMENTO == undefined ? null : "UPPER('" + _gs_DESC_TIPO_DOCUMENTO + "')";


    //var _NUM_REGISTRO = _gs_NUM_REGISTRO == '' || _gs_NUM_REGISTRO == undefined ? null : "UPPER('" + _gs_NUM_REGISTRO + "')";
    //var _NUM_EXPEDIENTE = _gs_NUM_EXPEDIENTE == '' || _gs_NUM_EXPEDIENTE == undefined ? null : "UPPER('" + _gs_NUM_EXPEDIENTE + "')";
    //var _VOLUMEN = _gs_VOLUMEN == '' || _gs_VOLUMEN == undefined ? null : "'" + _gs_VOLUMEN + "'";

    //var _DESCR_A = _gs_DESCR_A == '' || _gs_DESCR_A == undefined ? null : "UPPER('" + _gs_DESCR_A + "')";
    //var _DESCR_B = _gs_DESCR_B == '' || _gs_DESCR_B == undefined ? null : "UPPER('" + _gs_DESCR_B + "')";
    //var _DESCR_C = _gs_DESCR_C == '' || _gs_DESCR_C == undefined ? null : "UPPER('" + _gs_DESCR_C + "')";

    //var _FECHA_INI = _gs_FECHA_INI == '' || _gs_FECHA_INI == undefined ? null : "'" + _gs_FECHA_INI + "'";
    //var _FECHA_FIN = _gs_FECHA_FIN == '' || _gs_FECHA_FIN == undefined ? null : "'" + _gs_FECHA_FIN + "'";
    ////var _FECHA_INI = jQuery('#gs_FECHA_INI').val() == '' || jQuery('#gs_FECHA_INI').val() == undefined ? null : "'" + jQuery('#gs_FECHA_INI').val() + "'";
    ////var _FECHA_FIN = jQuery('#gs_FECHA_FIN').val() == '' || jQuery('#gs_FECHA_FIN').val() == undefined ? null : "'" + jQuery('#gs_FECHA_FIN').val() + "'";

    //var _FOLIOS = _gs_FOLIOS == '' || _gs_FOLIOS == undefined ? null : "'" + _gs_FOLIOS + "'";
    //var _TOT_IMAGENES = _gs_TOT_IMAGENES == '' || _gs_TOT_IMAGENES == undefined ? null : "'" + _gs_TOT_IMAGENES + "'";
    //var _CAJA = _gs_CAJA == '' || _gs_CAJA == undefined ? null : "'" + _gs_CAJA + "'";
    //var _OBSERVACION = _gs_OBSERVACION == '' || _gs_OBSERVACION == undefined ? null : "UPPER('" + _gs_OBSERVACION + "')";

    //var _USU_CREACION = _gs_USU_CREACION == '' || _gs_USU_CREACION == undefined ? null : "UPPER('" + _gs_USU_CREACION + "')";
    //var _IP_CREACION = _gs_IP_CREACION == '' || _gs_IP_CREACION == undefined ? null : "'" + _gs_IP_CREACION + "'";

    //var _USU_MODIFICACION = _gs_USU_MODIFICACION == '' || _gs_USU_MODIFICACION == undefined ? null : "UPPER('" + _gs_USU_MODIFICACION + "')";
    //var _IP_MODIFICACION = _gs_IP_MODIFICACION == '' || _gs_IP_MODIFICACION == undefined ? null : "'" + _gs_IP_MODIFICACION + "'";

    //var _STR_FEC_CREACION = _gs_STR_FEC_CREACION == '' || _gs_STR_FEC_CREACION == undefined ? null : "'" + _gs_STR_FEC_CREACION + "'";
    //var _STR_FEC_MODIFICACION = _gs_STR_FEC_MODIFICACION == '' || _gs_STR_FEC_MODIFICACION == undefined ? null : "'" + _gs_STR_FEC_MODIFICACION + "'";

    //var POR = "'%'";

    //rules = [
    //    { field: 'V.ID_CONTROL_CARGA', data: 'NVL(' + _ID_CONTROL_CARGA + ',V.ID_CONTROL_CARGA)', op: " = " },
    //    { field: 'V.COD_DOCUMENTO', data: POR + ' || ' + _COD_DOCUMENTO + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESC_FONDO', data: POR + ' || ' + _DESC_FONDO + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESC_LARGA_SECCION', data: POR + ' || ' + _DESC_LARGA_SECCION + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESC_LARGA_SUBSECCION', data: POR + ' || ' + _DESC_LARGA_SUBSECCION + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESC_SERIE', data: POR + ' || ' + _DESC_SERIE + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESC_TIPO_DOCUMENTO', data: POR + ' || ' + _DESC_TIPO_DOCUMENTO + ' || ' + POR, op: " LIKE " },

    //    { field: 'V.NUM_REGISTRO', data: POR + ' || ' + _NUM_REGISTRO + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.NUM_EXPEDIENTE', data: POR + ' || ' + _NUM_EXPEDIENTE + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.VOLUMEN', data: 'NVL(' + _VOLUMEN + ',V.VOLUMEN)', op: " = " },
    //    { field: 'V.DESCR_A', data: POR + ' || ' + _DESCR_A + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESCR_B', data: POR + ' || ' + _DESCR_B + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.DESCR_C', data: POR + ' || ' + _DESCR_C + ' || ' + POR, op: " LIKE " },

    //    { field: 'V.FOLIOS', data: POR + ' || ' + _FOLIOS + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.TOT_IMAGENES', data: 'NVL(' + _TOT_IMAGENES + ',V.TOT_IMAGENES)', op: " = " },
    //    { field: 'V.CAJA', data: 'NVL(' + _CAJA + ',V.CAJA)', op: " = " },
    //    { field: 'V.OBSERVACION', data: 'NVL(' + _OBSERVACION + ',V.OBSERVACION)', op: " = " },

    //    { field: 'V.FECHA_INI', data: POR + ' || ' + _FECHA_INI + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.FECHA_FIN', data: POR + ' || ' + _FECHA_FIN + ' || ' + POR, op: " LIKE " },

    //    { field: 'V.FECHA_FIN', data: POR + ' || ' + _FECHA_FIN + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.FECHA_FIN', data: POR + ' || ' + _FECHA_FIN + ' || ' + POR, op: " LIKE " },

    //    { field: 'V.USU_CREACION', data: POR + ' || ' + _USU_CREACION + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.IP_CREACION', data: POR + ' || ' + _IP_CREACION + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.USU_MODIFICACION', data: POR + ' || ' + _USU_MODIFICACION + ' || ' + POR, op: " LIKE " },
    //    { field: 'V.IP_MODIFICACION', data: POR + ' || ' + _IP_MODIFICACION + ' || ' + POR, op: " LIKE " }
 
    //];
    //if (_ID_MODULO != 1) {
    //    rules.push({ field: 'V.DESCRIPCION_ESTADO', data: POR + ' || ' + _DESCRIPCION_ESTADO + ' || ' + POR, op: " LIKE " });
    //    if (_ID_MODULO != 2)
    //        rules.push({ field: 'UPPER(V.NOMBRE_USUARIO)', data: POR + ' || ' + _NOMBRE_USUARIO + ' || ' + POR, op: " LIKE " });
    //}

    //if (_ID_MODULO == 2 || _ID_MODULO == 4 || _ID_MODULO == 5 || _ID_MODULO == 7 || _ID_MODULO == 9 || _ID_MODULO == 10 || _ID_MODULO == 11 || _ID_MODULO == 13) {
    //    rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: 'NVL(' + _ID_ESTADO_DOCUMENTO + ',V.ID_ESTADO_DOCUMENTO)', op: " = " });
    //}
    //if (_ID_MODULO == 3) { // Asignados
    //    rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '' + _ID_ESTADO_DOCUMENTO + '', op: " != " });
    //    rules.push({ field: 'V.ID_LOTE', data: 'NVL(' + _ID_LOTE + ',V.ID_LOTE)', op: " = " });
    //}
    //if (_ID_MODULO == 12) { // Grabar 
    //    rules.push({ field: 'V.ID_LOTE', data: 'NVL(' + _ID_LOTE + ',V.ID_LOTE)', op: " = " });
    //    rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: 'NVL(' + _ID_ESTADO_DOCUMENTO + ',V.ID_ESTADO_DOCUMENTO)', op: " != " });
    //}
    //if (_ID_MODULO == 13) { // Grabados
    //    rules.push({ field: 'V.ID_MICROFORMA', data: 'NVL(' + _ID_MICROFORMA + ',V.ID_MICROFORMA)', op: " = " });
    //}
    //if (_ID_MODULO == 6) { // Aprobar
    //    rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '(' + _ID_ESTADO_DOCUMENTO + ',6)', op: " in " });
    //}
    //if (_ID_MODULO == 8) { // Reprocesar
    //    rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '(' + _ID_ESTADO_DOCUMENTO + ',8)', op: " in " });
    //}
    //if (_ID_MODULO == 8) { // Reprocesar
    //    rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: '(' + _ID_ESTADO_DOCUMENTO + ',8)', op: " in " });
    //}

    //if ($("#input_hd_CodAdmin").val() != $("#inputHddid_perfil").val() && (_ID_MODULO == 1 || _ID_MODULO == 2)) {
    //    rules.push({ field: 'V.USU_CREACION', data: 'x_USU_CREACION_TOKEN_x', op: " = " });
    //}
    //if ($("#input_hd_CodAdmin").val() != $("#inputHddid_perfil").val() && (_ID_MODULO != 1 && _ID_MODULO != 2)) {
    //    rules.push({ field: 'V.ID_USUARIO', data: 'x_ID_USUARIO_TOKEN_x', op: " = " });
    //}

    return rules;
}

function Documento_Ver_Obs_CargarGrilla() {
    var item =
    {
        ID_DOCUMENTO: $("#hd_Documento_Ver_ID_DOCUMENTO").val()
    };
    var url = baseUrl + 'Microforma/Documento/Documento_Ver_Obs_Listar';
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + Documento_Ver_Obs_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (!auditoria.RECHAZAR) {
                $.each(auditoria.OBJETO, function (i, v) {
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
                        IP_CREACION: v.IP_CREACION
                    };
                    jQuery("#" + Documento_Ver_Obs_grilla).jqGrid('addRowData', ix, myData);
                });
                jQuery("#" + Documento_Ver_Obs_grilla).trigger("reloadGrid");
            }
        }
    }
}

function Documento_Ver_Obs_ConfigurarGrilla() {
    $("#" + Documento_Ver_Obs_grilla).GridUnload();
    var colNames = [
        '1', '2', '3', '4',
        'Tipo', 'Observación',
        'Usuario Creación', 'Fecha Creación', 'IP Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_DOCUMENTO_OBS', index: 'ID_DOCUMENTO_OBS', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//2
        { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'ID_TIPO_OBSERVACION', index: 'ID_TIPO_OBSERVACION', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },

        { name: 'DESC_TIPO_OBSERVACION', index: 'DESC_TIPO_OBSERVACION', align: 'center', width: 200, hidden: false, sorttype: 'number', sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 400, hidden: false, sorttype: 'number', sortable: true },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 120, hidden: false, sortable: true },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
        { name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 120, hidden: false, sortable: true }
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
        'Usuario Creación', 'Fecha Creación', 'IP Creación'];
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
        { name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 120, hidden: false, sortable: true }
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
    var item =
    {
        ID_DOCUMENTO: $("#hd_Documento_Ver_ID_DOCUMENTO").val()
    };
    var url = baseUrl + 'Microforma/Documento/Documento_Ver_Proceso_Listar';
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + Documento_Ver_Proceso_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (!auditoria.RECHAZAR) {
                $.each(auditoria.OBJETO, function (i, v) {
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
                        IP_CREACION: v.IP_CREACION
                    };
                    jQuery("#" + Documento_Ver_Proceso_grilla).jqGrid('addRowData', ix, myData);
                });
                jQuery("#" + Documento_Ver_Proceso_grilla).trigger("reloadGrid");
            }
        }
    }
}

