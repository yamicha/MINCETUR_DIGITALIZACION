#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "841c20f3dc1d1c4217334954a648412195bdc150"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Microforma_Mantenimiento), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Microforma/Mantenimiento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"841c20f3dc1d1c4217334954a648412195bdc150", @"/Areas/Digitalizacion/Views/Microforma/Mantenimiento.cshtml")]
    public class Areas_Digitalizacion_Views_Microforma_Mantenimiento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView>
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
#line 2 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "841c20f3dc1d1c4217334954a648412195bdc1504208", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "841c20f3dc1d1c4217334954a648412195bdc1505322", async() => {
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
        if ($('#HDF_ACCION').val() == ""M"") {
            $('#MICROFORMA_NROVOLUMEN').prop('disabled', true);
        }
        $('#Microforma_Grabar_btn_Grabar').click(function (e) {
            if ($(""#FrmMicroformaGrabar"").valid()) {
                if ($('#HDF_ACCION').val() == ""N"") {
                    MicroformaGrabar_Grabar();
                } else {
                    Microforma_Editar();
                }
            }
        });
    });
  
    timePicker('MICROFORMA_HORA');
    $('#MICROFORMA_FECHA').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: ""dd/mm/yy"",
        firstDay: 1,
        changeFirstDay: false,
        placeholder: ""dd/MM/yyyy""
    });
    $('.modal-dialogMicroforma').draggable({
        handle: "".modal-header"",
        cursor: ""handler""
    });
</script>

