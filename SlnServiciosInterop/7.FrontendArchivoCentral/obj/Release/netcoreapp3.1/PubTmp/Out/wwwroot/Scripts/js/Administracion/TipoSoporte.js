var Soporte_Grilla = 'Soporte_Grilla';
var Soporte_Barra = 'Soporte_Barra';

$(document).ready(function () {
    Soporte_ConfigurarGrilla(Soporte_Grilla, Soporte_Barra);
    Soporte_CargarGrilla(Soporte_Grilla);
    Remove_RemoverClases("liTipoSoporte");

    $("#soporte_btn_limpiar").click(function (e) {
        Soporte_LimpiarCampo();
    });

    $("#soporte_btn_buscar").click(function (e) {
        Soporte_CargarGrilla(Soporte_Grilla);
    });

    $("#soporte_btn_nuevo").click(function (e) {
        Soporte_MostrarNueva();
    });
});


function Soporte_LimpiarCampo() {
    $("#soporte_descripcion").val('');
    $("#SoporteCboEstado").val('');
    Soporte_CargarGrilla(Soporte_Grilla);
}

function Soporte_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Descripción', 
        'Usuario creación', 'Fecha creación',
        'Usuario Modificación', 'Fecha modificación'];
    var colModels = [
        { name: 'ID_SOPORTE', index: 'ID_FONDO', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 0, hidden: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: Soporte_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: Soporte_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Soporte_estadoAction },

        { name: 'DESC_SOPORTE', index: 'DESC_FONDO', align: 'center', width: 250, hidden: false },

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
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado Tipo Soporte', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Soporte_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='Soporte_MostrarEditar(" + rowObject['ID_SOPORTE'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Soporte_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='Soporte_Eliminar(" + rowObject['ID_SOPORTE'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Soporte_estadoAction(cellvalue, options, rowObject) {
    
    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_SOPORTE'] + "\" type=\"checkbox\" onchange=\"Soporte_Estado(" + rowObject['ID_SOPORTE'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function Soporte_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Soporte/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

/*  ----------------------------------
    |    estado registro           |
    ---------------------------------- */

function Soporte_Estado(ID, CHECK) {
    var item = {
        IdSoporte: ID,
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddCod_usuario").val()
    };
    var url = `archivo-central/soporte/estado/${item.IdSoporte}`;
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

function Soporte_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {
            var url = `archivo-central/soporte/eliminar/${id}`;
            API.FetchGet("DELETE", url, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            Soporte_CargarGrilla(Soporte_Grilla);
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

function Soporte_CargarGrilla(_grilla) {
    var item =
    {
        DescSoporte: $("#soporte_descripcion").val().toUpperCase(),
        FlgEstado: $("#SoporteCboEstado").val()
    };
    var url = "archivo-central/soporte/listar";
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

function Soporte_RegistrarDatos() {
    if ($('#hd_SOPORTE_ACCION').val() != 'N') {
        Soporte_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoSoporte").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {

                    var item =
                    {
                        DescSoporte: $("#DESC_SOPORTE").val().toUpperCase(),
                        UsuCreacion: $("#inputHddCod_usuario").val()
                    };
                    var url = 'archivo-central/soporte/insertar';
                    API.Fetch("POST", url, item, function (auditoria) {

                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Soporte_CargarGrilla(Soporte_Grilla);
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
function Soporte_ActualizarDatos() {
    if ($("#frmMantenimientoSoporte").valid()) {
        var id = $("#hd_SOPORTE_ID_SOPORTE").val();
        var item =
        {
            DescSoporte: $("#DESC_SOPORTE").val().toUpperCase(),
            UsuModificacion: $("#inputHddCod_usuario").val()
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {

                var url = `archivo-central/soporte/actualizar/${id}`;
                API.Fetch("PUT", url, item, function (auditoria) {

                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Soporte_CargarGrilla(Soporte_Grilla);
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

function Soporte_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Soporte/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


