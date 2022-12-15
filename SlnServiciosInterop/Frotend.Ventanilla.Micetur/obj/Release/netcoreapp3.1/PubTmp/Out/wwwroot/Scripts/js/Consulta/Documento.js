$(document).ready(function () {
    Remove_RemoverClases("liControl");
    Documento_ConfigurarGrilla_Venta("Documento_Grilla", "Documento_Barra", "Documentos");
 
});
function Documento_ConfigurarGrilla_Venta(_grilla, _barra, _titulo) {
    $("#Load_Busqueda").show();
    setTimeout(() => {
        $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
        _ID_MODULO = 1;
        _PREFIJO = "";
        var url = BaseUrlApi + 'Ventanilla/DocVentanilla/listado-doc-ventanilla-paginado';
        $("#" + _grilla).GridUnload();
        var colNames = [
            'N° Exp.', 'Fec. Reg. Exp.', 'Solicitante', 'Asunto', 'Clasificación','Observación',
            'Tipo Expediente', 'Número Doc.', 'Folios'
        ]
        var colModels = [
            { name: 'ID_EXPE', index: 'ID_EXPE', align: 'center', hidden: false, key: true }, //1
            { name: 'FEC_EXPE_STR', index: 'FEC_EXPE_STR', align: 'center', hidden: false, search: false }, //2
            { name: 'DES_PERSONA', index: 'DES_PERSONA', align: 'left', hidden: false, width: 200, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' }, search: false}, //3
            { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'left', hidden: false, width: 300, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' }, search: false}, //4
            { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'left', hidden: false, width: 200 },
            { name: 'DES_OBS', index: 'DES_OBS', align: 'left', hidden: false, width: 200 },
            { name: 'DES_TIP_DOC', index: 'DES_TIP_DOC', align: 'left', hidden: false, width: 200 },
            { name: 'NUM_DOC', index: 'NUM_DOC', align: 'left', hidden: false, width: 150, search: false },
            { name: 'NUM_FOLIOS', index: 'NUM_FOLIOS', align: 'left', hidden: false, width: 150, search: false },
        ];
        var opciones = {
            GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: false, rules: true, exportar: true, sort: 'asc', getrules: `GetRules()`,
            gridCompleteFunc: function () {
                $("#Load_Busqueda").hide();
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
            exportarExcel: function () {
                Documento_Exportar(GetRules());
            }
        };
        SICA.Grilla(_grilla, _barra, '', '400', '', _titulo, url, 'ID_EXPE', colNames, colModels, 'ID_EXPE', opciones);
        $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
        jqGridResponsive($(".Tabla_jqGrid"));
        $("#" + _grilla + "_barra_left").css('width', '0px');
    }, 500);
}
function GetRules() {
    var rules = new Array();
    var FECHA_INICIO = ($("#txtfechainicio").val() == null || $("#txtfechainicio").val() == '') ? '' : $("#txtfechainicio").val() + '';
    var FECHA_FIN = ($("#txtfechafin").val() == null || $("#txtfechafin").val() == '') ? '' : $("#txtfechafin").val() + '';
    var POR = "'%'";
    var FORM = "'DD/MM/YYYY'";
    var a = ' and ';

    _gs_DES_CLASIF = $('#gs_' + 'DES_CLASIF').val();
    _gs_DES_ASUNTO = $('#gs_' + 'DES_ASUNTO').val();
    _gs_DES_PERSONA = $('#gs_' + 'DES_PERSONA').val();
    _gs_DES_TIP_DOC = $('#gs_' + 'DES_TIP_DOC').val();
    _gs_NROEXPEDIENTE = $('#gs_' + _PREFIJO + 'ID_EXPE').val();
    //
    var _DES_CLASIF = _gs_DES_CLASIF == '' || _gs_DES_CLASIF == undefined ? null : "UPPER('" + _gs_DES_CLASIF + "')";
    var _DES_ASUNTO = _gs_DES_ASUNTO == '' || _gs_DES_ASUNTO == undefined ? null : "UPPER('" + _gs_DES_ASUNTO + "')";
    var _DES_DES_PERSONA = _gs_DES_PERSONA == '' || _gs_DES_PERSONA == undefined ? null : "UPPER('" + _gs_DES_PERSONA + "')";
    var _DES_TIP_DOC = _gs_DES_TIP_DOC == '' || _gs_DES_TIP_DOC == undefined ? null : "UPPER('" + _gs_DES_TIP_DOC + "')";
    var _NROEXPEDIENTE = _gs_NROEXPEDIENTE == '' || _gs_NROEXPEDIENTE == undefined ? null : "UPPER('" + _gs_NROEXPEDIENTE + "')";

    rules = [
        { field: 'V.DES_CLASIF', data: POR + ' || ' + _DES_CLASIF + ' || ' + POR, op: " LIKE " },
        { field: 'V.DES_ASUNTO', data: POR + ' || ' + _DES_ASUNTO + ' || ' + POR, op: " LIKE " },
        { field: 'V.DES_PERSONA', data: POR + ' || ' + _DES_DES_PERSONA + ' || ' + POR, op: " LIKE " },
        { field: 'V.DES_TIP_DOC', data: POR + ' || ' + _DES_TIP_DOC + ' || ' + POR, op: " LIKE " },
        { field: 'V.ID_EXPE', data: POR + ' || ' + _NROEXPEDIENTE + ' || ' + POR, op: " LIKE " },
        { field: "TO_DATE(TO_CHAR(V.FEC_EXPE," + FORM + "), " + FORM + ")", data: "TO_DATE('" + FECHA_INICIO + "', " + FORM + ")" + a + "TO_DATE('" + FECHA_FIN + "', " + FORM + ")", op: " between " },
    ];
    return rules;
}

$("#cons_btn_buscar").click(function (e) {
    Documento_ConfigurarGrilla_Venta("Documento_Grilla", "Documento_Barra", "Documentos");
});

function Documento_Exportar(Rules) {
    debugger;
    var params = new Object;
    params.rules = Rules;
    var url = BaseUrlApi + 'Ventanilla/DocVentanilla/documento-exportar';
    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(params),
        success: function (data) {
            if (data != null || data != "")
                window.location = BaseUrlApi + 'archivo-central/get-file/' + data
        }, failure: function (msg) {
            alert(msg);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}