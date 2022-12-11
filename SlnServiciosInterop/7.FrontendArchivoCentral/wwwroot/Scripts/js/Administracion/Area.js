var Area_Grilla = 'Area_Grilla';
var Area_Barra = 'Area_Barra';

$(document).ready(function () {
    Area_ConfigurarGrilla(Area_Grilla, Area_Barra);
    Area_CargarGrilla(Area_Grilla);
    Remove_RemoverClases("liArea");

    $("#Area_btn_limpiar").click(function (e) {
        Area_LimpiarCampo();
    });

    $("#Area_btn_buscar").click(function (e) {
        Area_CargarGrilla(Area_Grilla);
    });

    $("#Area_btn_nuevo").click(function (e) {
        Area_MostrarNueva();
    });
});

function Area_LimpiarCampo() {
    $("#area_descripcion").val('');
    $("#AreaCboEstado").val('');
    Area_CargarGrilla(Area_Grilla);
}


function Area_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '',
        'Editar', 'Estado',
        'Descripción', 'Sigla',
        'Usuario Creación', 'Fecha Creación',
        'Usuario Modificación', 'Fecha Modificación'];
    var colModels = [
        { name: 'ID_AREA', index: 'ID_AREA', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: Area_actionEditar },
        //{ name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: true, formatter: Area_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Area_estadoAction },

        { name: 'DES_AREA', index: 'DES_AREA', align: 'center', width: 250, hidden: false },
        { name: 'SIGLA', index: 'SIGLA', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false },
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', align: 'center', width: 150, hidden: false },
        //{ name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado de Área', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Area_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='Area_MostrarEditar(" + rowObject['ID_AREA'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Area_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='Area_Eliminar(" + rowObject['ID_AREA'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Area_estadoAction(cellvalue, options, rowObject) {
    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Area_chk_" + rowObject['ID_AREA'] + "\" type=\"checkbox\" onchange=\"Area_Estado(" + rowObject['ID_AREA'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}


function Area_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Area/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


/*  ----------------------------------
    |    estado registro           |
    ---------------------------------- */

function Area_Estado(ID_AREA, CHECK) {
    var item = {
        IdArea: ID_AREA,
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddId_Usuario").val()
    };
    var url = `archivo-central/area/estado/${item.IdArea}`;
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
    |    cargar registro           |
    ---------------------------------- */

function Area_CargarGrilla(_grilla) {
    var item =
    {
        DescArea: $("#area_descripcion").val().toUpperCase(),
        FlgEstado: $("#AreaCboEstado").val()
    };

    var url = "archivo-central/area/listar";
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
                            ID_AREA: v.ID_AREA,
                            DES_AREA: v.DES_AREA,
                            SIGLA: v.SIGLA,
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

function Area_RegistrarDatos() {
    if ($('#hd_AREA_ACCION').val() != 'N') {
        Area_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoArea").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {

                    var item =
                    {
                        DescArea: $("#DESC_AREA").val().toUpperCase(),
                        Sigla: $("#SIGLA").val().toUpperCase(),
                        UsuCreacion: $("#inputHddId_Usuario").val()
                    };
                    var url = 'archivo-central/area/insertar';
                    API.Fetch("POST", url, item, function (auditoria) {

                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Area_CargarGrilla(Area_Grilla);
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
function Area_ActualizarDatos() {
    if ($("#frmMantenimientoArea").valid()) {
        var id = $("#hd_AREA_ID_AREA").val();
        var item =
        {
            //IdFondo: $("#hd_Area_ID_FONDO").val(),
            DescArea: $("#DESC_AREA").val().toUpperCase(),
            Sigla: $("#SIGLA").val().toUpperCase(),
            UsuModificacion: $("#inputHddId_Usuario").val()
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {

                var url = `archivo-central/area/actualizar/${id}`;
                API.Fetch("PUT", url, item, function (auditoria) {

                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Area_CargarGrilla(Area_Grilla);
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

function Area_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Area/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


/*  ------------------------------
    |  Carga data para editar    |
    ------------------------------ */

function AreaLoadFormEdit(id) {
    var url = `archivo-central/Area/get-area/${id}`;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    $('#DESC_AREA').val(auditoria.Objeto.DES_AREA);
                    $('#SIGLA').val(auditoria.Objeto.SIGLA);
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Atención");
            }
        }
    });
}