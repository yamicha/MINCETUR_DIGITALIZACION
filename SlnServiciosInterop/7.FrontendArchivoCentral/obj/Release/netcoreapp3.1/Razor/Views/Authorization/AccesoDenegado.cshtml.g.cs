#pragma checksum "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbc9a6802d32bd27bb5148fd3cb64c6b7e001259"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authorization_AccesoDenegado), @"mvc.1.0.view", @"/Views/Authorization/AccesoDenegado.cshtml")]
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
#nullable restore
#line 1 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\_ViewImports.cshtml"
using Frotend.ArchivoCentral.Micetur;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\_ViewImports.cshtml"
using Frotend.ArchivoCentral.Micetur.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbc9a6802d32bd27bb5148fd3cb64c6b7e001259", @"/Views/Authorization/AccesoDenegado.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e765101418863faa7f91da2fe8a0a4281c306b7c", @"/Views/_ViewImports.cshtml")]
    public class Views_Authorization_AccesoDenegado : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/authorization/signin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
  
    Layout = null; 
    ViewBag.Title = "No Autorizado";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\" dir=\"ltr\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbc9a6802d32bd27bb5148fd3cb64c6b7e0012594856", async() => {
                WriteLiteral("\r\n    <!-- Meta data -->\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\'viewport\' content=\'width=device-width, initial-scale=1.0, user-scalable=0\'>\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <!-- Favicon -->\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 356, "\"", 392, 1);
#nullable restore
#line 14 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
WriteAttributeValue("", 363, Url.Content("~/favicon.ico"), 363, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"icon\">\r\n\r\n    <!-- Title -->\r\n    <!--Bootstrap.min css-->\r\n    <link rel=\"stylesheet\" type=\"text/css\"");
                BeginWriteAttribute("href", " href=\"", 501, "\"", 572, 1);
#nullable restore
#line 18 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
WriteAttributeValue("", 508, Url.Content("~/assets/plugins/bootstrap/css/bootstrap.min.css"), 508, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <link rel=\"stylesheet\" type=\"text/css\"");
                BeginWriteAttribute("href", " href=\"", 620, "\"", 697, 1);
#nullable restore
#line 19 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
WriteAttributeValue("", 627, Url.Content("~/assets/plugins/font-awesome/css/font-awesome.min.css"), 627, 70, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <link rel=\"stylesheet\" type=\"text/css\"");
                BeginWriteAttribute("href", " href=\"", 745, "\"", 792, 1);
#nullable restore
#line 20 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
WriteAttributeValue("", 752, Url.Content("~/assets/fonts/style.css"), 752, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbc9a6802d32bd27bb5148fd3cb64c6b7e0012598335", async() => {
                WriteLiteral("\r\n    <div class=\"container-fluid\" style=\"display: flex; height: 100vh; justify-content: center; align-items: center;\">\r\n        <div class=\"row\">\r\n            <div class=\"mb-3 text-center\">\r\n                <img");
                BeginWriteAttribute("src", " src=\"", 1025, "\"", 1080, 1);
#nullable restore
#line 26 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
WriteAttributeValue("", 1031, Url.Content("~/assets/images/logo-mincetur.png"), 1031, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\" mb-2\"");
                BeginWriteAttribute("alt", " alt=\"", 1095, "\"", 1101, 0);
                EndWriteAttribute();
                WriteLiteral(@" width=""350"">
            </div>
            <h1 class=""text-danger text-center"" style=""font-weight:bold;""> NO AUTORIZADO</h1>
            <h1 class=""text-center"">401</h1>
            <p class=""text-center"">No se encontró autorización, no tiene acesso a este sistema o su fecha de ingreso caduco<br /> Por favor contacte con el administrador del sistema.</p>
            <div class=""text-center"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbc9a6802d32bd27bb5148fd3cb64c6b7e0012599903", async() => {
                    WriteLiteral("<i class=\"clip-home\"></i> &nbsp;Iniciar Sessión ");
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
                WriteLiteral(" </div>\r\n        </div>\r\n    </div>\r\n\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 1662, "\"", 1717, 1);
#nullable restore
#line 35 "E:\APLICACIONES\MINCETUR - PROYECTO DIGITALIZACIÓN\PROYECTO\2023\MINCETUR_DIGITALIZACION\SlnServiciosInterop\7.FrontendArchivoCentral\Views\Authorization\AccesoDenegado.cshtml"
WriteAttributeValue("", 1668, Url.Content("~/Scripts/jquery-ui-1.8.24.min.js"), 1668, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"text/javascript\"></script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
