
var MicroEstado = {
    Grabado: 1,
    Conforme: 2,
    Observado: 3,
    Detalle: 0,
}
var MicroModulo = {
    Grabados: 1,
    Reprocesar: 2,
    Control: 3,
    Conforme: 4,
    CAlmacen: 5,
    CAlmacenFin: 6,
    RevisionPend: 7,
    RevisionObs: 8,
    RevisionAnulada: 9,
}

var _MICROMODULO = 0;
function MicroformaProceso_ConfigurarGrilla(_Grilla, _Barra, _GrillaDocumento, _BarraDocumento, _tab, _select = false) {
    _MICROMODULO = _tab;
    var EstadoHidden = false;
    var OpcionesHidden = true;
    if (_MICROMODULO >= MicroModulo.RevisionPend) {
        EstadoHidden = true;
        OpcionesHidden = false;
    }
    var url = BaseUrlApi + "ventanilla/microforma/listadoProceso-paginado";
    var urlsubgrid = BaseUrlApi + "ventanilla/microforma/lote-microforma";
    $("#" + _Grilla).GridUnload();
    var colNames = ['0', 'Opciones', 'Volumen', 'Revisiones', '2', '3',
        'Microforma', 'Estado', 'Fecha de Grabación', 'idestado', 'FlgConforme'];
    var colModels = [
        { name: 'ID_MICROFORMA', index: 'ID_MICROFORMA', align: 'center', hidden: true, width: 1, key: true }, // 0
        { name: 'OPCIONES', index: 'OPCIONES', align: 'center', width: 80, hidden: OpcionesHidden, formatter: Microforma_OpcionesFormatter, sortable: false },// 1
        { name: 'NRO_VOLUMEN', index: 'NRO_VOLUMEN', align: 'center', width: 180, hidden: false },// 2
        { name: 'NRO_REVISIONES', index: 'NRO_REVISIONES', align: 'center', width: 80, hidden: OpcionesHidden }, // 3
        { name: 'CODIGO_SOPORTE', index: 'CODIGO_SOPORTE', align: 'center', width: 1, hidden: true }, // 4
        { name: 'DESC_SOPORTE', index: 'DESC_SOPORTE', align: 'center', width: 200, hidden: true }, // 5
        { name: 'DESC_SOPORTE_X', index: 'DESC_SOPORTE_X', align: 'center', width: 200, hidden: false, formatter: Microforma_actionVerCodigo, sortable: false }, // 7
        { name: 'DESC_ESTADO', index: 'DESC_ESTADO', align: 'center', width: 150, hidden: EstadoHidden }, // 8
        { name: 'STR_FEC_GRABACION', index: 'STR_FEC_GRABACION', align: 'center', width: 250, hidden: false }, // 9
        { name: 'ID_ESTADO', index: 'ID_ESTADO', align: 'center', width: 250, hidden: true }, // 10
        { name: 'FLG_CONFORME', index: 'FLG_CONFORME', align: 'center', width: 250, hidden: true },// 11

    ];
    var colNames_2 = ['ID', 'Lote', 'Fecha de Creación'];
    var colModels_2 = [
        { name: 'ID_LOTE', index: 'ID_LOTE', align: 'center', width: 1, hidden: true, sortable: false, key: true },
        { name: 'NRO_LOTE', index: 'NRO_LOTE', align: 'center', width: 200, hidden: false, sortable: false },
        { name: 'STR_FEC_CREACION', index: 'STR_FEC_CREACION', align: 'center', width: 150, hidden: false },
    ];
    var opcionesSubgrid = {
        ColNames: colNames_2, Url: urlsubgrid, ColModels: colModels_2, Width: 595, Height: '',
        selectRowFunc: function (rowkey) {
            if (rowkey == undefined) _ID_LOTE = 0;
            _ID_LOTE = parseInt(rowkey);
            Documento_Detalle_buscar(_GrillaDocumento, _BarraDocumento);
        }
    }
    var opciones = {
        GridLocal: false, multiselect: _select, CellEdit: true, Editar: false, nuevo: false, eliminar: false, sort: 'desc',
        estadoSubGrid: true, viewrecords: true, subGrid: opcionesSubgrid, getrules: GetRulesMicroforma(), rules: true,
        gridCompleteFunc: function () {
            //MicroformaColorRevision(_Grilla);
        }
    };
    SICA.Grilla(_Grilla, _Barra, '', '582', '', '', url, "", colNames, colModels, "", opciones);
    jqGridResponsive($(".jqGridLote"));
}



