var TipoDocumento_grilla = 'TipoDocumento_grilla';
var TipoDocumento_barra = 'TipoDocumento_barra';

$(document).ready(function () {
    TipoDocumento_ConfigurarGrilla(TipoDocumento_grilla, TipoDocumento_barra);
    TipoDocumento_CargarGrilla(TipoDocumento_grilla);
});

function TipoDocumento_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Descripción Serie', 'Descripción Documento',
        'Usuario Creación', 'Fecha Creación', 'IP Creación',
        'Usuario Modificación', 'Fecha Modificación', 'IP Modificación'];
    var colModels = [
        { name: 'ID_TIPO_DOCUMENTO', index: 'ID_TIPO_DOCUMENTO', align: 'center', hidden: true, width: 50, key: true },
        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 50, hidden: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 50, hidden: true },
        { name: 'ID_SERIE', index: 'ID_SERIE', align: 'center', hidden: true, width: 0, key: false },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: TipoDocumento_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: true, formatter: TipoDocumento_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: TipoDocumento_estadoAction },

        { name: 'DESC_SERIE', index: 'DESC_SERIE', align: 'center', hidden: false, width: 200, key: false },
        { name: 'DESC_TIPO_DOCUMENTO', index: 'DESC_TIPO_DOCUMENTO', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        { name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        { name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado Tipo Documento', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function TipoDocumento_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='TipoDocumento_MostrarEditar(" + rowObject['ID_TIPO_DOCUMENTO'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function TipoDocumento_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='TipoDocumento_Eliminar(" + rowObject['ID_TIPO_DOCUMENTO'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function TipoDocumento_estadoAction(cellvalue, options, rowObject) {

    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_TIPO_DOCUMENTO'] + "\" type=\"checkbox\" onchange=\"TipoDocumento_Estado(" + rowObject['ID_TIPO_DOCUMENTO'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function TipoDocumento_Estado(ID, CHECK) {
    var item = {
        ID_TIPO_DOCUMENTO: ID,
        FLG_ESTADO: CHECK.checked == true ? '1' : '0'
        //USU_MODIFICACION: 'admin2'
    };
    var url = baseUrl + 'Administracion/TipoDocumento/TipoDocumento_Estado';
    var auditoria = SICA.Ajax(url, item, false);
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (auditoria.RECHAZAR) {
                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
            }
            TipoDocumento_CargarGrilla(TipoDocumento_grilla);
        } else {
            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
        }
    }
}

function TipoDocumento_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/TipoDocumento/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function TipoDocumento_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {
            var url = baseUrl + 'Administracion/TipoDocumento/TipoDocumento_Eliminar';
            var arrayParametro = {
                ID_TIPO_DOCUMENTO: id
                //USU_MODIFICACION: "ADMIN2"
            };
            var auditoria = SICA.Ajax(url, arrayParametro, false);
            if (auditoria.EJECUCION_PROCEDIMIENTO) {
                if (!auditoria.RECHAZAR) {
                    TipoDocumento_CargarGrilla(TipoDocumento_grilla);
                    jAlert("Registro eliminado", "Proceso");
                } else {
                    jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                }
            } else {
                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
            }

        }
    });

}

function TipoDocumento_CargarGrilla(_grilla) {
    var item =
    {
        descripcion: $("#TIPODOC_DESCRIPCION").val().toUpperCase()
    };
    var url = baseUrl + "Administracion/TipoDocumento/TipoDocumento_Listar";
    var auditoria = SICA.Ajax(url, item, false);
    jQuery("#" + _grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (!auditoria.RECHAZAR) {
                var x = 0;
                $.each(auditoria.OBJETO, function (i, v) {
                    x++;
                    var myData =
                    {
                        ID_TIPO_DOCUMENTO: v.ID_TIPO_DOCUMENTO,
                        ID_SERIE: v.ID_SERIE,
                        DESC_SERIE: v.DESC_SERIE,
                        DESC_TIPO_DOCUMENTO: v.DESC_TIPO_DOCUMENTO,
                        FLG_ELIMINADO: v.FLG_ELIMINADO,
                        FLG_ESTADO: v.FLG_ESTADO,
                        USU_CREACION: v.USU_CREACION,
                        FEC_CREACION: v.FEC_CREACION,
                        IP_CREACION: v.IP_CREACION,
                        USU_MODIFICACION: v.USU_MODIFICACION,
                        FEC_MODIFICACION: v.FEC_MODIFICACION,
                        IP_MODIFICACION: v.IP_MODIFICACION
                    };
                    jQuery("#" + _grilla).jqGrid('addRowData', x, myData);
                });
                jQuery("#" + _grilla).trigger("reloadGrid");
            } else {
                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
            }
        } else {
            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
        }
    } else {
        jAlert("No se encontraron registros", "Atención");
    }
}

function TipoDocumento_LimpiarCampo() {
    $("#TIPODOC_DESCRIPCION").val('');
    TipoDocumento_CargarGrilla(TipoDocumento_grilla);
}

/*  ----------------------------------
    |    Ingresar nuevo registro     |
    ---------------------------------- */

function TipoDocumento_RegistrarDatos() {
    if ($('#hd_TIPODOC_ACCION').val() != 'N') {
        TipoDocumento_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoTipoDocumento").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {
                    var item =
                    {
                        ID_SERIE: $("#ID_SERIE").val(),
                        DESC_TIPO_DOCUMENTO: $("#DESC_TIPO_DOCUMENTO").val().toUpperCase()
                        //USU_CREACION: "ADMIN"
                    };
                    var url = baseUrl + 'Administracion/TipoDocumento/TipoDocumento_Registrar';
                    var auditoria = SICA.Ajax(url, item, false);
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EJECUCION_PROCEDIMIENTO) {
                            if (!auditoria.RECHAZAR) {
                                TipoDocumento_CargarGrilla(TipoDocumento_grilla);
                                $('#myModalNuevo').modal('hide');
                                jQuery("#myModalNuevo").html('');
                                jAlert("Datos guardados satisfactoriamente", "Proceso");
                            } else {
                                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                            }
                        } else {
                            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                        }
                    }
                }
            });
        }
    }
}

/*  ------------------------------
    |    Actualizar registro     |
    ------------------------------ */
function TipoDocumento_ActualizarDatos() {
    if ($("#frmMantenimientoTipoDocumento").valid()) {
        
        var item =
        {
            ID_TIPO_DOCUMENTO: $("#hd_TIPODOC_ID_TIPO_DOCUMENTO").val(),
            ID_SERIE: $("#ID_SERIE").val(),
            DESC_TIPO_DOCUMENTO: $("#DESC_TIPO_DOCUMENTO").val().toUpperCase()
            //USU_MODIFICACION: "ADMIN2",
            
        };
        ID_SECCION = $("#ID_SECCION").val();
        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                var url = baseUrl + 'Administracion/TipoDocumento/TipoDocumento_Actualizar?id=' + ID_SECCION;
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {

                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            TipoDocumento_CargarGrilla(TipoDocumento_grilla);
                            $('#myModalNuevo').modal('hide');
                            jQuery("#myModalNuevo").html('');
                            jAlert("Datos actualizados satisfactoriamente", "Proceso");
                        } else {
                            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                        }
                    } else {
                        jAlert(auditoria.MENSAJE_SALIDA, "Atención");
                    }
                }
            }
        });
    }
}

/*  ------------------------------
    |    Modal nuevo registro     |
    ------------------------------ */

function TipoDocumento_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/TipoDocumento/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

