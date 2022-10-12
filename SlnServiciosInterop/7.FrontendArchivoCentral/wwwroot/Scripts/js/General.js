

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

function ValidarNumerosOtros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode == 8) return true;
    if (charCode == 46) return false;
    var patron = /([0-9]|[.])/;
    var te = String.fromCharCode(charCode);
    return patron.test(te);
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

function LeadingZero(Time) {
    return (Time < 10) ? "0" + Time : +Time;
}

function timePicker(id) {
    var MicroformaH_Hora = "00";
    var MicroformaH_Min = "00";
    var MicroformaH_Sec = "00";
    var input = document.getElementById(id);
    var timePicker = document.createElement('div');
    timePicker.classList.add('time-picker');
    var Microforma_Inicio = new Date().getTime();
    var Microforma_Inicio_Temp = new Date(Microforma_Inicio);
    MicroformaH_Hora = LeadingZero(Microforma_Inicio_Temp.getHours());
    MicroformaH_Min = LeadingZero(Microforma_Inicio_Temp.getUTCMinutes());
    MicroformaH_Sec = LeadingZero(Microforma_Inicio_Temp.getUTCSeconds());
    var Microforma_Hora = MicroformaH_Hora + ":" + MicroformaH_Min + ":" + MicroformaH_Sec;

    input.value = Microforma_Hora;

    input.onclick = function () {
        timePicker.classList.toggle('open');

        this.setAttribute('disabled', 'disabled');
        timePicker.innerHTML += `
                                  <div class="set-time">
                                     <div class="label">
                                        <a id="plusH" >+</a>
                                        <input class="set" type="text" id="hour" value="`+ MicroformaH_Hora + `" maxlength="2" onkeypress = "return ValidarNumerosOtrosR(event)">
                                        <a id="minusH">-</a>
                                     </div>
                                     <div class="label">
                                        <a id="plusM">+</a>
                                        <input class="set" type="text" id="minute" value="`+ MicroformaH_Min + `" maxlength="2" onkeypress = "return ValidarNumerosOtrosR(event)">
                                        <a id="minusM">-</a>
                                     </div>
                                    <div class="label">
                                        <a id="plusS">+</a>
                                        <input class="set" type="text" id="second" value="`+ MicroformaH_Sec + `" maxlength="2" onkeypress = "return ValidarNumerosOtrosR(event)">
                                        <a id="minusS">-</a>
                                     </div>
                                  </div>
                                  <div id="submitTime">actualizar</div>`;
        this.after(timePicker);
        var plusH = document.getElementById('plusH');
        var minusH = document.getElementById('minusH');
        var plusM = document.getElementById('plusM');
        var minusM = document.getElementById('minusM');
        var plusS = document.getElementById('plusS');
        var minusS = document.getElementById('minusS');
        var h = parseInt(document.getElementById('hour').value);
        var m = parseInt(document.getElementById('minute').value);
        var s = parseInt(document.getElementById('second').value);
        //increment hour
        plusH.onclick = function () {
            h = isNaN(h) ? 0 : h;
            if (h === 23) {
                h = -1;
            }
            h++;
            document.getElementById('hour').value = (h < 10 ? '0' : 0) + h;
        }
        //decrement hour
        minusH.onclick = function () {
            h = isNaN(h) ? 0 : h;
            if (h === 0) {
                h = 24;
            }
            h--;
            document.getElementById('hour').value = (h < 10 ? '0' : 0) + h;
        }
        //increment hour
        plusM.onclick = function () {
            m = isNaN(m) ? 0 : m;
            if (m === 59) {
                m = -1;
            }
            m++;// = m + 15;
            document.getElementById('minute').value = (m < 10 ? '0' : 0) + m;
        }
        //decrement hour
        minusM.onclick = function () {
            m = isNaN(m) ? 0 : m;
            if (m === 0) {
                m = 60;
            }
            m--;
            //m = m - 15;
            document.getElementById('minute').value = (m < 10 ? '0' : 0) + m;
        }
        //increment second
        plusS.onclick = function () {
            s = isNaN(s) ? 0 : s;
            if (s === 59) {
                s = -1;
            }
            s++;
            document.getElementById('second').value = (s < 10 ? '0' : 0) + s;
        }
        //decrement second
        minusS.onclick = function () {
            s = isNaN(s) ? 0 : s;
            if (s === 0) {
                s = 60;
            }
            s--;
            document.getElementById('second').value = (s < 10 ? '0' : 0) + s;
        }
        //submit timepicker
        var submit = document.getElementById("submitTime");
        submit.onclick = function () {

            MicroformaH_Hora = document.getElementById('hour').value;
            MicroformaH_Min = document.getElementById('minute').value;
            MicroformaH_Sec = document.getElementById('second').value;

            if (MicroformaH_Hora.length == 1) MicroformaH_Hora = '0' + MicroformaH_Hora;
            if (MicroformaH_Min.length == 1) MicroformaH_Min = '0' + MicroformaH_Min;
            if (MicroformaH_Sec.length == 1) MicroformaH_Sec = '0' + MicroformaH_Sec;

            input.value = MicroformaH_Hora + ":" + MicroformaH_Min + ":" + MicroformaH_Sec;
            //document.getElementById('hour').value + ':' + document.getElementById('minute').value + ':' + document.getElementById('second').value;
            input.removeAttribute('disabled');
            timePicker.classList.toggle('open');
            timePicker.innerHTML = '';
            $('#MICROFORMA_HORA').valid();
        }
    }
}