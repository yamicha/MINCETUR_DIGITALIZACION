
var Login = function () {
    var a = function () {
        var a = $(".box-login");
        if (f("box").length)
            switch (f("box")) {
                case "register": a = $(".box-register");
                    break;
                case "forgot": a = $(".box-forgot");
                    break;
                default:
                    a = $(".box-login")
            }
        a.show()
    },

    b = function () {
        $.validator.setDefaults({
            errorElement: "span",
            errorClass: "help-block",
            errorPlacement: function (a, b) {
                "radio" == b.attr("type") || "checkbox" == b.attr("type")
                            ? a.insertAfter($(b).closest(".form-group").children("div").children().last())
                            : "card_expiry_mm" == b.attr("name") || "card_expiry_yyyy" == b.attr("name") ? a.appendTo($(b).closest(".form-group").children("div")) : a.insertAfter(b)
            },
            ignore: ":hidden",
            highlight: function (a) {
                $(a).closest(".help-block").removeClass("valid"),
                $(a).closest(".form-group").removeClass("has-success").addClass("has-error").find(".symbol").removeClass("ok").addClass("required")
            },
            unhighlight: function (a) {
                $(a).closest(".form-group").removeClass("has-error")
            },
            success: function (a, b) {
                a.addClass("help-block valid"),
                $(b).closest(".form-group").removeClass("has-error")
            },
            highlight: function (a) {
                $(a).closest(".help-block").removeClass("valid"),
                $(a).closest(".form-group").addClass("has-error")
            },
            unhighlight: function (a) {
                $(a).closest(".form-group").removeClass("has-error")
            }
        })
    },

    c = function () {
        var a = $(".form-login"),
            b = $(".errorHandler", a);
        a.validate({
            rules: {
                username: {
                    minlength: 4,
                    maxlength: 50,
                    required: !0
                },
                password: {
                    maxlength: 20
                }
            },
            messages: {
                username: {
                    required: "[Nombre de usuario] es obligatorio"
                }
            },
            submitHandler: function (a) {
                b.hide(),
                g(a[1].value, a[2].value, b)
            },
            invalidHandler: function (a, c) {
                //b.show()
            }
        })
    },

    d = function () {
        var a = $(".form-forgot"),
            b = $(".errorHandler", a);

        a.validate({
            rules: {
                email: {
                    required: !0
                }
            },
            submitHandler: function (c) {
                b.hide()
            },
            invalidHandler: function (a, c) {
                b.show()
            }
        })
    },

    e = function () {
        var a = $(".form-register"),
            b = $(".errorHandler", a);
        a.validate({
            rules: {
                full_name: {
                    minlength: 2,
                    required: !0
                },
                address: {
                    minlength: 2, required: !0
                },
                city: {
                    minlength: 2, required: !0
                },
                gender: {
                    required: !0
                },
                email: {
                    required: !0
                },
                password: {
                    minlength: 6, required: !0
                },
                password_again: {
                    required: !0,
                    minlength: 5,
                    equalTo: "#password"
                },
                agree: {
                    minlength: 1,
                    required: !0
                }
            },
            submitHandler: function (c) {
                b.hide()
            },
            invalidHandler: function (a, c) {
                b.show()
            }
        })
    },

    f = function (a) {
        a = a.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var b = new RegExp("[\\?&]" + a + "=([^&#]*)"),
            c = b.exec(location.search);
        return null == c ? "" : decodeURIComponent(c[1].replace(/\+/g, " "))
    },

    g = function (_u, _p, _b) { 
        if (MiLogin.length == 0)
            b.show();
        else
            window.location = baseUrl + "Home/Index?ID_USUARIO=" + MiLogin[0].ID_USUARIO + "&ID_OFICINA=" + MiLogin[0].ID_OFICINA + "&DESC_USU=" + MiLogin[0].COD_USUARIO + "&NOM_USU=" + MiLogin[0].NOMBRE_USUARIO + "&NOM_OFI=" + MiLogin[0].DESC_OFICINA;

    },

    h = function () {
        var a = $("#i_username");
        a.autocomplete(
                     {
                         source: function (request, response) {
                             $.getJSON(baseUrl + 'Firma/DocumentoUsuario/Usuario_Listar',
                                 { NOMBRES: request.term.toUpperCase(), ID_OFICINA: $("#i_cbooficina").val() }, response);
                         },
                         minLength: 4,
                         select: function (event, ui) {
                             MiLogin = new Array();
                             a.val(ui.item.NOMBRE_USUARIO);
                             MiLogin.push(ui.item);
                             return false;
                         },
                         response: function (event, ui) {
                             return false;
                         }
                     }).data("autocomplete")._renderItem = function (ul, item) {
                         
                         return $("<li></li>").data("item.autocomplete", item).append($("<a></a>").html(item.NOMBRE_USUARIO)).appendTo(ul);
                     };
    },
    i = function () {
        var item =
            {
                DESC_OFICINA: ''
            };
        var url = baseUrl + 'Firma/Oficinas/Oficinas_Listar';
        var respuesta = SICA.Ajax(url, item, false);
        if (respuesta != null && respuesta != "") {
            var items = "<select class=\"form-control\" id=\"i_cbooficina\" name=\"i_cbooficina\">";
            items += "<option value=\"" + "" + "\"> --Seleccione-- </option>";
            $.each(respuesta, function (i, v) {
                items += "<option value=\"" + v.ID_OFICINA + "\" > " + v.DESC_OFICINA + " </option>";
            });
            items += "</select>";
            $("#i_cbooficina").html(items);
        } else {
            var items = "<option value=\"" + "" + "\"> --Seleccione-- </option>";
            $("#i_cbooficina").html(items);
        }
    };

    return {
        init: function () {
            a(), b(), c(), d(), e(), h(), i()
        }
    }
}();