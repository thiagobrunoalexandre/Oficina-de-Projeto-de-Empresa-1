#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb51671a9aee767c44104053b102023a55384fc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Clientes), @"mvc.1.0.view", @"/Views/Admin/Clientes.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
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
#line 1 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
using Alge.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
using Alge.Models.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb51671a9aee767c44104053b102023a55384fc4", @"/Views/Admin/Clientes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Clientes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
  
    ViewBag.Title = "Clientes";
    Layout = "~/Views/Shared/_IntraNetLayout.cshtml";
    List<UserModel> UsersList = ViewBag.UsersList;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb51671a9aee767c44104053b102023a55384fc44206", async() => {
                WriteLiteral("\r\n    <h4>Digite o email do cliente</h4>\r\n    Email: <input class=\"form-control width-300\" style=\"margin-bottom:10px\" type=\"text\" name=\"SearchEmail\">\r\n\r\n    <br />\r\n\r\n    \r\n    <br />    \r\n");
#nullable restore
#line 21 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
     if(ViewBag.Message != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <p style=\"color:red\" class=\"error-message\">");
#nullable restore
#line 23 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
                                              Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
#nullable restore
#line 24 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <input type=\"submit\" value=\"Buscar\" class=\"btn btn-primary requested\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-responsive"">
    <thead>
        <tr>
            <th>ID usuário</th>
            <th>Email/Login usuário</th>
            <th>Nível Permissão</th>
            <th></th>
            <th></th>
        </tr>
    </thead>

    <tbody>

");
#nullable restore
#line 42 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
         foreach (UserModel user in UsersList ?? Enumerable.Empty<UserModel>())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 45 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
           Write(user.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 46 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
           Write(user.EmailRegister);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 47 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
           Write(user.NivelPermissao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 48 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
           Write(Html.ActionLink("Ver/editar PEDIDOS", "Orders", "Admin", new { id = user.ID }, new { @class = "btn btn-primary", target = "_blank" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 51 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Clientes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
