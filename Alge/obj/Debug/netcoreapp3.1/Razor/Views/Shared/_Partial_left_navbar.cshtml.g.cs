#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Shared\_Partial_left_navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27de9cad58750a1c95fa2044ad98b98232479378"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Partial_left_navbar), @"mvc.1.0.view", @"/Views/Shared/_Partial_left_navbar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27de9cad58750a1c95fa2044ad98b98232479378", @"/Views/Shared/_Partial_left_navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Partial_left_navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 3 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Shared\_Partial_left_navbar.cshtml"
Write(Html.ActionLink("Perfil", "Profile", "Home", null, new { @class = "list-group-item list-group-item-guarana-style", @style = "width:100%;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Shared\_Partial_left_navbar.cshtml"
Write(Html.ActionLink("Alterar a senha", "ChangePassword", "Home", null, new { @class = "list-group-item  list-group-item-guarana-style" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Shared\_Partial_left_navbar.cshtml"
Write(Html.ActionLink("Alterae o email", "ChangeEmail", "Home", null, new { @class = "list-group-item  list-group-item-guarana-style" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Shared\_Partial_left_navbar.cshtml"
Write(Html.ActionLink("Pedidos", "Orders", "Usuario", null, new { @class = "list-group-item list-group-item-guarana-style" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<style>\r\n    .list-group-submenu .list-group-item {\r\n        padding-left: 30px;\r\n    }\r\n\r\n    .list-group-item-buttom[aria-expanded=\"true\"] {\r\n        background-color: #e3e3e3;\r\n    }\r\n</style>\r\n");
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
