function openVentana(url, w, h, name) {
    var leftScreen = (screen.width - w) / 2;
    var topScreen = (screen.height - h) / 2;
    var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
    ventana = window.open(url, name, opciones);
    //ventana.focus();
}
function VerReportes(Url) {
    window.open(Url, 'ReporteEmpresas', 'scrollbars=yes,width=950,height=650,resizable=yes');
}
function Abrir_ventana(pagina) {
    var opciones = "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=785,height=600,top=0,left=0";

    window.open(pagina, "", opciones);
}

function ValidarNumero(control, l, n, e, op, oc, oct) {
    l || (l = false);
    e || (e = true);
    op || (op = false);
    oc || (oc = true);
    oct || (oct = true);
    n || (n = true);
    $(control).allowChars({
        letras: l,
        numeros: n,
        espa6cios: e,
        onpaste: op,
        oncopy: oc,
        oncut: oct,
        caracteres: ""
    });
}
function ValidarLetras(control, l, n, e, op, oc, oct) {
    l || (l = true);
    e || (e = true);
    op || (op = true);
    oc || (oc = true);
    oct || (oct = true);
    n || (n = false);
    $(control).allowChars({
        letras: l,
        numeros: n,
        espacios: e,
        onpaste: op,
        oncopy: oc,
        oncut: oct,
        caracteres: ""
    });
}
function ValidarNumerosLetras(control, l, n, e, op, oc, oct) {
    l || (l = true);
    e || (e = true);
    op || (op = true);
    oc || (oc = true);
    oct || (oct = true);
    n || (n = false);
    $(control).allowChars({
        letras: l,
        numeros: n,
        espacios: e,
        onpaste: op,
        oncopy: oc,
        oncut: oct,
        caracteres: "_-"
    });
}
function ValidarNumerosLetrasCaracteres(control,carac, l, n, e, op, oc, oct) {
    l || (l = true);
    e || (e = true);
    op || (op = true);
    oc || (oc = true);
    oct || (oct = true);
    n || (n = false);
    $(control).allowChars({
        letras: l,
        numeros: n,
        espacios: e,
        onpaste: op,
        oncopy: oc,
        oncut: oct,
        caracteres: carac
    });
}
function Seleccionar(Grilla, chkTodos) {
    var grilla = document.getElementById(Grilla);
    if (document.getElementById(chkTodos).checked == true) {
        for (var i = 1; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[7];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = true;
                }
            }
            var cell2 = grilla.rows[i].cells[8];
            for (var k = 0; k < cell2.childNodes.length; k++) {
                if (cell2.childNodes[k].type == "text") {
                    cell2.childNodes[k].style.display = "none";
                    cell2.childNodes[k].style.borderColor = "";
                    cell2.childNodes[k].style.color = "";
                }
            }
        }
    }
    else {
        for (var i = 1; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[7];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = false;
                }
            }
            var cell2 = grilla.rows[i].cells[8];
            for (var k = 0; k < cell2.childNodes.length; k++) {
                if (cell2.childNodes[k].type == "text") {
                    cell2.childNodes[k].style.display = "inline";
                    cell2.childNodes[k].style.borderColor = "#FF0000";
                    cell2.childNodes[k].style.color = "#0000FF";
                }
            }
        }
    }
}
function MostrarObs(chekbox) {
    var fila = chekbox.parentNode.parentNode;
    if (chekbox.checked == true) {
        var cell = fila.cells[8];
        for (var j = 0; j < cell.childNodes.length; j++) {
            if (cell.childNodes[j].type == "text") {
                cell.childNodes[j].style.display = "none";
                cell.childNodes[j].style.borderColor = "";
                cell.childNodes[j].style.color = "";
            }
        }
    }
    else {
        var cell = fila.cells[8];
        for (var j = 0; j < cell.childNodes.length; j++) {
            if (cell.childNodes[j].type == "text") {
                cell.childNodes[j].style.display = "inline";
                cell.childNodes[j].style.borderColor = "#FF0000";
                cell.childNodes[j].style.color = "#0000FF";
                cell.childNodes[j].focus();
            }
        }
    }
}
function SeleccionarDevolucion(Grilla, chkTodos) {
    var grilla = document.getElementById(Grilla);
    if (document.getElementById(chkTodos).checked == true) {
        for (var i = 1; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[7];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = true;
                }
            }
        }
    }
    else {
        for (var i = 1; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[7];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = false;
                }
            }
        }
    }
}
function AjaxSICA(url, parameters, async) {
    var rsp = null;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: parameters,
        dataType: "json",
        async: async,
        success: function (response) {
            rsp = response;
        },
        failure: function (msg) {
            rsp = msg;
        },
        error: function (xhr, status, error) {
            rsp = error;
        }
    });
    return rsp;
}

function openWindow3(Accion,Id,Titulo, objform, radhijo) {
    var parentPage = GetRadWindow().BrowserWindow;
    var parentRadWindowManager = parentPage.GetRadWindowManager();
    var oWnd2 = parentRadWindowManager.open(objform + '?Accion=' + Accion + '&Id=' + Id, radhijo);
    oWnd2.set_title('<center>' + Titulo + '</center>');
    oWnd2.set_modal(true);
   
   // oWnd2.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Maximize);
    window.setTimeout(function () {
        oWnd2.setActive(true);
    }, 0);
}
function GeneralValidarCantCaracteresDNI(source, arguments) {
    if ($.trim(arguments.Value).length < 8 )
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}

function SeleccionarPermisos(Grilla, chkTodos) {
    var grilla = document.getElementById(Grilla);
    if (document.getElementById(chkTodos).checked == true) {
        for (var i = 0; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[2];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = true;
                }
            }
        }
    }
    else {
        for (var i = 0; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[2];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = false;
                }
            }
        }
    }
}

function SeleccionarPermisosDisponibles(Grilla, chkTodos) {
    var grilla = document.getElementById(Grilla);
    if (document.getElementById(chkTodos).checked == true) {
        for (var i = 0; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[4];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = true;
                }
            }
        }
    }
    else {
        for (var i = 0; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[4];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = false;
                }
            }
        }
    }
}

function SeleccionarChekGrilla(Grilla, chkTodos,Pos) {
    var grilla = document.getElementById(Grilla);
    if (document.getElementById(chkTodos).checked == true) {
        for (var i = 0; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[Pos];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = true;
                }
            }
        }
    }
    else {
        for (var i = 0; i < grilla.rows.length; i++) {
            var cell = grilla.rows[i].cells[Pos];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = false;
                }
            }
        }
    }
}

function SeleccionarChekGrillaPaging(Grilla, chkTodos, Pos) {
    var grilla = document.getElementById(Grilla);

    var cant = grilla.rows.length;
    cant = cant < 10 ? cant : cant - 1;
    if (document.getElementById(chkTodos).checked == true) {
        for (var i = 0; i < cant; i++) {
            var cell = grilla.rows[i].cells[Pos];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = true;
                }
            }
        }
    }
    else {
        for (var i = 0; i < cant; i++) {
            var cell = grilla.rows[i].cells[Pos];
            for (var j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    cell.childNodes[j].checked = false;
                }
            }
        }
    }
}