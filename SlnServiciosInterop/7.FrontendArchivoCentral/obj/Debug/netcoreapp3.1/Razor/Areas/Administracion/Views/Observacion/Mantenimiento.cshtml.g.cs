#pragma checksum "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afd55707dd12ac52b2bbd0ade326c18adbb89bf8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administracion_Views_Observacion_Mantenimiento), @"mvc.1.0.view", @"/Areas/Administracion/Views/Observacion/Mantenimiento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afd55707dd12ac52b2bbd0ade326c18adbb89bf8", @"/Areas/Administracion/Views/Observacion/Mantenimiento.cshtml")]
    public class Areas_Administracion_Views_Observacion_Mantenimiento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models.ObservacionModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\">\r\n    jQuery(\'#observacion_btn_grabar\').click(function (e) {\r\n        Observacion_RegistrarDatos();\r\n    });\r\n</script>\r\n");
#nullable restore
#line 10 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
 using (Html.BeginForm("Proceso", "Observacion", new { @area = "Administracion" }, FormMethod.Post, false, new { @id = "frmMantenimientoObservacion", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
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
#line 17 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                  
                    if (Model.ACCION == "N")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"modal-title\"><i class=\"clip-pencil\"></i> Nueva Observacion</h4>\r\n");
#nullable restore
#line 21 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"modal-title\"><i class=\"clip-pencil\"></i> Mantenimiento  de Observacion</h4>\r\n");
#nullable restore
#line 25 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"modal-body\">\r\n                <div class=\"row\">\r\n\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                   Write(Html.LabelFor(model => model.DESC_OBSERVACION, new { @class = "col-sm-3 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"col-sm-7\">\r\n                            ");
#nullable restore
#line 34 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                       Write(Html.TextBoxFor(model => model.DESC_OBSERVACION, new { @class = "form-control", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 35 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                       Write(Html.ValidationMessageFor(model => model.DESC_OBSERVACION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>

                <div class=""modal-footer"">
                    <button id=""observacion_btn_grabar"" class=""btn btn-blue"" type=""button"" data-toggle=""modal""><i class=""fa fa-save"" /> Grabar</button>
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""fa fa-share-square-o""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 47 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
Write(Html.Hidden("hd_OBSERVACION_ACCION", Model.ACCION));

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
Write(Html.Hidden("hd_OBSERVACION_ID_OBSERVACION", Model.ID_OBSERVACION));

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Administracion\Views\Observacion\Mantenimiento.cshtml"
                                                                       
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models.ObservacionModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
