
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