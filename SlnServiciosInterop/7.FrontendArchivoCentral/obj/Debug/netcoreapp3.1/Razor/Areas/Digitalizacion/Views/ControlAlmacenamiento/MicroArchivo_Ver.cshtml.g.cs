#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dae6acdd98e5f906c8da60c1a33c54753c5f1cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_ControlAlmacenamiento_MicroArchivo_Ver), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/ControlAlmacenamiento/MicroArchivo_Ver.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dae6acdd98e5f906c8da60c1a33c54753c5f1cc", @"/Areas/Digitalizacion/Views/ControlAlmacenamiento/MicroArchivo_Ver.cshtml")]
    public class Areas_Digitalizacion_Views_ControlAlmacenamiento_MicroArchivo_Ver : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroArchivoModel>
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
#line 2 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3dae6acdd98e5f906c8da60c1a33c54753c5f1cc4285", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3dae6acdd98e5f906c8da60c1a33c54753c5f1cc5399", async() => {
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
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        MicroArchivo_HistorialConfigurarGrilla(""MicroArchivoHistorial_grilla"", ""MicroArchivoHistorial_barra"");
        MicroArchivo_HistorialCargarGrilla(""MicroArchivoHistorial_grilla""); 
    });
</script>
");
#nullable restore
#line 13 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmMicroformaGrabar" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialog "" style=""width:800px;"">
        <div class=""modal-content"" style=""width:100%;"">
            <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
                <div class=""col-sm-14"">
                    <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">× </button>
                    <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; MicroArchivo </h4>
                </div>
            </div>
            <div class=""modal-body"">
                <fieldset style=""width: 100%;"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""col-sm-12 inline-container-Group"" style=""margin-bottom:5px;"">
                                <fieldset style=""width: 100%;"">
                                    <div class=""form-row"">
                                        <div class=""form-group col-sm-6"">
                                            <label for");
            WriteLiteral("=\"form-field-1\">Tipo Micro Archivo: </label>\r\n                                            ");
#nullable restore
#line 33 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.DropDownListFor(model => model.MA_TIPO_ARCHIVO, Model.Lista_TipoMicroArchivo, new { @class = "form-control", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 34 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_TIPO_ARCHIVO, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>

                                        <div class=""form-group col-sm-6"">
                                            <label for=""form-field-1"">Dirección: </label>
                                            ");
#nullable restore
#line 39 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_DIRECCION, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 40 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_DIRECCION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>

                                    <div class=""form-row"">
                                        <div class=""form-group col-sm-6"">
                                            <label for=""form-field-1"">Fecha: </label>
                                            ");
#nullable restore
#line 47 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_FECHA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 48 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_FECHA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>

                                        <div class=""form-group col-sm-6"">
                                            <label for=""form-field-1"">Hora: </label>
                                            ");
#nullable restore
#line 53 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_HORA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = "DD/MM/YYYY", @autocomplete = "off", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 54 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_HORA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""form-row"">
                                        <div class=""form-group col-sm-6"">
                                            <label for=""form-field-1"">Responsable: </label>
                                            ");
#nullable restore
#line 60 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_RESPONSABLE, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 61 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_RESPONSABLE, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                        <div class=""form-group col-sm-6"">
                                            <label for=""form-field-1"">Observación: </label>
                                            ");
#nullable restore
#line 65 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.TextAreaFor(model => model.MA_OBSERVACION, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @autocomplete = "off", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 66 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_OBSERVACION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"form-row\">\r\n                                        <a href=\"javascript:void(0)\" class=\"btn btn-link\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5388, "\"", 5443, 3);
            WriteAttributeValue("", 5398, "DownloadFile(", 5398, 13, true);
#nullable restore
#line 70 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
WriteAttributeValue("", 5411, Model.MA_ID_DOC_ALMACENAMIENTO, 5411, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5442, ")", 5442, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""clip-download""></i>&nbsp; Descargar Acta Almacenamiento</a>
                                    </div>
                                </fieldset>
                            </div>
                            <div class=""col-sm-12"" style=""padding:0px;"">
                                <div class=""jqGrid"">
                                    <table id=""MicroArchivoHistorial_grilla"">
                                    </table>
                                    <div id=""MicroArchivoHistorial_barra""></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""clip-close-4""></i> Cerrar</button>
                </div>
            </div>
        </div>
        ");
#nullable restore
#line 89 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
   Write(Html.Hidden("HDF_ID_MICROFORMA",Model.ID_MICROFORMA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 91 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\ControlAlmacenamiento\MicroArchivo_Ver.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroArchivoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
