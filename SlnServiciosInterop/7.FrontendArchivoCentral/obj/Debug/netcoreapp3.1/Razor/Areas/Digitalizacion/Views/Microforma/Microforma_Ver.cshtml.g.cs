#pragma checksum "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d9bfebbe7e250209c0d977fc0fdb868ddc714a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Digitalizacion_Views_Microforma_Microforma_Ver), @"mvc.1.0.view", @"/Areas/Digitalizacion/Views/Microforma/Microforma_Ver.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d9bfebbe7e250209c0d977fc0fdb868ddc714a2", @"/Areas/Digitalizacion/Views/Microforma/Microforma_Ver.cshtml")]
    public class Areas_Digitalizacion_Views_Microforma_Microforma_Ver : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models.MicroformaGrabaModelView>
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
#line 2 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d9bfebbe7e250209c0d977fc0fdb868ddc714a24231", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d9bfebbe7e250209c0d977fc0fdb868ddc714a25345", async() => {
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
    });
</script>
<style>
.time-picker {
        display: flex;
        justify-content: center;
        flex-direction: column;
        transition: all .4s ease;
        height: 0;
        overflow: hidden;
    }

        .time-picker .set-time {
            display: flex;
            justify-content: center;
            margin-bottom: 15px;
        }

    .label {
        width: 60px;
        margin: 0 5px;
        text-align: center;
        line-height: 34px;
        display: inline-style;
    }

        .label a {
            display: block;
            border: 1px solid #DDDDDD;
            cursor: pointer;
            font-size: 28px;
            font-weight: bold;
            border-radius: 3px;
            text-decoration: none
        }

            .label a:hover, .label a:active {
                background-color: red;
                color: #FFFFFF;
            }



        .label .s");
            WriteLiteral(@"et {
            text-align: center;
            box-sizing: border-box;
            width: 100%;
            height: 40px;
            line-height: 34px;
            font-size: 15px;
            font-weight: bold;
            border: transparent;
        }



    #submitTime {
        text-align: center;
        line-height: 34px;
        border: 1px solid #DDDDDD;
        width: 128px;
        margin: auto;
        border-radius: 3px;
        cursor: pointer;
        text-transform: uppercase;
        font-weight: bold;
    }



    .time-picker.open {
        border: 1px solid #DDDDDD;
        padding: 15px;
        transition: all .5s ease;
        height: auto;
        background-color: #FCFCFC;
    }
