//var BaseUrlApi = "http://intranetdesa.mincetur.gob.pe:8080/apisisgesdigarch/api/";
var BaseUrlApi = "http://localhost:21820/api/";
API = {
    Ajax: function (url, parameters, async, type) {
        var rsp;
        $.ajax({
            type: type,
            url: BaseUrlApi + url,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            async: async,
            data: parameters,
            success: function (response) {
                rsp = response;
            },
            failure: function (msg) {
                alert(msg);
                rsp = msg;
            },
            error: function (xhr, status, error) {
                alert(error);
                rsp = error;
            }
        });
        return rsp;
    },
    Fetch: function (type, url, paramters, calback) {
        fetchload.init();
        var request = new Request(BaseUrlApi + url, {
            method: type,
            body: JSON.stringify(paramters),
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'mode': 'no-cors'
            }
        });
        fetch(request)
            .then((resp) => resp.json())
            .then(function (data) {
                fetchload.close();
                calback(data);
            })
            .catch(function (error) {
                fetchload.close();
                alert("request error api: " + error.message);
            });
    },
    FetchGet: function (type, url, calback) {
        fetchload.init();
        var request = new Request(BaseUrlApi + url, {
            method: type,
            headers: new Headers(),
        });
        fetch(request)
            .then((resp) => resp.json())
            .then(function (data) {
                fetchload.close();
                calback(data);
            })
            .catch(function (error) {
                fetchload.close();
                alert("request error api: " + error.message);
            });
    },
    FetchPut: function (type, url, paramters, calback) {
        var requestOptions = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(paramters)
        };
        fetch(BaseUrlApi + url, requestOptions)
            .then(response => response.json())
            .then(data => alert(data));
    }
}

function DownloadFileApi(Url) {
    window.location = Url;
}

function ProcesarArchivo(input, filename) {
    var file = input.files[0];
    var nombre = "";
    $('#' + filename).text("");
    if (file != undefined) {
        var PesodeArchivo = parseFloat(file.size);
        var ext = input.files[0].name.split('.').pop();
        nombre = input.files[0].name;
        if (nombre.length > 100) {
            jAlert("El nombre del documento es muy largo", 'Atención');
            $(this).val('');
            return false;
        }
        else {
            var valido = false;
            if (ext.toLowerCase() == "pdf")
                valido = true;
            if (PesodeArchivo > Tamanio_Valido || !valido) {
                $(this).val('');
                if (!valido)
                    jAlert("Solo se permite documentos en formato PDF(.pdf", 'Atención');
                else
                    jAlert("La cantidad de el archivo que va adjuntar no pueden pesar más de " + Tamanio_Valido / 1024 / 1024 + "Mb", 'Atención');

                return false;
            } else {
                $('#' + filename).text(nombre);
                //PedidosGuardarArchivo(input, ID_DETALLE);
            }
        }
    }
}

function UploadFileService(formdata) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: baseUrl + "Base/UploadFileService",
            data: formdata,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (auditoria) {
                if (auditoria.ejecucionProceso) {
                    if (!auditoria.rechazo) {
                        resolve(auditoria.objeto);
                    } else {
                        console.log(auditoria.mensajeSalida, 'Atención');
                        resolve(0);
                    }
                } else {
                    resolve(0);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
                resolve(0);
            }
        });
    });
}

function DownloadFile(ID_DOC) {
    $.ajax({
        url: baseUrl + "Base/DownloadFileService?ID_DOC=" + ID_DOC,
        //data: item,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        type: 'GET',
        success: function (auditoria) {
            if (auditoria.ejecucionProceso) {
                if (!auditoria.rechazo) {
                    window.open(auditoria.objeto, "_blank");
                } else {
                    console.log(auditoria.mensajeSalida, 'Atención');
                }
            } else {
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status);
        }
    });
}

function LoadComboApi(Url, Input, Options) {
    return new Promise((resolve) => {
        var request = null;
        if (Options.method == "GET") {
            request = new Request(BaseUrlApi + Url, {
                method: "GET",
                headers: new Headers()
            });
        } if (Options.method == "POST") {
            request = new Request(BaseUrlApi + Url, {
                method: "POST",
                body: JSON.stringify(Options.paramters),
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': '*',
                    'mode': 'no-cors'
                }
            });
        }
        fetch(request)
            .then((resp) => resp.json())
            .then(function (data) {
                fetchload.close();
                if (data != null && data != "") {
                    if (data.EjecucionProceso) {
                        if (!data.Rechazo) {
                            if (data.Objeto != null) {
                                var Html = "";
                                var Combo = $('#' + Input);
                                $(Combo).html('').append('<option value="">--seleccione--</option>');
                                $.each(data.Objeto, function (x, v) {
                                    Html += `<option value=${eval('v.' + Options.KeyVal.value)}> ${eval('v.' + Options.KeyVal.name)} </option>`
                                });
                                $(Combo).append(Html);
                                resolve(true);
                            }
                        } else {
                            resolve(false);
                            jAlert(auditoria.MensajeSalida, "Atención");
                        }
                    }
                }
            })
            .catch(function (error) {
                fetchload.close();
                resolve(false);
                alert("request error api: " + error.message);
            });
    });
}