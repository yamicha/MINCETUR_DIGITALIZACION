
function DocumentoProceso_ConfigurarGrilla(_grilla, _barra, _titulo, _modulo) {
    _ID_MODULO = _modulo;
    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    $("#Load_Busqueda").show();
    let showColumnHora = false;
    let showObservaciones = true; 
    if (_ID_MODULO != 5) {
        showColumnHora = true;
        showObservaciones = false; 
    }
    setTimeout(() => {
        var url = BaseUrlApi + 'ventanilla/documento/proceso-paginado';
        $("#" + _grilla).GridUnload();
        var colNames = [
            '1', '2', 'Ver Adjuntos','Estado', 'Nro. Lote',
            'Nro. Expediente', 'Tipo Expediente', 'Asunto', 'Clasificación', 'Hora Inicio', 'Hora Fin', 'Obervación', 'Usuario de Creación', 'Fecha de Creación'
        ]
        var colModels = [
            { name: 'ID_DOCUMENTO_PROCESO', index: 'ID_DOCUMENTO_PROCESO ', align: 'center', hidden: true, key: true }, //1
            { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO ', align: 'center', hidden: true }, //2
            { name: 'VER_IMAGEN', index:  'VER_IMAGEN', align: 'center', width: 110, hidden: false, formatter: DocumentoProceso_actionVerImagen, search: false, sortable: false }, //4
            { name: 'DESCRIPCION_ESTADO', index: 'DESCRIPCION_ESTADO', align: 'center', width: 150, hidden: true, search: false },
            { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false },
            { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO', align: 'center', width: 150, hidden: false },
            { name: 'DES_TIP_DOC', index: 'DES_TIP_DOC', align: 'center', width: 150, hidden: false },
            { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'center', width: 200, hidden: false },
            { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'center', width: 200, hidden: false },
            { name: 'HORA_INICIO', index: 'HORA_INICIO', align: 'center', width: 100, hidden: showColumnHora , search:false},
            { name: 'HORA_FIN', index: 'HORA_FIN', align: 'center', width: 100, hidden: showColumnHora, search: false},
            { name: 'OBSERVACION', index: 'OBSERVACION ', align: 'center', width: 200, hidden: showObservaciones, formatter: DocumentoProceso_actionVerObs},
            { name: 'USU_CREACION', index: 'USU_CREACION ', align: 'center', width: 200, hidden: false },
            { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: false, search: false },
        ];
        var opciones = {
            GridLocal: false, nuevo: false, editar: false, eliminar: false, search: false, multiselect: false, rules: true, sort: 'asc',
            getrules: `GetRulesProceso()`,
            gridCompleteFunc: function () {
                var allJQGridData = $("#" + _grilla).jqGrid('getRowData');
                if (allJQGridData.length == 0) {
                    $(".ui-jqgrid-hdiv").css("overflow-x", "auto");
                }
                else {
                    // 
                    var e = $(".ui-jqgrid-hdiv");// document.getElementsByClassName(".ui-jqgrid-hdiv");
                    var ex = $(".ui-jqgrid-bdiv");
                    //scrollHeight: 68
                    e[0].scrollLeft = ex[0].scrollLeft;
                    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
                    //jQuery("#" + _grilla).trigger("reloadGrid");
                }
            },
        };
        SICA.Grilla(_grilla, _barra, '', '400', '', _titulo, url, 'ID_DOCUMENTO_PROCESO', colNames, colModels, 'ID_DOCUMENTO_PROCESO', opciones);
        $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
        jqGridResponsive($(".Tabla_jqGrid"));
        $("#" + _grilla + "_barra_left").css('width', '0px');
        //jQuery("#" + _grilla).jqGrid('setLabel', 0, 'NewLabel');
        $("#Load_Busqueda").hide();
    }, 100);
}
function GetRulesProceso() {
    let ESTADO_DOC = {
        digitalizados: 3, 
        calidadConforme: 4, 
        calidadObservado: 5, 
        reprocesado: 6, 
        FedatarioConforme: 7
    }
    var rules = new Array();
    _gs_NRO_LOTE = jQuery('#gs_' + 'NRO_LOTE').val();
    _gs_DESC_TIPO_DOC = jQuery('#gs_' + 'DES_TIP_DOC').val();
    _gs_DESC_ASUNTO = jQuery('#gs_' + 'DES_ASUNTO').val();
    _gs_DESC_CLASIF = jQuery('#gs_' + 'DES_CLASIF').val();
    _gs_OBSERVACION = jQuery('#gs_' + 'OBSERVACION').val();
    _gs_USU_CREACION = jQuery('#gs_' + 'USU_CREACION').val();
    ////
    var _NRO_LOTE = _gs_NRO_LOTE == '' || _gs_NRO_LOTE == undefined ? `''` : "'" + _gs_NRO_LOTE + "'";
    var _DESC_TIPO_DOC = _gs_DESC_TIPO_DOC == '' || _gs_DESC_TIPO_DOC == undefined ? `''` : "UPPER('" + _gs_DESC_TIPO_DOC + "')";
    var _DESC_ASUNTO = _gs_DESC_ASUNTO == '' || _gs_DESC_ASUNTO == undefined ? `''` : "UPPER('" + _gs_DESC_ASUNTO + "')";
    var _DESC_CLASIF = _gs_DESC_CLASIF == '' || _gs_DESC_CLASIF == undefined ? `''` : "UPPER('" + _gs_DESC_CLASIF + "')";
    var _OBSERVACION = _gs_OBSERVACION == '' || _gs_OBSERVACION == undefined ? `''` : "UPPER('" + _gs_OBSERVACION + "')";
    var _USU_CREACION = _gs_USU_CREACION == '' || _gs_USU_CREACION == undefined ? `''` : "UPPER('" + _gs_USU_CREACION + "')";
    let FECHA_INICIO = ($("#txtfechainicio").val() == null || $("#txtfechainicio").val() == '') ? '' : $("#txtfechainicio").val() + '';
    let FECHA_FIN = ($("#txtfechafin").val() == null || $("#txtfechafin").val() == '') ? '' : $("#txtfechafin").val() + '';
    let POR = "'%'";
    let format = "'DD/MM/YYYY'";
    var a = ' and ';
    rules = [
        { field: 'UPPER(V.NRO_LOTE)', data: POR + ' || ' + _NRO_LOTE + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.DES_TIP_DOC)', data: POR + ' || ' + _DESC_TIPO_DOC + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.DES_ASUNTO)', data: POR + ' || ' + _DESC_ASUNTO + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.DES_CLASIF)', data: POR + ' || ' + _DESC_CLASIF + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.OBSERVACION)', data: POR + ' || ' + _OBSERVACION + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.USU_CREACION)', data: POR + ' || ' + _USU_CREACION + ' || ' + POR, op: " LIKE " },
        { field: "TO_DATE(TO_CHAR(V.FEC_CREACION," + format + "), " + format + ")", data: "TO_DATE('" + FECHA_INICIO + "', " + format + ")" + a + "TO_DATE('" + FECHA_FIN + "', " + format + ")", op: " between " },
    ];

    if (_ID_MODULO == 5) { // digitilzados
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.digitalizados}`, op: " = " });
        rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    if (_ID_MODULO == 7) { // Aprobados
        let IdEstadoDocumento = $('#comboEstadoDocumento').val(); 
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${IdEstadoDocumento}`, op: "=" });
        rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    if (_ID_MODULO == 9) { //reprocesado
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.reprocesado}`, op: " = " });
        rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    if (_ID_MODULO == 11) { //fedatario conforme
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.FedatarioConforme}`, op: " = " });
        rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    return rules;
}

function DocumentoProceso_actionVerObs(cellvalue, options, rowObject) {
    var _btn = "";
    _btn = "<button title='Ver Observaciones' onclick='Documento_Ver_Obs(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'><i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}

function DocumentoProceso_actionVerImagen(cellvalue, options, rowObject) {
      let  _btn = "<button title='Ver Imagen' onclick='Documento_VerImagen(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen'> <i class=\"clip-images\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}