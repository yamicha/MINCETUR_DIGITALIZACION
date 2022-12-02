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
                UsuCreacion: $("#inputHddId_Usuario").val(),
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

function Microforma_MostrarEditar() {
    jQuery("#myModal_Documento_Grabar").html('');
    jQuery("#myModal_Documento_Grabar").modal('show');
    jQuery("#myModal_Documento_Grabar").load(baseUrl + "Digitalizacion/control-almacenamiento/mantenimiento-microarchivo?ID_MICROFORMA=0&Accion=M", function (responseText, textStatus, request) {
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
                UsuCreacion: $("#inputHddId_Usuario").val(),
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

function MicroArchivo_GetOne(id) {
    var url = `archivo-central/microforma/get-microforma/${id}`;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $('#MA_TIPO_ARCHIVO').val(auditoria.Objeto.MicroArchivo.TIPO_ARCHIVO);
                    $('#MA_RESPONSABLE').val(auditoria.Objeto.MicroArchivo.RESPONSABLE);
                    $('#MICROFORMA_FECHA').val(auditoria.Objeto.MicroArchivo.FECHA);
                    $('#MA_OBSERVACION').val(auditoria.Objeto.MicroArchivo.OBSERVACION);
                    $('#MA_DIRECCION').val(auditoria.Objeto.MicroArchivo.DIRECCION);
                    $('#MA_FECHA').val(auditoria.Objeto.MicroArchivo.FECHA);
                    $('#MA_HORA').val(auditoria.Objeto.MicroArchivo.HORA);
                    $('#MicroArchivoActa').attr('data-file', auditoria.Objeto.MicroArchivo.ID_DOC_ALMACENAMIENTO);
                    $('a[download-file="yes"]').click(function () {
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

// grila historial
function MicroArchivo_HistorialCargarGrilla(_Grilla) {
    ID_MICROFORMA = $("#HDF_ID_MICROFORMA").val()
    var url = `archivo-central/microforma/get-microArchivo/${ID_MICROFORMA}/0`;
    API.FetchGet("GET", url, function (auditoria) {
        jQuery("#" + _Grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $.each(auditoria.Objeto, function (i, v) {
                        var ix = i + 1;
                        var myData =
                        {
                            CODIGO: ix,
                            ID_MICROARCHIVO: v.ID_MICROARCHIVO,
                            ID_DOC_CONFORMIDAD: v.ID_DOC_CONFORMIDAD,
                            STR_TIPO_ARCHIVO: v.STR_TIPO_ARCHIVO,
                            DIRECCION: v.DIRECCION,
                            FECHA: v.FECHA,
                            HORA: v.HORA,
                            RESPONSABLE: v.RESPONSABLE,
                            OBSERVACION: v.OBSERVACION,
                            FEC_CREACION: v.FEC_CREACION
                        };
                        jQuery("#" + _Grilla).jqGrid('addRowData', ix, myData);
                    });
                    jQuery("#" + _Grilla).trigger("reloadGrid");
                }
            }
        }
    });
}

function MicroArchivo_HistorialConfigurarGrilla(_Grilla, _barra) {
    $("#" + _Grilla).GridUnload();

    var colNames = [
        '1', '2', 'Acta',
        'Tipo MicroArchivo', 'Dirección', 'Fecha', 'Hora', 'Responsable', 'Observación', 'Fecha Creación','ID_DOC'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', width: 1, hidden: true, sortable: false, key: true },//1
        { name: 'ID_MICROARCHIVO', index: 'ID_MICROARCHIVO', align: 'center', width: 1, hidden: true, sorttype: 'number', sortable: false },//2
        { name: 'ACTA', index: 'ACTA', align: 'center', width: 80, hidden: false, formatter: MicroArchivo_ActaFormatter, sortable: false },// 1
        { name: 'STR_TIPO_ARCHIVO', index: 'STR_TIPO_ARCHIVO', align: 'center', width: 150, hidden: false, sortable: false },//3 
        { name: 'DIRECCION', index: 'DIRECCION', align: 'center', width: 200, hidden: false, sortable: false },
        { name: 'FECHA', index: 'FECHA', align: 'center', width: 150, hidden: false, sortable: true },
        { name: 'HORA', index: 'HORA', align: 'center', width: 150, hidden: false, sortable: true },
        { name: 'RESPONSABLE', index: 'RESPONSABLE', align: 'center', width: 150, hidden: false, sortable: true },
        { name: 'OBSERVACION', index: 'OBSERVACION', align: 'center', width: 200, hidden: false, sortable: true },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false, sortable: true },
        { name: 'ID_DOC_CONFORMIDAD', index: 'ID_DOC_CONFORMIDAD', align: 'center', width: 150, hidden: true, sortable: true },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, leyenda: true, exportar: true, Editar: false, nuevo: false, eliminar: false, search: false,
        exportarExcel: function (_grilla_base) {
            //ExportJQGridDataToExcel(_grilla_base, "Derivados.xlsx");
        }
    };
    SICA.Grilla(_Grilla, _barra, '', '', '', "Listado Historial MicroArchivo", '', '', colNames, colModels, '', opciones);
}

function MicroArchivo_ActaFormatter(cellvalue, options, rowObject) {
    var _btn = "<button title='Descargar Formato Revisión' onclick='DownloadFile(" + rowObject.ID_DOC_CONFORMIDAD + ");' class=\"btn btn-link\" type=\"button\"  style=\"text-decoration: none !important;cursor: pointer;\"> <i class=\"clip-file-pdf\" style=\"color:#a01010;font-size:15px\"></i></button>";
    return _btn;
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