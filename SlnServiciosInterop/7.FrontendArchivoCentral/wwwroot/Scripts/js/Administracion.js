$(document).ready(function () {
    var menuResponsivo = $('#menuResponsivo').is(':visible');
    $("#lbNombreMenuSecundario").text("Gestión de Logs");
    $("#lbNombreOficinaPrincipal").text("Administración");

    RemoveClases();

    $("#liLog").addClass("active");
    CargaLogs();

    if (menuResponsivo) $("#menuResponsivo").click();

});


function CargaLogs() {

    $.ajax({
        url: baseUrl + "Administracion/Administracion/ListaLogs",
        type: 'POST',
        datatype: 'json',
        success: function (data) {
            if (data.length > 0) {
                var inf = data;
                var table = $('#logs').DataTable({
                    data: inf,
                    //"order": [[1, 'desc']],
                    "paging": true,
                    "select": true,
                    "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                        $('td:eq(0)', nRow).css("text-align", "center").css("width", "09");
                        $('td:eq(1)', nRow).css("text-align", "center");
                        $('td:eq(2)', nRow).css("text-align", "center");
                        $('td:eq(3)', nRow).css("text-align", "center");
                        return nRow;
                    },
                    "language": { "url": baseUrl + "assets/js/Spanish.json" },
                    "lengthMenu": [[20, 50, 100, -1], [20, 50, 100, "Todo"]],
                    "destroy": true,
                    "columns": [
                        { "data": "Id" },
                        { "data": "NombreArchivo" },
                        { "data": "Tamanio" },
                        {
                            "data": null,
                            render: function (data, type, full, meta) {
                                var botones = "";
                                var archivo = full.NombreArchivo.substring(5, 13);
                                botones = "<a class=\"green \" href='#' onclick=\"fn_DescargarLog(" + archivo + ")\" title='Descargar Log'><i class='clip-download' style='font-size: 16px; color:#87B87F'></i></a> ";
                                return botones;
                            }
                        }
                    ]

                });
            }
            else {
                var table = $('#tblListadoEmpadrona').DataTable({
                    "language": { "url": baseUrl + "assets/js/Spanish.json" },
                    destroy: true
                });
                table.clear().draw();
            }
        }
    });
}

function fn_DescargarLog(ArchivoLog) {
    window.location = baseUrl + 'Administracion/Administracion/DownloadLog?Archivo=' + ArchivoLog;
}

function RemoveClases() {
    //para el Icono de la opciones de MENU
    $("#liConvocatoria").removeClass("active");
    $("#liEvaluacion").removeClass("active");
    $("#liPreguntas").removeClass("active");
    $("#liPersonal").removeClass("active");
    $("#liPanel").removeClass("active");
}

function ConfigurarGrillaLogs(ancho, alto) {
    $.jgrid.gridUnload("#tableLogs");
    var colNames = ['Archivo', 'Tamaño', 'Acciones'];
    var colModels = [
        { name: 'NOMBREARCHIVO', index: 'NOMBREARCHIVO', width: 600, hidden: false, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;' } },
        { name: 'TAMANIO', index: 'TAMANIO', align: 'center', width: 150, hidden: false },
        { name: 'BTNACCION', index: 'BTNACCION', align: 'center', width: 120, formatter: BtnAccion }
    ];
    var opciones = {
        GridLocal: true, multiselect: false, CellEdit: false, Editar: false, nuevo: false, eliminar: false, search: false, sort: 'asc', grouping: false,
        rowNumber: 30, rowNumbers: [30, 60, 90, 120]
    };

    SITRADOC.Grilla("tableLogs", 'divLogs', '', 500, ancho, "Listado de Archivos Log del Sistema", '', 'NOMBREARCHIVO', colNames, colModels, 'NOMBREARCHIVO', opciones);
    jqGridResponsive($(".jqGridLogs"));
}

function BtnAccion(cellvalue, options, rowObject) {
    var html = ""

    html = '<button  class="btn btn-link"  onclick="fn_editar(' + rowObject.NOMBREARCHIVO + ');" type="button"  id="btn-prg' + options.rowId + '"  title="Descargar Archivo"><i class="clip-download" style="color:green; font-size: 16px;"></i></button>';
    return html;
}
