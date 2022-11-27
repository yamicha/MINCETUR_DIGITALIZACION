var Devolver_grilla = 'Devolver_grilla';
var Devolver_barra = 'Devolver_barra';

var Devolver_Lote_grilla = 'Devolver_Lote_grilla';
var Devolver_Lote_barra = 'Devolver_Lote_barra';
var Devolver_ListaLotes = new Array();

$(document).ready(function () {
    DevolverLote_ConfigurarGrilla(Devolver_Lote_grilla, Devolver_Lote_barra);
    Lote_CargarGrilla(Devolver_Lote_grilla, "0","");
    Documento_Detalle_buscar(Devolver_grilla, Devolver_barra);
    $('#Devolver_btnDevolver').click(async function (e) {
        var rowKey = $("#" + Devolver_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
        if (rowKey != null) {
            if (rowKey.length > 0) {
                if (await Devueltos_ValidarLote()) {
                    Devolver_MostrarDevolver();
                }
            }
            else {
                jAlert("Debe seleccionar por lo menos un lote.", "Atención");
            }
        }
        else {
            jAlert("Debe seleccionar por lo menos un lote.", "Atención");
        }
    });
});

function Devolver_CloseModal() {
    $('#myModalNuevo').html("");
    $('#myModalNuevo').modal("hide"); 
}
function DevolverLote_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = ['1', '2',
        'Lote', 'Fecha de Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 50, hidden: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false, search: true  },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false, search: true  }
    ];
    var opciones = {
        GridLocal: true, multiselect: true, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
        grouping: false,
        selectRowFunc: function () {
            var rowKey = parseInt(jQuery("#" + _grilla).getGridParam('selrow'));
            var data = jQuery("#" + _grilla).jqGrid('getRowData', rowKey);
            _ID_LOTE = data.ID_LOTE;
            if (data.ID_LOTE == undefined) _ID_LOTE = 0;
            Documento_Detalle_buscar(Devolver_grilla, Devolver_barra);
        },
        //tituloGrupo: 'Sub Lote(s)'
    };
    SICA.Grilla(_grilla, _barra, '', '550', '', '', "", "", colNames, colModels, "", opciones)
    $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });;
    jqGridResponsive($(".jqGridLote"));
}

function Devolver_MostrarDevolver() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").modal('show');
    jQuery("#myModalNuevo").load(baseUrl + "Digitalizacion/devolucion/mantenimiento?Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function Devolver_GrabarDevolucion() {
    if ($('#FrmDevolucion').valid()) {
        var rowKey = $("#" + Devolver_Lote_grilla).jqGrid('getGridParam', 'selarrrow');
        if (rowKey.length > 0) {
            jConfirm(" ¿ Desea grabar todas los lotes seleccionados para devolución ? ", "Atención", function (r) {
                if (r) {
                    Devolver_ListaLotes.pop(); 
                    for (var i = 0; i < rowKey.length; i++) {
                        var data = jQuery("#" + Devolver_Lote_grilla).jqGrid('getRowData', rowKey[i]);
                        var item = { IdLote: parseInt(data.ID_LOTE)};
                        Devolver_ListaLotes.push(item);
                    }
                    var item = {
                        ListaIdsLotes: Devolver_ListaLotes,
                        IdArea: parseInt($('#ID_AREA').val()),
                        IdUsuario: parseInt($('#inputHddId_Usuario').val()),
                        Comentario: $('#OBSERVACION').val(),
                        UsuCreacion: $('#inputHddId_Usuario').val()
                    }
                    var url = "archivo-central/digitalizacion/devolver-documentos";
                    API.Fetch("POST", url, item, function (auditoria) {
                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Devolver_CloseModal(); 
                                    jOkas("Devolución generado correctamente", "Atención");
                                    Lote_CargarGrilla(Devolver_Lote_grilla, "0", "");
                                    _ID_LOTE = 0;
                                    Documento_Detalle_buscar(Devolver_grilla, Devolver_barra);
                                    Devolver_ListaLotes = new Array();
                                } else {
                                    jAlert(auditoria.MensajeSalida, "Atención");
                                }
                            } else {
                                jAlert(auditoria.MensajeSalida, "Atención");
                            }
                        } else {
                            jAlert("No se encontraron registros", "Atención");
                        }
                    });
                }
            });
        } else {
            jAlert("Debe seleccionar por lo menos un lote.", "Atención");
        }
    }
}

