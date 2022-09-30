var Reprocesar_grilla = 'Reprocesar_grilla';
var Reprocesar_barra = 'Reprocesar_barra';
var Reprocesar_ListaDocumentos = new Array();

var Reprocesar_Int_Documento;
var Reprocesar_Reloj = false;
var Reprocesar_Inicio = 0;
var Reprocesar_intervalo = 0;
var Reprocesar_COD_DOCUMENTO = "";
var Reprocesar_HORA_INICIO = "";
var Reprocesar_HORA_FIN = "";

$(document).ready(function () {
    Reprocesar_HORA_INICIO = "";
    Reprocesar_HORA_FIN = "";
    clearInterval(Reprocesar_Int_Documento);
    Reprocesar_COD_DOCUMENTO = "";
    Reprocesar_ListaDocumentos = new Array();
    Reprocesar_Reloj = false;
    clearTimeout(Reprocesar_intervalo);
    Reprocesar_Inicio = 0;
    Reprocesar_intervalo = 0;
    Reprocesar_buscar();
});

jQuery('#aTabReprocesar').click(function (e) {
    Reprocesar_buscar();
});

jQuery('#Reprocesar_btn_Iniciar').click(function (e) {
    Reprocesar_Iniciar();
});

jQuery('#Reprocesar_Check_Finalizar').change(function (e) {
    var check = $("#Reprocesar_Check_Finalizar:checked").val();
    if (check == "0") {
        $("#Reprocesar_btn_Fin").show();
    } else {
        $("#Reprocesar_btn_Fin").hide();
    }
});

function Reprocesar_buscar() {
    $("#Recepcion_busqueda").show();
    setTimeout("Documento_ConfigurarGrilla(" + Reprocesar_grilla + "," + Reprocesar_barra + ",\"Listado de documentos no aprobados\", false, 8);", 500);
}

function Reprocesar_Iniciar() {
    Reprocesar_ListaDocumentos = new Array();
    var rowKey = $("#" + Reprocesar_grilla).jqGrid('getGridParam', 'selrow');
    //var rowKey = $("#" + Reprocesar_grilla).jqGrid('getGridParam', 'selarrrow'); // esta opcion permite traer los indices de cada fila seleccionada
    if (rowKey != null) {
        if (rowKey.length != 0) {
            $("#Reprocesar_btn_Fin").show();
            //for (var i = 0; i < rowKey.length; i++) {
            var data = jQuery("#" + Reprocesar_grilla).jqGrid('getRowData', rowKey);
            // var data = jQuery("#" + Reprocesar_grilla).jqGrid('getRowData', rowKey[i]);
            Reprocesar_COD_DOCUMENTO = data.Reprocesar_COD_DOCUMENTO;
            var itemDoc = {
                IdDocumento: data.Reprocesar_ID_DOCUMENTO,
                IdDocumentoAsignado: data.Reprocesar_ID_DOCUMENTO_ASIGNADO,
                HORA_INICIO: '',
                HORA_FIN: '',
                ID_LASERFICHER: data.Reprocesar_ID_LASERFICHE,
            };
            Reprocesar_ListaDocumentos.push(itemDoc);
            // }
            $('#Reprocesar_btn_Iniciar').attr('disabled', true);
            $('#Reprocesar_btn_Fin').attr('disabled', false);
            panelLoanding('Escaneando documento', Reprocesar_grilla);
            Reprocesar_IniciarReloj();
            //Reprocesar_ValidarDocumento();
        } else {
            jAlert("Seleccione un solo registro para iniciar la digitalización", "Atención");
        }
    } else {
        jAlert("Seleccione un solo registro para iniciar la digitalización", "Atención");
    }
}

function Reprocesar_IniciarReloj() {
    Reprocesar_Reloj = true;
    if (Reprocesar_intervalo == 0) {
        Reprocesar_Inicio = new Date().getTime();
        console.log(Reprocesar_Inicio);
        var Reprocesar_Inicio_Temp = new Date(Reprocesar_Inicio);
        console.log(Reprocesar_Inicio_Temp);
        Reprocesar_HORA_INICIO = LeadingZero(Reprocesar_Inicio_Temp.getHours()) + ":" + LeadingZero(Reprocesar_Inicio_Temp.getUTCMinutes()) + ":" + LeadingZero(Reprocesar_Inicio_Temp.getUTCSeconds());

        console.log(Reprocesar_HORA_INICIO);
        Reprocesar_ListaDocumentos[0].HORA_INICIO = Reprocesar_HORA_INICIO;
        Reprocesar_RelojFuncionando();
    } else {
        // detemer el cronometro
        clearTimeout(Reprocesar_intervalo);
        Reprocesar_intervalo = 0;
    }
}

