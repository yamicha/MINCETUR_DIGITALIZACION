var Asignar_grilla = 'Asignar_grilla';
var Asignar_barra = 'Asignar_barra';
var Asignar_ListaDocumentos = new Array();

$(document).ready(function () {
});

jQuery('#aTabAsignar').click(function (e) {
    Asignar_ListaDocumentos = new Array();
    Asignar_buscar();
});

function Asignar_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Asignar_grilla + "," + Asignar_barra + ",\"Listado de documentos\",true,2);", 500);
}

jQuery('#Asignar_btn_Grabar').click(function (e) {
    if (Asignar_ListaDocumentos.length > 0) {
        jConfirm(" ¿ Desea grabar todas las asignaciones realizadas ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    ListaIdsDocumento: Asignar_ListaDocumentos,
                    UsuCreacion: $('#inputHddCod_usuario').val()
                }
                debugger; 
                var url = "archivo-central/documento/grabar-asignacion";
                //var auditoria = SICA.Ajax(url, item, false);
                API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            jOkas("Documentos asignados correctamente", "Atención");
                            Asignar_buscar();
                            Asignar_ListaDocumentos = new Array();
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
        jAlert("Debe asignar por lo menos un documento.", "Atención");
    }
});

jQuery('#Asignar_btnDigitalizador').click(function (e) {
    Asignar_Digitalizador();
});

function Asignar_Digitalizador() {
    var ID_DIGITALIZADOR = $("#ID_DIGITALIZADOR").val();
    if (ID_DIGITALIZADOR != '') {
        var rowKey = $("#" + Asignar_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
        if (rowKey.length > 0) {
            var DESC_DIGITALIZADOR = $("#ID_DIGITALIZADOR option:selected").text();
            for (var i = 0; i < rowKey.length; i++) {
                var data = jQuery("#" + Asignar_grilla).jqGrid('getRowData', rowKey[i]);
                jQuery("#" + Asignar_grilla).jqGrid('setRowData', rowKey[i], { Asignar_NOMBRE_USUARIO: DESC_DIGITALIZADOR });
                data.Asignar_NOMBRE_USUARIO = DESC_DIGITALIZADOR;
                const resultado = Asignar_ListaDocumentos.find(x => x.ID_DOCUMENTO === data.Asignar_ID_DOCUMENTO);

                var miitem = {
                    IdDocumento: parseInt(data.Asignar_ID_DOCUMENTO),
                    IdUsuario: parseInt(ID_DIGITALIZADOR),
                    //NOMBRE_USUARIO: DESC_DIGITALIZADOR
                }
                if (resultado != undefined) {
                    resultado.ID_USUARIO = ID_DIGITALIZADOR;
                } else {
                    debugger; 
                    Asignar_ListaDocumentos.push(miitem);
                }
            }
            //jQuery("#" + Asignar_grilla).jqGrid('resetSelection');
        } else {
            jAlert("Debe seleccionar por lo menos un documento.", "Atención");
        }
    } else {
        jAlert("Debe seleccionar un digitalizador.", "Atención");
    }
}