async function Devolver_ComboArea() {
    var OptionsCbo = {
        KeyVal: { value: "ID_AREA", name: "DES_AREA" },
        paramters: { FlgEstado: "1" },
        method: "POST"
    }
    await LoadComboApi("archivo-central/area/listar", "ID_AREA", OptionsCbo)

}


/*************************************************** TAB DEVUELTOS *********************************/
var Devueltos_grilla = 'Devueltos_grilla';
var Devueltos_barra = 'Devueltos_barra';

var Devueltos_Lote_grilla = 'Devueltos_Lote_grilla';
var Devueltos_Lote_barra = 'Devueltos_Lote_barra';
$('#aTabDevueltos').click(function () {
    DevueltosLote_ConfigurarGrilla();
    DevueltosLote_CargarGrilla(); 
    _ID_LOTE = 0; 
    Documento_Detalle_buscar(Devueltos_grilla, Devueltos_barra);
}); 

function DevueltosLote_ConfigurarGrilla() {
    $("#" + Devueltos_Lote_grilla).GridUnload();
    var colNames = ['1', '2',
        'Lote', 'Fecha de Creación','Area','Fecha Devolución','Observación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 50, hidden: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false, search: true },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false, search: true },
        { name: 'DES_AREA', index: 'DES_AREA', align: 'center', width: 250, hidden: true, search: true },
        { name: 'STR_FEC_DEVOLUCION', index: 'STR_FEC_DEVOLUCION', align: 'center', width: 150, hidden: false, search: true },
        { name: 'OBS_DEVOLUCION', index: 'OBS_DEVOLUCION', align: 'center', width: 250, hidden: false, search: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
        grouping: true, groupingCampo: 'DES_AREA', tituloGrupo: 'Area(s)',
        selectRowFunc: function () {
            var rowKey = parseInt(jQuery("#" + Devueltos_Lote_grilla).getGridParam('selrow'));
            var data = jQuery("#" + Devueltos_Lote_grilla).jqGrid('getRowData', rowKey);
            _ID_LOTE = data.ID_LOTE;
            if (data.ID_LOTE == undefined) _ID_LOTE = 0;
            Documento_Detalle_buscar(Devueltos_grilla, Devueltos_barra);
        },

    };
    SICA.Grilla(Devueltos_Lote_grilla, Devueltos_Lote_barra, '', '550', '', '', "", "", colNames, colModels, "", opciones)
    $("#" + Devueltos_Lote_grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });;
    jqGridResponsive($(".jqGridLote"));
}

function DevueltosLote_CargarGrilla() {
    var item = {
        flgDevuelto: "1",
        flgMicroforma: ""
    }
    var url = `archivo-central/digitalizacion/listar-lotes`;
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + Devueltos_Lote_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    var x = 0;
                    $.each(auditoria.Objeto, function (i, v) {
                        x++;
                        var myData =
                        {
                            CODIGO: x,
                            ID_LOTE: v.ID_LOTE,
                            NRO_LOTE: v.NRO_LOTE,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            OBS_DEVOLUCION: v.OBS_DEVOLUCION, 
                            DES_AREA: v.DES_AREA,
                            STR_FEC_DEVOLUCION: v.STR_FEC_DEVOLUCION,
                            USU_DEVOLUCION: v.USU_DEVOLUCION,
                        };
                        jQuery("#" + Devueltos_Lote_grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + Devueltos_Lote_grilla).trigger("reloadGrid");
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Atención");
            }

        } else {
            jAlert("No se encontraron registros", "Atención");
        }
    });

}

function Devueltos_ValidarLote() {
    var VALIDO = false;
    var rowKey = $("#" + Devolver_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    return new Promise((valido) => {
        if (rowKey != null) {
            MicroformaGrabar_ListaLotes = new Array();
            for (i_ = 0; i_ < rowKey.length; i_++) {
                var data = jQuery("#" + Devolver_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
                var _item = {
                    IdLote: parseInt(data.ID_LOTE)
                }
                MicroformaGrabar_ListaLotes.push(_item);
            }
            var item = {
                ListaIdsLotes: MicroformaGrabar_ListaLotes
            }
            var url = "archivo-central/digitalizacion/documento-validar-lote";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            valido(true);
                        } else {
                            valido(false);
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                        $("#Microforma_Div_validar").hide();
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                        $("#Microforma_Div_validar").hide();
                    }
                } else {
                    jAlert("No se encontraron registros", "Atención");
                    $("#Microforma_Div_validar").hide();
                }
            });
        }
    });
}