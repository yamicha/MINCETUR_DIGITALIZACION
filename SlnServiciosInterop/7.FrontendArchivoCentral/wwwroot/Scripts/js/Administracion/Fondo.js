var Fondo_grilla = 'Fondo_Grilla';
var Fondo_barra = 'Fondo_Barra';

$(document).ready(function () {
    Fondo_ConfigurarGrilla(Fondo_grilla, Fondo_barra);
    Fondo_CargarGrilla(Fondo_grilla);
    Remove_RemoverClases("liFondo");

    $("#fondo_btn_limpiar").click(function (e) {
        Fondo_LimpiarCampo();
    });

    $("#fondo_btn_buscar").click(function (e) {
        Fondo_CargarGrilla(Fondo_grilla);
    });

    $("#fondo_btn_nuevo").click(function (e) {
        Fondo_MostrarNueva();
    });
});

function Fondo_LimpiarCampo() {
    $("#fondo_descripcion").val('');
    Fondo_CargarGrilla(Fondo_grilla);
}


function Fondo_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Descripción',
        'Usuario Creación', 'Fecha Creación', 'IP Creación',
        'Usuario Modificación', 'Fecha Modificación', 'IP Modificación'];
    var colModels = [
        { name: 'ID_FONDO', index: 'ID_FONDO', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 0, hidden: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: Fondo_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: Fondo_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Fondo_estadoAction },

        { name: 'DESC_FONDO', index: 'DESC_FONDO', align: 'center', width: 250, hidden: false },

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
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado de Fondo', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Fondo_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='Fondo_MostrarEditar(" + rowObject['ID_FONDO'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Fondo_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='Fondo_Eliminar(" + rowObject['ID_FONDO'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Fondo_estadoAction(cellvalue, options, rowObject) {

    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Fondo_chk_" + rowObject['ID_FONDO'] + "\" type=\"checkbox\" onchange=\"Fondo_Estado(" + rowObject['ID_FONDO'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}


function Fondo_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Fondo/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


/*  ----------------------------------
    |    estado registro           |
    ---------------------------------- */

function Fondo_Estado(ID_FONDO, CHECK) {
    var item = {
        IdFondo: ID_FONDO,
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddCod_usuario").val()
    };
    var url = `archivo-central/fondo/estado/${item.IdFondo}`;
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

function Fondo_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {

            var url = `archivo-central/fondo/eliminar/${id}`;
            API.FetchGet("DELETE", url, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            Fondo_CargarGrilla(Fondo_grilla);
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

function Fondo_CargarGrilla(_grilla) {
    var item =
    {
        DescFondo: $("#fondo_descripcion").val().toUpperCase()
    };
    
    var url = "archivo-central/fondo/listar";
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
                            ID_FONDO: v.ID_FONDO,
                            DESC_FONDO: v.DESC_FONDO,
                            FLG_ELIMINADO: v.FLG_ELIMINADO,
                            FLG_ESTADO: v.FLG_ESTADO,
                            USU_CREACION: v.USU_CREACION,
                            FEC_CREACION: v.FEC_CREACION,
                            IP_CREACION: v.IP_CREACION,
                            USU_MODIFICACION: v.USU_MODIFICACION,
                            FEC_MODIFICACION: v.FEC_MODIFICACION,
                            IP_MODIFICACION: v.IP_MODIFICACION,
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

function Fondo_RegistrarDatos() {
    if ($('#hd_FONDO_ACCION').val() != 'N') {
        Fondo_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoFondo").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {

                    var item =
                    {
                        DescFondo: $("#DESC_FONDO").val().toUpperCase(),
                        UsuCreacion: $("#inputHddCod_usuario").val()
                    };
                    var url = 'archivo-central/fondo/insertar';
                    API.Fetch("POST", url, item, function (auditoria) {
                        
                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Fondo_CargarGrilla(Fondo_grilla);
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
function Fondo_ActualizarDatos() {
    if ($("#frmMantenimientoFondo").valid()) {
        var id = $("#hd_FONDO_ID_FONDO").val();
        var item =
        {
            //IdFondo: $("#hd_FONDO_ID_FONDO").val(),
            DescFondo: $("#DESC_FONDO").val().toUpperCase(),
            UsuModificacion: $("#inputHddCod_usuario").val()
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                
                var url = `archivo-central/fondo/actualizar/${id}`;
                API.Fetch("PUT", url, item, function (auditoria) {
                    
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Fondo_CargarGrilla(Fondo_grilla);
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

function Fondo_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Fondo/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