function Reprocesar_RelojFuncionando() {
    if (Reprocesar_Reloj) {
        var fecha_actual = new Date().getTime();
        var Reprocesar_Fin_Temp = new Date(fecha_actual);
        Reprocesar_HORA_FIN = LeadingZero(Reprocesar_Fin_Temp.getHours()) + ":" + LeadingZero(Reprocesar_Fin_Temp.getUTCMinutes()) + ":" + LeadingZero(Reprocesar_Fin_Temp.getUTCSeconds());
        Reprocesar_ListaDocumentos[0].HORA_FIN = Reprocesar_HORA_FIN;
        var diferencia = new Date(fecha_actual - Reprocesar_Inicio);
        var resultado = LeadingZero(diferencia.getUTCHours()) + ":" + LeadingZero(diferencia.getUTCMinutes()) + ":" + LeadingZero(diferencia.getUTCSeconds());
        document.getElementById('Reprocesar_lbl_Crono').innerHTML = resultado;
        Reprocesar_intervalo = setTimeout("Reprocesar_RelojFuncionando()", 1000);
    }
}

function LeadingZero(Time) {
    return (Time < 10) ? "0" + Time : +Time;
}

function Reprocesar_LimpiarCronometro() {
    Reprocesar_HORA_INICIO = "";
    Reprocesar_HORA_FIN = "";
    Reprocesar_Reloj = false;
    clearTimeout(Reprocesar_intervalo);
    Reprocesar_Inicio = 0;
    Reprocesar_intervalo = 0;
    $("#Reprocesar_lbl_Crono").html("00:00:00");
}

function Reprocesar_RestaurarBotones() {
    Reprocesar_COD_DOCUMENTO = "";
    panelHidden(Reprocesar_grilla);
    $("#Reprocesar_Check_Finalizar").prop("checked", false);
    $('#Reprocesar_btn_Iniciar').attr('disabled', false);
    $('#Reprocesar_btn_Fin').attr('disabled', true);
    $('#Reprocesar_btn_Fin').hide();
}

jQuery('#Reprocesar_btn_Fin').click(function (e) {
    Reprocesar_FinalizarPregunta();
});

function Reprocesar_FinalizarPregunta() {
    if (Reprocesar_ListaDocumentos.length > 0) {
        jPrompt(" ¿ Desea finalizar con la digitalización ?<br/> En caso de ser necesario actualice el <b>ID LASERFICHER</b> ", Reprocesar_ListaDocumentos[0].ID_LASERFICHER, "Atención", function (val) {
            if (val != null) {
                if (val != 0 && !isNaN(val))
                    Reprocesar_Finalizar(val);
                else
                    jAlert("El <b>ID LASERFICHER</b> no puede ser (0 - vacío o de tipo carácter).", "Atención");
            }
        });
    } else {
        jAlert("Debe asignar por lo menos un documento.", "Atención");
    }
}

function Reprocesar_Finalizar(ID_LASERFICHER) {     
    if (Reprocesar_ListaDocumentos.length > 0) {
        var item = {        
            IdDocumento: parseInt(Reprocesar_ListaDocumentos[0].IdDocumento),
            IdDocumentoAsignado: parseInt(Reprocesar_ListaDocumentos[0].IdDocumentoAsignado),
            IdLaserfiche: parseInt(ID_LASERFICHER),
            HoraInicio: Reprocesar_ListaDocumentos[0].HORA_INICIO,
            HoraFIn: Reprocesar_ListaDocumentos[0].HORA_FIN,
            UsuCreacion: $('#inputHddCod_usuario').val()
        }
        var url = "archivo-central/digitalizacion/reprocesar-documento";
        API.Fetch("POST", url, item, function (auditoria) {
            if (auditoria != null && auditoria != "") {
                if (auditoria.EjecucionProceso) {
                    if (!auditoria.Rechazo) {
                        jOkas("Documento reprocesado correctamente", "Atención");
                    } else {
                        jAlert(auditoria.MensajeSalida, "Atención");
                    }
                    Reprocesar_ListaDocumentos = new Array();
                    Reprocesar_LimpiarCronometro();
                    Reprocesar_RestaurarBotones();
                    Reprocesar_buscar();
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

//function Reprocesar_ValidarDocumento() {
//    Reprocesar_Int_Documento = setInterval(function () {
//        var item = {
//            COD_DOCUMENTO: Reprocesar_COD_DOCUMENTO
//        }
//        var url = baseUrl + "Microforma/Documento/Documento_Validar";
//        var auditoria = SICA.Ajax(url, item, false);
//        if (auditoria != null && auditoria != "") {
//            if (auditoria.EjecucionProceso) {
//                if (!auditoria.Rechazo) {
//                    clearInterval(Reprocesar_Int_Documento);
//                    Reprocesar_Finalizar();
//                }
//            } else {
//                jAlert(auditoria.MensajeSalida, "Atención");
//            }
//        } else {
//            jAlert("No se encontraron registros", "Atención");
//        }
//    }, 1000);
//}