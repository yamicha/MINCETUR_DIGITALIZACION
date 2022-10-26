
function Leyenda_Cargar() {

    var html = '';
    var orden = Number('0');
    var item =
    {
        ID_TABLA: $("#hd_Formato_ID_TABLA").val()
    };
    var url = baseUrl + 'Carga/Leyenda/Leyenda_Listar';
    var auditoria = SICA.Ajax(url, item, false);
    if (auditoria != null) {
        if (auditoria.EJECUCION_PROCEDIMIENTO) {
            html += '<div class="col-sm-12">';
            html += '<center>';
            html += '<div class="col-sm-12" style="border:2px solid #dddddd;border-right-width: 1px;border-top-width: 1px;;border-bottom-width: 1px;height: 90%;background-color:#434243">';
            html += '<label class="col-sm-12 control-label" for="form-field-1" style="width:100%;font-size: 15px; color: white; font-weight: bold;text-align:left;margin-bottom: 5px;"> Leyenda </label>';
            html += '</div>';
            html += '<br/>';

            $.each(auditoria.OBJETO, function (i, v) {
                orden = orden + 1;
                html += '<div class="col-sm-12">';
                html += '<label class="col-sm-10 control-label" for="form-field-1" style="width:100%;font-size: 12px; color: black; font-weight: bold;text-align:left">' + v.ORDEN_LEYENDA + '. ' + v.DESCRIPCION_LEYENDA + ' ' + '<a  title="Descargar" style="color:#007be8;cursor: pointer" data-toggle="modal"  onclick="Leyenda_Descargar(' + v.ID_LEYENDA + ');" id="123"><i class="clip-clipboard"></i> ' + v.LINK_LEYENDA + '</a></label>';
                html += '</div>';
            });
            if (orden == 0) {
                orden = 1;
            } else {
                orden = orden + 1;
            }
            html += '<div class="col-sm-12" style="text-align:left">';
            html += '<label class="col-sm-10 control-label" for="form-field-1" style="width:100%;font-size: 12px; color: black; font-weight: bold;text-align:left">' + orden + '. ' + 'Los campos obligatorios deben ser llenados correctamente.</label>';
            html += '</div>';
            html += '</center>';
            html += '</div>';
            $('#Formato_leyenda').html('');
            $('#Formato_leyenda').append(html);
        }
    }
}

function Leyenda_Descargar(ID_LEYENDA) {
    jQuery("#myModal_Leyenda_Descargar").html('');
    jQuery("#myModal_Leyenda_Descargar").load(baseUrl + "Carga/Leyenda/Leyenda_Descargar?ID_LEYENDA=" + ID_LEYENDA, function (responseText, textStatus, request) {
        $.validator.unobtrusive.parse('#myModal_Leyenda_Descargar');
        if (request.status != 200) return;
    });
}
