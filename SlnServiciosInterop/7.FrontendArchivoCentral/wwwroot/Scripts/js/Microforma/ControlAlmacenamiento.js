// tab 1
var MicroAlmacen_grilla = 'MicroAlmacen_grilla';
var MicroAlmacen_barra = 'MicroAlmacen_barra';

var MicroAlmacen_Lote_grilla = 'MicroAlmacen_Lote_grilla';
var MicroAlmacen_Lote_barra = 'MicroAlmacen_Lote_barra';

// tab 2
var MicroAlmacenFin_grilla = 'MicroAlmacenFin_grilla';
var MicroAlmacenFin_barra = 'MicroAlmacenFin_barra';

var MicroAlmacenFin_Lote_grilla = 'MicroAlmacenFin_Lote_grilla';
var MicroAlmacenFin_Lote_barra = 'MicroAlmacenFin_Lote_barra';
var MicroForma_Lista = new Array();

$(document).ready(function () {
    ControlBuscar();
    jQuery('#aTabMicroAlmacen').click(function (e) {
        _ID_LOTE = 0;
        ControlBuscar();
    });
    jQuery('#aTabMicroAlamcenFinalizado').click(function (e) {
        _ID_LOTE = 0;
        ControlFinalizadoBuscar();
    });
    $('#Microforma_BtnMicroArchivo').click(function () {
        var rowKey = $("#" + MicroAlmacenFin_Lote_grilla).jqGrid('getGridParam', 'selarrrow');
        if (rowKey != null) {
            if (rowKey.length > 0) {
                //$("#Microforma_Div_validar").show();
                Microforma_MostrarEditar();
            }
            else {
                jAlert("Debe seleccionar por lo menos un registo.", "Atención");
            }
        }
        else {
            jAlert("Debe seleccionar por lo menos un registo.", "Atención");
        }

    });
});

