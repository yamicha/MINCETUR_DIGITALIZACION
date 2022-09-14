//function cargarVista(url) {
//    $.ajax({
//        url: url,
//        dataType: 'html',
//        type: 'get',
//        contentType: 'text/xml; charset=utf-8',
//        // async: false,
//        success: function (result) {
//            $('#divProceso').html("");
//            $('#divProceso').html(result);
//        }
//    });
//}

function ValidarSoloNumeroEntero(control, l, n, e, op, oc, oct) {
    l || (l = false);
    e || (e = true);
    op || (op = false);
    oc || (oc = true);
    oct || (oct = true);
    n || (n = true);

    $(control).allowChars2({
        letras: l,
        numeros: n,
        espacios: e,
        onpaste: op,
        oncopy: oc,
        oncut: oct,
        caracteres: ""
    });
}

function CountCharactersControlTxt(obj, lblObject, max) {
    try {
        var total = max;
        cant = document.getElementById(obj).value.length;
        total = total - cant
        if (cant > max) {
            var aux = document.getElementById(obj).value;
            document.getElementById(obj).value = aux.substring(0, max);
            return;
        }
        $("#" + lblObject).html("Nº Caracteres: " + cant + " restan " + total);
    } catch (e) {
        alert(e.Message);
    }
}

/**********************************************     VALIDACION DE FECHAS          

**********************************************/

function ValidarFormatoFecha(campo) {

    var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
    if ((campo.match(RegExPattern)) && (campo != '')) {
        return true;
    } else {
        return false;
    }
}

function ValidarFecha(fecha) {

    var fechaf = fecha.split("/");
    var day = fechaf[0];
    var month = fechaf[1];
    if (Number(month) > 12 || Number(month) < 1) {
        return false;
    }
    var year = fechaf[2];
    var date = new Date(year, month, '0');
    if ((day - 0) > (date.getDate() - 0)) {
        return false;
    }
    return true;
}

function ValidarFechasInicioFin(fechaini, fechafin, tipo) {

    var valido = true;
    //var fechaini = $('#' + fec_ini).val();
    //var fechafin = $('#' + fec_fin).val();
    if (fechaini != "") {
        if (ValidarFormatoFecha(fechaini) != true) {
            SICA.Alert('Alerta', 'La fecha es incorrecta', '', 'es');
            valido = false;
            return valido;
        }
        if (ValidarFecha(fechaini) != true) {
            SICA.Alert('Alerta', 'La fecha no existe', '', 'es');
            valido = false;
            return valido;
        }
    }
    if (fechafin != "") {
        if (ValidarFormatoFecha(fechafin) != true) {
            SICA.Alert('Alerta', 'La fecha fin es incorrecta', '', 'es');
            valido = false;
            return valido;
        }

        if (ValidarFecha(fechafin) != true) {
            SICA.Alert('Alerta', 'La fecha fin no existe', '', 'es');
            valido = false;
            return valido;
        }
    }
    if ((fechaini != "" || fechafin != "") && tipo) {
        if (fechaini == "") {
            SICA.Alert('Alerta', 'La fecha no puede estar vacio si hay fecha final', '', 'es');
            valido = false;
            return valido;
        }
        if (fechafin == "") {
            SICA.Alert('Alerta', 'La fecha final no puede estar vacio si hay fecha inicio', '', 'es');
            valido = false;
            return valido;
        }
        var x = new Date();
        var fecha = fechaini.split("/");
        if (fecha[2].length != 4) {
            SICA.Alert('Alerta', 'La fecha tiene el año incompleto', '', 'es');
            valido = false;
            return valido;
        }

        x.setFullYear(fecha[2], fecha[1] - 1, fecha[0]);

        var x1 = new Date();
        var fecha1 = fechafin.split("/");
        x1.setFullYear(fecha1[2], fecha1[1] - 1, fecha1[0]);
        if (fecha1[2].length != 4) {
            SICA.Alert('Alerta', 'La fecha fin tiene el año incompleto', '', 'es');
            valido = false;
            return valido;
        }
        if (x > x1) {
            SICA.Alert('Alerta', 'La fecha inicio no puede ser mayor a la final', '', 'es');
            valido = false;
            return valido;
        }
    }

    return valido;
}