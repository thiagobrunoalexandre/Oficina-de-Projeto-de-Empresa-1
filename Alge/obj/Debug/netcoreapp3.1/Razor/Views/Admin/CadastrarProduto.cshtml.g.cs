#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a85f59c8687a35c1f7ee06c8621d805e427f62b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CadastrarProduto), @"mvc.1.0.view", @"/Views/Admin/CadastrarProduto.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a85f59c8687a35c1f7ee06c8621d805e427f62b7", @"/Views/Admin/CadastrarProduto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CadastrarProduto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Alge.Models.Produto.Produto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
  
  
    Layout = "~/Views/Shared/_IntraNetLayout.cshtml";
    ViewBag.SearchBar = true;



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""container"">
    <div style=""margin-bottom: 20px;"" class=""row"">
        <div class=""col-md-4 col-md-offset-4""><h2>Cadastrar Produto</h2></div>
    </div>
    <div class=""col-md-12 my-5"">
        <div class=""form-row"">



          
           
            <div class=""form-group col-sm-8"">

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a85f59c8687a35c1f7ee06c8621d805e427f62b74883", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                     using (Html.BeginForm())
                    {

                      


#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"file\" name=\"Image\" class=\"form-control\" />\r\n");
                WriteLiteral("                        <br />\r\n");
#nullable restore
#line 37 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.Label("Nome"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.TextBoxFor(model => model.nome, new { @class = "form-control", placeholder = "Nome", @id = "nome", maxlength = "11" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.ValidationMessageFor(model => model.nome));

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.Label("Descrição"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.TextBoxFor(model => model.descricao, new { @class = "form-control", placeholder = "Descrição", @id = "des", maxlength = "50" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.ValidationMessageFor(model => model.descricao));

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <br />\r\n");
#nullable restore
#line 46 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.Label("Preço"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.TextBoxFor(model => model.preco, new { @class = "form-control", placeholder = "Preço", @id = "pre", maxlength = "10" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                   Write(Html.ValidationMessageFor(model => model.preco));

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <br />\r\n");
                WriteLiteral("                        <p style=\"font-size:30px; color:red\">");
#nullable restore
#line 54 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                                                        Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        <p>\r\n                            <input style=\"max-width:300px;\" type=\"submit\"");
                BeginWriteAttribute("name", " name=\"", 1913, "\"", 1926, 1);
#nullable restore
#line 56 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
WriteAttributeValue("", 1920, Model, 1920, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" value=\"Cadastrar\" class=\"form-control btn-outline-info\" />\r\n                        </p>\r\n");
#nullable restore
#line 58 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\CadastrarProduto.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    
            </div>









        </div>

    </div>
</div>

<script>


    $(document).ready(function () {
        $(""#qtd"").keyup(function () {
            $(""#qtd"").val(this.value.match(/[0-9]*/));
        });
    });
</script>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Alge.Models.Produto.Produto> Html { get; private set; }
    }
}
#pragma warning restore 1591
