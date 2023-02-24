
function DocumentoProceso_ConfigurarGrilla(_grilla, _barra, _titulo, _modulo) {
    _ID_MODULO = _modulo;
    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    $("#Load_Busqueda").show();
    let showColumnHora = false;
    let showUsuario = false;
    let showFecha = false;
    let showObservaciones = true;
    let columnaUsuario = "Usuario Reproceso";
    let columnaFecha = "Fecha Reproceso";
    if (_ID_MODULO == 5) {
        columnaUsuario = "Digitalizador";
        showFecha = true;
    }
    if (_ID_MODULO != 5) {
        showColumnHora = true;
        showObservaciones = false; 
    }
    if (_ID_MODULO == 7) {
        showUsuario = true;
        showFecha = true;
    }
    setTimeout(() => {
        var url = BaseUrlApi + 'ventanilla/documento/proceso-paginado';
        $("#" + _grilla).GridUnload();
        var colNames = [
            '1', '2', 'Ver Adjuntos', 'Estado', 'Nro. Lote', 'Digitalizador',
            'Nro. Expediente', 'Documento', 'Ver Movimiento', 'Comentario', 'Tipo Expediente', 'Asunto', 'Clasificación', 'Hora Inicio', 'Hora Fin', 'Obervación', columnaUsuario, columnaFecha
        ]
        //var colModels = [
        //    { name: 'ID_DOCUMENTO_PROCESO', index: 'ID_DOCUMENTO_PROCESO ', align: 'center', hidden: true, key: true }, //1
        //    { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO ', align: 'center', hidden: true }, //2
        //    { name: 'VER_IMAGEN', index:  'VER_IMAGEN', align: 'center', width: 110, hidden: false, formatter: DocumentoProceso_actionVerImagen, search: false, sortable: false }, //4
        //    { name: 'DESCRIPCION_ESTADO', index: 'DESCRIPCION_ESTADO', align: 'center', width: 150, hidden: true, search: false },
        //    { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false },
        //    { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO', align: 'center', width: 150, hidden: false },
        //    { name: 'DES_TIP_DOC', index: 'DES_TIP_DOC', align: 'center', width: 150, hidden: false },
        //    { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'center', width: 200, hidden: false },
        //    { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'center', width: 200, hidden: false },
        //    { name: 'HORA_INICIO', index: 'HORA_INICIO', align: 'center', width: 100, hidden: showColumnHora , search:false},
        //    { name: 'HORA_FIN', index: 'HORA_FIN', align: 'center', width: 100, hidden: showColumnHora, search: false},
        //    { name: 'OBSERVACION', index: 'OBSERVACION ', align: 'center', width: 200, hidden: showObservaciones, formatter: DocumentoProceso_actionVerObs},
        //    { name: 'USU_CREACION', index: 'USU_CREACION ', align: 'center', width: 200, hidden: false },
        //    { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: false, search: false },
        //];
        var colModels = [
            { name: 'ID_DOCUMENTO_PROCESO', index: 'ID_DOCUMENTO_PROCESO ', align: 'center', hidden: true, key: true }, //0
            { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO ', align: 'center', hidden: true }, //1
            { name: 'VER_IMAGEN', index: 'VER_IMAGEN', align: 'center', width: 110, hidden: false, formatter: DocumentoProceso_actionVerImagen, search: false, sortable: false, hidden: true }, //2
            { name: 'DESCRIPCION_ESTADO', index: 'DESCRIPCION_ESTADO', align: 'center', width: 150, hidden: true, search: false }, //3
            { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false }, //4
            { name: 'NOMBRE_USUARIO', index: 'NOMBRE_USUARIO', align: 'center', width: 180, hidden: false, editable: true, sortable: false }, //5
            { name: 'EXPE_ID_DOCUMENTO', index: 'EXPE_ID_DOCUMENTO', align: 'center', width: 150, hidden: false, sortable: false }, //6
            { name: 'VERIFICAR', index: _PREFIJO + 'VERIFICAR', align: 'center', width: 110, formatter: Reprocesar_actionVer, search: false, sortable: false, hidden: false }, //9
            { name: '_VER_MOVIMIENTO', index: '_VER_MOVIMIENTO', align: 'center', width: 150, hidden: false, formatter: DocumentoProceso_actionCodVerProceso, sortable: false, search: false }, //7
            { name: 'COMENTARIO', index: 'COMENTARIO ', align: 'center', width: 200, hidden: showObservaciones, sortable: false  },
            { name: 'DES_TIP_DOC', index: 'DES_TIP_DOC', align: 'center', width: 150, hidden: false },
            { name: 'DES_ASUNTO', index: 'DES_ASUNTO', align: 'center', width: 200, hidden: false },
            { name: 'DES_CLASIF', index: 'DES_CLASIF', align: 'center', width: 200, hidden: false },
            { name: 'HORA_INICIO', index: 'HORA_INICIO', align: 'center', width: 100, hidden: showColumnHora, search: false },
            { name: 'HORA_FIN', index: 'HORA_FIN', align: 'center', width: 100, hidden: showColumnHora, search: false },
            { name: 'OBSERVACION', index: 'OBSERVACION ', align: 'center', width: 200, hidden: showObservaciones, formatter: DocumentoProceso_actionVerObs, search: false },
            { name: 'USU_CREACION', index: 'USU_CREACION ', align: 'center', width: 200, hidden: showUsuario },
            { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: showFecha, search: false },
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
    _gs_NOMBRE_USUARIO = jQuery('#gs_' + 'NOMBRE_USUARIO').val();
    _gs_EXPE_ID_DOCUMENTO = jQuery('#gs_' + 'EXPE_ID_DOCUMENTO').val();
    _gs_COMENTARIO = jQuery('#gs_' + 'COMENTARIO').val();
    ////
    var _NRO_LOTE = _gs_NRO_LOTE == '' || _gs_NRO_LOTE == undefined ? `''` : "'" + _gs_NRO_LOTE + "'";
    var _DESC_TIPO_DOC = _gs_DESC_TIPO_DOC == '' || _gs_DESC_TIPO_DOC == undefined ? `''` : "UPPER('" + _gs_DESC_TIPO_DOC + "')";
    var _DESC_ASUNTO = _gs_DESC_ASUNTO == '' || _gs_DESC_ASUNTO == undefined ? `''` : "UPPER('" + _gs_DESC_ASUNTO + "')";
    var _DESC_CLASIF = _gs_DESC_CLASIF == '' || _gs_DESC_CLASIF == undefined ? `''` : "UPPER('" + _gs_DESC_CLASIF + "')";
    var _OBSERVACION = _gs_OBSERVACION == '' || _gs_OBSERVACION == undefined ? `''` : "UPPER('" + _gs_OBSERVACION + "')";
    var _USU_CREACION = _gs_USU_CREACION == '' || _gs_USU_CREACION == undefined ? `''` : "UPPER('" + _gs_USU_CREACION + "')";
    var _NOMBRE_USUARIO = _gs_NOMBRE_USUARIO == '' || _gs_NOMBRE_USUARIO == undefined ? `''` : "UPPER('" + _gs_NOMBRE_USUARIO + "')";
    var _EXPE_ID_DOCUMENTO = _gs_EXPE_ID_DOCUMENTO == '' || _gs_EXPE_ID_DOCUMENTO == undefined ? `''` : "UPPER('" + _gs_EXPE_ID_DOCUMENTO + "')";
    var _COMENTARIO = _gs_COMENTARIO == '' || _gs_COMENTARIO == undefined ? `''` : "UPPER('" + _gs_COMENTARIO + "')";
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
        { field: 'UPPER(V.NOMBRE_USUARIO)', data: POR + ' || ' + _NOMBRE_USUARIO + ' || ' + POR, op: " LIKE " },
        { field: "TO_DATE(TO_CHAR(V.FEC_CREACION," + format + "), " + format + ")", data: "TO_DATE('" + FECHA_INICIO + "', " + format + ")" + a + "TO_DATE('" + FECHA_FIN + "', " + format + ")", op: " between " },
    ];

    if (_ID_MODULO == 5) { // digitilzados
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.digitalizados}`, op: " = " });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
        rules.push({ field: 'V.ID_DOCUMENTO', data: POR + ' || ' + _EXPE_ID_DOCUMENTO + ' || ' + POR, op: " LIKE " });
    }
    if (_ID_MODULO == 7) { // Aprobados
        let IdEstadoDocumento = $('#comboEstadoDocumento').val(); 
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${IdEstadoDocumento}`, op: "=" });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
        rules.push({ field: 'V.ID_DOCUMENTO', data: POR + ' || ' + _EXPE_ID_DOCUMENTO + ' || ' + POR, op: " LIKE " });
        rules.push({ field: 'UPPER(V.OBSERVACION)', data: POR + ' || ' + _COMENTARIO + ' || ' + POR, op: " LIKE " });
    }
    if (_ID_MODULO == 9) { //reprocesado
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.reprocesado}`, op: " = " });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
        rules.push({ field: 'V.ID_DOCUMENTO', data: POR + ' || ' + _EXPE_ID_DOCUMENTO + ' || ' + POR, op: " LIKE " });
        rules.push({ field: 'UPPER(V.OBSERVACION)', data: POR + ' || ' + _COMENTARIO + ' || ' + POR, op: " LIKE " });
    }
    if (_ID_MODULO == 11) { //fedatario conforme
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.FedatarioConforme}`, op: " = " });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    // modo admin
    debugger;
    const perfilLogin = $('#inputHddCod_perfil').val();
    //DIGI_ADMIN para desarrollo y para QA es SCDDBA_ADMIN_CDA
    if ((_ID_MODULO == 5 || _ID_MODULO == 7 || _ID_MODULO == 9 || _ID_MODULO == 11) && (perfilLogin != "SCDDBA_ADMIN_CDV")) {
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

function DocumentoProceso_actionCodVerProceso(cellvalue, options, rowObject) {
    var _btn = "";//rowObject[4];
    if (_ID_MODULO != 2)
        _btn += " <br/> <button title='Ver Movimientos' onclick='Documento_Ver_Proceso(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen' style=\"color:#a01010;font-size:12px\"><i class=\"clip-stack\"></i> Movimientos</button>";
    return _btn;
}

function Reprocesar_actionVer(cellvalue, options, rowObject) {
    var _btn = "";
    _btn = "<button title='Ver Documento' onclick='Reprocesar_Recibir(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Recibir_Doc'> <i class=\"clip-folder-plus\" style=\"color:#a01010;font-size:20px\"></i></button>";
    return _btn;
}

function Reprocesar_Recibir(CODIGO) {
    jQuery("#myModal_Recibir_Doc").html('');
    jQuery("#myModal_Recibir_Doc").load(baseUrl + "Digitalizacion/Recepcion/expediente-documento?ID_EXPE=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Recibir_Doc');
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