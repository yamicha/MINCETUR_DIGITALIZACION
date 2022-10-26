﻿
var Microforma_grilla = 'Microforma_grilla';
var Microforma_barra = 'Microforma_barra';

var Microforma_Lote_grilla = 'Microforma_Lote_grilla';
var Microforma_Lote_barra = 'Microforma_Lote_barra';

/// tab2 
var MicroformaRepro_grilla = 'MicroformaRepro_grilla';
var MicroformaRepro_barra = 'MicroformaRepro_barra';

var MicroformaRepro_Lote_grilla = 'MicroformaRepro_Lote_grilla';
var MicroformaRepro_Lote_barra = 'MicroformaRepro_Lote_barra';

$(document).ready(function () {
    jQuery('#aTabMicroforma').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        Microforma_ConfigurarGrilla(Microforma_Lote_grilla, Microforma_Lote_barra, Microforma_grilla, Microforma_barra, MicroModulo.Grabados);
        Documento_Detalle_buscar(Microforma_grilla, Microforma_barra);
    });

    jQuery('#aTabMicroReprocesar').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        Microforma_ConfigurarGrilla(MicroformaRepro_Lote_grilla, MicroformaRepro_Lote_barra, MicroformaRepro_grilla, MicroformaRepro_barra, MicroModulo.Reprocesar);
        Documento_Detalle_buscar(MicroformaRepro_grilla, MicroformaRepro_barra);
    });
});


/******************************* TAB REPROCESADOR ********************************/


async function Microforma_Editar() {
    jConfirm(" ¿ Desea reprocesar esta microforma ? ", "Atención", async function (r) {
        if (r) {
            var ID_DOC_APERTURA = 0;
            var ID_DOC_CIERRE = 0;
            if ($('#fileActaApertura').prop('files')[0] != undefined) {
                var FileApertura = new FormData();
                FileApertura.append('fileArchivo', $('#fileActaApertura').prop('files')[0]);
                ID_DOC_APERTURA = await UploadFileService(FileApertura);
            } else {
                ID_DOC_APERTURA = parseInt($("#HDF_ID_DOC_APERTURA").val());
            }
            if ($('#fileActaCierre').prop('files')[0] != undefined) {
                var FileCierre = new FormData();
                FileCierre.append('fileArchivo', $('#fileActaCierre').prop('files')[0]);
                ID_DOC_CIERRE = await UploadFileService(FileCierre);
            } else {
                ID_DOC_CIERRE = parseInt($("#HDF_ID_DOC_CIERRE").val());
            }
            var item = {
                IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                Fecha: $("#MICROFORMA_FECHA").val(),
                Hora: $("#MICROFORMA_HORA").val(),
                CodigoSoporte: $("#MICROFORMA_CODIGO_SOPORTE").val(),
                IdSoporte: parseInt($("#MICROFORMA_ID_TIPO_SOPORTE").val()),
                NroActa: $("#MICROFORMA_ACTA").val(),
                IdDocApertura: parseInt(ID_DOC_APERTURA),
                IdDocCierre: parseInt(ID_DOC_CIERRE), 
                NroCopias: $("#MICROFORMA_COPIAS").val(),
                CodigoFedatario: $("#MICROFORMA_CODIGO_FEDATARIO").val(),
                Observacion: $("#MICROFORMA_OBSERVACION").val(),
                UsuModificacion: $("#inputHddId_Usuario").val(),
            }
            var url = "archivo-central/microforma/editar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            Microforma_CargarGrilla(MicroformaRepro_Lote_grilla, MicroEstado.Observado);
                            jOkas("Microforma reprocesada correctamente.", "Atención");
                            MicroformaGrabar_Cerrar();
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

}