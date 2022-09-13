
var Tabla_grilla = "Tabla_grilla";
var Tabla_barra = "Tabla_barra";
var Tabla_ID_CONTROL_CARGA = 0;

$(document).ready(function () {
    $("#file-upload").change(function () {
        $("#lbl_file").html("Seleccionar archivo");
        var input = document.getElementById('file-upload');
        var file = input.files[0];
        var PesodeArchivo = parseFloat(file.size);
        var ext = input.files[0].name.split('.').pop();
        var nombre = input.files[0].name;
        if (nombre.length > 100) {
            jAlert("El nombre de la imagen es muy largo", 'Alerta');
            $(this).val('');
            return false;
        } else {
            var validopes = false;
            if (PesodeArchivo <= Tamanio_Valido)
                validopes = true;

            if (!validopes) {
                $(this).val('');
                jAlert("El peso de la imagen no pueden pesar más de " + Tamanio_Valido / 1024 / 1024 + "Mb", 'Alerta');
                return false;
            } else {
                $("#lbl_file").html(nombre);
            }
        }
    });
});

jQuery('#aTabTabla').click(function (e) {
    _PREFIJO = "";
    _ID_MODULO = 1;
});

function Tabla_ControlCarga_Listar() {
    var url = baseUrl + 'Carga/ControlCarga/ControlCarga_Listar';
    $.ajax({
        url: url,
        //data: JSON.stringify(entidad),
        dataType: "json",
        type: "POST",
        error: function () {
            $('#ID_CONTROL_CARGA').html("<option value=''>--Seleccione--</option>");
        },
        success: function (auditoria) {
            var items = "";
            items += "<option value=\"" + "" + "\">" + "--Seleccione--" + "</option>";
            if (auditoria.EJECUCION_PROCEDIMIENTO) {
                if (!auditoria.RECHAZAR) {
                    if (auditoria.OBJETO.length > 0) {
                        $.each(auditoria.OBJETO, function (i, item) {
                            items += "<option value=\"" + item.ID_CONTROL_CARGA + "\">" + item.ID_CONTROL_CARGA + " | Fecha : " + item.STR_FEC_CREACION + " | N° Registros : " + item.NRO_REGISTROS + "</option>";
                        });
                    }
                }
            }
            $('#ID_CONTROL_CARGA').html(items);
        }
    });
}

function CargarComboTipoCarga() {
    var url = '@Url.Action("Get_TipoCarga", "Carga", new { area = "Carga" })';
    var data = Seguridad.Ajax(url, '', false);
    if (data != undefined || data != null) {
        var stateDropdown = $('#ddlGrupo');
        stateDropdown.empty();
        stateDropdown.append('<option value = "0">-Seleccione-</option>');
        if (data.length > 0) {
            $.each(data, function (i, v) {
                stateDropdown.append('<option value = "' + v.GRUPO + '">' + v.DESCRIPCION + '</option>');
            });
        }
    }
}

jQuery('#ID_TABLA').change(function (e) {
    Tabla_Mostrar_div_Formato();
});

function Tabla_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_Temporal_ConfigurarGrilla(" + Tabla_grilla + "," + Tabla_barra + ",\"Listado de documentos cargados\");", 500);
}

jQuery('#Tabla_btn_Buscar').click(function (e) {
    Tabla_buscar();
});

function Tabla_Mostrar_div_Formato() {
    var ID_TABLA = $("#ID_TABLA").val();
    if (ID_TABLA == '') {
        $("#div_btn_VerFormato").hide();
    } else {
        $("#div_btn_VerFormato").show();
    }
}

jQuery('#ID_CONTROL_CARGA').change(function (e) {
    Tabla_buscar();
});


jQuery('#btn_VerFormato').click(function (e) {
    Tabla_Mostrar_Formato();
});

jQuery('#Tabla_btn_Eliminar').click(function (e) {
    Tabla_Eliminar();
});