function GetRulesMicroforma() {
    var rules = new Array();
    var POR = "'%'";
    if (_MICROMODULO == MicroModulo.Reprocesar) { // Reprocesar
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(3)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.Control) { // Reprocesador, grabados
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(1,4)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.Conforme) { // conformes
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2,5)', op: " in " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacen) { // control almacen
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2)', op: " in " });
        rules.push({ field: 'FLG_MICROARCHIVO', data: '0', op: " = " });
    }
    if (_MICROMODULO == MicroModulo.Grabados) { // cmicro grabados
        debugger;
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(1)', op: " in " });
        var _STR_FEC_CREACION = $('#txtfechainiciograbado').val();
        var _STR_FEC_FIN = $('#txtfechafingrabado').val();
        rules.push({ field: '', data: "V.FECHA >= TRUNC(TO_DATE('" + _STR_FEC_CREACION + "', 'DD/MM/YYYY')) AND V.FECHA < TRUNC(TO_dATE('" + _STR_FEC_FIN + "', 'DD/MM/YYYY'))+1", op: " " });
    }
    if (_MICROMODULO == MicroModulo.CAlmacenFin) { // control almacen
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(2,5)', op: " in " });
        rules.push({ field: 'FLG_MICROARCHIVO', data: '1', op: " = " });
    } if (_MICROMODULO == MicroModulo.RevisionPend) { // revision pendiente 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='1' OR FLG_CONFORME IS NULL)`, op: "" });
    }
    if (_MICROMODULO == MicroModulo.RevisionObs) { // revision Obs 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='0' AND FLG_ANULADO ='0')`, op: "" });
    }
    if (_MICROMODULO == MicroModulo.RevisionAnulada) { // revision anulada 
        rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
        rules.push({ field: '', data: `(FLG_CONFORME ='0' AND FLG_ANULADO ='1')`, op: "" });
    }
    //} if (_MICROMODULO == MicroModulo.RevisionFin) { // control almacen
    //    rules.push({ field: 'ID_ESTADO_MICROFORMA', data: '(5)', op: " in " });
    //    rules.push({ field: 'FLG_ACCION', data: `'1'`, op: "=" });
    //}
    return rules;
}

function Microforma_actionVerCodigo(cellvalue, options, rowObject) {
    var _btn = rowObject[4];
    var _Revisiones = rowObject[10];
    if (_MICROMODULO == MicroModulo.Grabados || _MICROMODULO == MicroModulo.Conforme) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_GrabadaVer(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-vynil\" style=\"color:#a01010;font-size:15px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.Control) {
        _btn += "<button title='Ver Microforma' onclick='Microforma_ValidarMicroforma(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-clipboard\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.Reprocesar) {
        _btn += "<br/><button title='Ver Microforma' onclick='Microforma_EditarMicroforma(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-refresh\" style=\"color:;font-size:16px\"></i></button>";
        _btn += "<button title='Ver Observaciones' onclick='Microforma_VerObs(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-bubbles-3\" style=\"color:#a01010;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.CAlmacen) {
        _btn += "<button title='Ingresar Micro Archivo' onclick='Microforma_MantenimientoMicroArchivo(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-folder-upload\" style=\"color:##ec971f;font-size:16px\"></i></button>";
    } else if (_MICROMODULO == MicroModulo.CAlmacenFin) {
        _btn += "<button title='Ver MicroArchivo' onclick='Microforma_VerMicroArchivo(" + rowObject[0] + ");' class=\"btn btn-link\" type=\"button\" data-toggle=\"modal\" style=\"text-decoration: none !important;cursor: pointer;\" data-target='#myModal_Documento_Grabar'> <i class=\"clip-paste\" style=\"color:#a01010;font-size:16px\"></i></button>";
    }

    return _btn;
}

