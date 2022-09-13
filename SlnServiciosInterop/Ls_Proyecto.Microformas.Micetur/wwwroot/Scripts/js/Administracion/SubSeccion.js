var SubSeccion_grilla = 'SubSeccion_grilla';
var SubSeccion_barra = 'SubSeccion_barra';

$(document).ready(function () {

    SubSeccion_ConfigurarGrilla(SubSeccion_grilla, SubSeccion_barra);
    SubSeccion_CargarGrilla(SubSeccion_grilla);
});

function SubSeccion_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '',
        '', '', '', '',
        'Editar', 'Eliminar', 'Estado',
        'Cod Subsección', 'Descripción Corta', 'Descripción Larga', 
        'Usuario Creación', 'Fecha Creación', 'IP Creación',
        'Usuario Modificación', 'Fecha Modificación', 'IP Modificación'];
    var colModels = [
        { name: 'ID_SUBSECCION', index: 'ID_SUBSECCION', align: 'center', hidden: true, width: 0, key: true },
        { name: 'ID_SECCION', index: 'ID_SECCION', align: 'center', width: 0, hidden: true },

        { name: 'FLG_ELIMINADO', index: 'FLG_ELIMINADO', align: 'center', width: 50, hidden: true },
        { name: 'CAMPO1', index: 'CAMPO1', align: 'center', width: 50, hidden: true, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
        { name: 'CAMPO2', index: 'CAMPO2', align: 'center', width: 50, hidden: true, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 50, hidden: true },

        { name: 'EDITAR', index: 'EDITAR', align: 'center', width: 80, hidden: false, formatter: SubSeccion_actionEditar },
        { name: 'ELIMINAR', index: 'ELIMINAR', align: 'center', width: 90, hidden: false, formatter: SubSeccion_actionEliminar },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: SubSeccion_estadoAction },

        { name: 'COD_SUBSECCION', index: 'COD_SUBSECCION', align: 'center', width: 150, hidden: false },
        { name: 'DESC_CORTA_SUBSECCION', index: 'DESC_CORTA_SUBSECCION', align: 'center', width: 250, hidden: false },
        { name: 'DESC_LARGA_SUBSECCION', index: 'DESC_LARGA_SUBSECCION', align: 'center', width: 250, hidden: false },

        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 150, hidden: false },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        { name: 'IP_CREACION', index: 'IP_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', align: 'center', width: 150, hidden: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y h:i A', newformat: 'd/m/Y h:i A' } },
        { name: 'IP_MODIFICACION', index: 'IP_MODIFICACION', align: 'center', width: 250, hidden: false }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado de SubSección', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function SubSeccion_actionEditar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Editar\" onclick='SubSeccion_MostrarEditar(" + rowObject['ID_SUBSECCION'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\" data-toggle=\"modal\" data-target=\"#myModalNuevo\"><i class=\"clip-pencil-3\" style=\"color:#f59d3f;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function SubSeccion_actionEliminar(cellvalue, options, rowObject) {
    var ModificarSeccion = "<button title=\"Eliminar\" onclick='SubSeccion_Eliminar(" + rowObject['ID_SUBSECCION'] + ");' class=\"btn btn-link\" type=\"button\" style=\"text-decoration: none !important;\"><i class=\"clip-cancel-circle-2\" style=\"color:#e40613;font-size:17px\"></i></button>";
    return ModificarSeccion;
}

function SubSeccion_estadoAction(cellvalue, options, rowObject) {

    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Seccion_chk_" + rowObject['ID_SUBSECCION'] + "\" type=\"checkbox\" onchange=\"SubSeccion_Estado(" + rowObject['ID_SUBSECCION'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}

function SubSeccion_Estado(ID_SUBSECCION, CHECK) {
    var item = {
        ID_SUBSECCION: ID_SUBSECCION,
        FLG_ESTADO: CHECK.checked == true ? '1' : '0'
        //USU_MODIFICACION: 'admin2'
    };
    var url = baseUrl + 'Administracion/SubSeccion/SubSeccion_Estado';
    var auditoria = SICA.Ajax(url, item, false);
    if (auditoria != null && auditoria != "") {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            if (auditoria.RECHAZAR) {
                jAlert(auditoria.MENSAJE_SALIDA, "Atención");
            }
            SubSeccion_CargarGrilla(SubSeccion_grilla);
        } else {
            jAlert(auditoria.MENSAJE_SALIDA, "Atención");
        }
    }
}

function SubSeccion_MostrarEditar(id) {

    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/SubSeccion/Mantenimiento?id=" + id + "&Accion=M", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

function SubSeccion_Eliminar(id) {

    jConfirm("¿Desea eliminar este registro ?", "Atención", function (r) {
        if (r) {
            
            var arrayParametro = {
                ID_SUBSECCION: id
            };
            var url = baseUrl + 'Administracion/SubSeccion/SubSeccion_Eliminar';
            var auditoria = SICA.Ajax(url, arrayParametro, false);
            if (auditoria.EJECUCION_PROCEDIMIENTO) {
                if (!auditoria.RECHAZAR) {
                    SubSeccion_CargarGrilla(SubSeccion_grilla);
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

function SubSeccion_CargarGrilla(_grilla) {
    var item =
    {
        descripcion: $("#SUBSECCION_DESCRIPCION").val().toUpperCase()
    };
    var url = baseUrl + "Administracion/SubSeccion/SubSeccion_Listar";
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
                        ID_SUBSECCION: v.ID_SUBSECCION,
                        ID_SECCION: v.ID_SECCION,
                        COD_SUBSECCION: v.COD_SUBSECCION,
                        DESC_CORTA_SUBSECCION: v.DESC_CORTA_SUBSECCION,
                        DESC_LARGA_SUBSECCION: v.DESC_LARGA_SUBSECCION,
                        FLG_ELIMINADO: v.FLG_ELIMINADO,
                        CAMPO1: v.CAMPO1,
                        CAMPO2: v.CAMPO2,
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

function SubSeccion_LimpiarCampo() {
    $("#SUBSECCION_DESCRIPCION").val('');
    SubSeccion_CargarGrilla(SubSeccion_grilla);
}

/*  ----------------------------------
    |    Ingresar nuevo registro     |
    ---------------------------------- */

function SubSeccion_RegistrarDatos() {
    if ($('#hd_SUBSECCION_ACCION').val() != 'N') {

        SubSeccion_ActualizarDatos();
    } else {
        if ($("#frmMantenimientoSubSeccion").valid()) {
            jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
                if (r) {
                    var item =
                    {
                        ID_SECCION: $("#ID_SECCION").val(),
                        COD_SUBSECCION: $("#COD_SUBSECCION").val(),
                        DESC_CORTA_SUBSECCION: $("#DESC_CORTA_SUBSECCION").val().toUpperCase(),
                        DESC_LARGA_SUBSECCION: $("#DESC_LARGA_SUBSECCION").val().toUpperCase()
                        //USU_CREACION: "ADMIN"
                    };
                    var url = baseUrl + 'Administracion/SubSeccion/SubSeccion_Registrar';
                    var auditoria = SICA.Ajax(url, item, false);
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EJECUCION_PROCEDIMIENTO) {
                            if (!auditoria.RECHAZAR) {
                                SubSeccion_CargarGrilla(SubSeccion_grilla);
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
function SubSeccion_ActualizarDatos() {

    if ($("#frmMantenimientoSubSeccion").valid()) {
        var item =
        {
            ID_SUBSECCION: $("#hd_SUBSECCION_ID_SECCION").val(),
            ID_SECCION: $("#ID_SECCION").val(),
            COD_SUBSECCION: $("#COD_SUBSECCION").val(),
            DESC_CORTA_SUBSECCION: $("#DESC_CORTA_SUBSECCION").val().toUpperCase(),
            DESC_LARGA_SUBSECCION: $("#DESC_LARGA_SUBSECCION").val().toUpperCase()
            //USU_MODIFICACION: "ADMIN2"
        };

        jConfirm("¿Desea actualizar este registro ?", "Atención", function (r) {
            if (r) {
                var url = baseUrl + 'Administracion/SubSeccion/SubSeccion_Actualizar';
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {

                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            SubSeccion_CargarGrilla(SubSeccion_grilla);
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

function SubSeccion_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/SubSeccion/Mantenimiento?id=0&Accion=N", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}


