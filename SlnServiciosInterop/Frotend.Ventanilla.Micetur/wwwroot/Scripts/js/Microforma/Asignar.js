var Asignar_grilla = 'Asignar_grilla';
var Asignar_barra = 'Asignar_barra';
var Asignar_ListaDocumentos = new Array();

$(document).ready(function () {
    jQuery('#aTabAsignar').click(function (e) {
        Asignar_ListaDocumentos = new Array();
        Asignar_buscar();
    });
});

function Asignar_buscar() {
    Documento_ConfigurarGrilla(Asignar_grilla, Asignar_barra, "Listado de documentos", true, 2);
}

jQuery('#Asignar_btn_Grabar').click(function (e) {
    Asginar_Grabar(); 
});

jQuery('#Asignar_btnDigitalizador').click(function (e) {
    Asignar_Digitalizador();
});

function Asignar_Digitalizador() {
    var ID_DIGITALIZADOR = $("#ID_DIGITALIZADOR").val();
    if (ID_DIGITALIZADOR != '') {
        Asignar_ListaDocumentos.pop();
        var rowKey = $("#" + Asignar_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
        if (rowKey.length > 0) {
            var DESC_DIGITALIZADOR = $("#ID_DIGITALIZADOR option:selected").text();
            let PesoTotal = 0; 
            for (var i = 0; i < rowKey.length; i++) {
                var data = jQuery("#" + Asignar_grilla).jqGrid('getRowData', rowKey[i]);
                jQuery("#" + Asignar_grilla).jqGrid('setRowData', rowKey[i], { Asignar_NOMBRE_USUARIO: DESC_DIGITALIZADOR });
                data.Asignar_NOMBRE_USUARIO = DESC_DIGITALIZADOR;
                const resultado = Asignar_ListaDocumentos.find(x => x.ID_DOCUMENTO === data.Asignar_ID_DOCUMENTO);
                PesoTotal = PesoTotal + parseInt(data.Asignar_PESO_ADJ) ; 
                var miitem = {
                    IdDocumento: parseInt(data.Asignar_ID_DOCUMENTO),
                    IdUsuario: parseInt(ID_DIGITALIZADOR),
                }
                if (resultado != undefined) {
                    resultado.ID_USUARIO = ID_DIGITALIZADOR;
                } else {
                    Asignar_ListaDocumentos.push(miitem);
                }
            }
            PesoTotal = formatBytes(PesoTotal);
            if (PesoTotal != 0) {
                $('#mssgPesoAsignar').text(PesoTotal); 
                $('#mssgAsignar').show('slow'); 
            }
        } else {
            jAlert("Debe seleccionar por lo menos un documento.", "Atención");
        }
    } else {
        jAlert("Debe seleccionar un digitalizador.", "Atención");
    }
}

function Asginar_Grabar() {
    if (Asignar_ListaDocumentos.length > 0) {
        jConfirm(" ¿ Desea grabar todas las asignaciones realizadas ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    ListaIdsDocumento: Asignar_ListaDocumentos,
                    FlgDigitalizar: $('input[name="flgdigital"]:checked').val(),
                    UsuCreacion: $('#inputHddId_Usuario').val()
                }
                var url = "ventanilla/documento/grabar-asignacion";
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
                    }
                });
            }
        });
    } else {
        jAlert("Debe asignar por lo menos un documento.", "Atención");
    }
}