#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dab04e515701b29a9ae451b6771edbe3bb97666"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Documento_Documento_Validar_Imagen), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Documento/Documento_Validar_Imagen.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dab04e515701b29a9ae451b6771edbe3bb97666", @"/Areas/Digitalizacion/Views/Documento/Documento_Validar_Imagen.cshtml")]
    public class Areas_Digitalizacion_Views_Documento_Documento_Validar_Imagen : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.DocumentoValidarModelView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/Microforma/Formato.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/Microforma/Modals.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1dab04e515701b29a9ae451b6771edbe3bb976664269", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1dab04e515701b29a9ae451b6771edbe3bb976665383", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        Documento_EditValidarImagen();\r\n        DocumentoAdjuntos_ConfigurarGrilla();\r\n        DocumentoAdjuntos_CargarGrilla(");
#nullable restore
#line 12 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                  Write(Model.ID_DOCUMENTO);

#line default
#line hidden
#nullable disable
            WriteLiteral(@");
    });
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
            $(""#"" + lblObject).html(""Nº Caracteres: "" + cant + "" restan "" + total);
        } catch (e) {
            alert(e.Message);
        }
    }
    jQuery('#Documento_Validar_btn_Evaluar').click(function (e) {
        Aprobar_Evaluar();
    });
    jQuery('#VALIDAR_ID_CONFORME').change(function (e) {
        var VALIDAR_ID_CONFORME = $(""#VALIDAR_ID_CONFORME"").val();
        if (VALIDAR_ID_CONFORME == 1) {
            $(""#VALIDAR_ID_TIPO_OBS"").val('');
            $(""#Validar_Div_IDTIPO"").hide();
        } else {
            $(""#Validar_Div_IDTIPO"").show();
        }");
            WriteLiteral("\r\n    });\r\n    $(\'.modal-dialogValidar\').draggable({\r\n        handle: \".modal-header\",\r\n        cursor: \"handler\"\r\n    });\r\n</script>\r\n");
#nullable restore
#line 46 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
  
    var htmlLarge = new Dictionary<string, object> { { "style", "width:300px; font-family:verdana; font-size:.8em" } };
    var htmlShort = new Dictionary<string, object> { { "style", "width:100px; font-family:verdana; font-size:.8em" } };

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @class = "form-horizontal", @Role = "dialog" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-lg"" style=""margin:50px auto;"">
        <div class=""modal-content"">
            <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
                <div class=""col-sm-14"">
                    <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">× </button>
                    <h4 class=""modal-title""><i class='clip-pictures'></i>&nbsp; Validar Expediente digitalizada </h4>
                </div>
            </div>
            <div class=""modal-body"">
                <fieldset style=""width: 100%;"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""col-sm-12 inline-container-Group"" style=""margin-bottom:15px"">
                                <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 10px; margin-top: -5px"">Datos del expediente: </p>
                                <div class=""form-group row"">
                                 ");
            WriteLiteral("   <label class=\"col-sm-2 col-form-label\" style=\"text-align:right\"><strong>Nº Expediente:</strong> </label>\r\n                                    <div class=\"col-sm-4\">\r\n                                        <span>");
#nullable restore
#line 70 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.ID_DOCUMENTO);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Tipo Doc.:</strong> </label>
                                    <div class=""col-sm-4"">
                                        <span>");
#nullable restore
#line 74 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.DES_TIP_DOC);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                </div>
                                <div class=""form-group row"">
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Nro. Doc:</strong> </label>
                                    <div class=""col-sm-4"">
                                        <span>");
#nullable restore
#line 80 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.NUM_DOC);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Folios:</strong> </label>
                                    <div class=""col-sm-4"">
                                        <span>");
#nullable restore
#line 84 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.NUM_FOLIOS);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                </div>
                                <div class=""form-group row"">
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Clasificación:</strong> </label>
                                    <div class=""col-sm-4"">
                                        <span>");
#nullable restore
#line 90 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.DES_CLASIF);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Persona:</strong> </label>
                                    <div class=""col-sm-4"">
                                        <span>");
#nullable restore
#line 94 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.DES_PERSONA);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                </div>
                                <div class=""form-group row"">
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Asunto:</strong> </label>
                                    <div class=""col-sm-10"">
                                        <span>");
#nullable restore
#line 100 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.DES_ASUNTO);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                </div>
                                <div class=""form-group row"">
                                    <label class=""col-sm-2 col-form-label"" style=""text-align:right""><strong>Observación:</strong> </label>
                                    <div class=""col-sm-10"">
                                        <span>");
#nullable restore
#line 106 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                         Write(Model.DES_OBS);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                </div>
                                <div class=""Documento_jqGrid"" >
                                    <table id=""DocumentoAdjunto_grilla""></table>
                                    <div id=""DocumentoAdjunto_barra""></div>
                                </div>
                            </div>
                            <div class=""col-sm-12 inline-container-Group"">
                                <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Evaluar: </p>
                                <fieldset style=""width: 100%;"">
                                    <div class=""row"">
                                        <div class=""col-sm-2"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Conforme ?</label>
                                        </div>
                     ");
            WriteLiteral("                   <div class=\"col-sm-6\">\r\n                                            ");
#nullable restore
#line 122 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                       Write(Html.DropDownListFor(model => model.VALIDAR_ID_CONFORME, Model.Lista_VALIDAR_ID_CONFORME, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"" id=""Validar_Div_IDTIPO"">
                                        <div class=""col-sm-2"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Tipo:</label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 130 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                       Write(Html.DropDownListFor(model => model.VALIDAR_ID_TIPO_OBS, Model.Lista_VALIDAR_ID_TIPO_OBS, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-2"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Comentario:</label>
                                        </div>
                                        <div class=""col-sm-10"">
                                            ");
#nullable restore
#line 138 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                       Write(Html.TextAreaFor(model => model.VALIDAR_OBSERVACION, new { @class = "form-control", @maxlength = "3000", @style = "height:90px;resize: none;text-transform: uppercase;", onkeyup = "CountCharactersControlTxt(this.id,'Documento_Validar_lbl4', 3000)" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <label id=\"Documento_Validar_lbl4\" style=\"width: 100%\" class=\"Formato\" runat=\"server\"");
            BeginWriteAttribute("text", " text=\"", 8719, "\"", 8726, 0);
            EndWriteAttribute();
            WriteLiteral("></label>\r\n                                        </div>\r\n                                    </div>\r\n");
            WriteLiteral(@"                                </fieldset>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class=""modal-footer"">
                    <button type=""button"" id=""Documento_Validar_btn_Evaluar"" class=""btn btn-blue""><i class=""fa fa-save""></i> Grabar Evaluación</button>
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""clip-close-4""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 162 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
Write(Html.Hidden("hd_Documento_Validar_ID_DOCUMENTO", Model.ID_DOCUMENTO));

#line default
#line hidden
#nullable disable
#nullable restore
#line 163 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
Write(Html.Hidden("hd_Documento_Validar_ID_DOCUMENTO_ASIGNADO", Model.ID_DOCUMENTO_ASIGNADO));

#line default
#line hidden
#nullable disable
#nullable restore
#line 163 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Documento\Documento_Validar_Imagen.cshtml"
                                                                                           
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.DocumentoValidarModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
