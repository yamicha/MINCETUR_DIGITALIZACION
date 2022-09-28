var Serie_grilla = 'Serie_Grilla';
var Serie_barra = 'Serie_Barra';

$(document).ready(function () {
    Serie_ConfigurarGrilla(Serie_grilla, Serie_barra);
    Serie_CargarGrilla(Serie_grilla);
    Remove_RemoverClases("liSerie");

    $("#serie_btn_limpiar").click(function (e) {
        Serie_LimpiarCampo();
    });

    $("#serie_btn_buscar").click(function (e) {
        Serie_CargarGrilla(Serie_grilla);
    });

    $("#serie_btn_nuevo").click(function (e) {
        Serie_MostrarNueva();
    });
});

function Serie_LimpiarCampo() {
    $("#serie_descripcion").val('');
    $("#SerieCboEstado").val('');
    Serie_CargarGrilla(Serie_grilla);
}

function Serie_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '',
        '', '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Sección', 'Código Serie', 'Descripción Serie',
        'Usuario Creación', 'Fecha Creación',
        'Usuario Modificación', 'Fecha Modificación'];
    var colModels = [
        { name: 'ID_SERIE', index: 'ID_SERIE', align: 'center', hidden: true, width: 0, key: true },
        { name: 'ID_SECCION', index: 'ID_SECCION', align: 'center', width: 0, hidden: true },

        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 0, hidden: true },
        { name: 'CAMPO1', index: 'CAMPO1', align: 'center', width: 0, hidden: true, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
        { name: 'CAMPO2', index: 'CAMPO2', align: 'center', width: 0, hidden: true, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: Serie_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: Serie_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Serie_estadoAction },

        { name: 'DES_CORTA_SECCION', index: 'DES_CORTA_SECCION', align: 'center', width: 100, hidden: false },
        { name: 'COD_SERIE', index: 'COD_SERIE', align: 'center', width: 100, hidden: false },
        { name: 'DES_SERIE', index: 'DES_SERIE', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 150, hidden: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false},
        //{ name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'STR_FEC_MODIFICACION', index: 'STR_FEC_MODIFICACION', align: 'center', width: 150, hidden: false },
        //{ name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado de Serie', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Serie_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='Serie_MostrarEditar(" + rowObject['ID_SERIE'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Serie_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='Serie_Eliminar(" + rowObject['ID_SERIE'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function Serie_estadoAction(cellvalue, options, rowObject) {
    debugger;
    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_SERIE'] + "\" type=\"checkbox\" onchange=\"Serie_Estado(" + rowObject['ID_SERIE'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function Serie_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Serie/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

/*  ----------------------------------
    |    estado registro           |
    ---------------------------------- */

function Serie_Estado(ID, CHECK) {
    var item = {
        IdSerie: ID,
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddCod_usuario").val()
    };
    var url = `archivo-central/serie/estado/${item.IdSerie}`;
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

function Serie_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {

            var url = `archivo-central/serie/eliminar/${id}`;
            API.FetchGet("DELETE", url, function (auditoria) {
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EjecucionProceso) {
                        if (!auditoria.Rechazo) {
                            Serie_CargarGrilla(Serie_grilla);
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
function Serie_CargarGrilla(_grilla) {
    var item =
    {
        //IdSeccion: null,
        DescSerie: $("#serie_descripcion").val().toUpperCase(),
        FlgEstado: $("#SerieCboEstado").val()
    };

    var url = "archivo-central/serie/listar";
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
                            ID_SERIE: v.ID_SERIE,
                            ID_SECCION: v.ID_SECCION,
                            DES_CORTA_SECCION: v.DES_CORTA_SECCION,
                            COD_SERIE: v.COD_SERIE,
                            DES_SERIE: v.DES_SERIE,
                            FLG_ELIMINADO: v.FLG_ELIMINADO,
                            CAMPO1: v.CAMPO1,
                            CAMPO2: v.CAMPO2,
                            FLG_ESTADO: v.FLG_ESTADO,
                            USU_CREACION: v.USU_CREACION,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            IP_CREACION: v.IP_CREACION,
                            USU_MODIFICACION: v.USU_MODIFICACION,
                            STR_FEC_MODIFICACION: v.STR_FEC_MODIFICACION,
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

function Serie_RegistrarDatos() {
    
    if ($('#hd_SERIE_ACCION').val() != 'N') {

        Serie_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoSerie").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {
                    debugger;
                    var item =
                    {
                        //IdSerie: $("#ID_SECCION").val(),
                        IdSeccion: parseInt($("#ID_SECCION").val()),
                        DescCodSerie: $("#COD_SERIE").val().toUpperCase(),
                        DescSerie: $("#DES_SERIE").val().toUpperCase(),
                        UsuCreacion: $("#inputHddCod_usuario").val()
                    };
                    var url = 'archivo-central/serie/insertar';
                    API.Fetch("POST", url, item, function (auditoria) {

                        if (auditoria != null && auditoria != "") {
                            if (auditoria.EjecucionProceso) {
                                if (!auditoria.Rechazo) {
                                    Serie_CargarGrilla(Serie_grilla);
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
function Serie_ActualizarDatos() {

    if ($("#frmMantenimientoSerie").valid()) {
        var id = $("#hd_SERIE_ID_SERIE").val();
        var item =
        {
            
            //IdSerie: $("#hd_SERIE_ID_SERIE").val(),
            IdSeccion: parseInt($("#ID_SECCION").val()),
            //ID_SUBSECCION: $("#ID_SUBSECCION").val(),
            DescCodSerie: $("#COD_SERIE").val().toUpperCase(),
            DescSerie: $("#DES_SERIE").val().toUpperCase(),
            UsuModificacion: $("#inputHddCod_usuario").val()
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                var url = `archivo-central/serie/actualizar/${id}`;
                API.Fetch("PUT", url, item, function (auditoria) {

                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Serie_CargarGrilla(Serie_grilla);
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

function Serie_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Serie/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