");
#nullable restore
#line 38 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmMicroformaGrabar", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialogMicroforma"">
        <div class=""modal-content"" style=""width:100%;"">
            <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
                <div class=""col-sm-14"">
                    <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">× </button>
                    <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; Grabar Microforma </h4>
                </div>
            </div>
            <div class=""modal-body"">
                <fieldset style=""width: 100%;"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""col-sm-12 inline-container-Group"">
                                <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Ingresar los siguientes datos: </p>
                                <fieldset style=""width: 100%;"">
                                    <div class=""row"">
 ");
            WriteLiteral(@"                                       <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Nro. Volumen: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 61 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_NROVOLUMEN, new { @class = "form-control", @maxlength = "100", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 62 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_NROVOLUMEN, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Fecha de grabación: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 70 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_FECHA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = "DD/MM/YYYY", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 71 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_FECHA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Hora de grabación: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 79 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_HORA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = "HH:mm:ss" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 80 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_HORA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Código de medio de soporte: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 89 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_CODIGO_SOPORTE, new { @class = "form-control", @maxlength = "100", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 90 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_CODIGO_SOPORTE, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Tipo de soporte: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 98 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.DropDownListFor(model => model.MICROFORMA_ID_TIPO_SOPORTE, Model.Lista_MICROFORMA_ID_TIPO_SOPORTE, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 99 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_ID_TIPO_SOPORTE, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">N° de Acta: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 107 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_ACTA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 108 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_ACTA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">N° de Copias: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 116 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_COPIAS, new { @class = "form-control", @maxlength = "100", @style = "width:100%", onkeypress = "return ValidarNumerosOtros(event)" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 117 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_COPIAS, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>

                                    <div class=""row"" style=""margin-bottom:3px;"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta Apertura: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            <div class=""input-group"">
                                                <div style="" height: 31px;"" class=""form-control file-caption  kv-fileinput-caption"">
                                                    <div class=""file-caption-name"" id=""filenameApertura""></div>
                                                </div>
                                                <div class=""input-group-btn"">
                                                    <la");
            WriteLiteral(@"bel for=""fileActaApertura"" class=""btn btn-primary btn-file"">
                                                        <i class="" clip-upload-3""></i>&nbsp; <span class=""hidden-xs"">Cargar …</span>
                                                        <input id=""fileActaApertura"" type=""file"" class=""file"" onchange=""ProcesarArchivo(this,'filenameApertura')"">
                                                    </label>
");
#nullable restore
#line 135 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                                     if (Model.Accion == "M" && Model.ID_DOC_APERTURA != 0)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <label class=\"btn btn-danger btn-file\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9851, "\"", 9897, 3);
            WriteAttributeValue("", 9861, "DownloadFile(", 9861, 13, true);
#nullable restore
#line 137 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
WriteAttributeValue("", 9874, Model.ID_DOC_APERTURA, 9874, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9896, ")", 9896, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                            <i class=\"clip-file-pdf\"></i>&nbsp; <span class=\"hidden-xs\">Descargar</span>\r\n                                                        </label>\r\n");
#nullable restore
#line 140 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""row"" style=""margin-bottom:3px;"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta Cierre: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            <div class=""input-group "">
                                                <div style="" height: 31px; "" class=""form-control file-caption  kv-fileinput-caption"">
                                                    <div class=""file-caption-name"" id=""filenameCierre""></div>
                                                </div>
                                ");
            WriteLiteral(@"                <div class=""input-group-btn"">
                                                    <label for=""fileActaCierre"" class=""btn btn-primary btn-file"">
                                                        <i class="" clip-upload-3""></i>&nbsp; <span class=""hidden-xs"">Cargar …</span>
                                                        <input id=""fileActaCierre"" type=""file"" class=""file"" onchange=""ProcesarArchivo(this,'filenameCierre')"">
                                                    </label>
");
#nullable restore
#line 159 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                                     if (Model.Accion == "M" && Model.ID_DOC_CIERRE != 0)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <label class=\"btn btn-danger btn-file\"");
            BeginWriteAttribute("onclick", " onclick=\"", 11958, "\"", 12002, 3);
            WriteAttributeValue("", 11968, "DownloadFile(", 11968, 13, true);
#nullable restore
#line 161 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
WriteAttributeValue("", 11981, Model.ID_DOC_CIERRE, 11981, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 12001, ")", 12001, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                            <i class=\"clip-file-pdf\"></i>&nbsp; <span class=\"hidden-xs\">Descargar</span>\r\n                                                        </label>\r\n");
#nullable restore
#line 164 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class=""row"" >
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Código de Fedatario: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 175 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_CODIGO_FEDATARIO, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 176 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_CODIGO_FEDATARIO, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Comentario:</label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 184 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                       Write(Html.TextAreaFor(model => model.MICROFORMA_OBSERVACION, new { @class = "form-control", @maxlength = "3000", @style = "resize: none;text-transform: uppercase;", onkeyup = "CountCharactersControlTxt(this.id,'Microforma_Grabar_lbl1', 3000)" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <label id=\"Microforma_Grabar_lbl1\" style=\"width: 100%\" class=\"Formato\" runat=\"server\"");
            BeginWriteAttribute("text", " text=\"", 14143, "\"", 14150, 0);
            EndWriteAttribute();
            WriteLiteral(@"></label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class=""modal-footer"">
                    <button type=""button"" id=""Microforma_Grabar_btn_Grabar"" class=""btn btn-blue""><i class=""fa fa-save""></i> Grabar</button>
                    <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""clip-close-4""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 200 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
Write(Html.Hidden("HDF_ID_MICROFORMA", Model.ID_MICROFORMA));

#line default
#line hidden
#nullable disable
#nullable restore
#line 201 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
Write(Html.Hidden("HDF_ID_DOC_APERTURA", Model.ID_DOC_APERTURA));

#line default
#line hidden
#nullable disable
#nullable restore
#line 202 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
Write(Html.Hidden("HDF_ID_DOC_CIERRE", Model.ID_DOC_CIERRE));

#line default
#line hidden
#nullable disable
#nullable restore
#line 203 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
Write(Html.Hidden("HDF_ACCION", Model.Accion));

#line default
#line hidden
#nullable disable
#nullable restore
#line 203 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Mantenimiento.cshtml"
                                            
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591