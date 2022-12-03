
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
                ID_DOC_APERTURA = parseInt($('#DownloadApertura').data('file'));
            }
            if ($('#fileActaCierre').prop('files')[0] != undefined) {
                var FileCierre = new FormData();
                FileCierre.append('fileArchivo', $('#fileActaCierre').prop('files')[0]);
                ID_DOC_CIERRE = await UploadFileService(FileCierre);
            } else {
                ID_DOC_CIERRE = parseInt($('#DownloadCierre').data('file'));
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

async function MicroformaReprocesar_GetOne(id) {
    var OptionsCboSoporte = {
        KeyVal: { value: "ID_SOPORTE", name: "DESC_SOPORTE" },
        paramters: { FlgEstado: "1" },
        method: "POST"
    }
    if (await LoadComboApi("archivo-central/soporte/listar", "MICROFORMA_ID_TIPO_SOPORTE", OptionsCboSoporte)) {
        var url = `archivo-central/microforma/get-microforma/${id}`;
        API.FetchGet("GET", url, function (auditoria) {
            if (auditoria != null && auditoria != "") {
                if (auditoria.EjecucionProceso) {
                    if (!auditoria.Rechazo) {
                        $('#MICROFORMA_ID_TIPO_SOPORTE').val(auditoria.Objeto.ID_TIPO_SOPORTE);
                        $('#MICROFORMA_CODIGO_FEDATARIO').val(auditoria.Objeto.CODIGO_FEDATARIO);
                        $('#MICROFORMA_FECHA').val(auditoria.Objeto.FECHA);
                        $('#MICROFORMA_HORA').val(auditoria.Objeto.HORA);
                        $('#MICROFORMA_ACTA').val(auditoria.Objeto.NRO_ACTA);
                        $('#MICROFORMA_COPIAS').val(auditoria.Objeto.NRO_COPIAS);
                        $('#MICROFORMA_OBSERVACION').val(auditoria.Objeto.OBSERVACION);
                        $('#MICROFORMA_CODIGO_SOPORTE').val(auditoria.Objeto.CODIGO_SOPORTE);
                        $('#MICROFORMA_NROVOLUMEN').val(auditoria.Objeto.NRO_VOLUMEN);
                        if (auditoria.Objeto.ID_DOC_APERTURA != 0) {
                            $('#DownloadApertura').show();
                            $('#DownloadApertura').attr('data-file', auditoria.Objeto.ID_DOC_APERTURA);
                        }
                        if (auditoria.Objeto.ID_DOC_CIERRE != 0) {
                            $('#DownloadCierre').show();
                            $('#DownloadCierre').attr('data-file', auditoria.Objeto.ID_DOC_APERTURA);
                        }

                        $('label[download-file="yes"]').click(function () {
                            var IdFile = $(this).data('file');
                            DownloadFile(IdFile);
                        });
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            }
        });
    }
}


// METODO QUE VALIDA LA FECHA
const validateDate = (birthDate) => {
    const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/

    /* Comprobar formato dd/mm/yyyy, que el no sea mayor de 12 y los días mayores de 31 */
    if (!birthDate.match(DATE_REGEX)) {
        return false
    }

    /* Comprobar los días del mes */
    const day = parseInt(birthDate.split('/')[0])
    const month = parseInt(birthDate.split('/')[1])
    const year = parseInt(birthDate.split('/')[2])
    const monthDays = new Date(year, month, 0).getDate()
    if (day > monthDays) {
        return false
    }

    /* Comprobar que el año no sea superior al actual*/
    //if (year > CURRENT_YEAR) {
    //    return false
    //}
    return true
}