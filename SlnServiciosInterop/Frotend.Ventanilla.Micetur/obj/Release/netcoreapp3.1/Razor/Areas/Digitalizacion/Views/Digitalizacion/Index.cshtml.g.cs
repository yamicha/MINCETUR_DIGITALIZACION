#pragma checksum "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e814b0091c8b7cfdc65a6d312ab01ea3f6265a7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Digitalizacion_Index), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Digitalizacion/Index.cshtml")]
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
#nullable restore
#line 2 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
using Frotend.Ventanilla.Micetur.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e814b0091c8b7cfdc65a6d312ab01ea3f6265a7a", @"/Areas/Digitalizacion/Views/Digitalizacion/Index.cshtml")]
    public class Areas_Digitalizacion_Views_Digitalizacion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/Grilla.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/Leyenda.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
  
    ViewBag.Title = "Digitalización";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e814b0091c8b7cfdc65a6d312ab01ea3f6265a7a4406", async() => {
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
            WriteLiteral("\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 162, "\"", 206, 1);
#nullable restore
#line 7 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 168, Url.Content("~/Scripts/js/Remove.js"), 168, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 255, "\"", 319, 1);
#nullable restore
#line 8 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 261, Url.Content("~/Scripts/js/Microforma/Documento_Color.js"), 261, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 368, "\"", 433, 1);
#nullable restore
#line 9 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 374, Url.Content("~/Scripts/js/Microforma/DocumentoAdjunto.js"), 374, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 482, "\"", 540, 1);
#nullable restore
#line 10 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 488, Url.Content("~/Scripts/js/Microforma/Documento.js"), 488, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 589, "\"", 654, 1);
#nullable restore
#line 11 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 595, Url.Content("~/Scripts/js/Microforma/DocumentoProceso.js"), 595, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 703, "\"", 756, 1);
#nullable restore
#line 12 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 709, Url.Content("~/Scripts/js/Microforma/Lote.js"), 709, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 805, "\"", 865, 1);
#nullable restore
#line 13 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 811, Url.Content("~/Scripts/js/Microforma/Digitalizar.js"), 811, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 914, "\"", 976, 1);
#nullable restore
#line 14 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 920, Url.Content("~/Scripts/js/Microforma/Digitalizados.js"), 920, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e814b0091c8b7cfdc65a6d312ab01ea3f6265a7a9768", async() => {
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
            WriteLiteral("\r\n<script defer type=\"text/javascript\">\r\n    var Ruta_Visor_LF = $(\'#HD_RUTA_VISOR\').val();\r\n    var IdLaserMin = ");
#nullable restore
#line 19 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
                Write(AppSettings.MinIdLaser);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"; 
    $(document).ready(function () {
        Remove_RemoverClases(""liDigitalizacion"");
        $(""#Digitalizar_btn_Fin"").hide();
        $(""#Digitalizar_btn_Cancelar"").hide();
        $('#txtfechafin,#txtfechainicio').datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: ""dd/mm/yy"",
            firstDay: 1,
            changeFirstDay: false,
            placeholder: ""dd/MM/yyyy"",
        }).datepicker(""setDate"", 'now');
        $('#btnDigitalizadosBuscar').click(Digitalizados_buscar); 
    });

</script>

