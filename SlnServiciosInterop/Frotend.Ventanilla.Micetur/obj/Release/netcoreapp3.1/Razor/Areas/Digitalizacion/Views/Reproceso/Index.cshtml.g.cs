#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9662c1ad2b66ce83b0db98f153798b2132068924"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Reproceso_Index), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Reproceso/Index.cshtml")]
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
#line 1 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
using Frotend.Ventanilla.Micetur.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9662c1ad2b66ce83b0db98f153798b2132068924", @"/Areas/Digitalizacion/Views/Reproceso/Index.cshtml")]
    public class Areas_Digitalizacion_Views_Reproceso_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#nullable restore
#line 2 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
  
    ViewBag.Title = "Reproceso";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9662c1ad2b66ce83b0db98f153798b21320689244364", async() => {
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
            BeginWriteAttribute("src", " src=\"", 155, "\"", 199, 1);
#nullable restore
#line 6 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 161, Url.Content("~/Scripts/js/Remove.js"), 161, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 248, "\"", 312, 1);
#nullable restore
#line 7 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 254, Url.Content("~/Scripts/js/Microforma/Documento_Color.js"), 254, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 361, "\"", 426, 1);
#nullable restore
#line 8 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 367, Url.Content("~/Scripts/js/Microforma/DocumentoAdjunto.js"), 367, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 475, "\"", 533, 1);
#nullable restore
#line 9 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 481, Url.Content("~/Scripts/js/Microforma/Documento.js"), 481, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 582, "\"", 635, 1);
#nullable restore
#line 10 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 588, Url.Content("~/Scripts/js/Microforma/Lote.js"), 588, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 684, "\"", 743, 1);
#nullable restore
#line 11 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 690, Url.Content("~/Scripts/js/Microforma/Reprocesar.js"), 690, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n<script defer");
            BeginWriteAttribute("src", " src=\"", 792, "\"", 853, 1);
#nullable restore
#line 12 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 798, Url.Content("~/Scripts/js/Microforma/Reprocesados.js"), 798, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"text/javascript\"></script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9662c1ad2b66ce83b0db98f153798b21320689249228", async() => {
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
            WriteLiteral("\r\n<script>\r\n    var extensionValid =");
#nullable restore
#line 16 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
                   Write(AppSettings.FileValid);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    var IdLaserMin = ");
#nullable restore
#line 17 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
                Write(AppSettings.MinIdLaser);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    $(document).ready(function () {
        Remove_RemoverClases(""liReproceso"");
        //$(""#Reprocesar_btn_Fin"").hide();
    });

</script>
<div id=""Load_Busqueda"" hidden=""hidden"" class=""blockUI blockMsg blockPage"" style=""z-index: 1011; position: fixed; padding: 0px; margin: 0px; width: 30%; top: 40%; left: 35%; text-align: center; color: rgb(0, 0, 0); border: 3px solid rgb(170, 170, 170); background-color: rgb(255, 255, 255); cursor: wait;"">
    <h5>
        <img style=""height: 20px""");
            BeginWriteAttribute("src", " src=\"", 1555, "\"", 1604, 1);
#nullable restore
#line 26 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Reproceso\Index.cshtml"
WriteAttributeValue("", 1561, Url.Content("~/assets/images/loading.gif"), 1561, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
        Buscando registros...
    </h5>
</div>
<div class=""modal fade"" id=""myModalNuevo"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true""></div>
<div class=""modal fade"" id=""myModal_Documento_Ver_Imagen"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true""></div>
<div class=""tab-content"">
    <ul id=""myTab"" class=""nav nav-tabs tab-bricky"">
        <li class=""active"">
            <a data-toggle=""tab"" href=""#panel_tab_1"" id=""aTabReprocesar"">
                <i class=""green fa fa-home""></i>
                Pendientes de Reproceso
            </a>
        </li>
        <li");
            BeginWriteAttribute("class", " class=\"", 2249, "\"", 2257, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <a data-toggle=""tab"" href=""#panel_tab_2"" id=""aTabReprocesados"">
                Reprocesados
            </a>
        </li>
    </ul>

    <div id=""panel_tab_1"" class=""tab-pane active"">
        <div class=""col-sm-12 inline-container-Group"">
            <div class=""alert alert-info"">
                <p>Listado de documentos para su reproceso</p>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <fieldset style=""width:100%; display:block;  margin-left: 2px;margin-right: 2px;padding-top: 0.35em;padding-bottom: 0.625em;padding-left: 0.75em;padding-right: 0.75em;border: 1px groove;"">
                        <legend style=""font-size:small;display:block"">Iniciar Reproceso</legend>
                        <button id=""Reprocesar_btn_Iniciar"" title=""Iniciar reloj"" class=""btn btn-blue"" type=""button"" style=""margin-left:20px;margin-bottom:10px;""><i class=""clip-clock-2""></i> Reprocesar seleccionado</button>
");
            WriteLiteral(@"                    </fieldset>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""Reprocesar_jqGrid"">
                        <table id=""Reprocesar_grilla""></table>
                    </div>
                    <div id=""Reprocesar_barra""></div>
                </div>
            </div>
        </div>
    </div>

    <div id=""panel_tab_2"" class=""tab-pane"">
        <div class=""col-sm-12 inline-container-Group"">
            <div class=""alert alert-info"">
                <p>Listado de documentos reprocesados</p>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""Reprocesados_jqGrid"">
                        <table id=""Reprocesados_grilla""></table>
                    </div>
                    <div id=""Reprocesados_barra""></div>
                </div>
            </div>
        </div>
    </div>
</div>

");
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