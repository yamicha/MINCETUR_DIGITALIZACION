var BaseUrlApi = "http://localhost:21820/api/";

//var appConfig = {
//    IdlaserMin: '@AppSettingsHelper.MinIdLaser',

//}

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
                'Content-Type': 'application/json'
            }
        });
        fetch(request)
            .then((resp) => resp.json() )
            .then(function (data) {
                fetchload.close();
                calback(data);
            })
            .catch(function (error) {
                fetchload.close();
                alert("request error api: "+ error.message);
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
                alert("request error api", error);
            });
    },
    FetchPut: function (type, url, paramters, calback) {
        var requestOptions = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                //'Authorization': 'Bearer my-token',
                //'My-Custom-Header': 'foobar'
            },
            body: JSON.stringify(paramters)
        };
        fetch(BaseUrlApi+url, requestOptions)
            .then(response => response.json())
            .then(data => alert(data));
    }


}

function DownloadFile(Url) {
    window.location = Url;
}

function ProcesarArchivo(input, filename) {
    debugger; 
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