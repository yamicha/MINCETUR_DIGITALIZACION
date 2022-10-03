var Devolver_grilla = 'Devolver_grilla';
var Devolver_barra = 'Devolver_barra';

var Devolver_Lote_grilla = 'Devolver_Lote_grilla';
var Devolver_Lote_barra = 'Devolver_Lote_barra';
var Devolver_ListaLotes = new Array();

$(document).ready(function () {
    DevolverLote_ConfigurarGrilla(Devolver_Lote_grilla, Devolver_Lote_barra);
    Lote_CargarGrilla(Devolver_Lote_grilla, 0);
    Documento_Detalle_buscar(Devolver_grilla, Devolver_barra);
    $('#Devolver_btnDevolver').click(function (e) {
        var rowKey = $("#" + Devolver_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
        if (rowKey != null) {
            if (rowKey.length > 0) {
                Devolver_ListaLotes.pop();
                Devolver_ListaLotes = rowKey;
                Devolver_MostrarDevolver();
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

function DevolverLote_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = ['1', '2',
        'Lote', 'Fecha de Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 50, hidden: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false }
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
    SICA.Grilla(_grilla, _barra, '', '582', '', '', "", "", colNames, colModels, "", opciones);
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
jQuery('#Devolver_btn_Grabar').click(function (e) {
    if (Devolver_ListaLotes.length > 0) {
        jConfirm(" ¿ Desea grabar todas los lotes seleccionados para devolución ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    ListaIdsLotes: Devolver_ListaLotes,
                    UsuCreacion: $('#inputHddCod_usuario').val()
                }
                var url = "archivo-central/documento/devolver-documentos";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                jOkas("Devolución generado correctamente", "Atención");
                                Lote_CargarGrilla(Devolver_Lote_grilla, 0);
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
});