jQuery('#btn_Procesar').click(function (e) {
    Tabla_Procesar();
});

jQuery('#Tabla_btn_Grabar').click(function (e) {
    Tabla_Grabar();
});

function Tabla_Mostrar_Formato() {
    var ID_TABLA = $("#ID_TABLA").val();
    jQuery("#myModal_VerFormato").html('');
    jQuery("#myModal_VerFormato").load(baseUrl + "Carga/Formato/Formato_Ver?ID_TABLA=" + ID_TABLA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_VerFormato');
        if (request.status != 200) return;
    });
}

function Tabla_Procesar() {
    var __ID_TABLA = $("#ID_TABLA").val();
    var pregunta = "";
    if (__ID_TABLA == "") {
        jAlert("Seleccione su formato", "Atención");
        return;
    }
    jConfirm("Antes de continuar favor de asegurarse que el archivo no tenga caracteres especiales [;*_\!,etc] en el nombre y el nombre de la hoja sea Hoja1, si ya hizo todo lo mencionado obvie este mensaje presionando el botón Aceptar para seguir con el proceso", "Atención", function (r) {
        if (r) {
            var url = baseUrl + "Carga/Carga/CargarArchivo";
            var ID_TABLA = $("#ID_TABLA").val();
            var options = {
                type: "POST",
                dataType: "json",
                url: url,
                extraData: ({ 
                }),
                resetForm: true,
                beforeSubmit: function (formData, jqForm, options) {
                    var queryString = $.param(formData);
                    return true;
                },
                success: function (auditoria) {
                    $("#lbl_file").html("Seleccionar archivo");
                    Tabla_Mostrar_div_Formato();
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            jOkas('El proceso de carga ha culminado', 'Alerta');
                            Tabla_buscar();
                            //Tabla_ConfigurarGrilla();
                        } else {
                            SICA.Alert('Alerta', auditoria.MENSAJE_SALIDA, '', 'es');
                        }
                    }
                    else {
                        SICA.Alert('Alerta', auditoria.MENSAJE_SALIDA, '', 'es');
                    }
                    if (auditoria.OBJETO != null)
                        Tabla_Resultados(auditoria.OBJETO, ID_TABLA);
                    else {
                        html = "<i class=\"clip-close\" style='color:#f30203'></i>&nbsp; <span style='color:#f30203'>Carga con errores</span>";
                        $("#lbl_resultado").html(html);
                    }
                }
            };
            $("#Tabla_FrmCarga").ajaxForm(options);
            $("#Tabla_FrmCarga").submit();
        }
    });
}

function Tabla_Descargar_Errores(ID_CONTROL_CARGA) {
    jQuery("#myModal_DescargarErrores").html('');
    jQuery("#myModal_DescargarErrores").load(baseUrl + "Carga/CargaError/CargaError_Descargar?ID_CONTROL_CARGA=" + ID_CONTROL_CARGA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_DescargarErrores');
        if (request.status != 200) return;
    });
}

function Tabla_Descargar_Cargas() {
    jQuery("#myModal_DescargarErrores").html('');
    jQuery("#myModal_DescargarErrores").load(baseUrl + "Carga/ControlCarga/ControlCarga_Descargar", function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_DescargarErrores');
        if (request.status != 200) return;
    });
}

