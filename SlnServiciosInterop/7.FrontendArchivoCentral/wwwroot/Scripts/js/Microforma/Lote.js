
function Lote_ConfigurarGrilla(_grilla, _barra, _multiselect) {
    $("#" + _grilla).GridUnload();
    var colNames = ['1', '2',
        'Lote', 'Fecha de Creación','Usuario Recepción'];
    var colModels = [
        { name: 'CODIGO', index: 'CODIGO', align: 'center', hidden: true, width: 1, key: true },
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 1, hidden: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 100, hidden: false, search: false, search: true },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 250, hidden: false, search: true },
        { name: 'USU_CREACION', index: 'USU_CREACION', align: 'center', width: 250, hidden: false, search: true }
    ];
    var opciones = {
        GridLocal: true, multiselect: _multiselect, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc', footerrow: false,
        grouping: false,
        selectRowFunc: function () {
            if (!_multiselect) {
                var rowKey = parseInt(jQuery("#" + _grilla).getGridParam('selrow'));
                var data = jQuery("#" + _grilla).jqGrid('getRowData', rowKey);
                _ID_LOTE = data.ID_LOTE;
                if (data.ID_LOTE == undefined) _ID_LOTE = 0;
                if (_ID_MODULO == 3) {
                    Asignados_buscar();
                }
            }
        },

    };
    SICA.Grilla(_grilla, _barra, '', '550', '', '', "", "", colNames, colModels, "", opciones);
    $("#" + _grilla).filterToolbar({ searchOnEnter: true, stringResult: false, defaultSearch: "cn" });
    jqGridResponsive($(".jqGridLote"));
}

function Lote_actionVerDocumentos(cellvalue, options, rowObject) {
    var _btn = rowObject.STR_SUB_LOTE;
    if (_ID_MODULO == 12) {
        _btn += "<button title='Ver Documentos' onclick='Lote_VerDocumentos(" + rowObject.ID_DOCUMENTO_LOTE + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;padding: 5px;\"> <i class=\"clip-search-3\" style=\"color:#a01010;font-size:15px\"></i></button>";
    }
    return _btn;
}

function Lote_VerDocumentos(CODIGO) {
    if (_ID_MODULO == 12) {
        _ID_LOTE = CODIGO;
        MicroformaGrabar_buscar();
    }
}

function Lote_CargarGrilla(_grilla, _FLG_DEVOLUCION, _FLG_MICROFORMA, _FEHCA_INICIO, _FECHA_FIN) {
    debugger;
    if (_FEHCA_INICIO == null && _FECHA_FIN == null) {
        _FEHCA_INICIO = GetFecha();
        _FECHA_FIN = GetFecha();
    }
    var item = {
        flgDevuelto: _FLG_DEVOLUCION,
        flgMicroforma: _FLG_MICROFORMA,
        fechaInicio: _FEHCA_INICIO,
        fechaFin: _FECHA_FIN
    }
    var url = `archivo-central/digitalizacion/listar-lotes`;
    API.Fetch("POST", url, item, function (auditoria) {
        jQuery("#" + _grilla).jqGrid('clearGridData', true).trigger("reloadGrid");
        if (auditoria != null && auditoria != "") {
            if (auditoria.EjecucionProceso) {
                if (!auditoria.Rechazo) {
                    var x = 0;
                    $.each(auditoria.Objeto, function (i, v) {
                        x++;
                        var myData =
                        {
                            CODIGO: x,
                            ID_LOTE: v.ID_LOTE,
                            NRO_LOTE: v.NRO_LOTE,
                            STR_FEC_CREACION: v.STR_FEC_CREACION,
                            USU_CREACION: v.USU_CREACION
                        };
                        jQuery("#" + _grilla).jqGrid('addRowData', x, myData);
                    });
                    jQuery("#" + _grilla).trigger("reloadGrid");
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



// METODO QUE VALIDA LA FECHA
const validateDate = (birthDate) => {
    const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/

    /* Comprobar formato dd/mm/yyyy, que el no sea mayor de 12 y los días mayores de 31 */
    if (!birthDate.match(DATE_REGEX)) {
        return false
    }

    /* Comprobar los días del mes */
    const day = parseInt(birthDate.split('/')[0])
    const month = parseInt(birthDate.split('/')[1])
    const year = parseInt(birthDate.split('/')[2])
    const monthDays = new Date(year, month, 0).getDate()
    if (day > monthDays) {
        return false
    }

    /* Comprobar que el año no sea superior al actual*/
    //if (year > CURRENT_YEAR) {
    //    return false
    //}
    return true
}

//METODO QUE TRAE LA FECHA HOY
function GetFecha() {

    var f = new Date();
    var fechaActual = '';
    fechaActual = (("0" + f.getDate()).slice(-2) + "/" + ("0" + (f.getMonth() + 1)).slice(-2) + "/" + f.getFullYear());
    return fechaActual;
}