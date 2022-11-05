var Digitalizar_grilla = 'Digitalizar_grilla';
var Digitalizar_barra = 'Digitalizar_barra';
var Digitalizar_ListaDocumentos = new Array();
var Digitalizar_Int_Documento = 0;
var Digitalizar_Reloj = false;
var Digitalizar_Inicio = 0;
var Digitalizar_intervalo = 0;
var Digitalizar_COD_DOCUMENTO = "";
var Digitalizar_HORA_INICIO = "";
var Digitalizar_HORA_FIN = "";

$(document).ready(function () {
    Digitalizar_HORA_INICIO = "";
    Digitalizar_HORA_FIN = "";
    clearInterval(Digitalizar_Int_Documento);
    Digitalizar_COD_DOCUMENTO = "";
    Digitalizar_ListaDocumentos = new Array();
    Digitalizar_Reloj = false;
    clearTimeout(Digitalizar_intervalo);
    Digitalizar_Inicio = 0;
    Digitalizar_intervalo = 0;
    Digitalizar_buscar();
});

jQuery('#aTabDigitalizar').click(function (e) {
    Digitalizar_buscar();
});

jQuery('#Digitalizar_btn_Iniciar').click(function (e) {
    Digitalizar_Iniciar();
});
jQuery('#Digitalizar_btn_Cancelar').click(function (e) {
    Digitalizar_Cancelar();
});

function Digitalizar_Cancelar() {
    jConfirm(" ¿ Desea cancelar el proceso de digitalización ? ", "Atención", function (e) {
        if (e) {
            Digitalizar_ListaDocumentos = new Array();
            Digitalizar_LimpiarCronometro();
            Digitalizar_RestaurarBotones();
        }
    });
}

jQuery('#Digitalizar_Check_Finalizar').change(function (e) {
    var check = $("#Digitalizar_Check_Finalizar:checked").val();
    if (check == "0") {
        $("#Digitalizar_btn_Fin").show();
    } else {
        $("#Digitalizar_btn_Fin").hide();
    }
});

function Digitalizar_buscar() {
    Documento_ConfigurarGrilla(Digitalizar_grilla ,Digitalizar_barra ,"Listado de documentos asignados", false, 4);
}

function Digitalizar_Iniciar() {

    Digitalizar_ListaDocumentos = new Array();
    var rowKey = $("#" + Digitalizar_grilla).jqGrid('getGridParam', 'selrow'); // esta opcion permite traer los indices de cada fila seleccionada
    if (rowKey != null) {
        if (rowKey.length != 0) {
            jConfirm(" ¿ Desea iniciar el proceso de digitalización ? ", "Atención", function (e) {
                if (e) {
                    $("#Digitalizar_btn_Fin").show();
                    //for (var i = 0; i < rowKey.length; i++) {
                    var data = jQuery("#" + Digitalizar_grilla).jqGrid('getRowData', rowKey);
                    // var data = jQuery("#" + Digitalizar_grilla).jqGrid('getRowData', rowKey[i]);
                    Digitalizar_COD_DOCUMENTO = data.Digitalizar_COD_DOCUMENTO;
                    var itemDoc = {
                        IdDocumento: parseInt(data.Digitalizar_ID_DOCUMENTO),
                        IdDocumentoAsignado: parseInt(data.Digitalizar_ID_DOCUMENTO_ASIGNADO),
                        HORA_INICIO: '',
                        HORA_FIN: ''
                    };
                    Digitalizar_ListaDocumentos.push(itemDoc);
                    //}
                    $('#Digitalizar_btn_Iniciar').attr('disabled', true);
                    $('#Digitalizar_btn_Fin').attr('disabled', false);
                    $('#Digitalizar_btn_Cancelar').show();
                    //$(".ui-jqgrid-bdiv").css("overflow-x", "hidden");
                    // $(".ui-jqgrid-bdiv").css("overflow-y", "hidden");
                    panelLoanding('Escaneando documento', Digitalizar_grilla);
                    Digitalizar_IniciarReloj();
                    //Digitalizar_ValidarDocumento();
                    // $(".blockUI blockMsg blockElement").css("top", "10%");
                }
            });
        } else {
            jAlert("Seleccione un solo registro para iniciar la digitalización", "Atención");
        }
    } else {
        jAlert("Seleccione un solo registro para iniciar la digitalización", "Atención");
    }
}

function Digitalizar_IniciarReloj() {
    Digitalizar_Reloj = true;
    if (Digitalizar_intervalo == 0) {
        Digitalizar_Inicio = new Date().getTime();
        var Digitalizar_Inicio_Temp = new Date(Digitalizar_Inicio);
        Digitalizar_HORA_INICIO = LeadingZero(Digitalizar_Inicio_Temp.getHours()) + ":" + LeadingZero(Digitalizar_Inicio_Temp.getUTCMinutes()) + ":" + LeadingZero(Digitalizar_Inicio_Temp.getUTCSeconds());
        Digitalizar_ListaDocumentos[0].HORA_INICIO = Digitalizar_HORA_INICIO;
        Digitalizar_RelojFuncionando();
    } else {
        clearTimeout(Digitalizar_intervalo);
        Digitalizar_intervalo = 0;
    }
}