function Tabla_Resultados(ID_CONTROL_CARGA, ID_TABLA) {
    if (ID_CONTROL_CARGA == 0) {
        var html = "";
        html = "<i class=\"clip-notification-2\"></i> <span>No se encontró ninguna carga realizada</span>";
        $("#lbl_resultado").html(html);
    } else {
        var item =
        {
            ID_CONTROL_CARGA: ID_CONTROL_CARGA,
            ID_TABLA: ID_TABLA
        };
        var url = baseUrl + 'Carga/Carga/Carga_Listar_Uno';
        var auditoria = SICA.Ajax(url, item, false);
        if (auditoria != null && auditoria != "") {
            if (auditoria.EJECUCION_PROCEDIMIENTO) {
                if (!auditoria.RECHAZAR) {
                    var Cls_Ent_Control_Carga = auditoria.OBJETO;
                    var html = "";
                    var color = "#9999b1";
                    if (Cls_Ent_Control_Carga.ID_CONTROL_CARGA != 0) {
                        if (Cls_Ent_Control_Carga.FLG_CARGA == 1) {
                            color = "green";
                            html = " Ultima carga registrada   : "
                                + "<br/> <i class=\"clip-checkmark-2\" style='color:#6f9a37'></i>&nbsp; <span style='color:#6f9a37'> Carga correcta sin errores</span>"
                                + "<br/> N°               : " + Cls_Ent_Control_Carga.ID_CONTROL_CARGA
                                + "<br/> Fecha de Carga   : " + Cls_Ent_Control_Carga.STR_FEC_CREACION
                                + "<br/> Nro de Registros : " + Cls_Ent_Control_Carga.NRO_REGISTROS;
                            Tabla_ControlCarga_Listar();
                        } else {
                            color = "red";
                            html = " Ultima carga registrada   : "
                                + "<br/> <i class=\"clip-close\" style='color:#f30203'></i>&nbsp; <span style='color:#f30203;margin-bottom:10px'> Carga incorrecta se encontraron con errores</span> "
                                + "<br/> N°               : " + Cls_Ent_Control_Carga.ID_CONTROL_CARGA
                                + "<br/> Fecha de Carga   : " + Cls_Ent_Control_Carga.STR_FEC_CREACION
                                + "<br/> <a  title='Click para descargar los errores'  onclick='Tabla_Descargar_Errores(" + Cls_Ent_Control_Carga.ID_CONTROL_CARGA + " );' style='color:#f30203;cursor: pointer;margin-top:10px'><i class='clip-download' style='color:#f30203' data-toggle='modal'></i> Click para descargar los errores de esta carga</a>  ";
                        }
                    } else {
                        html = "<i class=\"clip-notification-2\"></i> <span>No se encontró ninguna carga realizada</span>";
                    }
                    $("#lbl_resultado").css("outline-color", color);
                    $("#lbl_resultado").html(html);
                }
            }
        } else {
            jAlert("No se encontraron registros", "Atención");
        }
    }
}

function Tabla_Grabar() {
    if ($("#ID_CONTROL_CARGA").val() == "") {
        jAlert("Seleccione un proceso de carga para grabar.", "Atención");
    } else {
        jConfirm("¿ Desea grabar todos los documentos ?", "Atención", function (r) {
            if (r) {
                var item =
                {
                    ID_CONTROL_CARGA: $("#ID_CONTROL_CARGA").val()
                };
                var url = baseUrl + 'Microforma/Documento/Documento_Grabar';
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            jOkas("Documentos grabados correctamente", "Atención");
                            Tabla_ControlCarga_Listar();
                            Tabla_buscar();
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
        });
    }
}

function Tabla_Eliminar() {
    if ($("#ID_CONTROL_CARGA").val() == "") {
        jAlert("Seleccione un proceso de carga para eliminar.", "Atención");
    } else {
        jConfirm("¿ Desea eliminar el proceso de carga y sus documentos ?", "Atención", function (r) {
            if (r) {
                var item =
                {
                    ID_CONTROL_CARGA: $("#ID_CONTROL_CARGA").val()
                };
                var url = baseUrl + 'Carga/ControlCarga/ControlCarga_Eliminar';
                var auditoria = SICA.Ajax(url, item, false);
                if (auditoria != null && auditoria != "") {
                    if (auditoria.EJECUCION_PROCEDIMIENTO) {
                        if (!auditoria.RECHAZAR) {
                            jOkas("Proceso de carga eliminado correctamente", "Atención");
                            Tabla_ControlCarga_Listar();
                            Tabla_buscar();
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
        });
    }
}