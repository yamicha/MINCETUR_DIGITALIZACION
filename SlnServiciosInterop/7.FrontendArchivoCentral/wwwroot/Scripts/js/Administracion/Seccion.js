var Seccion_grilla = 'Seccion_grilla';
var Seccion_barra = 'Seccion_barra';

$(document).ready(function () {
    Remove_RemoverClases("liSeccion");
    Seccion_ConfigurarGrilla(Seccion_grilla, Seccion_barra);
    Seccion_CargarGrilla(Seccion_grilla);

    $("#SECCION_BTN_LIMPIAR").click(function (e) {
        Seccion_LimpiarCampo();
    });

    $("#SECCION_BTN_BUSCAR").click(function (e) {
        Seccion_CargarGrilla(Seccion_grilla);
    });

    $("#SECCION_BTN_NUEVO").click(function (e) {
        Seccion_MostrarNueva();
    });

});

function Seccion_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '', '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Cod Sección', 'Descripción Corta', 'Descripción Larga',
        'Usuario Creación', 'Fecha Creación',
        'Usuario Modificación', 'Fecha Modificación'];
    var colModels = [
        { name: 'ID_SECCION', index: 'ID_SECCION', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 0, hidden: true },
        { name: 'CAMPO1', index: 'CAMPO1', align: 'center', width: 0, hidden: true, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
        { name: 'CAMPO2', index: 'CAMPO2', align: 'center', width: 0, hidden: true, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: Seccion_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: Seccion_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Seccion_estadoAction },

        { name: 'COD_SECCION', index: 'COD_SECCION', align: 'center', width: 100, hidden: true },
        { name: 'DES_CORTA_SECCION', index: 'DES_CORTA_SECCION', align: 'center', width: 250, hidden: false },
        { name: 'DES_LARGA_SECCION', index: 'DES_LARGA_SECCION', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 150, hidden: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'STR_FEC_MODIFICACION', index: 'STR_FEC_MODIFICACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        //{ name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado de Seccion', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Seccion_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='Seccion_MostrarEditar(" + rowObject['ID_SECCION'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Seccion_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='Seccion_Eliminar(" + rowObject['ID_SECCION'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Seccion_estadoAction(cellvalue, options, rowObject) {

    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_SECCION'] + "\" type=\"checkbox\" onchange=\"Seccion_Estado(" + rowObject['ID_SECCION'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function Seccion_Estado(ID_SECCION, CHECK) {
    var item = {
        IdSeccion: parseInt(ID_SECCION),
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddCod_usuario").val()
    };
    var url = `archivo-central/seccion/estado/${item.IdSeccion}`;
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

function Seccion_MostrarEditar(id) {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Seccion/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function Seccion_Eliminar(id) {
    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {
            var url = `archivo-central/seccion/eliminar/${id}`;
            API.FetchGet("DELETE", url, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            Seccion_CargarGrilla(Seccion_grilla);
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

function Seccion_CargarGrilla(_grilla) {
    var item =
    {
        DescLargaSeccion: $("#SecciontxtDescripcionLarga").val(),
        FlgEstado: $("#SeccionCboEstado").val(),
    };
    var url = "archivo-central/seccion/listar";
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
                            ID_SECCION: v.ID_SECCION,
                            COD_SECCION: v.COD_SECCION,
                            DES_CORTA_SECCION: v.DES_CORTA_SECCION,
                            DES_LARGA_SECCION: v.DES_LARGA_SECCION,
                            FLG_ELIMINADO: v.FLG_ELIMINADO,
                            CAMPO1: v.CAMPO1,
                            CAMPO2: v.CAMPO2,
                            FLG_ESTADO: v.FLG_ESTADO,
                            USU_CREACION: v.USU_CREACION,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            USU_MODIFICACION: v.USU_MODIFICACION,
                            STR_FEC_MODIFICACION: v. STR_FEC_MODIFICACION,
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

function Seccion_LimpiarCampo() {
    $("#SecciontxtDescripcionLarga").val('');
    $("#SeccionCboEstado").val('');
    Seccion_CargarGrilla(Seccion_grilla);
}

/*  ----------------------------------
    |    Ingresar nuevo registro     |
    ---------------------------------- */

function Seccion_RegistrarDatos() {
    if ($('#hd_SECCION_ACCION').val() != 'N') {
        Seccion_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoSeccion").valid()) {

            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {
                    var item =
                    {
                        //ID_SECCION: $("#ID_SECCION").val(),
                        //COD_SECCION: $("#COD_SECCION").val(),
                        DescCortaSeccion: $("#DESC_CORTA_SECCION").val().toUpperCase(),
                        DescLargaSeccion: $("#DESC_LARGA_SECCION").val().toUpperCase(),
                        UsuCreacion: $("#inputHddCod_usuario").val()
                    };
                    var url = 'archivo-central/seccion/insertar';
                    API.Fetch("POST", url, item, function (auditoria) {
                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Seccion_CargarGrilla(Seccion_grilla);
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
function Seccion_ActualizarDatos() {
    if ($("#frmMantenimientoSeccion").valid()) {
        var id = $("#hd_SECCION_ID_SECCION").val(); 
        var item =
        {
            IdSeccion: parseInt($("#hd_SECCION_ID_SECCION").val()),
            DescCortaSeccion: $("#DESC_CORTA_SECCION").val().toUpperCase(),
            DescLargaSeccion: $("#DESC_LARGA_SECCION").val().toUpperCase(),
            UsuModificacion: $("#inputHddCod_usuario").val()
        };
        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                var url = `archivo-central/seccion/actualizar/${id}` ;
                API.Fetch("PUT", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Seccion_CargarGrilla(Seccion_grilla);
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

function Seccion_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Seccion/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