</style>
");
#nullable restore
#line 88 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
 using (Html.BeginForm("", "", new { @area = "" }, FormMethod.Post, false, new { @id = "FrmMicroformaGrabar", @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-dialogMicroforma"">
        <div class=""modal-content"" style=""width:100%;"">
            <div class=""modal-header"" style=""cursor: move; background-color: #ca2626"">
                <div class=""col-sm-14"">
                    <button class=""close"" aria-hidden=""true"" data-dismiss=""modal"" type=""button"">× </button>
                    <h4 class=""modal-title""><i class='clip-new-tab'></i>&nbsp; Microforma </h4>
                </div>
            </div>
            <div class=""modal-body"">
                <fieldset style=""width: 100%;"">
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""panel panel-default"">
                                <div class=""panel-heading"">
                                    <i class=""clip-vynil""></i>Detalle  Microforma
                                </div>
                                <div class=""panel-body"">
                                    <div class=""row"">
           ");
            WriteLiteral(@"                             <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Nro Volumen:</label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 113 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_NROVOLUMEN, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @readonly = "true" }));

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
#line 121 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_FECHA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = "DD/MM/YYYY", @autocomplete = "off", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 122 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 130 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_HORA, new { @class = "form-control", @maxlength = "100", @style = "width:100%", @placeholder = "HH:mm:ss", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 131 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 139 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_CODIGO_SOPORTE, new { @class = "form-control", @maxlength = "100", @style = "width:100%", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 140 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 149 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_DESC_SOPORTE, new { @class = "form-control", @maxlength = "100", @style = "width:100%", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 150 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MICROFORMA_DESC_SOPORTE, string.Empty, new { @class = "cssMessageError" }));

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
#line 158 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_ACTA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 159 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 167 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_COPIAS, new { @class = "form-control", @maxlength = "100", @style = "width:100%", onkeypress = "return ValidarNumerosOtros(event)", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 168 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 176 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MICROFORMA_CODIGO_FEDATARIO, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 177 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 185 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextAreaFor(model => model.MICROFORMA_OBSERVACION, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta Apertura: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            <a href=""javascript:void(0)"" class=""btn btn-link""");
            BeginWriteAttribute("onclick", " onclick=\"", 11122, "\"", 11168, 3);
            WriteAttributeValue("", 11132, "DownloadFile(", 11132, 13, true);
#nullable restore
#line 193 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
WriteAttributeValue("", 11145, Model.ID_DOC_APERTURA, 11145, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 11167, ")", 11167, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""clip-download""></i>&nbsp; Descargar Acta Apertura</a>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta Cierre </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            <a href=""javascript:void(0)"" class=""btn btn-link""");
            BeginWriteAttribute("onclick", " onclick=\"", 11810, "\"", 11854, 3);
            WriteAttributeValue("", 11820, "DownloadFile(", 11820, 13, true);
#nullable restore
#line 201 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
WriteAttributeValue("", 11833, Model.ID_DOC_CIERRE, 11833, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 11853, ")", 11853, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""clip-download""></i>&nbsp;Descargar Acta Cierre</a>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta conformidad </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            <a href=""javascript:void(0)"" class=""btn btn-link""");
            BeginWriteAttribute("onclick", " onclick=\"", 12498, "\"", 12547, 3);
            WriteAttributeValue("", 12508, "DownloadFile(", 12508, 13, true);
#nullable restore
#line 209 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
WriteAttributeValue("", 12521, Model.ID_DOC_CONFORMIDAD, 12521, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 12546, ")", 12546, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""clip-download""></i>&nbsp;Descargar Acta Conformidad</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""panel panel-default"">
                                <div class=""panel-heading"">
                                    <i class=""clip-paste""></i> Detalle MicroArchivo
                                </div>
                                <div class=""panel-body"">
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Tipo MicroArchivo:</label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 224 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.DropDownListFor(model => model.MA_TIPO_ARCHIVO, Model.Lista_TipoMicroArchivo, new { @class = "form-control", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 225 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 234 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_DIRECCION, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 235 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 244 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_FECHA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 245 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
#line 254 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_HORA, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 255 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_HORA, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Responsable: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 264 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextBoxFor(model => model.MA_RESPONSABLE, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 265 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_RESPONSABLE, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Observación: </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            ");
#nullable restore
#line 274 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.TextAreaFor(model => model.MA_OBSERVACION, new { @class = "form-control", @maxlength = "100", @style = "width:100%;text-transform: uppercase;", disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 275 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MA_OBSERVACION, string.Empty, new { @class = "cssMessageError" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <label class=""col-sm-15 control-label"" for=""form-field-1"" style=""width: 100%; color: black;"">Acta Almacenamiento </label>
                                        </div>
                                        <div class=""col-sm-6"">
                                            <a href=""javascript:void(0)"" class=""btn btn-link""");
            BeginWriteAttribute("onclick", " onclick=\"", 18626, "\"", 18681, 3);
            WriteAttributeValue("", 18636, "DownloadFile(", 18636, 13, true);
#nullable restore
#line 283 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
WriteAttributeValue("", 18649, Model.MA_ID_DOC_ALMACENAMIENTO, 18649, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 18680, ")", 18680, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""clip-download""></i>&nbsp;Descargar Acta Conformidad</a>
                                        </div>
                                    </div>

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
    </div>
");
#nullable restore
#line 299 "E:\APLICACIONES\LINKSOFT_PROYECT\App_Mincetur_Digitalizacion\SlnServiciosInterop\7.FrontendArchivoCentral\Areas\Digitalizacion\Views\Microforma\Microforma_Ver.cshtml"
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
