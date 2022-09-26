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
                'Content-Type': 'application/json'
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
                alert("request error api", error);
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