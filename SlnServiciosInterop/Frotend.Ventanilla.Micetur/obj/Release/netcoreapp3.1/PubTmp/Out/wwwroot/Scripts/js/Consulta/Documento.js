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
            { name: 'FEC_EXPE_STR', index: 'FEC_EXPE_STR', align: 'center', hidden: false }, //2
            { name: 'DES_PERSONA', index: 'DES_PERSONA', align: 'left', hidden: false, width: 200, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' } }, //3
            { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'left', hidden: false, width: 300, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' } }, //4
            { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'left', hidden: false, width: 200 },
            { name: 'DES_OBS', index: 'DES_OBS', align: 'left', hidden: false, width: 200 },
            { name: 'DES_TIP_DOC', index: 'DES_TIP_DOC', align: 'left', hidden: false, width: 200 },
            { name: 'NUM_DOC', index: 'NUM_DOC', align: 'left', hidden: false, width: 150 },
            { name: 'NUM_FOLIOS', index: 'NUM_FOLIOS', align: 'left', hidden: false, width: 150 },
        ];
        var opciones = {
            GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: false, rules: true, sort: 'asc', getrules: `GetRules()`,
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
    rules = [
        { field: "TO_DATE(TO_CHAR(V.FEC_EXPE," + FORM + "), " + FORM + ")", data: "TO_DATE('" + FECHA_INICIO + "', " + FORM + ")" + a + "TO_DATE('" + FECHA_FIN + "', " + FORM + ")", op: " between " },
    ];
    return rules;
}
$("#cons_btn_buscar").click(function (e) {
    Documento_ConfigurarGrilla_Venta("Documento_Grilla", "Documento_Barra", "Documentos");
});