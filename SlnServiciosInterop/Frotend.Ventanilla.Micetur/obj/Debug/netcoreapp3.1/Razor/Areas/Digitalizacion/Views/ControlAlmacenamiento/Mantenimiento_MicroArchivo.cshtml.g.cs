#pragma checksum "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5ae75d9a77d3a5237cf300d7bb17c3bcc3c47d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_ControlAlmacenamiento_Mantenimiento_MicroArchivo), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/ControlAlmacenamiento/Mantenimiento_MicroArchivo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5ae75d9a77d3a5237cf300d7bb17c3bcc3c47d2", @"/Areas/Digitalizacion/Views/ControlAlmacenamiento/Mantenimiento_MicroArchivo.cshtml")]
    public class Areas_Digitalizacion_Views_ControlAlmacenamiento_Mantenimiento_MicroArchivo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.MicroArchivoModel>
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
#line 2 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5ae75d9a77d3a5237cf300d7bb17c3bcc3c47d24331", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5ae75d9a77d3a5237cf300d7bb17c3bcc3c47d25445", async() => {
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
        $('#MicroformaBtnMicroArchivo').click(function (e) {
            if ($(""#FrmMicroArchivo"").valid()) {
                if ($('#HDF_Accion').val() == ""M"") {
                    MicroArchivo_Editar();
                }
                else {
                    Microforma_MicroArchivoGrabar();
                }
            }
        });
    });
    timePicker('MA_HORA');
    $('#MA_FECHA').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: ""dd/mm/yy"",
        firstDay: 1,
        changeFirstDay: false,
        placeholder: ""dd/MM/yyyy""
    });
</script>
");
#nullable restore
#line 30 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmMicroArchivo", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialogMicroforma"">
        <div class=""modal-content"" style=""width:100%;"">
            <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
                <div class=""col-sm-14"">
                    <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">× </button>
                    <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; Grabar MicroArchivo </h4>
                </div>
            </div>
            <div class=""modal-body"">
                <fieldset style=""width: 100%;"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""col-sm-12 inline-container-Group"">
                                <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Ingresar los siguientes datos: </p>
                                <fieldset style=""width: 100%;"">

                                    <div class=""row""");
            WriteLiteral(@">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Tipo MicroArchivo: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 54 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.DropDownListFor(model => model.MA_TIPO_ARCHIVO, Model.Lista_TipoMicroArchivo, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 55 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_TIPO_ARCHIVO, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Dirección: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 63 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_DIRECCION, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 64 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_DIRECCION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Fecha: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 72 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_FECHA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 73 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_FECHA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Hora: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 81 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_HORA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", @placeholder = "HH:mm:ss" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 82 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_HORA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"" style=""margin-bottom:3px;"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta Almacenamiento: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            <div class=""input-group"">
                                                <div style="" height: 31px;"" class=""form-control file-caption  kv-fileinput-caption"">
                                                    <div class=""file-caption-name"" id=""filenameAlma""></div>
                                                </div>
                                                <div class=""input-group-btn"">
                                                    <la");
            WriteLiteral(@"bel for=""fileActaAlma"" class=""btn btn-primary btn-file"">
                                                        <i class="" clip-upload-3""></i>&nbsp; <span class=""hidden-xs"">Cargar …</span>
                                                        <input id=""fileActaAlma"" type=""file"" class=""file"" onchange=""ProcesarArchivo(this,'filenameAlma')"">
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Responsable: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                       ");
            WriteLiteral("                     ");
#nullable restore
#line 108 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_RESPONSABLE, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 109 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_RESPONSABLE, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Observación:</label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 118 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.TextAreaFor(model => model.MA_OBSERVACION, new { @class = "form-control", @maxlength = "3000", @style = "height:90px;resize: none;text-transform: uppercase;", onkeyup = "CountCharactersControlTxt(this.id,'Microforma_Grabar_lbl1', 3000)" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <label id=\"Microforma_Grabar_lbl1\" style=\"width: 100%\" class=\"Formato\" runat=\"server\"");
            BeginWriteAttribute("text", " text=\"", 8546, "\"", 8553, 0);
            EndWriteAttribute();
            WriteLiteral("></label>\r\n                                            ");
#nullable restore
#line 120 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_OBSERVACION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class=""modal-footer"">
                    <button type=""button"" id=""MicroformaBtnMicroArchivo"" class=""btn btn-blue""><i class=""fa fa-save""></i> Grabar</button>
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""clip-close-4""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 135 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
Write(Html.Hidden("HDF_ID_MICROFORMA", Model.ID_MICROFORMA));

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
Write(Html.Hidden("HDF_Accion", Model.Accion));

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\Inmortal\Documents\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\ControlAlmacenamiento\Mantenimiento_MicroArchivo.cshtml"
                                            
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.MicroArchivoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