<div id=""Load_Busqueda"" hidden=""hidden"" class=""blockUI blockMsg blockPage"" style=""z-index: 1011; position: fixed; padding: 0px; margin: 0px; width: 30%; top: 40%; left: 35%; text-align: center; color: rgb(0, 0, 0); border: 3px solid rgb(170, 170, 170); background-color: rgb(255, 255, 255); cursor: wait;"">
    <h5>
        <img style=""height: 20px""");
            BeginWriteAttribute("src", " src=\"", 2134, "\"", 2183, 1);
#nullable restore
#line 39 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
WriteAttributeValue("", 2140, Url.Content("~/assets/images/loading.gif"), 2140, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
        Buscando registros...
    </h5>
</div>

<div class=""modal fade"" id=""myModalReporte"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true""></div>
<div class=""modal fade"" id=""myModal_Documento_Ver_Imagen"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true""></div>
<div class=""modal fade"" id=""myModal_Recibir_Doc"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true""></div>

<div class=""tab-content"">
    <ul id=""myTab"" class=""nav nav-tabs tab-bricky"">
        <li class=""active"">
            <a data-toggle=""tab"" href=""#panel_tab_1"" id=""aTabDigitalizar"">
                <i class=""green fa fa-home""></i>
                Pendientes por Digitalizar
            </a>
        </li>
        <li");
            BeginWriteAttribute("class", " class=\"", 2973, "\"", 2981, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <a data-toggle=""tab"" href=""#panel_tab_2"" id=""aTabDigitalizados"">
                Digitalizados
            </a>
        </li>
    </ul>

    <div id=""panel_tab_1"" class=""tab-pane active"">
        <div class=""col-sm-12 inline-container-Group"">
            <div class=""alert alert-info"">
                <p>Listado de documentos para su digitalización</p>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <fieldset style=""width:100%; display:block;  margin-left: 2px;margin-right: 2px;padding-top: 0.35em;padding-bottom: 0.625em;padding-left: 0.75em;padding-right: 0.75em;border: 1px groove;"">
                        <legend style=""font-size:small;display:block"">Iniciar Digitalización</legend>
                        <button id=""Digitalizar_btn_Iniciar"" title=""Iniciar reloj"" class=""btn btn-blue"" type=""button"" style=""margin-left:20px;margin-bottom:10px;""><i class=""clip-clock-2""></i> Iniciar</button>
                        <butto");
            WriteLiteral(@"n id=""Digitalizar_btn_Fin"" title=""Detener reloj y finalizar la digitalización"" class=""btn btn-blue"" type=""button"" style=""margin-right:6px;margin-left:6px;margin-bottom:10px;""><i class=""clip-stopwatch""></i> Finalizar</button>
                        <button id=""Digitalizar_btn_Cancelar"" title=""Detener reloj y cancelar la digitalización"" class=""btn btn-red"" type=""button"" style=""margin-right:6px;margin-left:6px;margin-bottom:10px;""><i class=""clip-cancel-circle""></i> Cancelar</button>
                        <label id=""Digitalizar_lbl_Crono"" style=""text-align:center;margin-right:6px;margin-left:6px;color:red;font-size:large;"">00:00:00</label>
");
            WriteLiteral(@"                    </fieldset>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""Digitalizar_jqGrid"">
                        <table id=""Digitalizar_grilla""></table>
                    </div>
                    <div id=""Digitalizar_barra""></div>
                </div>
            </div>
        </div>
    </div>

    <div id=""panel_tab_2"" class=""tab-pane"">
        <div class=""col-sm-12 inline-container-Group"">
            <div class=""alert alert-info"">
                <p>Listado de documentos digitalizados</p>
            </div>
            <div class=""col-sm-12 inline-container-Group"" style=""margin-bottom:5px;"">
                <fieldset style=""width:100%; display:block;  margin-left: 2px;margin-right: 2px;padding-top: 0.35em;padding-bottom: 0.625em;padding-left: 0.75em;padding-right: 0.75em;border: 1px groove;"">
                    <legend style=""font-size:small;display:block"">Busqueda:</leg");
            WriteLiteral(@"end>
                    <div class=""col-sm-3"">
                        <label>Fecha inicio :</label>
                        <input class=""form-control"" id=""txtfechainicio"" type=""text"" maxlength=""13"" readonly style=""background:white"">
                    </div>
                    <div class=""col-sm-3"">
                        <label>Fecha fin :</label>
                        <input class=""form-control"" id=""txtfechafin"" name=""txtfechafin"" type=""text"" maxlength=""13"" readonly style=""background:white"">
                    </div>
                    <div class=""col-sm-3"">
                        <label></label><br />
                        <button id=""btnDigitalizadosBuscar"" class=""btn btn-blue"" type=""button""><i class=""clip-search""></i>&nbsp Buscar</button>
                    </div>
                </fieldset>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""Digitalizados_jqGrid"">
                        <table id=""Digit");
            WriteLiteral("alizados_grilla\"></table>\r\n                    </div>\r\n                    <div id=\"Digitalizados_barra\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 127 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Digitalizacion\Index.cshtml"
Write(Html.Hidden("hdfFlag", "0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
