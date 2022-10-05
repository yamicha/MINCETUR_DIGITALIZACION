﻿// tab 1
var MicroControl_grilla = 'MicroControl_grilla';
var MicroControl_barra = 'MicroControl_barra';

var MicroControl_Lote_grilla = 'MicroControl_Lote_grilla';
var MicroControl_Lote_barra = 'MicroControl_Lote_barra';

// tab 2
var MicroFin_grilla = 'MicroFin_grilla';
var MicroFin_barra = 'MicroFin_barra';

var MicroFin_Lote_grilla = 'MicroFin_Lote_grilla';
var MicroFin_Lote_barra = 'MicroFin_Lote_barra';


$(document).ready(function () {
    _MODULOMICRO = 3; 
    Microforma_ConfigurarGrilla(MicroControl_Lote_grilla, MicroControl_Lote_barra, MicroControl_grilla, MicroControl_barra);
    Microforma_ConfigurarGrilla(MicroFin_Lote_grilla, MicroFin_Lote_barra, MicroFin_grilla, MicroFin_barra);
    Microforma_CargarGrilla(MicroControl_Lote_grilla, EstadoMicroforma.Grabado);
    Documento_Detalle_buscar(MicroControl_grilla, MicroControl_barra);
    jQuery('#aTabMicroformaControl').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        _MODULOMICRO = 3; 
        Microforma_CargarGrilla(MicroControl_Lote_grilla, EstadoMicroforma.Grabado);
        Documento_Detalle_buscar(MicroControl_grilla, MicroControl_barra);
    });
    jQuery('#aTabMicroformaFinalizado').click(function (e) {
        _ID_MODULO = 0;
        _ID_LOTE = 0;
        _MODULOMICRO = 0; 
        Microforma_CargarGrilla(MicroFin_Lote_grilla, EstadoMicroforma.Conforme);
        Documento_Detalle_buscar(MicroFin_grilla, MicroFin_barra);
    });

});

function MicroformaCerrar() {
    $('#myModal_Documento_Grabar').modal('hide');
    jQuery("#myModal_Documento_Grabar").html('');
}

function MicroformaEvaluar() {
    if ($('#FrmMicroEvaluar').valid()) {
        jConfirm(" ¿ Desea grabar esta evaluación de microforma ? ", "Atención", function (r) {
            if (r) {
                var item = {
                    IdMicroforma: parseInt($("#HDF_ID_MICROFORMA").val()),
                    FlgConforme: parseInt($("#MICROFORMA_FLG_CONFORME").val()),
                    Observacion: $("#MICROFORMA_OBSERVACION").val(),
                    UsuCreacion: $("#inputHddCod_usuario").val(),
                }
                var url = "archivo-central/microforma/evaluar";
                API.Fetch("POST", url, item, function (auditoria) {
                    if (auditoria != null && auditoria != "") {
                        if (auditoria.EjecucionProceso) {
                            if (!auditoria.Rechazo) {
                                _ID_LOTE = 0;
                                Microforma_CargarGrilla(MicroControl_Lote_grilla, EstadoMicroforma.Grabado);
                                Documento_Detalle_buscar(MicroControl_grilla, MicroControl_barra);
                                jOkas("Microforma evaluada correctamente.", "Atención");
                                MicroformaCerrar();
                            } else {
                                jAlert(auditoria.MensajeSalida, "Atención");
                            }
                        } else {
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                    } else {
                        jAlert("No se encontraron registros", "Atención");
                    }
                });
            }
        });
    }
}

//********************************************************** tab finalizados *********************************************************/