function ControlBuscar() {
    Microforma_ConfigurarGrilla(MicroAlmacen_Lote_grilla, MicroAlmacen_Lote_barra, MicroAlmacen_grilla, MicroAlmacen_barra, MicroModulo.CAlmacen);
    Documento_Detalle_buscar(MicroAlmacen_grilla, MicroAlmacen_barra);
}
function ControlFinalizadoBuscar() {
    Microforma_ConfigurarGrilla(MicroAlmacenFin_Lote_grilla, MicroAlmacenFin_Lote_barra,
        MicroAlmacenFin_grilla, MicroAlmacenFin_barra, MicroModulo.CAlmacenFin, true);
    Documento_Detalle_buscar(MicroAlmacenFin_grilla, MicroAlmacenFin_barra);
}
async function Microforma_MicroArchivoGrabar() {
    jConfirm(" ¿ Desea guardar datos de microArchivo ingresados ? ", "Atención", async function (r) {
        if (r) {
            var IdDocAlmacenamiento = 0;
            if ($('#fileActaAlma').prop('files')[0] != undefined) {
                var FileAlmacenamiento = new FormData();
                FileAlmacenamiento.append('fileArchivo', $('#fileActaAlma').prop('files')[0]);
                IdDocAlmacenamiento = await UploadFileService(FileAlmacenamiento);
            }
            var item = {
                IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                TipoArchivo: parseInt($("#MA_TIPO_ARCHIVO").val()),
                Direccion: $("#MA_DIRECCION").val(),
                Observacion: $("#MA_OBSERVACION").val(),
                IdUsuario: parseInt($("#inputHddId_Usuario").val()),
                UsuCreacion: $("#inputHddCod_usuario").val(),
                IdDocAlmacenamiento: parseInt(IdDocAlmacenamiento),
                Fecha: $("#MA_FECHA").val(),
                Hora: $("#MA_HORA").val(),
            }
            var url = "archivo-central/microforma/micro-archivo-insertar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            ControlBuscar();
                            Microforma_CloseModal();
                            jOkas("Datos guardados correctamente.", "Atención");
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
function MicroformaAlmacen_CargarGrilla() {
    var item = {
    }
    var url = "archivo-central/microforma/listar-control";
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + MicroAlmacen_Lote_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    var x = 0;
                    $.each(auditoria.Objeto, function (i, v) {
                        x++;
                        var myData =
                        {
                            CODIGO: x,
                            ID_MICROFORMA: v.ID_MICROFORMA,
                            DESC_SOPORTE: v.DESC_SOPORTE,
                            CODIGO_SOPORTE: v.CODIGO_SOPORTE,
                            DESCRIPCION_LOTE: v.DESCRIPCION_LOTE,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            DESC_ESTADO: v.DESC_ESTADO,
                            ID_ESTADO: v.ID_ESTADO
                        };
                        jQuery("#" + MicroAlmacen_Lote_grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + MicroAlmacen_Lote_grilla).trigger("reloadGrid");
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

//********************************************************** tab finalizados *********************************************************/

//function Microforma_VolverGrabarMicroArchivo() {
//    jConfirm(" ¿ Desea enviar a pendientes de grabación de micro archivos todos los registros seleccionados  ? ", "Atención", function (r) {
//        if (r) {
//            var rowKey = $("#" + MicroAlmacenFin_Lote_grilla).jqGrid('getGridParam', 'selarrrow'); 
//            for (i_ = 0; i_ < rowKey.length; i_++) {
//                var data = jQuery("#" + MicroAlmacenFin_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
//                var _item = {
//                    IdMicroforma: parseInt(data.ID_MICROFORMA)
//                }
//                MicroForma_Lista.push(_item);
//            }
//            var item = {
//                ListaIdsMicroforma: MicroForma_Lista
//            }
//            var url = "archivo-central/microforma/micro-archivo-estado";
//            API.Fetch("POST", url, item, function (auditoria) {
//                if (auditoria != null && auditoria != "") {
//                    if (auditoria.EjecucionProceso) {
//                        if (!auditoria.Rechazo) {
//                            _ID_LOTE = 0;
//                            ControlFinalizadoBuscar();
//                            jOkas("Datos guardados correctamente.", "Atención");
//                        } else {
//                            jAlert(auditoria.MensajeSalida, "Atención");
//                        }
//                    } else {
//                        jAlert(auditoria.MensajeSalida, "Atención");
//                    }
//                } else {
//                    jAlert("No se encontraron registros", "Atención");
//                }
//            });
//        }
//    });
//}

function Microforma_MostrarEditar() {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").modal('show');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/microformas/mantenimiento-microarchivo?ID_MICROFORMA=0&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Documento_Grabar');
        if (request.status != 200) return;
    });
}


function MicroArchivo_Editar() {
    jConfirm(" ¿ Desea guardar datos de microArchivo ingresados ? ", "Atención", async function (r) {
        if (r) {
            var IdDocAlmacenamiento = 0;
            if ($('#fileActaAlma').prop('files')[0] != undefined) {
                var FileAlmacenamiento = new FormData();
                FileAlmacenamiento.append('fileArchivo', $('#fileActaAlma').prop('files')[0]);
                IdDocAlmacenamiento = await UploadFileService(FileAlmacenamiento);
            }

            var rowKey = $("#" + MicroAlmacenFin_Lote_grilla).jqGrid('getGridParam', 'selarrrow');
            for (i_ = 0; i_ < rowKey.length; i_++) {
                var data = jQuery("#" + MicroAlmacenFin_Lote_grilla).jqGrid('getRowData', rowKey[i_]);
                var _item = {
                    IdMicroforma: parseInt(data.ID_MICROFORMA)
                }
                MicroForma_Lista.push(_item);
            }
            var item = {
                ListaIdsMicroforma: MicroForma_Lista,
                TipoArchivo: parseInt($("#MA_TIPO_ARCHIVO").val()),
                Direccion: $("#MA_DIRECCION").val(),
                Observacion: $("#MA_OBSERVACION").val(),
                IdUsuario: parseInt($("#inputHddId_Usuario").val()),
                UsuCreacion: $("#inputHddCod_usuario").val(),
                IdDocAlmacenamiento: parseInt(IdDocAlmacenamiento),
                Fecha: $("#MA_FECHA").val(),
                Hora: $("#MA_HORA").val(),
            }
            var url = "archivo-central/microforma/micro-archivo-editar";
            API.Fetch("POST", url, item, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            _ID_LOTE = 0;
                            ControlBuscar();
                            Microforma_CloseModal();
                            jOkas("Datos guardados correctamente.", "Atención");
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

function Documento_Ver_Obs_CargarGrilla() {
    ID_DOCUMENTO = $("#hd_Documento_Ver_ID_DOCUMENTO").val()
    var url = `archivo-central/documento/listado-obs-documento/${ID_DOCUMENTO}`;
    //var auditoria = SICA.Ajax(url, item, false);
    API.FetchGet("GET", url, function (auditoria) {
        jQuery("#" + Documento_Ver_Obs_grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $.each(auditoria.Objeto, function (i, v) {
                        var rowKey = jQuery("#" + Documento_Ver_Obs_grilla).getDataIDs();
                        var ix = rowKey.length;
                        ix++;
                        var myData =
                        {
                            CODIGO: ix,
                            ID_DOCUMENTO_OBS: v.ID_DOCUMENTO_OBS,
                            ID_DOCUMENTO: v.ID_DOCUMENTO,
                            ID_TIPO_OBSERVACION: v.ID_TIPO_OBSERVACION,
                            DESC_TIPO_OBSERVACION: v.DESC_TIPO_OBSERVACION,
                            OBSERVACION: v.OBSERVACION,
                            USU_CREACION: v.USU_CREACION,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            //IP_CREACION: v.IP_CREACION
                        };
                        jQuery("#" + Documento_Ver_Obs_grilla).jqGrid('addRowData', ix, myData);
                    });
                    jQuery("#" + Documento_Ver_Obs_grilla).trigger("reloadGrid");
                }
            }
        }
    });
}

function Documento_Ver_Obs_ConfigurarGrilla() {
    var MicroArchivoHistorial_barra = "MicroArchivoHistorial_barra";
    var MicroArchivoHistorial_grilla = "MicroArchivoHistorial_grilla";

    $("#" + MicroArchivoHistorial_grilla).GridUnload();
    var colNames = [
        '1', '2', '3', '4',
        'Tipo', 'Observación',
        'Usuario Creación', 'Fecha Creación'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_DOCUMENTO_OBS', index: 'ID_DOCUMENTO_OBS', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//2
        { name: 'ID_DOCUMENTO', index: 'ID_DOCUMENTO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//3 
        { name: 'ID_TIPO_OBSERVACION', index: 'ID_TIPO_OBSERVACION', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },

        { name: 'DESC_TIPO_OBSERVACION', index: 'DESC_TIPO_OBSERVACION', align: 'center', width: 200, hidden: false, sorttype: 'number', sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 400, hidden: false, sorttype: 'number', sortable: true },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 120, hidden: false, sortable: true },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 120, hidden: false, sortable: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false, search: false,
        exportarExcel: function (_grilla_base) {
            ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(MicroArchivoHistorial_grilla, MicroArchivoHistorial_barra, '', '300', '', "Listado Historial MicroArchivo", '', '', colNames, colModels, '', opciones);
}
