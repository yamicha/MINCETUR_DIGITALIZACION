
function ConfigurarColor(Documento_Color_grilla) {
    var rowKey = jQuery("#" + Documento_Color_grilla).getDataIDs();
    for (var i = 0; i < rowKey.length; i++) {
        var data = jQuery("#" + Documento_Color_grilla).jqGrid('getRowData', rowKey[i]);
        var _estado = "";
        if (_ID_MODULO == 3) {
            _estado = data.Asignados_ID_ESTADO_DOCUMENTO;
        } else if (_ID_MODULO == 12) {
            _estado = data.MicroformaGrabar_ID_ESTADO_DOCUMENTO;
        }
        if (_estado != "") {
            if (_estado != 1 && _estado != 2 && _ID_MODULO == 3) {
                $("#" + Documento_Color_grilla).jqGrid('setRowData', rowKey[i], true, { background: "#ffc790" });
            } else if (_estado == 7 && _ID_MODULO == 12) {
                $("#" + Documento_Color_grilla).jqGrid('setRowData', rowKey[i], true, { background: "rgb(35 173 0 / 54%)" });
            }
        }
    }
}

function ConfigurarColor_DocumentoRepetido(_Grilla) {
    var valido = true; 
    var rowKey = jQuery("#" + _Grilla).getDataIDs();
    for (var i = 0; i < rowKey.length; i++) {
        var data = jQuery("#" + _Grilla).jqGrid('getRowData', rowKey[i]);
        var _FLG_REPETIDO = data.FLG_REPETIDO;
        if (_FLG_REPETIDO == 1) {
            valido = false; 
            $("#" + _Grilla).jqGrid('setRowData', rowKey[i], true, { background: "#EE6B6F",color:"#fff" });
            //} else if (_estado == 7 && _ID_MODULO == 12) {
            //    $("#" + _Grilla).jqGrid('setRowData', rowKey[i], true, { background: "rgb(35 173 0 / 54%)" });
            //}
        }
    }
    if (!valido)
        jAlert('Se encontraron documentos repetidos en este proceso de carga, por favor validar.','Atención')
}