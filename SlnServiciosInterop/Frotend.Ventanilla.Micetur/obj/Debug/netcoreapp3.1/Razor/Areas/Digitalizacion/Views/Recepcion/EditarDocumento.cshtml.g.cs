#pragma checksum "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5274008a6c84e14d601fe73c416472d40db6d2e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Recepcion_EditarDocumento), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Recepcion/EditarDocumento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5274008a6c84e14d601fe73c416472d40db6d2e1", @"/Areas/Digitalizacion/Views/Recepcion/EditarDocumento.cshtml")]
    public class Areas_Digitalizacion_Views_Recepcion_EditarDocumento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.RecibirModelView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/Microforma/Modals.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5274008a6c84e14d601fe73c416472d40db6d2e13828", async() => {
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
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        $('.modal-dialogMicroforma').draggable({
            handle: "".modal-header"",
            cursor: ""handler""
        });
        $('#DocumentoBtnEditar').click(function () {
            DocumentoAdj_Editar();
        });
    });
    function CloseModal() {
        $('#MyModalDoc').modal('hide');
    }
</script>

");
#nullable restore
#line 21 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmDocumentoAdj", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialogMicroforma"" style=""margin:100px auto"">
        <div class=""modal-content"" style=""width:100%;"">
            <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
                <div class=""col-sm-14"">
                    <button class=""close"" aria-hidden=""true"" onclick=""CloseModal()"" type=""button"">× </button>
                    <h4 class=""modal-title""><i class='clip-pencil-2'></i>&nbsp; Editar Documento </h4>
                </div>
            </div>
            <div class=""modal-body"">
                <fieldset style=""width: 100%;"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""col-sm-12 inline-container-Group"">
                                <p class=""modal-title"" style=""color: #999; font-size: 15px; margin-bottom: 5px; margin-top: -5px"">Ingresar los siguientes datos: </p>
                                <fieldset style=""width: 100%;"">
                            ");
            WriteLiteral(@"        <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Extensión: </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 44 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
                                       Write(Html.TextBoxFor(model => model.EXTENSION, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = ".pdf", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 45 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.EXTENSION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Peso(Bytes): </label>
                                        </div>
                                        <div class=""col-sm-8"">
                                            ");
#nullable restore
#line 53 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
                                       Write(Html.TextBoxFor(model => model.PESO_ARCHIVO, new { @class = "form-control", @maxlength = "100", @style = "width:100%" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 54 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.PESO_ARCHIVO, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-12"" id=""Adv_Conforme"" >
                                            <div class=""alert alert-block alert-warning fade in"">
                                                <button data-dismiss=""alert"" class=""close"" type=""button""> × </button>
                                                <h4 class=""alert-heading""><i class=""fa fa-exclamation-triangle""></i> Tener en cuenta!</h4>
                                                <p>
                                                    Por favor ingresar el peso del archivo en bytes tener en cuentra tambien ingresar dicho peso sin decimales.
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                     ");
            WriteLiteral(@"           </fieldset>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class=""modal-footer"">
                    <button type=""button"" id=""DocumentoBtnEditar"" class=""btn btn-blue""><i class=""clip-pencil-2""></i> Editar</button>
                    <button type=""button"" class=""btn btn-light-grey"" onclick=""CloseModal()""><i class=""clip-close-4""></i> Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 80 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
Write(Html.Hidden("HDF_ID_DOC", Model.ID_DOC));

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "D:\1.APLICACIONES\7.MINCETUR_DIGITALIZACION\MINCETUR_DIGITALIZACION\SlnServiciosInterop\Frotend.Ventanilla.Micetur\Areas\Digitalizacion\Views\Recepcion\EditarDocumento.cshtml"
                                            
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models.RecibirModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
