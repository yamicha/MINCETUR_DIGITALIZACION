#pragma checksum "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e835ac5fe86df1e144a40a8fc50c83887541a807"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administracion_Views_Seccion_Mantenimiento), @"mvc.1.0.view", @"/Areas/Administracion/Views/Seccion/Mantenimiento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e835ac5fe86df1e144a40a8fc50c83887541a807", @"/Areas/Administracion/Views/Seccion/Mantenimiento.cshtml")]
    public class Areas_Administracion_Views_Seccion_Mantenimiento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models.SeccionModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n    if ($(\'#hd_SECCION_ACCION\').val() == \"M\")\r\n        SeccionLoadFormEdit(");
#nullable restore
#line 8 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                       Write(Model.ID_SECCION);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n    });\r\n    jQuery(\'#SECCION_BTNGRABAR\').click(function (e) {\r\n        Seccion_RegistrarDatos();\r\n    });\r\n</script>\r\n");
#nullable restore
#line 14 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
 using (Html.BeginForm("Proceso", "Seccion", new { @area = "Administracion" }, FormMethod.Post, false, new { @id = "frmMantenimientoSeccion", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialog"">
        <div class=""modal-content"" style=""width:100%;"">
            <div class=""modal-header"" style=""cursor: move; background-color: #530d0d;"">
                <button type=""button"" class=""close"" data-dismiss=""modal""><span aria-hidden=""true"">&times;</span><span class=""sr-only"">Close</span></button>
");
#nullable restore
#line 21 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                  
                    if (Model.ACCION == "N")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"modal-title\"><i class=\"clip-pencil\"></i> Nueva Sección</h4>\r\n");
#nullable restore
#line 25 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"modal-title\"><i class=\"clip-pencil\"></i> Mantenimiento  de Sección</h4>\r\n");
#nullable restore
#line 29 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"modal-body\">\r\n                <div class=\"row\">\r\n\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 36 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                   Write(Html.LabelFor(model => model.DESC_CORTA_SECCION, new { @class = "col-sm-3 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"col-sm-7\">\r\n                            ");
#nullable restore
#line 38 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                       Write(Html.TextBoxFor(model => model.DESC_CORTA_SECCION, new { @class = "form-control", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 39 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                       Write(Html.ValidationMessageFor(model => model.DESC_CORTA_SECCION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 43 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                   Write(Html.LabelFor(model => model.DESC_LARGA_SECCION, new { @class = "col-sm-3 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"col-sm-7\">\r\n                            ");
#nullable restore
#line 45 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                       Write(Html.TextBoxFor(model => model.DESC_LARGA_SECCION, new { @class = "form-control", @maxlength = "300" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 46 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                       Write(Html.ValidationMessageFor(model => model.DESC_LARGA_SECCION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>

                <div class=""modal-footer"">
                    <button id=""SECCION_BTNGRABAR"" class=""btn btn-blue"" type=""button"" data-toggle=""modal""><i class=""fa fa-save"" /> Grabar</button>
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""fa fa-share-square-o""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 58 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
Write(Html.Hidden("hd_SECCION_ACCION", Model.ACCION));

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
Write(Html.Hidden("hd_SECCION_ID_SECCION", Model.ID_SECCION));

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Seccion\Mantenimiento.cshtml"
                                                           
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models.SeccionModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
