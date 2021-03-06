#pragma checksum "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db340407e9543cb11121c2bc756f3653cc127356"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Orders), @"mvc.1.0.view", @"/Views/Admin/Orders.cshtml")]
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
#line 5 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
using Alge.Models.Order;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db340407e9543cb11121c2bc756f3653cc127356", @"/Views/Admin/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c990f32d128001cd17e379d54040adc75a2b0e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
  
    ViewBag.Title = "Pedidos";
    Layout = "~/Views/Shared/_IntraNetLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Pedidos do usuário: ");
#nullable restore
#line 7 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
                   Write(ViewBag.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
<table class=""table table-responsive"">
    <thead>
        <tr>
            <th>ID Pedido</th>
            <th>Valor Pedido</th>
            <th>Status</th>

            <th>Alterar o status</th>
           
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 21 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
         foreach (Order order in ViewBag.orders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr style=\"height:220px;\">\r\n            <td>");
#nullable restore
#line 24 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
           Write(order.id_pedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
           Write(String.Format("R$ {0:N2}", @order.valor_total));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
           Write(order.OrderStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
            <td style=""min-height:230px;"">
                <nav class=""navbar navbar-inverse"">

                    <ul class=""nav navbar-nav"">
                        <li class=""dropdown"">
                            <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">
                                Status

                            </a>
                            <ul class=""dropdown-menu"">
                                <li><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1133, "\"", 1247, 7);
            WriteAttributeValue("", 1143, "ChangeOrderStatus(", 1143, 18, true);
#nullable restore
#line 37 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1161, order.id_pedido, 1161, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1177, ",", 1177, 1, true);
#nullable restore
#line 37 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1178, order.fk_usuario, 1178, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1195, ",", 1195, 1, true);
#nullable restore
#line 37 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1196, Convert.ToInt32(OrderStatus.aguardando_aprovacao), 1196, 50, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1246, ")", 1246, 1, true);
            EndWriteAttribute();
            WriteLiteral(" href=\"#\">Aguardando aprovação de orçamento</a></li>\r\n                                <li><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1340, "\"", 1452, 7);
            WriteAttributeValue("", 1350, "ChangeOrderStatus(", 1350, 18, true);
#nullable restore
#line 38 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1368, order.id_pedido, 1368, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1384, ",", 1384, 1, true);
#nullable restore
#line 38 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1385, order.fk_usuario, 1385, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1402, ",", 1402, 1, true);
#nullable restore
#line 38 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1403, Convert.ToInt32(OrderStatus.orcamento_aprovado), 1403, 48, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1451, ")", 1451, 1, true);
            EndWriteAttribute();
            WriteLiteral(" href=\"#\">Orçamento Aprovado</a></li>\r\n                                <li><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1530, "\"", 1633, 7);
            WriteAttributeValue("", 1540, "ChangeOrderStatus(", 1540, 18, true);
#nullable restore
#line 39 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1558, order.id_pedido, 1558, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1574, ",", 1574, 1, true);
#nullable restore
#line 39 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1575, order.fk_usuario, 1575, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1592, ",", 1592, 1, true);
#nullable restore
#line 39 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1593, Convert.ToInt32(OrderStatus.completed), 1593, 39, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1632, ")", 1632, 1, true);
            EndWriteAttribute();
            WriteLiteral(" href=\"#\">Completado</a></li>\r\n                                <li><a");
            BeginWriteAttribute("onclick", " onclick=\"", 1703, "\"", 1806, 7);
            WriteAttributeValue("", 1713, "ChangeOrderStatus(", 1713, 18, true);
#nullable restore
#line 40 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1731, order.id_pedido, 1731, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1747, ",", 1747, 1, true);
#nullable restore
#line 40 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1748, order.fk_usuario, 1748, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1765, ",", 1765, 1, true);
#nullable restore
#line 40 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
WriteAttributeValue("", 1766, Convert.ToInt32(OrderStatus.cancelado), 1766, 39, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1805, ")", 1805, 1, true);
            EndWriteAttribute();
            WriteLiteral(" href=\"#\">Cancelado</a></li>\r\n                            </ul>\r\n                        </li>\r\n\r\n                    </ul>\r\n\r\n                </nav>\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 51 "C:\git\Oficina-de-Projeto-de-Empresa-1\Alge\Views\Admin\Orders.cshtml"
           
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </tbody>

</table>

<script>
    function ChangeOrderStatus(ID, ID_User, OrderStatus) {
        var Order = {
            id_pedido: ID,
            fk_usuario: ID_User,
            OrderStatus: OrderStatus,
            
           
        };

        $.ajax({
            method: ""POST"",
            url: ""/Admin/ChangeOrderStatus"",
            data: JSON.stringify(Order),
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json""
        })
            .done(function (obj) {
                alert(obj.message);
                window.location.reload();
            });
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
