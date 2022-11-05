var Expediente_Grilla = "Tabla_Pen_grilla";
var Expediente_Barra = "Tabla_Pen_barra";

$(document).ready(function () {
    $('#Load_Busqueda').show();
    setTimeout("Documento_ConfigurarGrilla_Vent_Pen()", 500);
});

$("#cons_btn_buscar").click(function (e) {
    $('#Load_Busqueda').show();
    setTimeout(function () { Documento_ConfigurarGrilla_Vent_Pen("Tabla_Pen_grilla", "Tabla_Pen_barra", "Documentos Pendientes") }, 500);
});
function Documento_ConfigurarGrilla_Vent_Pen() {
    $('#Load_Busqueda').show();
    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    var url = BaseUrlApi + 'ventanilla/DocRecepcion/listado-doc-ventanilla-pendiente';
    $("#" + Expediente_Grilla).GridUnload();
    var colNames = [
        'N° Exp.', 'Recibir', 'Doc.', 'Fec. Reg. Exp.', 'Solicitante', 'Asunto', 'Clasificación', '', ''
    ]
    var colModels = [
        { name: 'ID_EXPE', index: 'ID_EXPE', align: 'center', hidden: false, key: true }, //1
        { name: 'VERIFICAR', index: 'VERIFICAR', align: 'center', width: 110, formatter: Documento_actionRecibir },
        { name: 'DOC', index: 'DOC', align: 'center', width: 110, formatter: Documento_actionVerDoc },
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
            var allJQGridData = $("#" + Expediente_Grilla).jqGrid('getRowData');
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
    SICA.Grilla(Expediente_Grilla, Expediente_Barra, '', '400', '', 'Expedientes Pendientes', url, 'ID_EXPE', colNames, colModels, 'ID_EXPE', opciones);
    $("#" + Expediente_Grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
    jqGridResponsive($(".Tabla_jqGrid"));
    $("#" + Expediente_Grilla + "_barra_left").css('width', '0px');
}
function Documento_actionRecibir(cellvalue, options, rowObject) {
    var _btn = "";
    _btn = "<button title='Ver Imagen' onclick='Documento_Recibir(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Recibir_Doc'> <i class=\"clip-folder-plus\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}
function Documento_actionVerDoc(cellvalue, options, rowObject) {
    var _btn = "";
    var cant = rowObject[7];
    if (cant != 0) {
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
function Expediente_Recibir() {
    var ListaAdjuntos = $("#" + Adjuntos_grilla).getRowData();
    var ListaDocumento = $("#" + Documento_grilla).getRowData();
    jConfirm("¿Desea recibir este expediente ?", "Atención", function (r) {
        if (r) {
            ListaAdjuntos = ListaAdjuntos.map(function (x) {
                return {
                    FlgTipo: 1,
                    NombreArchivo: x.NOMBRE_ARCHIVO,
                    Extension: x.EXTENSION,
                    PesoArchivo: parseInt(x.PESO_ARCHIVO),
                    CodigoArchivo: x.CODIGO_ARCHIVO,
                    FlgLink: parseInt(x.FLG_ARCHIVO)
                }
            });
            if (ListaDocumento.length > 0) {
                ListaDocumento.forEach(function (itemdoc) {
                    ListaAdjuntos.push({
                        IdArchivo: parseInt(itemdoc.ID_DOC_CMS),
                        IdDocumento: parseInt(itemdoc.ID_DOC),
                        FlgTipo: 2,
                        NombreArchivo: itemdoc.DES_NOM_ABR,
                        Extension: itemdoc.EXTENSION,
                        PesoArchivo: parseInt(itemdoc.NUM_SIZE_ARCHIVO),
                        FlgLink: 0
                    });
                });
            }
            var item =
            {
                IdExpediente: parseInt($('#HDF_ID_EXPE').val()),
                UsuCrea: parseInt($('#inputHddId_Usuario').val()),
                ListaAdjuntos: ListaAdjuntos,
            };
            var url = baseUrl + 'Digitalizacion/Recepcion/recibir-expediente';
            API.Ajax(url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.ejecucionProceso) {
                        if (!auditoria.rechazo) {
                            $('#myModal_Recibir_Doc').modal('hide');
                            Documento_ConfigurarGrilla_Vent_Pen();
                            jAlert("Expediente recibido corrrectamente", "Proceso");
                        } else {
                            $('#myModal_Recibir_Doc').modal('hide');
                            jAlert(auditoria.mensajeSalida, "Atención");
                        }
                    } else {
                        $('#myModal_Recibir_Doc').modal('hide');
                        jAlert(auditoria.mensajeSalida, "Atención");
                    }
                }
            });
        }
    });
}