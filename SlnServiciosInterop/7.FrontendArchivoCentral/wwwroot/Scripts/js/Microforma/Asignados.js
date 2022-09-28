var Asignados_grilla = 'Asignados_grilla';
var Asignados_barra = 'Asignados_barra';

var Asignados_Lote_grilla = 'Asignados_Lote_grilla';
var Asignados_Lote_barra = 'Asignados_Lote_barra';
var Asignados_ListaDocumentos = new Array();

$(document).ready(function () {
    Lote_ConfigurarGrilla(Asignados_Lote_grilla, Asignados_Lote_barra, false);
});

jQuery('#aTabAsignados').click(function (e) {
    _ID_LOTE = 0;
    Asignados_ListaDocumentos = new Array();
    Lote_CargarGrilla(Asignados_Lote_grilla, 0);
    Asignados_buscar();
});

function Asignados_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Asignados_grilla + "," + Asignados_barra + ",\"Listado de documentos asignados\", true, 3);", 500);
}

jQuery('#Asignados_btn_Reasignar').click(function (e) {
    Asignados_Digitalizador();
});

function Asignados_Digitalizador() {
    var ID_DIGITALIZADOR = $("#ID_DIGITALIZADOR2").val();
    if (ID_DIGITALIZADOR != '') {
        var rowKey = $("#" + Asignados_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
        if (rowKey.length > 0) {
            var DESC_DIGITALIZADOR = $("#ID_DIGITALIZADOR2 option:selected").text();
            for (var i = 0; i < rowKey.length; i++) {
                var data = jQuery("#" + Asignados_grilla).jqGrid('getRowData', rowKey[i]);
                if (data.Asignados_ID_ESTADO_DOCUMENTO == 2) {
                    jQuery("#" + Asignados_grilla).jqGrid('setRowData', rowKey[i], { Asignados_NOMBRE_USUARIO: DESC_DIGITALIZADOR });
                    data.Asignados_NOMBRE_USUARIO = DESC_DIGITALIZADOR;
                    const resultado = Asignados_ListaDocumentos.find(x => x.ID_DOCUMENTO === data.Asignados_ID_DOCUMENTO);

                    var miitem = {
                        IdDocumentoAsignado: parseInt(data.Asignados_ID_DOCUMENTO_ASIGNADO),
                        IdDocumento: parseInt(data.Asignados_ID_DOCUMENTO),
                        IdUsuario: parseInt(ID_DIGITALIZADOR),
                        //IdUsuario: DESC_DIGITALIZADOR
                    }
                    if (resultado != undefined) {
                        resultado.ID_USUARIO = ID_DIGITALIZADOR;
                    } else {
                        Asignados_ListaDocumentos.push(miitem);
                    }
                } else {
                    jAlert("Debe seleccionar solo documento(s) con estado asignado.", "Atención");
                    break;
                }
            }
            //jQuery("#" + Asignados_grilla).jqGrid('resetSelection');
        } else {
            jAlert("Debe seleccionar por lo menos un documento.", "Atención");
        }
    } else {
        jAlert("Debe seleccionar un digitalizador.", "Atención");
    }
}

jQuery('#Asignados_btn_Grabar').click(function (e) {
    if (Asignados_ListaDocumentos.length > 0) {
        jConfirm(" ¿ Desea grabar todas las re-asignaciones realizadas ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    ListaIdsDocumento: Asignados_ListaDocumentos,
                    UsuModificacion: $('#inputHddCod_usuario').val(),
                }
                var url = "archivo-central/documento/actualizar-asignacion";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                jOkas("Documentos re-asignados correctamente", "Atención");
                            } else {
                                jAlert(auditoria.MensajeSalida, "Atención");
                            }
                            Asignados_buscar();
                            Asignados_ListaDocumentos = new Array();
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
        jAlert("Debe re-asignar por lo menos un documento.", "Atención");
    }
});