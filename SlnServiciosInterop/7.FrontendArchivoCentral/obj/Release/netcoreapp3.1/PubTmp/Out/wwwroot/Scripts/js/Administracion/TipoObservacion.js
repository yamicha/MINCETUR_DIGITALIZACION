var Observacion_grilla = 'Observacion_Grilla';
var Observacion_barra = 'Observacion_Barra';

$(document).ready(function () {
    Observacion_ConfigurarGrilla(Observacion_grilla, Observacion_barra);
    Observacion_CargarGrilla(Observacion_grilla);
    Remove_RemoverClases("liTipoObservacion");

    $("#observacion_btn_limpiar").click(function (e) {
        Observacion_LimpiarCampo();
    });

    $("#observacion_btn_buscar").click(function (e) {
        Observacion_CargarGrilla(Observacion_grilla);
    });

    $("#observacion_btn_nuevo").click(function (e) {
        Observacion_MostrarNueva();
    });
});

function Observacion_LimpiarCampo() {
    $("#observacion_descripcion").val('');
    $("#ObservacionCboEstado").val('');
    Observacion_CargarGrilla(Observacion_grilla);
}

function Observacion_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Descripción', 
        'Usuario Creación', 'Fecha Creación',
        'Usuario Modificación', 'Fecha Modificación'];
    var colModels = [
        { name: 'ID_OBSERVACION', index: 'ID_OBSERVACION', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 0, hidden: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: Observacion_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: Observacion_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Observacion_estadoAction },

        { name: 'DESC_OBSERVACION', index: 'DESC_OBSERVACION', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false },
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', align: 'center', width: 150, hidden: false},
        //{ name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado Tipo Observación', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Observacion_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='Observacion_MostrarEditar(" + rowObject['ID_OBSERVACION'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Observacion_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='Observacion_Eliminar(" + rowObject['ID_OBSERVACION'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Observacion_estadoAction(cellvalue, options, rowObject) {
    
    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_OBSERVACION'] + "\" type=\"checkbox\" onchange=\"Observacion_Estado(" + rowObject['ID_OBSERVACION'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function Observacion_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Observacion/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

/*  ----------------------------------
    |    estado registro           |
    ---------------------------------- */
function Observacion_Estado(ID, CHECK) {
    var item = {
        IdObservacion: ID,
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddId_Usuario").val()
    };
    var url = `archivo-central/observacion/estado/${item.IdObservacion}`;
    API.Fetch("PUT", url, item, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Atención");
            }
        }
    });
}

/*  ----------------------------------
    |    eliminar registro           |
    ---------------------------------- */

function Observacion_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {

            var url = `archivo-central/observacion/eliminar/${id}`;
            API.FetchGet("DELETE", url, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            Observacion_CargarGrilla(Observacion_grilla);
                            jAlert("Registro eliminado", "Proceso");
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
}

/*  ----------------------------------
    |    cargar registro           |
    ---------------------------------- */

function Observacion_CargarGrilla(_grilla) {
    var item =
    {
        DescObservacion: $("#observacion_descripcion").val().toUpperCase(),
        FlgEstado: $("#ObservacionCboEstado").val()
    };
    var url = "archivo-central/observacion/listar";
    jQuery("#" + _grilla).jqGrid('clearGridData', true).trigger("reloadGrid");

    API.Fetch("POST", url, item, function (auditoria) {

        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    var x = 0;
                    $.each(auditoria.Objeto, function (i, v) {
                        x++;
                        var myData =
                        {
                            ID_OBSERVACION: v.ID_OBSERVACION,
                            DESC_OBSERVACION: v.DESC_OBSERVACION,
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
                    jAlert(auditoria.MensajeSalida, "Ocurrio un Error");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Ocurrio un Error");
            }
        } else {
            jAlert(auditoria.MensajeSalida, "Ocurrio un Error");
        }
    });
}



/*  ----------------------------------
    |    Ingresar nuevo registro     |
    ---------------------------------- */

function Observacion_RegistrarDatos() {
    if ($('#hd_OBSERVACION_ACCION').val() != 'N') {
        Observacion_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoObservacion").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {

                    var item =
                    {
                        DescObservacion: $("#DESC_OBSERVACION").val().toUpperCase(),
                        UsuCreacion: $("#inputHddId_Usuario").val()
                    };
                    var url = 'archivo-central/observacion/insertar';
                    API.Fetch("POST", url, item, function (auditoria) {

                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Observacion_CargarGrilla(Observacion_grilla);
                                    $('#myModalNuevo').modal('hide');
                                    jQuery("#myModalNuevo").html('');
                                    jAlert("Datos guardados satisfactoriamente", "Proceso");
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
        }
    }
}

/*  ------------------------------
    |    Actualizar registro     |
    ------------------------------ */
function Observacion_ActualizarDatos() {
    if ($("#frmMantenimientoObservacion").valid()) {
        var id = $("#hd_OBSERVACION_ID_OBSERVACION").val();
        var item =
        {
            DescObservacion: $("#DESC_OBSERVACION").val().toUpperCase(),
            UsuModificacion: $("#inputHddId_Usuario").val()
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                var url = `archivo-central/observacion/actualizar/${id}`;
                API.Fetch("PUT", url, item, function (auditoria) {

                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Observacion_CargarGrilla(Observacion_grilla);
                                $('#myModalNuevo').modal('hide');
                                jQuery("#myModalNuevo").html('');
                                jAlert("Datos actualizados satisfactoriamente", "Proceso");
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
    }
}

/*  ------------------------------
    |    Modal nuevo registro     |
    ------------------------------ */

function Observacion_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Observacion/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


