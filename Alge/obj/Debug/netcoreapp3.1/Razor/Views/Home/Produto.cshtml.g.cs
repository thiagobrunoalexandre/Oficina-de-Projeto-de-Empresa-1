#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49b4446bd77f527bbadf98ff050a0bc43d9c4a89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Produto), @"mvc.1.0.view", @"/Views/Home/Produto.cshtml")]
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
#line 8 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
using Alge.Models.Produto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49b4446bd77f527bbadf98ff050a0bc43d9c4a89", @"/Views/Home/Produto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Produto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/script.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
  

    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.SearchBar = true;
    List<Produto> Produtos = (List<Produto>)ViewBag.produtos;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\">\r\n    <div style=\"margin-bottom: 20px;\" class=\"row\">\r\n        <div class=\"col-md-4 col-md-offset-4\"><h2>Produtos</h2></div>\r\n    </div>\r\n    \r\n\r\n\r\n\r\n\r\n\r\n\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 23 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
         if (ViewBag.carrinho == "")
        {


        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-12\">\r\n                <p>");
#nullable restore
#line 31 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
              Write(Html.Raw(@String.Format("Produto foi adicionado ao carrinho")));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 628, "\"", 666, 1);
#nullable restore
#line 32 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
WriteAttributeValue("", 635, Url.Action("Index","Checkout"), 635, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control btn-outline-info\">\r\n                    Ir para o carrinho \r\n                </a>\r\n            </div>\r\n");
#nullable restore
#line 36 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"

        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
         foreach (Produto produto in Produtos)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3\" style=\"padding-left:10px\">\r\n\r\n                <div class=\"card my-5 \" style=\"width: 18rem;\">\r\n\r\n\r\n\r\n                    <div class=\"card-body\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1070, "\"", 1110, 2);
            WriteAttributeValue("", 1077, "/Home/Detalhe/", 1077, 14, true);
#nullable restore
#line 48 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
WriteAttributeValue("", 1091, produto.id_produto, 1091, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1146, "\"", 1167, 1);
#nullable restore
#line 49 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
WriteAttributeValue("", 1152, produto.imagem, 1152, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" runat=\"server\" style=\"max-width:200px; max-height:120px\" />\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 50 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
                                              Write(produto.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n\r\n                            <p>Cod: ");
#nullable restore
#line 53 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
                               Write(produto.id_produto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>");
#nullable restore
#line 54 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
                          Write(produto.descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>Preço ");
#nullable restore
#line 55 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
                                Write(String.Format("R$ {0:N2}", @produto.preco));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>Categoria ");
#nullable restore
#line 56 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"
                                    Write(produto.categoria);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n                        </a>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 65 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\Produto.cshtml"




        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49b4446bd77f527bbadf98ff050a0bc43d9c4a898637", async() => {
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
