#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29c9cf9b2652619617211b01eb7f6c0899857e11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ItensPedido), @"mvc.1.0.view", @"/Views/Home/ItensPedido.cshtml")]
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
#line 8 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
using Alge.Models.ItensPedido;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29c9cf9b2652619617211b01eb7f6c0899857e11", @"/Views/Home/ItensPedido.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ItensPedido : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
  

    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.SearchBar = true;
    List<ItensPedido> itens = (List<ItensPedido>)ViewBag.itensPedido;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\">\r\n    <div style=\"margin-bottom: 20px;\" class=\"row\">\r\n        <div class=\"col-md-4 col-md-offset-4\"><h2>Itens do pedido ");
#nullable restore
#line 13 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                                             Write(ViewBag.pedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2></div>\r\n    </div>\r\n    \r\n\r\n\r\n\r\n\r\n\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <div class=\"list-group\">\r\n");
#nullable restore
#line 25 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                  
                    Html.RenderPartial("~/Views/Shared/_Partial_left_navbar.cshtml");
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n      \r\n        <div class=\"col-md-6 col-md-offset-1\">\r\n");
#nullable restore
#line 32 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
             foreach (ItensPedido item in itens)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-3\" style=\"padding-left:10px\">\r\n\r\n                    <div class=\"card my-5 \" style=\"width: 18rem;\">\r\n\r\n\r\n\r\n                        <div class=\"card-body\">\r\n\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1011, "\"", 1029, 1);
#nullable restore
#line 43 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
WriteAttributeValue("", 1017, item.imagem, 1017, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" runat=\"server\" style=\"max-width:200px; max-height:120px\" />\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 44 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                              Write(item.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n\r\n                            <p>Código do produto ");
#nullable restore
#line 47 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                            Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>preço unitario  ");
#nullable restore
#line 48 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                          Write(String.Format("R$ {0:N2}", @item.precoProduto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>Personalização ");
#nullable restore
#line 49 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                         Write(item.texto_personalizado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>Quantidade ");
#nullable restore
#line 50 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                     Write(item.quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>Total ");
#nullable restore
#line 51 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"
                                Write(String.Format("R$ {0:N2}", @item.valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 59 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Home\ItensPedido.cshtml"



            
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "29c9cf9b2652619617211b01eb7f6c0899857e118145", async() => {
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