var Operador_grilla = 'Operador_Grilla';
var Operador_barra = 'Operador_Barra';

$(document).ready(function () {
    Operador_ConfigurarGrilla(Operador_grilla, Operador_barra);
    Operador_CargarGrilla(Operador_grilla);
    Remove_RemoverClases("liOperador");

    $("#operador_btn_limpiar").click(function (e) {
        Operador_LimpiarCampo();
    });

    $("#operador_btn_buscar").click(function (e) {
        Operador_CargarGrilla(Operador_grilla);
    });

    $("#operador_btn_nuevo").click(function (e) {
        Operador_MostrarNueva();
    });
});

function Operador_LimpiarCampo() {
    $("#operador_descripcion").val('');
    $("#OperadorCboEstado").val('');
    Operador_CargarGrilla(Operador_grilla);
}


function Operador_ConfigurarGrilla(_grilla, _barra) {
    $("#" + _grilla).GridUnload();
    var colNames = [
        '', '',
        'Estado',
        'Operador',
        'Usuario Creación', 'Fecha Creación',
        'Usuario Modificación', 'Fecha Modificación'];
    var colModels = [
        { name: 'ID_USUARIO', index: 'ID_USUARIO', align: 'center', hidden: true, width: 0, key: true },
        { name: 'FLG_ESTADO', index: 'FLG_ESTADO', align: 'center', width: 0, hidden: true },
        { name: 'ACTIVO', index: 'ACTIVO', align: 'center', width: 70, hidden: false, sortable: true, formatter: Operador_estadoAction },
        { name: 'NOMBRE_USUARIO', index: 'NOMBRE_USUARIO', align: 'center', width: 300, hidden: false },
        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_CREACION', index: 'FEC_CREACION', align: 'center', width: 150, hidden: false },
        { name: 'USU_MODIFICACION', index: 'USU_MODIFICACION', align: 'center', width: 250, hidden: false },
        { name: 'FEC_MODIFICACION', index: 'FEC_MODIFICACION', align: 'center', width: 150, hidden: false },
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
    };
    SICA.Grilla(_grilla, _barra, '', '582', '', 'Listado de Operador', "", "", colNames, colModels, "", opciones);
    //jqGridResponsive($(".jqGridLote"));
}

/*  ----------------------------------
    |    Opciones de la grilla     |
    ---------------------------------- */

function Operador_estadoAction(cellvalue, options, rowObject) {
    var check_ = 'check';
    if (rowObject['FLG_ESTADO'] == 1)
        check_ = 'checked';
    var _btn = "<label class=\"switch\" title=\"Estado\">"
        + "<input id=\"Operador_chk_" + rowObject['ID_USUARIO'] + "\" type=\"checkbox\" onchange=\"Operador_Estado(" + rowObject['ID_USUARIO'] + ",this)\" " + check_ + ">"
        + "<span class=\"slider round\"></span>"
        + "</label>";
    return _btn;
}


function Operador_MostrarNueva() {
    jQuery("#myModalNuevo").html('');
    jQuery("#myModalNuevo").load(baseUrl + "Administracion/Operador/Mantenimiento", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModalNuevo');
        if (request.status != 200) return;
    });
}

/*  ----------------------------------
    |    estado registro           |
    ---------------------------------- */

function Operador_Estado(ID_USUARIO, CHECK) {
    var item = {
        IdUsuario: ID_USUARIO,
        FlgEstado: CHECK.checked == true ? '1' : '0',
        UsuModificacion: $("#inputHddId_Usuario").val()
    };
    var url = `ventanilla/operador/estado/${item.IdUsuario}`;
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

function Operador_CargarGrilla(_grilla) {
    var item =
    {
        NombreUsuario: $("#operador_descripcion").val(),
        FlgEstado: $("#OperadorCboEstado").val()
    };

    var url = "ventanilla/operador/listar";
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
                            ID_USUARIO: v.ID_USUARIO,
                            NOMBRE_USUARIO: v.NOMBRE_USUARIO,
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

function Operador_RegistrarDatos() {
    if ($("#frmMantenimientoOperador").valid()) {
        jConfirm("¿Desea guardar este registro ?", "Atención", function (r) {
            if (r) {

                var item =
                {
                    IdUsuario: parseInt($("#OPERADOR").val()),
                    UsuCreacion: $("#inputHddId_Usuario").val()
                };
                var url = 'ventanilla/operador/insertar';
                API.Fetch("POST", url, item, function (auditoria) {

                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                Operador_CargarGrilla(Operador_grilla);
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

function Operador_Usuarios() {
    var url = `archivo-central/usuario/listar`;
    API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    let dataList = $('#OPERADOR');
                    dataList.html("").append("<option value=''>--seleccione--</option>");
                    $.each(auditoria.Objeto, function (i, v) {
                        let option = $('<option>', { "value": `${v.ID_USUARIO}`, "text": `${v.NOMBRE_USUARIO}` });
                        dataList.append(option);
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

