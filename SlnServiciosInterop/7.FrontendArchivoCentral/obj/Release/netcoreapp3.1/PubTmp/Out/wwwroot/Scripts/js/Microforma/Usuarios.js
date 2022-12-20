
 function Lista_Usuarios() {
    var url = `archivo-central/usuario/listar`;
     API.FetchGet("GET", url, function (auditoria) {
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    let dataList = $('#comboUsuario');
                    dataList.html("").append("<option value=''>--Seleccione--</option>");
                    $.each(auditoria.Objeto, function (i, v) {
                        let option = $('<option>', { "value": `${v.ID_USUARIO}`, "text": `${v.NOMBRE_USUARIO}` });
                        dataList.append(option);
                    });
                    $('#comboUsuario').val($("#inputHddId_Usuario").val());
                } else {
                    jAlert(auditoria.MensajeSalida, "Atención");
                }
            } else {
                jAlert(auditoria.MensajeSalida, "Atención");
            }
        }
    });
}