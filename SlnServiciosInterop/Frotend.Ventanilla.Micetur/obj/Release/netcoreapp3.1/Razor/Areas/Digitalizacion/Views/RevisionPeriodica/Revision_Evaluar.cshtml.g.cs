#pragma checksum "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d357d6b010fd8c91eb7565adf96afde448f4a0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_RevisionPeriodica_Revision_Evaluar), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/RevisionPeriodica/Revision_Evaluar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d357d6b010fd8c91eb7565adf96afde448f4a0b", @"/Areas/Digitalizacion/Views/RevisionPeriodica/Revision_Evaluar.cshtml")]
    public class Areas_Digitalizacion_Views_RevisionPeriodica_Revision_Evaluar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.RevisionPeriodicaModel>
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
#line 2 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d357d6b010fd8c91eb7565adf96afde448f4a0b4304", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d357d6b010fd8c91eb7565adf96afde448f4a0b5418", async() => {
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
<script>
    $(function () {
        Revision_CargarConboUsuario();
        $('#TIPO_PRUEBA').fastselect();
        $('#Microforma_Revision_Evaluar').click(function () {
            debugger;
            if ($('#FrmEvaluarRevision').valid()) {
                Revision_Grabar();
            }
        });
        $('#FLG_CONFORME').change(function () {
            if ($(this).val() == 0) {
                $('#InputAccion').show('slow');
            } else
                $('#InputAccion').hide();
        });
        $('#ID_USUARIO').select2();
    });
    $('#FECHA').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: ""dd/mm/yy"",
        firstDay: 1,
        changeFirstDay: false,
        placeholder: ""dd/MM/yyyy""
    });

    $('#FECHA').blur(function () {
        if (this.value == """" || this.value.length == 0) {
            return true;
        }
        if (!validateDate(this.value)) {
            jOkas(""Ingrese una fecha válida."", ""Mensaje""");
            WriteLiteral(@", function (lol) {
                $('#FECHA').val('');
                $('#FECHA').focus();
            });
            
        }
    });

    function ConvertirMayusculaPrimeraLetra(idInput) {
        var texto = document.getElementById(idInput).value;
        var primeraLetra = texto.substring(0, 1);
        var restoTexto = texto.substring(1);
        primeraLetra = primeraLetra.toUpperCase();
        restoTexto = restoTexto.toLowerCase();
        document.getElementById(idInput).value = primeraLetra + restoTexto;
    }
    
</script>

<div class=""modal-dialogMicroforma"">
    <div class=""modal-content"" style=""width:100%;"">
        <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
            <div class=""col-sm-14"">
                <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">×</button>
                <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; Revisión Periódica </h4>
            </div>
        </div>
     ");
            WriteLiteral("   <div class=\"modal-body\">\r\n            <fieldset style=\"width: 100%;\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-sm-12\">\r\n");
            WriteLiteral("                        <fieldset style=\"width: 100%;\">\r\n");
#nullable restore
#line 72 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                             using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmEvaluarRevision", @class = "form-horizontal" }))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                           Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-sm-12 inline-container-Group"">
                                    <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Evaluar: </p>
                                    <fieldset style=""width: 100%;"">

                                        <div class=""form-row"">
                                            <div class=""form-group col-sm-12"">
                                                <label for=""form-field-1"">Tipo de Revisiónes: </label>
                                                ");
#nullable restore
#line 83 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.DropDownListFor(model => model.TIPO_PRUEBA, Model.Lista_TipoPrueba, new
                                                {
                                                    @class = "form-control",
                                                    @multiple = "true",
                                                    @placeholder = "Seleccione Tipos de Prueba"
                                                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 89 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.TIPO_PRUEBA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>

                                            <div class=""form-group col-sm-12"">
                                                <label for=""form-field-1"">Responsable: </label>
                                                ");
#nullable restore
#line 94 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.DropDownListFor(model => model.ID_USUARIO, Model.Lista_Usuarios, new { @class = "form-control", @style = "width: 100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 95 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.ID_USUARIO, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>

                                        </div>

                                        <div class=""form-row"">
                                            <div class=""form-group col-sm-12"" id=""InputActa"">
                                                <label for=""form-field-1"">Acta Revisión: </label>
                                                <div class=""input-group"">
                                                    <div style="" height: 31px;"" class=""form-control file-caption  kv-fileinput-caption"">
                                                        <div class=""file-caption-name"" id=""filenameRevision""></div>
                                                    </div>
                                                    <div class=""input-group-btn"">
                                                        <label for=""fileActaRevision"" class=""btn btn-primary btn-file"">
                                                            <i cla");
            WriteLiteral(@"ss="" clip-upload-3""></i>&nbsp; <span class=""hidden-xs"">Cargar …</span>
                                                            <input id=""fileActaRevision"" type=""file"" class=""file"" onchange=""ProcesarArchivo(this,'filenameRevision')"">
                                                        </label>
                                                    </div>
                                                </div>
                                                <span class=""field-validation-valid cssMessageError"" style=""display:none;"" id=""MsgValidActa"" data-valmsg-for=""fileActaRevision"" data-valmsg-replace=""true"">
                                                    (*) Acta de revisión es obligatorio.
                                                </span>
                                            </div>
                                            <div class=""form-group col-sm-12"">
                                                <label for=""form-field-1"">Fecha Revisión: </label>
                  ");
            WriteLiteral("                              ");
#nullable restore
#line 120 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.TextBoxFor(model => model.FECHA, new { @class = "form-control", @maxlength = "10", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 121 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.FECHA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>
                                        </div>
                                        <div class=""form-row"">
                                            <div class=""form-group col-sm-12"">
                                                <label for=""form-field-1"">Observación: </label>
                                                ");
#nullable restore
#line 127 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.TextAreaFor(model => model.OBSERVACION, new { @class = "form-control", @maxlength = "1000", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 128 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.OBSERVACION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>
                                        </div>

                                        <div class=""form-row"">
                                            <div class=""form-group col-sm-12"">
                                                <label for=""form-field-1"">Conforme ?: </label>
                                                ");
#nullable restore
#line 135 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.DropDownListFor(model => model.FLG_CONFORME, Model.Lista_Conforme, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 136 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.FLG_CONFORME, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>
                                            <div class=""form-group col-sm-12"" id=""InputAccion"" style=""display:none;"">
                                                <label for=""form-field-1"">Accion: </label>
                                                ");
#nullable restore
#line 140 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.DropDownListFor(model => model.FLG_ACCION, Model.Lista_Accion, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 141 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.FLG_ACCION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n\r\n                                    </fieldset>\r\n                                </div>\r\n");
#nullable restore
#line 147 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </fieldset>
                    </div>
                </div>
            </fieldset>
            <div class=""modal-footer"">
                <button type=""button"" id=""Microforma_Revision_Evaluar"" class=""btn btn-blue""><i class=""fa fa-save""></i> Evaluar Revisión</button>
                <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""clip-close-4""></i> Cerrar</button>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.RevisionPeriodicaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
