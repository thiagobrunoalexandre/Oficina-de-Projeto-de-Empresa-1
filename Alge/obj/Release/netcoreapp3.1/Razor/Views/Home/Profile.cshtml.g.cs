#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e5724120243e20755c4e3c458b501e31d8b8419"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Profile), @"mvc.1.0.view", @"/Views/Home/Profile.cshtml")]
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
#line 1 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\_ViewImports.cshtml"
using Alge;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\_ViewImports.cshtml"
using Alge.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
using Alge.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e5724120243e20755c4e3c458b501e31d8b8419", @"/Views/Home/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Alge.Models.UserProfileModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/MaskPlugin/MaskPlugin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/MaskPlugin/MaskPlugin2.0.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
  

    ViewBag.Title = "Perfil";
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.SearchBar = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .field-validation-error {\r\n        color: red;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e5724120243e20755c4e3c458b501e31d8b84195012", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e5724120243e20755c4e3c458b501e31d8b84196051", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 18 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <fieldset>
        <div class=""container-fluid"">
            <!--        Corpo Site-->
            <div style=""margin-bottom: 20px;"" class=""row"">
                <div class=""col-md-8 col-md-offset-4 col-sm-offset-3 col-sm-9s""><h2>Perfil</h2></div>
            </div>

            <div class=""row"">
                <div class=""col-md-3 col-sm-3"">
                    <div class=""list-group"">
");
#nullable restore
#line 31 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                          
                            Html.RenderPartial("~/Views/Shared/_Partial_left_navbar.cshtml");
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"col-md-4 col-md-offset-1 col-sm-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e5724120243e20755c4e3c458b501e31d8b84198397", async() => {
                WriteLiteral("\r\n                        <div class=\"form-group loginInputs\">\r\n\r\n                            <p class=\"form-text-view\">");
#nullable restore
#line 40 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                                                 Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                            <p class=\"form-text-view\">");
#nullable restore
#line 42 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                                                 Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <div class=\"form-row\">\r\n\r\n                                <div class=\"form-group col-sm-3\">\r\n\r\n                                    ");
#nullable restore
#line 47 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                               Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n\r\n                                <div class=\"form-group col-sm-3\">\r\n                                    ");
#nullable restore
#line 51 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                               Write(Html.HiddenFor(model => model.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-row\">\r\n\r\n                                ");
#nullable restore
#line 56 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                           Write(Html.Label("Nome"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 57 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                           Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control", placeholder = "Nome", @Value = Model.Name }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 58 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n\r\n\r\n                            </div>\r\n                            <div class=\"form-row\">\r\n\r\n                                ");
#nullable restore
#line 64 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                           Write(Html.Label("Telefone"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 65 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                           Write(Html.TextBoxFor(model => model.Phone, new { @class = "form-control", placeholder = "Telefone", @Value = Model.Phone }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 66 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                            </div>\r\n\r\n\r\n                                <p style=\"font-size:18px; color:red\">");
#nullable restore
#line 70 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"
                                                                Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p>\r\n                                    <input type=\"submit\" value=\"Atualizar\"  class=\"form-control btn-outline-primary\" />\r\n                                </p>\r\n                            </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </fieldset>\r\n");
#nullable restore
#line 80 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Profile.cshtml"

   

    


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Alge.Models.UserProfileModel> Html { get; private set; }
    }
}
#pragma warning restore 1591