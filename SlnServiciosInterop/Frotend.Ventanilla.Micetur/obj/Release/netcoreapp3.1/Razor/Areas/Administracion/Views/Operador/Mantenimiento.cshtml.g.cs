#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b20d3f89a7e7ad7f465c288366492fe5d71539b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administracion_Views_Operador_Mantenimiento), @"mvc.1.0.view", @"/Areas/Administracion/Views/Operador/Mantenimiento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b20d3f89a7e7ad7f465c288366492fe5d71539b2", @"/Areas/Administracion/Views/Operador/Mantenimiento.cshtml")]
    public class Areas_Administracion_Views_Operador_Mantenimiento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.Ventanilla.Micetur.Areas.Administracion.Models.OperadorModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
     Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        Operador_Usuarios();\r\n        $(\'#OPERADOR\').select2();\r\n    });\r\n    jQuery(\'#fondo_btn_grabar\').click(function (e) {\r\n        Operador_RegistrarDatos();\r\n    });\r\n</script>\r\n");
#nullable restore
#line 12 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
 using (Html.BeginForm("Proceso", "Operador", new { @area = "Administracion" }, FormMethod.Post, false, new { @id = "frmMantenimientoOperador", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"" style=""cursor: move; background-color: #530d0d;"">
                <button type=""button"" class=""close"" data-dismiss=""modal""><span aria-hidden=""true"">&times;</span><span class=""sr-only"">Close</span></button>
                <h4 class=""modal-title""><i class=""clip-user""></i> Nuevo Operador</h4>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""form-group"">
                        ");
#nullable restore
#line 24 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
                   Write(Html.LabelFor(model => model.OPERADOR, new { @class = "col-sm-3 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"col-sm-7\">\r\n                            ");
#nullable restore
#line 26 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
                       Write(Html.DropDownListFor(model => model.OPERADOR, Model.ListaUsuarios, new { @class = "form-control", @maxlength = "100", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 27 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
                       Write(Html.ValidationMessageFor(model => model.OPERADOR, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>

                <div class=""modal-footer"">
                    <button id=""fondo_btn_grabar"" class=""btn btn-blue"" type=""button"" data-toggle=""modal""><i class=""fa fa-save"" /> Grabar</button>
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""fa fa-share-square-o""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 39 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Administracion\Views\Operador\Mantenimiento.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.Ventanilla.Micetur.Areas.Administracion.Models.OperadorModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
