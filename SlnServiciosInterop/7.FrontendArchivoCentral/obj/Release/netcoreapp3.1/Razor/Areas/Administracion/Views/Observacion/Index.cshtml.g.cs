#pragma checksum "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d85ecf8187ad0f7d8abdd52aba2a876dc995d34d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administracion_Views_Observacion_Index), @"mvc.1.0.view", @"/Areas/Administracion/Views/Observacion/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d85ecf8187ad0f7d8abdd52aba2a876dc995d34d", @"/Areas/Administracion/Views/Observacion/Index.cshtml")]
    public class Areas_Administracion_Views_Observacion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Index.cshtml"
  
    ViewBag.Title = "Observacion";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" type=\"text/css\"");
            BeginWriteAttribute("href", " href=\"", 81, "\"", 130, 1);
#nullable restore
#line 4 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Index.cshtml"
WriteAttributeValue("", 88, Url.Content("~/assets/Switch_Toggle.css"), 88, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<script");
            BeginWriteAttribute("src", " src=\"", 143, "\"", 187, 1);
#nullable restore
#line 5 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Index.cshtml"
WriteAttributeValue("", 149, Url.Content("~/Scripts/js/Remove.js"), 149, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" defer type=\"text/javascript\"></script>\r\n<script");
            BeginWriteAttribute("src", " src=\"", 236, "\"", 304, 1);
#nullable restore
#line 6 "C:\Users\Inmortal\Documents\GitHub\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Index.cshtml"
WriteAttributeValue("", 242, Url.Content("~/Scripts/js/Administracion/TipoObservacion.js"), 242, 62, false);

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
                        <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; margin-top: 5px; text-align: right;"">Descripción:</label>
                    </div>
                    <div class=""col-sm-3"">
                        <input type=""text"" id=""observacion_descripcion"" name=""observacion_descripcion"" maxlength=""150"" class=""form-control"" style=""width: 100%"" />
                   ");
            WriteLiteral(@" </div>

                    <div class=""col-sm-2"">
                        <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; margin-top: 5px; text-align: right;"">Estado:</label>
                    </div>
                    <div class=""col-sm-3"">
                        <select id=""ObservacionCboEstado"" class=""form-control"">
                            <option");
            BeginWriteAttribute("value", " value=\"", 1728, "\"", 1736, 0);
            EndWriteAttribute();
            WriteLiteral(@">--Seleccione--</option>
                            <option value=""1"">Activo</option>
                            <option value=""0"">Inactivo</option>
                        </select>
                    </div>
                    <div class=""col-sm-3"">
                        <button id=""observacion_btn_buscar"" class=""btn btn-blue"" type=""button""><i class=""clip-search""></i>&nbsp Buscar</button>
                        <button id=""observacion_btn_limpiar"" class=""btn btn-grey"" type=""button""><i class=""clip-undo""></i>&nbsp Limpiar</button>
                    </div>
                </div>
            </fieldset>
        </div>
        <div class=""row"">
            <br />
            <br />
            <div class=""col-sm-7"">
                <button id=""observacion_btn_nuevo"" class=""btn btn-red"" type=""button"" data-toggle=""modal"" data-target=""#myModalNuevo""><i class=""clip-file-plus""></i> Nueva Observación</button>
            </div>
            <div class=""col-sm-12"" style=""margin-top: 10px"">
   ");
            WriteLiteral("             <div class=\"Observacion_jqGrid\">\r\n                    <table id=\"Observacion_Grilla\"></table>\r\n                    <div id=\"Observacion_Barra\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
