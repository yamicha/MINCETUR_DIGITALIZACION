#pragma checksum "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbc25d6a9fc38c1dc29eb18b9cc33762c70b5807"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administracion_Views_Seccion_Index), @"mvc.1.0.view", @"/Areas/Administracion/Views/Seccion/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbc25d6a9fc38c1dc29eb18b9cc33762c70b5807", @"/Areas/Administracion/Views/Seccion/Index.cshtml")]
    public class Areas_Administracion_Views_Seccion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Index.cshtml"
  
    ViewBag.Title = "Secciones";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" type=\"text/css\"");
            BeginWriteAttribute("href", " href=\"", 79, "\"", 128, 1);
#nullable restore
#line 4 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Index.cshtml"
WriteAttributeValue("", 86, Url.Content("~/assets/Switch_Toggle.css"), 86, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n<script");
            BeginWriteAttribute("src", "  src=\"", 140, "\"", 185, 1);
#nullable restore
#line 5 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Index.cshtml"
WriteAttributeValue("", 147, Url.Content("~/Scripts/js/Remove.js"), 147, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" defer type=\"text/javascript\"></script>\r\n<script");
            BeginWriteAttribute("src", "  src=\"", 234, "\"", 295, 1);
#nullable restore
#line 6 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Index.cshtml"
WriteAttributeValue("", 241, Url.Content("~/Scripts/js/Administracion/Seccion.js"), 241, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" defer type=""text/javascript""></script>
<div class=""modal fade"" id=""myModalNuevo"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true""></div>
<div class=""tab-content"">
    <div id=""panel_tab_directorio"" class=""tab-pane active"">
        <div class=""col-sm-12 inline-container-Group"" style="" margin-bottom: 10px;"">
            <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Criterios de búsqueda: </p>
            <fieldset style=""width: 100%;"">
                <div class=""row"">
                    <div class=""col-sm-2"">
                        <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; margin-top: 5px; text-align: right;"">Descripción Larga:</label>
                    </div>
                    <div class=""col-sm-3"">
                        <input type=""text"" id=""SECCION_DESCRIPCION"" name=""SECCION_DESCRIPCION"" maxlength=""150"" class=""form-control"" style=""width: 100%"" />
                    </d");
            WriteLiteral(@"iv>
                    <div class=""col-sm-3"">
                        <button id=""SECCION_BTN_BUSCAR"" class=""btn btn-blue"" type=""button""><i class=""clip-search""></i>&nbsp Buscar</button>
                        <button id=""SECCION_BTN_LIMPIAR"" class=""btn btn-grey"" type=""button""><i class=""clip-undo""></i>&nbsp Limpiar</button>
                    </div>
                </div>
            </fieldset>
        </div>
        <div class=""row"">
            <br />
            <br />
            <div class=""col-sm-7"">
                <button id=""SECCION_BTN_NUEVO"" class=""btn btn-red"" type=""button"" data-toggle=""modal"" data-target=""#myModalNuevo""><i class=""clip-file-plus""></i> Nueva Sección</button>
            </div>
            <div class=""col-sm-12"" style=""margin-top: 10px"">
                <div class=""Seccion_jqGrid"">
                    <table id=""Seccion_grilla""></table>
                    <div id=""Seccion_barra""></div>
                </div>
            </div>
        </div>
    </div>
</di");
            WriteLiteral("v>\r\n");
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
