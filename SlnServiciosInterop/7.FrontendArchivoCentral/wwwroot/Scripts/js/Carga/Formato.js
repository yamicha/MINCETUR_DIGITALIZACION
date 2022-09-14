
var Formato_grilla = 'Formato_grilla';
var Formato_barra = 'Formato_barra';

function Formato_ConfigurarGrilla() {
    $("#" + Formato_grilla).GridUnload();
    var colNames = ['N°', 'Código', 'Proceso', 'Descripción', 'Obligatorio', '', 'Longitud', 'Ejemplo', 'Leyenda'];
    var colModels = [
        { name: 'NRO_CAMPO', index: 'NRO_CAMPO', align: 'center', width: 60, hidden: true, key: true },
        { name: 'COD_CAMPO', index: 'COD_CAMPO', align: 'center', width: 100, hidden: true },
        { name: 'TIPO_DATO', index: 'TIPO_DATO', align: 'center', width: 150, hidden: true },
        { name: 'DESCRIPCION_CAMPO', index: 'DESCRIPCION_CAMPO', align: 'center', width: 300, hidden: false },
        { name: 'OBLIGATORIO_MOS', index: 'OBLIGATORIO_MOS', align: 'center', width: 100, hidden: false, formatter: Formato_actionobligatorio },
        { name: 'OBLIGATORIO', index: 'OBLIGATORIO', align: 'center', width: 1, hidden: true },
        { name: 'LONGITUD', index: 'LONGITUD', align: 'center', width: 70, hidden: false },
        { name: 'DATO_EJEMPLO', index: 'DATO_EJEMPLO', align: 'center', width: 250, hidden: false },
        { name: 'COD_LEYENDA', index: 'COD_LEYENDA', align: 'center', width: 350, hidden: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, Editar: false, nuevo: false, eliminar: false, search: false
        //,
        //selectRowFunc: function () {

        //    var rowKey = parseInt(jQuery("#" + grilla_for).getGridParam('selrow'));
        //    var data = jQuery("#" + grilla_for).jqGrid('getRowData', rowKey);

        //}
    };
    SICA.Grilla(Formato_grilla, Formato_barra, '400', '400', '', '', '', 'NRO_CAMPO', colNames, colModels, '', opciones);
}

function Formato_actionobligatorio(cellvalue, options, rowObject) {
    var OBLIGATORIO = rowObject.OBLIGATORIO;
    var VALOR = '';
    if (OBLIGATORIO == '1') {
        VALOR = "<a> SI </a>";
    } else {
        VALOR = "<a> NO </a>";
    }
    return VALOR;
}

function Formato_CargarGrilla() {
    var item =
    {
        ID_TABLA: $("#hd_Formato_ID_TABLA").val()
    };
    var url = baseUrl + 'Carga/Formato/Listar_Todo';
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + Formato_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            $.each(auditoria.OBJETO, function (i, v) {
                if (v.FLG_CLASIFICACION == 'F') {
                    var myData =
                    {
                        COD_CAMPO: v.COD_CAMPO,
                        TIPO_DATO: v.TIPO_DATO,
                        DESCRIPCION_CAMPO: v.DESCRIPCION_CAMPO,
                        LONGITUD: v.LONGITUD,
                        DATO_EJEMPLO: v.DATO_EJEMPLO,
                        OBLIGATORIO: v.OBLIGATORIO,
                        COD_LEYENDA: v.COD_LEYENDA,
                        NRO_CAMPO: v.NRO_CAMPO
                    };
                    jQuery("#" + Formato_grilla).jqGrid('addRowData', i, myData);
                }
            });
            jQuery("#" + Formato_grilla).trigger("reloadGrid");
        }
    }
}

jQuery('#FormatoVer_btnDescargar').click(function (e) {
    Formato_Descargar();
});

function Formato_Descargar() {
    jQuery("#myModal_FormatoVer_Descargar").html('');
    jQuery("#myModal_FormatoVer_Descargar").load(baseUrl + "Carga/Formato/Formato_Descargar?ID_TABLA=" + $("#hd_Formato_ID_TABLA").val(), function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_FormatoVer_Descargar');
        if (request.status != 200) return;
    });
}

