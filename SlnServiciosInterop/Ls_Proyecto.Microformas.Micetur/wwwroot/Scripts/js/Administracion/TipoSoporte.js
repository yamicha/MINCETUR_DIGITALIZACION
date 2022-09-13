var TipoSoporte_grilla = 'TipoSoporte_Grilla';
var TipoSoporte_barra = 'TipoSoporte_Barra';

$(document).ready(function () {
    TipoSoporte_ConfigurarGrilla(TipoSoporte_grilla, TipoSoporte_barra);
    TipoSoporte_CargarGrilla(TipoSoporte_grilla);
});

function TipoSoporte_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Descripción', 
        'Usuario creación', 'Fecha creación', 'Ip creación',
        'Usuario Modificación', 'Fecha modificación', 'Ip modificación'];
    var colModels = [
        { name: 'ID_SOPORTE', index: 'ID_FONDO', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 0, hidden: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: TipoSoporte_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: TipoSoporte_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: TipoSoporte_estadoAction },

        { name: 'DESC_SOPORTE', index: 'DESC_FONDO', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        { name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' }},
        { name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado Tipo Soporte', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function TipoSoporte_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='TipoSoporte_MostrarEditar(" + rowObject['ID_SOPORTE'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function TipoSoporte_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='TipoSoporte_Eliminar(" + rowObject['ID_SOPORTE'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function TipoSoporte_estadoAction(cellvalue, options, rowObject) {
    
    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_SOPORTE'] + "\" type=\"checkbox\" onchange=\"TipoSoporte_Estado(" + rowObject['ID_SOPORTE'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function TipoSoporte_Estado(ID, CHECK) {
    var item = {
        ID_SOPORTE: ID,
        FLG_ESTADO: CHECK.checked == true ? '1' : '0'

    };
    var url = baseUrl + 'Administracion/TipoSoporte/TipoSoporte_Estado';
    var auditoria = SICA.Ajax(url, item, false);
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (auditoria.RECHAZAR) {
                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
            }
            TipoSoporte_CargarGrilla(TipoSoporte_grilla);
        } else {
            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
        }
    }
}

function TipoSoporte_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/TipoSoporte/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function TipoSoporte_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {
            var url = baseUrl + 'Administracion/TipoSoporte/TipoSoporte_Eliminar';
            var arrayParametro = {
                ID_SOPORTE: id
            };
            var auditoria = SICA.Ajax(url, arrayParametro, false);
            if (auditoria.EJECUCION_PROCEDIMIENTO) {
                if (!auditoria.RECHAZAR) {
                    TipoSoporte_CargarGrilla(TipoSoporte_grilla);
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

function TipoSoporte_CargarGrilla(_grilla) {
    var item =
    {
        descripcion: $("#TIPOSOPORTE_DESCRIPCION").val().toUpperCase()
    };
    var url = baseUrl + "Administracion/TipoSoporte/TipoSoporte_Listar";
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
                        ID_SOPORTE: v.ID_SOPORTE,
                        DESC_SOPORTE: v.DESC_SOPORTE,
                        FLG_ELIMINADO: v.FLG_ELIMINADO,
                        FLG_ESTADO: v.FLG_ESTADO,
                        USU_CREACION: v.USU_CREACION,
                        FEC_CREACION: v.FEC_CREACION,
                        IP_CREACION: v.IP_CREACION,
                        USU_MODIFICACION: v.USU_MODIFICACION,
                        FEC_MODIFICACION: v.FEC_MODIFICACION,
                        //STR_FEC_MODIFICACION: v.STR_FEC_MODIFICACION,
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

function TipoSoporte_LimpiarCampo() {
    $("#TIPOSOPORTE_DESCRIPCION").val('');
    TipoSoporte_CargarGrilla(TipoSoporte_grilla);
}

/*  ----------------------------------
    |    Ingresar nuevo registro     |
    ---------------------------------- */

function TipoSoporte_RegistrarDatos() {
    if ($('#hd_TIPOSOPORTE_ACCION').val() != 'N') {
        TipoSoporte_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoTipoSoporte").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {

                    var item =
                    {
                        DESC_SOPORTE: $("#DESC_SOPORTE").val().toUpperCase()
                    };
                    var url = baseUrl + 'Administracion/TipoSoporte/TipoSoporte_Registrar';
                    var auditoria = SICA.Ajax(url, item, false);
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EJECUCION_PROCEDIMIENTO) {
                            if (!auditoria.RECHAZAR) {
                                TipoSoporte_CargarGrilla(TipoSoporte_grilla);
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
function TipoSoporte_ActualizarDatos() {
    if ($("#frmMantenimientoTipoSoporte").valid()) {
        var item =
        {
            ID_SOPORTE: $("#hd_TIPOSOPORTE_ID_SOPORTE").val(),
            DESC_SOPORTE: $("#DESC_SOPORTE").val().toUpperCase()
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                var url = baseUrl + 'Administracion/TipoSoporte/TipoSoporte_Actualizar';
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {

                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            TipoSoporte_CargarGrilla(TipoSoporte_grilla);
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

function TipoSoporte_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/TipoSoporte/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


