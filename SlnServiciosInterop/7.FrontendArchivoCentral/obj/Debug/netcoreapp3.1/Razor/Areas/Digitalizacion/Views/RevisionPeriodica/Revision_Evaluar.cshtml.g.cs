#pragma checksum "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5dc518d864a8ae2307cc44405e6375e532508fe"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5dc518d864a8ae2307cc44405e6375e532508fe", @"/Areas/Digitalizacion/Views/RevisionPeriodica/Revision_Evaluar.cshtml")]
    public class Areas_Digitalizacion_Views_RevisionPeriodica_Revision_Evaluar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView>
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
#line 2 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5dc518d864a8ae2307cc44405e6375e532508fe4303", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5dc518d864a8ae2307cc44405e6375e532508fe5417", async() => {
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
        $('#Microforma_Revision_Evaluar').click(function () {
            Revision_Grabar();
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
                <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; Revisión Periodica </h4>
            </div>
        </div>
        <div class=""modal-body"">
            <fieldset style=""width: 100%;"">
                <div class=""row"">
                    <div class=""col-sm-12"">
");
            WriteLiteral("                            <fieldset style=\"width: 100%;\">              \r\n");
#nullable restore
#line 36 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmMicroEvaluar", @class = "form-horizontal" }))
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
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
#line 48 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                               Write(Html.DropDownListFor(model => model.MICROFORMA_FLG_CONFORME, Model.Lista_MICROFORMA_ID_CONFORME, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    ");
#nullable restore
#line 49 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
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
#line 57 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
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
#line 72 "C:\Users\ivans\OneDrive\Documentos\GitHub\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\RevisionPeriodica\Revision_Evaluar.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </fieldset>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
