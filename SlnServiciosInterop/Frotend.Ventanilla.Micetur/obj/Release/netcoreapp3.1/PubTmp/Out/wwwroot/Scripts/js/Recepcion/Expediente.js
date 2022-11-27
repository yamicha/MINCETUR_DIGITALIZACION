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
        'N° Exp.', 'Recibir', 'Fec. Reg. Exp.', 'Solicitante', 'Asunto', 'Clasificación', 'Tipo Expediente', 'Número Doc.', 'Folios', 'Usuario'
    ]
    var colModels = [
        { name: 'ID_EXPE', index: 'ID_EXPE', align: 'center', hidden: false, key: true, search:true }, //1
        { name: 'VERIFICAR', index: 'VERIFICAR', align: 'center', width: 110, formatter: Documento_actionRecibir, search: false },
        { name: 'FEC_EXPE_STR', index: 'FEC_EXPE_STR', align: 'center', hidden: false, search: false }, //2
        { name: 'DES_PERSONA', index: 'DES_PERSONA', align: 'left', hidden: false, width: 200, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' }, search: false }, //3
        { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'left', hidden: false, width: 300, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' }, search: true }, //4
        { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'left', hidden: false, width: 200},
        { name: 'DES_TIP_DOC', index: 'DES_TIP_DOC', align: 'left', hidden: false, width: 200 },
        { name: 'NUM_DOC', index: 'NUM_DOC', align: 'left', hidden: false, width: 150 },
        { name: 'NUM_FOLIOS', index: 'NUM_FOLIOS', align: 'left', hidden: false, width: 150 },
        { name: 'USU_CREA', index: 'USU_CREA', align: 'left', hidden: true, width: 200, search: false},

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
function Expediente_Recibir() {
    let ListaAdjuntos;
    var ListaGridAdjunto = $("#" + Adjuntos_grilla).getRowData();
    var ListaDocumento = $("#" + DocumentoAdj_grilla).getRowData();
    jConfirm("¿Desea recibir este expediente ?", "Atención", function (r) {
        if (r) {
            fetchload.init();
            var data = new FormData();
            ListaAdjuntos = ListaGridAdjunto.filter(x => x.FLG_ARCHIVO == 1); //links
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
            ListaDocumento.forEach(function (itemdoc) {
                ListaAdjuntos.push({
                    IdExpediente: 0,
                    IdArchivo: parseInt(itemdoc.ID_DOC_CMS),
                    IdDocumento: parseInt(itemdoc.ID_DOC),
                    FlgTipo: 2,
                    NombreArchivo: itemdoc.DES_NOM_ABR,
                    Extension: itemdoc.EXTENSION,
                    PesoArchivo: parseInt(itemdoc.NUM_SIZE_ARCHIVO),
                    FlgLink: 0
                });
            });
            // enviar todos los archivos
            for (var i = 0; i < files.length; i++) {
                data.append("files", files[i]);
            }
            data.append("IdExpediente", parseInt($('#HDF_ID_EXPE').val()));
            data.append("UsuCrea", parseInt($('#inputHddId_Usuario').val()));
            data.append("ListaAdj", JSON.stringify(ListaAdjuntos));
            var url = baseUrl + 'Digitalizacion/Recepcion/recibir-expediente';
            fetch(url, {
                method: 'POST', //
                body: data, // 
            }).then(res => res.json())
                .catch(error => { fetchload.close(); alert(error) })
                .then(auditoria => {
                    fetchload.close();
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