function Digitalizar_RelojFuncionando() {
    if (Digitalizar_Reloj) {
        var fecha_actual = new Date().getTime();
        var Digitalizar_Fin_Temp = new Date(fecha_actual);
        Digitalizar_HORA_FIN = LeadingZero(Digitalizar_Fin_Temp.getHours()) + ":" + LeadingZero(Digitalizar_Fin_Temp.getUTCMinutes()) + ":" + LeadingZero(Digitalizar_Fin_Temp.getUTCSeconds());
        Digitalizar_ListaDocumentos[0].HORA_FIN = Digitalizar_HORA_FIN;
        var diferencia = new Date(fecha_actual - Digitalizar_Inicio);
        var resultado = LeadingZero(diferencia.getUTCHours()) + ":" + LeadingZero(diferencia.getUTCMinutes()) + ":" + LeadingZero(diferencia.getUTCSeconds());
        document.getElementById('Digitalizar_lbl_Crono').innerHTML = resultado;
        Digitalizar_intervalo = setTimeout("Digitalizar_RelojFuncionando()", 1000);
    }
}

function LeadingZero(Time) {
    return (Time < 10) ? "0" + Time : +Time;
}

function Digitalizar_LimpiarCronometro() {
    Digitalizar_HORA_INICIO = "";
    Digitalizar_HORA_FIN = "";
    Digitalizar_Reloj = false;
    clearTimeout(Digitalizar_intervalo);
    Digitalizar_Inicio = 0;
    Digitalizar_intervalo = 0;
    $("#Digitalizar_lbl_Crono").html("00:00:00");
}

function Digitalizar_RestaurarBotones() {
    Digitalizar_COD_DOCUMENTO = "";
    panelHidden(Digitalizar_grilla);
    $("#Digitalizar_Check_Finalizar").prop("checked", false);
    $('#Digitalizar_btn_Iniciar').attr('disabled', false);
    $('#Digitalizar_btn_Fin').attr('disabled', true);
    $('#Digitalizar_btn_Fin').hide();
    $('#Digitalizar_btn_Cancelar').hide();
}

jQuery('#Digitalizar_btn_Fin').click(function (e) {
    Digitalizar_FinalizarPregunta();
});

function Digitalizar_FinalizarPregunta() {
    if (Digitalizar_ListaDocumentos.length > 0) {
        jPrompt(" Para finalizar con la digitalización <br/> porfavor ingrese el <b>ID LASERFICHE</b> ", 0, "Atención", function (val) {
            if (val != null) {
                debugger; 
                if (Digitalizar_ValidIdLaser(IdLaserMin, val)) {
                    Digitalizar_Finalizar(val);
                }
            }
        });
    } else {
        jAlert("Debe asignar por lo menos un documento.", "Atención");
    }
}

function Digitalizar_Finalizar(ID_LASERFICHER) {
    if (Digitalizar_ListaDocumentos.length > 0) {
        var item = {
            IdDocumento: Digitalizar_ListaDocumentos[0].IdDocumento,
            IdDocumentoAsignado: Digitalizar_ListaDocumentos[0].IdDocumentoAsignado,
            IdLaserfiche: parseInt(ID_LASERFICHER),
            HoraInicio: Digitalizar_ListaDocumentos[0].HORA_INICIO,
            HoraFIn: Digitalizar_ListaDocumentos[0].HORA_FIN,
            UsuCreacion: $('#inputHddId_Usuario').val()
        }
        var url = "ventanilla/digitalizacion/digitalizar-documento";
        API.Fetch("POST", url, item, function (auditoria) {
            if (auditoria != null && auditoria != "") {
                if (auditoria.EjecucionProceso) {
                    if (!auditoria.Rechazo) {
                        jOkas("Documento digitalizado correctamente", "Atención");
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                    Digitalizar_ListaDocumentos = new Array();
                    Digitalizar_LimpiarCronometro();
                    Digitalizar_RestaurarBotones();
                    Digitalizar_buscar();
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            } else {
                jAlert("No se encontraron registros", "Atención");
            }
        });
    } else {
        jAlert("Debe asignar por lo menos un documento.", "Atención");
    }
}

//function Digitalizar_ValidarDocumento() {
//    Digitalizar_Int_Documento = setInterval(function () {
//        var item = {
//            COD_DOCUMENTO: Digitalizar_COD_DOCUMENTO
//        }
//        var url = baseUrl + "Microforma/Documento/Documento_Validar";
//        var auditoria = SICA.Ajax(url, item, false);
//        if (auditoria != null && auditoria != "") {
//            if (auditoria.EjecucionProceso) {
//                if (!auditoria.Rechazo) {
//                    clearInterval(Digitalizar_Int_Documento);
//                    Digitalizar_Finalizar();
//                }
//            } else {
//                jAlert(auditoria.MensajeSalida, "Atención");
//            }
//        } else {
//            jAlert("No se encontraron registros", "Atención");
//        }
//    }, 1000);
//}