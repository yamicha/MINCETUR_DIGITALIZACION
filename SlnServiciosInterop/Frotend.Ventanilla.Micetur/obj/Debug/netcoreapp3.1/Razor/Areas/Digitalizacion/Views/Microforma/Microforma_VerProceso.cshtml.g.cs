#pragma checksum "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Microforma\Microforma_VerProceso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbe0ec077544da8d3de90c470dbdcb7fc1cac82b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Microforma_Microforma_VerProceso), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Microforma/Microforma_VerProceso.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbe0ec077544da8d3de90c470dbdcb7fc1cac82b", @"/Areas/Digitalizacion/Views/Microforma/Microforma_VerProceso.cshtml")]
    public class Areas_Digitalizacion_Views_Microforma_Microforma_VerProceso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/Microforma/Modals.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Microforma\Microforma_VerProceso.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbe0ec077544da8d3de90c470dbdcb7fc1cac82b3878", async() => {
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
            WriteLiteral(@"
<script type=""text/javascript"">

    $(document).ready(function () {
        Microforma_ProcesoConfigurarGrilla('Microforma_Procesogrilla', 'Microforma_Procesobarra');
        Microforma_ProcesoCargarGrilla('Microforma_Procesogrilla');
    });

    $('.modal-dialogDocObs').draggable({
        handle: "".modal-header"",
        cursor: ""handler""
    });

</script>
");
#nullable restore
#line 19 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Microforma\Microforma_VerProceso.cshtml"
  
    var htmlLarge = new Dictionary<string, object> { { "style", "width:300px; font-family:verdana; font-size:.8em" } };
    var htmlShort = new Dictionary<string, object> { { "style", "width:100px; font-family:verdana; font-size:.8em" } };

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal-dialogDocObs"" style=""width:800px;"">
    <div class=""modal-content"" style=""width:100%;"">
        <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
            <div class=""col-sm-14"">
                <button class=""close"" aria-hidden=""true"" type=""button"" data-dismiss=""modal"">× </button>
                <h4 class=""modal-title""><i class='clip-tree'></i>&nbsp; Listado de Proceso</h4>
            </div>
        </div>
        <div class=""modal-body"">
            <fieldset style=""width: 100%;"">
                <div class=""row"">
                    <div class=""col-sm-12"">
                        <div class=""jqGrid"">
                            <table id=""Microforma_Procesogrilla"">
                            </table>
                            <div id=""Microforma_Procesobarra""></div>
                        </div>
                    </div>
                </div>
            </fieldset>
            <div class=""modal-footer"">
                <button type");
            WriteLiteral("=\"button\" class=\"btn btn-light-grey\" data-dismiss=\"modal\"><i class=\"clip-close-4\"></i> Cerrar</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
#nullable restore
#line 48 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Microforma\Microforma_VerProceso.cshtml"
Write(Html.Hidden("hd_ID_MICROFORMA", Model.ID_MICROFORMA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
