#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34c0e15f2c6383aa659588e1720120d9193d4c02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Microforma_Microforma_Validar), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Microforma/Microforma_Validar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34c0e15f2c6383aa659588e1720120d9193d4c02", @"/Areas/Digitalizacion/Views/Microforma/Microforma_Validar.cshtml")]
    public class Areas_Digitalizacion_Views_Microforma_Microforma_Validar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView>
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
#line 2 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34c0e15f2c6383aa659588e1720120d9193d4c024273", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34c0e15f2c6383aa659588e1720120d9193d4c025387", async() => {
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
        $('#Microforma_Grabar_btn_Evaluar').click(function () {
            MicroformaEvaluar();
        });
        $('#MICROFORMA_FLG_CONFORME').change(function () {
            if ($(this).val() == 1) {
                $('#Adv_Conforme').show('slow');
            } else
                $('#Adv_Conforme').hide();
        });
    });
</script>

<div class=""modal-dialogMicroforma"">
    <div class=""modal-content"" style=""width:100%;"">
        <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
            <div class=""col-sm-14"">
                <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">×</button>
                <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; Evaluar Microforma </h4>
            </div>
        </div>
        <div class=""modal-body"">
            <fieldset style=""width: 100%;"">
                <div class=""row"">
                    <div class=""col-sm-12"">
                   ");
            WriteLiteral("     <div class=\"col-sm-12 inline-container-Group\">\r\n");
            WriteLiteral(@"                            <fieldset style=""width: 100%;"">
                                <div class=""row"" hidden=""hidden"">
                                    <div class=""col-sm-4"">
                                        <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Nro de Lote:</label>
                                    </div>
                                    <div class=""col-sm-4"">
                                        ");
#nullable restore
#line 42 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextBoxFor(model => model.MICROFORMA_ID_LOTE, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @readonly = "true" }));

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
                                    <div class=""col-sm-6"">
                                        ");
#nullable restore
#line 50 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextBoxFor(model => model.MICROFORMA_FECHA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = "DD/MM/YYYY", @autocomplete = "off", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 51 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.MICROFORMA_FECHA, string.Empty, new { @class = "cssMessageError" }));

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
                                    <div class=""col-sm-6"">
                                        ");
#nullable restore
#line 59 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextBoxFor(model => model.MICROFORMA_CODIGO_SOPORTE, new { @class = "form-control", @maxlength = "100", @style = "width:100%", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 60 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
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
                                    <div class=""col-sm-6"">
                                        ");
#nullable restore
#line 68 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.DropDownListFor(model => model.MICROFORMA_ID_TIPO_SOPORTE, Model.Lista_MICROFORMA_ID_TIPO_SOPORTE, new { @class = "form-control", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 69 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
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
                                    <div class=""col-sm-6"">
                                        ");
#nullable restore
#line 77 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextBoxFor(model => model.MICROFORMA_ACTA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 78 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
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
                                    <div class=""col-sm-6"">
                                        ");
#nullable restore
#line 86 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextBoxFor(model => model.MICROFORMA_COPIAS, new { @class = "form-control", @maxlength = "100", @style = "width:100%", onkeypress = "return ValidarNumerosOtros(event)", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 87 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.MICROFORMA_COPIAS, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-4"">
                                        <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Código de Fedatario: </label>
                                    </div>
                                    <div class=""col-sm-6"">
                                        ");
#nullable restore
#line 95 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextBoxFor(model => model.MICROFORMA_CODIGO_FEDATARIO, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 96 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
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
#line 104 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                   Write(Html.TextAreaFor(model => model.MICROFORMA_OBSERVACION, new { @class = "form-control", @maxlength = "3000", @style = "height:90px;resize: none;text-transform: uppercase;", onkeyup = "CountCharactersControlTxt(this.id,'Microforma_Grabar_lbl1', 3000)", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <label id=\"Microforma_Grabar_lbl1\" style=\"width: 100%\" class=\"Formato\" runat=\"server\"");
            BeginWriteAttribute("text", " text=\"", 8034, "\"", 8041, 0);
            EndWriteAttribute();
            WriteLiteral("></label>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 108 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmMicroEvaluar", @class = "form-horizontal" }))
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                               Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-sm-12 inline-container-Group"">
                                        <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Evaluar: </p>
                                        <fieldset style=""width: 100%;"">
                                            <div class=""row"">
                                                <div class=""col-sm-2"">
                                                    <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Conforme ?</label>
                                                </div>
                                                <div class=""col-sm-6"">
                                                    ");
#nullable restore
#line 120 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                               Write(Html.DropDownListFor(model => model.MICROFORMA_FLG_CONFORME, Model.Lista_MICROFORMA_ID_CONFORME, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    ");
#nullable restore
#line 121 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                               Write(Html.ValidationMessageFor(model => model.MICROFORMA_FLG_CONFORME, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </div>
                                            </div>
                                            <div class=""row"">
                                                <div class=""col-sm-2"">
                                                    <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Observación:</label>
                                                </div>
                                                <div class=""col-sm-10"">
                                                    ");
#nullable restore
#line 129 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                               Write(Html.TextAreaFor(model => model.MICROFORMA_OBSERVACION_EVALUAR, new { @class = "form-control", @maxlength = "1000", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </div>
                                                <div class=""col-sm-12"" id=""Adv_Conforme"" style=""display:none;"">
                                                    <blockquote style=""font-size:15px;"">
                                                        <p>
                                                            <strong>Al seleccionar conforme</strong> usted acepta, que la
                                                            funcionalidad de los medios de soporte, Identificación y recuperación de imágenes,
                                                            Integridad, Legibilidad de Imagen/Impresión son correctos.
                                                        </p>
                                                    </blockquote>
                                                </div>

                                            </div>
                                        </fieldset>
                       ");
            WriteLiteral("             </div>\r\n");
#nullable restore
#line 144 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </fieldset>
                        </div>
                    </div>
                </div>
            </fieldset>
            <div class=""modal-footer"">
                <button type=""button"" id=""Microforma_Grabar_btn_Evaluar"" class=""btn btn-blue""><i class=""fa fa-save""></i> Evaluar</button>
                <button type=""button"" class=""btn btn-light-grey"" data-dismiss=""modal""><i class=""clip-close-4""></i> Cerrar</button>
            </div>
        </div>
    </div>
</div>
");
#nullable restore
#line 157 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Validar.cshtml"
Write(Html.Hidden("HDF_ID_MICROFORMA", Model.ID_MICROFORMA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
