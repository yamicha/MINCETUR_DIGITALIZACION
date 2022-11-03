$(document).ready(function () {
    Remove_RemoverClases("liRecepcion");
    $('#Load_Busqueda').show(); 
    setTimeout(function () {Documento_ConfigurarGrilla_Vent_Pen("Tabla_Pen_grilla", "Tabla_Pen_barra", "Documentos Pendientes")}, 500);
});

$("#cons_btn_buscar").click(function (e) {
    $('#Load_Busqueda').show();
    setTimeout(function () { Documento_ConfigurarGrilla_Vent_Pen("Tabla_Pen_grilla", "Tabla_Pen_barra", "Documentos Pendientes") }, 500);
});
function Documento_ConfigurarGrilla_Vent_Pen(_grilla, _barra, _titulo) {
    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    _ID_MODULO = 1;
    _PREFIJO = "";
    var url = BaseUrlApi + 'ventanilla/DocRecepcion/listado-doc-ventanilla-pendiente';
    $("#" + _grilla).GridUnload();
    var colNames = [
        'N° Exp.','Recibir' ,'Doc.','Fec. Reg. Exp.', 'Solicitante', 'Asunto', 'Clasificación','',''
    ]
    var colModels = [
        { name: 'ID_EXPE', index: 'ID_EXPE', align: 'center', hidden: false, key: true }, //1
        { name: 'VERIFICAR', index: 'VERIFICAR', align: 'center', width: 110, formatter: Documento_actionRecibir},
        { name: 'DOC', index:'DOC', align: 'center', width: 110, formatter: Documento_actionVerDoc}, 
        { name: 'FEC_EXPE_STR', index: 'FEC_EXPE_STR', align: 'center', hidden: false }, //2
        { name: 'DES_PERSONA', index: 'DES_PERSONA', align: 'left', hidden: false, width: 200, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' } }, //3
        { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'left', hidden: false, width: 300, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' } }, //4
        { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'left', hidden: false, width: 200 },
        { name: 'CANT_DOC', index: 'CANT_DOC', align: 'left', hidden: true, width: 200 },
        { name: 'ID_DOC', index: 'ID_DOC', align: 'left', hidden: true, width: 200 },
    ];
    var opciones = {
        GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: false, rules: true, sort: 'asc', getrules: `GetRules()`,
        gridCompleteFunc: function () {
            $('#Load_Busqueda').hide(); 
            var allJQGridData = $("#" + _grilla).jqGrid('getRowData');
            if (allJQGridData.length == 0) {
                $(".ui-jqgrid-hdiv").css("overflow-x", "auto");
            }
            else {
                var e = $(".ui-jqgrid-hdiv");
                var ex = $(".ui-jqgrid-bdiv");
                e[0].scrollLeft = ex[0].scrollLeft;
                $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
            }
        },
    };
    SICA.Grilla(_grilla, _barra, '', '400', '', _titulo, url, 'ID_EXPE', colNames, colModels, 'ID_EXPE', opciones);
    $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
    jqGridResponsive($(".Tabla_jqGrid"));
    $("#" + _grilla + "_barra_left").css('width', '0px');
}
function Documento_actionRecibir(cellvalue, options, rowObject) {
    var _btn = "";
    _btn = "<button title='Ver Imagen' onclick='Documento_Recibir(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Recibir_Doc'> <i class=\"clip-folder-plus\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}
function Documento_actionVerDoc(cellvalue, options, rowObject) {
    var _btn = "";
    var cant = rowObject[7];
    if (cant!=0) {
        _btn = "<button title='Descargar Documento' onclick='DownloadFile(" + rowObject[8] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" > <i class=\"clip-download-3\" style=\"color:#a01010;font-size:20px\"></i></button>";

    }
    return _btn;
}
function Documento_Recibir(CODIGO) {
    jQuery("#myModal_Recibir_Doc").html('');
    jQuery("#myModal_Recibir_Doc").load(baseUrl + "Digitalizacion/Recepcion/RecibirDoc?ID_EXPE=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Recibir_Doc');
        if (request.status != 200) return;
    });
}

function GetRules() {
    var rules = new Array();
    var FECHA_INICIO = ($("#txtfechainicio").val() == null || $("#txtfechainicio").val() == '') ? '' : $("#txtfechainicio").val() + '';
    var FECHA_FIN = ($("#txtfechafin").val() == null || $("#txtfechafin").val() == '') ? '' : $("#txtfechafin").val() + '';
    var POR = "'%'";
    var FORM = "'DD/MM/YYYY'";
    var a = ' and ';
    rules = [
        { field: "TO_DATE(TO_CHAR(V.FEC_EXPE," + FORM + "), " + FORM + ")", data: "TO_DATE('" + FECHA_INICIO + "', " + FORM + ")" + a + "TO_DATE('" + FECHA_FIN + "', " + FORM + ")", op: " between " },
    ];
    return rules;
}
function RecibirLoadFormEdit(id) {
    var url = `Ventanilla/DocRecepcion/listado-doc-ventanilla-getone?id=${id}`;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $('#HDF_ID_EXPE').val(auditoria.Objeto.ID_EXPE);
                   
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Atención");
            }
        }
    });
}