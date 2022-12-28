
function DocumentoProceso_ConfigurarGrilla(_grilla, _barra, _titulo, _modulo) {
    debugger;
    _ID_MODULO = _modulo;
    $(".ui-jqgrid-hdiv").css("overflow-x", "hidden");
    $("#Recepcion_busqueda").show();
    let showColumnHora = false;
    let showUsuario = false;
    let showFecha = false;
    let columnaUsuario = "Usuario Reproceso";
    let columnaFecha = "Fecha Reproceso";
    if (_ID_MODULO == 5) {
        columnaUsuario = "Digitalizador";
        showFecha = true;
    }
    if (_ID_MODULO != 5) showColumnHora = true;
    if (_ID_MODULO == 7) {
        showUsuario = true;
         showFecha = true;
    }
    setTimeout(() => {
        var url = BaseUrlApi + 'archivo-central/documento/proceso-paginado';
        $("#" + _grilla).GridUnload();
        var colNames = [
            '1', '2', 'Estado', 'Nro. Lote', '',
            'Nombre Documento', 'Fondo', 'Sección', 'Serie', 'Hora Inicio', 'Hora Fin', 'Obervación', columnaUsuario, columnaFecha
        ]
        var colModels = [
            { name: 'ID_DOCUMENTO_PROCESO', index: 'ID_DOCUMENTO_PROCESO ', align: 'center', hidden: true, key: true }, //0
            { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO ', align: 'center', hidden: true }, //1
            { name: 'DESCRIPCION_ESTADO', index: 'DESCRIPCION_ESTADO', align: 'center', width: 150, hidden: true, search: false }, //2
            { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false }, //3
            { name: 'NOM_DOCUMENTO', index: 'NOM_DOCUMENTO', align: 'center', width: 300, hidden: true }, //4
            { name: '_NOM_DOCUMENTO', index: '_NOM_DOCUMENTO', align: 'center', width: 300, hidden: false, formatter: DocumentoProceso_actionCodVerProceso, sortable: false }, //5
            { name: 'DES_FONDO', index: 'DES_FONDO', align: 'center', width: 200, hidden: false },
            { name: 'DES_LARGA_SECCION', index: 'DES_LARGA_SECCION', align: 'center', width: 220, hidden: false },
            { name: 'DES_SERIE', index: 'DES_SERIE', align: 'center', width: 220, hidden: false },
            { name: 'HORA_INICIO', index: 'HORA_INICIO', align: 'center', width: 100, hidden: showColumnHora , search:false},
            { name: 'HORA_FIN', index: 'HORA_FIN', align: 'center', width: 100, hidden: showColumnHora, search: false},
            { name: 'OBSERVACION', index: 'OBSERVACION ', align: 'center', width: 250, hidden: false },
            { name: 'USU_CREACION', index: 'USU_CREACION ', align: 'center', width: 200, hidden: showUsuario },
            { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION ', align: 'center', width: 150, hidden: showFecha },
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
        $("#Recepcion_busqueda").hide();
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
    _gs_DESC_FONDO = jQuery('#gs_' + 'DES_FONDO').val();
    _gs_DESC_LARGA_SECCION = jQuery('#gs_' + 'DES_LARGA_SECCION').val();
    _gs_DESC_SERIE = jQuery('#gs_'+ 'DES_SERIE').val();
    _gs_NOM_DOCUMENTO = jQuery('#gs_' + 'NOM_DOCUMENTO').val();
    _gs_OBSERVACION = jQuery('#gs_' + 'OBSERVACION').val();
    _gs_USU_CREACION = jQuery('#gs_' + 'USU_CREACION').val();
    _gs_STR_FEC_CREACION = jQuery('#gs_' + 'STR_FEC_CREACION').val();
    ////
    var _NRO_LOTE = _gs_NRO_LOTE == '' || _gs_NRO_LOTE == undefined ? `''` : "'" + _gs_NRO_LOTE + "'";
    var _DESC_FONDO = _gs_DESC_FONDO == '' || _gs_DESC_FONDO == undefined ? `''` : "UPPER('" + _gs_DESC_FONDO + "')";
    var _DESC_LARGA_SECCION = _gs_DESC_LARGA_SECCION == '' || _gs_DESC_LARGA_SECCION == undefined ? `''` : "UPPER('" + _gs_DESC_LARGA_SECCION + "')";
    var _DESC_SERIE = _gs_DESC_SERIE == '' || _gs_DESC_SERIE == undefined ? `''` : "UPPER('" + _gs_DESC_SERIE + "')";
    var _NOM_DOCUMENTO = _gs_NOM_DOCUMENTO == '' || _gs_NOM_DOCUMENTO == undefined ? `''` : "UPPER('" + _gs_NOM_DOCUMENTO + "')";
    var _OBSERVACION = _gs_OBSERVACION == '' || _gs_OBSERVACION == undefined ? `''` : "UPPER('" + _gs_OBSERVACION + "')";
    var _USU_CREACION = _gs_USU_CREACION == '' || _gs_USU_CREACION == undefined ? `''` : "UPPER('" + _gs_USU_CREACION + "')";
    var _FEC_CREACION = _gs_STR_FEC_CREACION == '' || _gs_STR_FEC_CREACION == undefined ? `''` : "UPPER('" + _gs_STR_FEC_CREACION + "')";
    let FECHA_INICIO = ($("#txtFechaInicio").val() == null || $("#txtFechaInicio").val() == '') ? '' : $("#txtFechaInicio").val() + '';
    let FECHA_FIN = ($("#txtFechaFin").val() == null || $("#txtFechaFin").val() == '') ? '' : $("#txtFechaFin").val() + '';
    let POR = "'%'";
    let format = "'DD/MM/YYYY'";
    var a = ' and ';
    rules = [
        { field: 'UPPER(V.NRO_LOTE)', data: POR + ' || ' + _NRO_LOTE + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.DES_FONDO)', data: POR + ' || ' + _DESC_FONDO + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.DES_LARGA_SECCION)', data: POR + ' || ' + _DESC_LARGA_SECCION + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.DES_SERIE)', data: POR + ' || ' + _DESC_SERIE + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.NOM_DOCUMENTO)', data: POR + ' || ' + _NOM_DOCUMENTO + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.OBSERVACION)', data: POR + ' || ' + _OBSERVACION + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.USU_CREACION)', data: POR + ' || ' + _USU_CREACION + ' || ' + POR, op: " LIKE " },
        { field: 'UPPER(V.STR_FEC_CREACION)', data: POR + ' || ' + _FEC_CREACION + ' || ' + POR, op: " LIKE " },
        { field: "TO_DATE(TO_CHAR(V.FEC_CREACION," + format + "), " + format + ")", data: "TO_DATE('" + FECHA_INICIO + "', " + format + ")" + a + "TO_DATE('" + FECHA_FIN + "', " + format + ")", op: " between " },
    ];

    if (_ID_MODULO == 5) { // digitilzados
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.digitalizados}`, op: " = " });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    if (_ID_MODULO == 7) { // Aprobados
        let IdEstadoDocumento = $('#comboEstadoDocumento').val(); 
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${IdEstadoDocumento}`, op: "=" });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    if (_ID_MODULO == 9) { //reprocesado
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.reprocesado}`, op: " = " });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    if (_ID_MODULO == 11) { //fedatario conforme
        rules.push({ field: 'V.ID_ESTADO_DOCUMENTO', data: `${ESTADO_DOC.FedatarioConforme}`, op: " = " });
        //rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }
    // modo admin
    debugger; 
    const perfilLogin = $('#inputHddCod_perfil').val();
    //DIGI_ADMIN para desarrollo y para QA es SCDDBA_ADMIN_CDA
    if ((_ID_MODULO == 5 || _ID_MODULO == 7 || _ID_MODULO == 9 || _ID_MODULO == 11) && (perfilLogin != "SCDDBA_ADMIN_CDA")) {
        rules.push({ field: 'V.ID_USU_CREACION', data: $("#inputHddId_Usuario").val(), op: " = " });
    }

    return rules;
}

function DocumentoProceso_actionCodVerProceso(cellvalue, options, rowObject) {
    var _btn = rowObject[4];
    if (_ID_MODULO != 2)
        _btn += " <br/> <button title='Ver Movimientos' onclick='Documento_Ver_Proceso(" + rowObject[1] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Ver_Imagen' style=\"color:#a01010;font-size:12px\"><i class=\"clip-stack\"></i> Movimientos</button>";
    return _btn;
}

function Documento_Ver_Proceso(CODIGO) {
    jQuery("#myModal_Documento_Ver_Imagen").html('');
    jQuery("#myModal_Documento_Ver_Imagen").load(baseUrl + "Digitalizacion/documento/ver-proceso?ID_DOCUMENTO=" + CODIGO, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Ver_Imagen');
        if (request.status != 200) return;
    });
}