var MicroformaGrabar_grilla = 'MicroformaGrabar_grilla';
var MicroformaGrabar_barra = 'MicroformaGrabar_barra';

var MicroformaGrabar_Lote_grilla = 'MicroformaGrabar_Lote_grilla';
var MicroformaGrabar_Lote_barra = 'MicroformaGrabar_Lote_barra';
var MicroformaGrabar_ListaLotes = new Array();

$(document).ready(function () {
    MicroformaGrabar_ListaLotes = new Array();
    _ID_MODULO = 0;
    _ID_LOTE = 0;
    var fechaInicio = GetFecha();
    var fechaFin = GetFecha();
    MicroformaLote_ConfigurarGrilla();
    Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, "", "0", fechaInicio, fechaFin);
    //MicroformaGrabar_buscar();
    Documento_Detalle_buscar(MicroformaGrabar_grilla, MicroformaGrabar_barra);

    jQuery('#MicroformaGrabar_btn_Nuevo').click(function (e) {
        var rowKey = $("#" + MicroformaGrabar_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
        if (rowKey != null) {
            if (rowKey.length > 0) {
                $("#Microforma_Div_validar").show();
                setTimeout("MicroformaGrabar_IniciarProceso();", 500);
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

function MicroformaPendiente_Buscar() {
    var fechaInicio = $('#txtfechainicio').val();
    var fechaFin = $('#txtfechafin').val();
    Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, "", "0", fechaInicio, fechaFin);
}

function MicroformaLote_ConfigurarGrilla() {
    $("#" + MicroformaGrabar_Lote_grilla).GridUnload();
    var colNames = ['1', '2',
        'Lote', 'Fecha de Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 1, hidden: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false, search: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false, search: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: true, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
        grouping: false,
        selectRowFunc: function () {
            var rowKey = parseInt(jQuery("#" + MicroformaGrabar_Lote_grilla).getGridParam('selrow'));
            var data = jQuery("#" + MicroformaGrabar_Lote_grilla).jqGrid('getRowData', rowKey);
            _ID_LOTE = data.ID_LOTE;
            if (data.ID_LOTE == undefined) _ID_LOTE = 0;
            Documento_Detalle_buscar(MicroformaGrabar_grilla, MicroformaGrabar_barra);
        },
    };
    SICA.Grilla(MicroformaGrabar_Lote_grilla, MicroformaGrabar_Lote_barra, '', '582', '', '', "", "", colNames, colModels, "", opciones);

    jqGridResponsive($(".jqGridLote"));
}
jQuery('#aTabMicroformaGrabar').click(function (e) {
    _ID_LOTE = 0;
    _ID_MODULO = 12;
    Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, 0);
    MicroformaGrabar_buscar();
});
function MicroformaGrabar_Cerrar() {
    $('#myModal_Documento_Grabar').modal('hide');
    jQuery("#myModal_Documento_Grabar").html('');
}
function Documento_MostrarGrabar() {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").modal('show');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/mantenimiento?accion=N&ID_MICROFORMA=0", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}
async function MicroformaGrabar_IniciarProceso() {
    var rowKey = $("#" + MicroformaGrabar_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    if (rowKey != null) {
        if (await MicroformaGrabar_ValidarLote()) {
            Documento_MostrarGrabar();
        }
    } else {
        jAlert("Debe seleccionar por lo menos un lote.", "Atención");
    }
}
function MicroformaGrabar_ValidarLote() {
    var rowKey = $("#" + MicroformaGrabar_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); // solo los q estan seleccionados
    return new Promise((valido) => {
        if (rowKey != null) {
            MicroformaGrabar_ListaLotes = new Array();
            for (i_ = 0; i_ < rowKey.length; i_++) {
                var data = jQuery("#" + MicroformaGrabar_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
                var _item = {
                    IdLote: parseInt(data.ID_LOTE)
                }
                MicroformaGrabar_ListaLotes.push(_item);
            }
            var item = {
                ListaIdsLotes: MicroformaGrabar_ListaLotes
            }
            var url = "ventanilla/digitalizacion/documento-validar-lote";
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
async function MicroformaGrabar_Grabar() {
     jConfirm(" ¿ Desea grabar esta microforma ? ", "Atención", async function (r) {
        if (r) {
            try {
                var FileApertura = new FormData();
                FileApertura.append('fileArchivo', $('#fileActaApertura').prop('files')[0]);
                var FileCierre = new FormData();
                FileCierre.append('fileArchivo', $('#fileActaCierre').prop('files')[0]); 
                let IdDocApertura = await UploadFileService(FileApertura);
                let IdDocCierre = await UploadFileService(FileCierre);
                var item = {
                    ListaIdsLotes: MicroformaGrabar_ListaLotes,
                    Fecha: $("#MICROFORMA_FECHA").val(),
                    Hora: $("#MICROFORMA_HORA").val(),
                    NroVolumen: $("#MICROFORMA_NROVOLUMEN").prev().text() + "-"+ $("#MICROFORMA_NROVOLUMEN").val(),
                    CodigoSoporte: $("#MICROFORMA_CODIGO_SOPORTE").val(),
                    IdSoporte: parseInt($("#MICROFORMA_ID_TIPO_SOPORTE").val()),
                    IdDocApertura: parseInt(IdDocApertura),
                    IdDocCierre: parseInt(IdDocCierre),
                    NroActa: $("#MICROFORMA_ACTA").val(),
                    NroCopias: $("#MICROFORMA_COPIAS").val(),
                    CodigoFedatario: $("#MICROFORMA_CODIGO_FEDATARIO").val(),
                    Observacion: $("#MICROFORMA_OBSERVACION").val(),
                    UsuCreacion: $("#inputHddId_Usuario").val(),
                }
                var url = "ventanilla/microforma/insertar";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                _ID_LOTE = 0;
                                Documento_Detalle_buscar(MicroformaGrabar_grilla, MicroformaGrabar_barra);
                                Lote_CargarGrilla(MicroformaGrabar_Lote_grilla, "", "0");
                                jOkas("Microforma grabada correctamente.", "Atención");
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

                //});
            } catch (err) {
                alert(err);
            }
        }
    });
}
function MicroformaGrabar_CargarCboSoporte() {
    var OptionsCbo = {
        KeyVal: { value: "ID_SOPORTE", name: "DESC_SOPORTE" },
        paramters: { FlgEstado: "1" },
        method: "POST"
    }
    LoadComboApi("ventanilla/soporte/listar", "MICROFORMA_ID_TIPO_SOPORTE", OptionsCbo)
}

// METODO QUE VALIDA LA FECHA
//const validateDate = (birthDate) => {
//    const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/

//    /* Comprobar formato dd/mm/yyyy, que el no sea mayor de 12 y los días mayores de 31 */
//    if (!birthDate.match(DATE_REGEX)) {
//        return false
//    }

//    /* Comprobar los días del mes */
//    const day = parseInt(birthDate.split('/')[0])
//    const month = parseInt(birthDate.split('/')[1])
//    const year = parseInt(birthDate.split('/')[2])
//    const monthDays = new Date(year, month, 0).getDate()
//    if (day > monthDays) {
//        return false
//    }

//    /* Comprobar que el año no sea superior al actual*/
//    //if (year > CURRENT_YEAR) {
//    //    return false
//    //}
//    return true
//}