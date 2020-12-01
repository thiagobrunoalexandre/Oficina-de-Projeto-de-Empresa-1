using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics;
using System.Threading;
using System.Globalization;

using System.IO;
using System.Text;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Hosting;

using Alge;
using Alge.Models.Checkout;
using Alge.Procedures;
using static CallDB;
using Alge.DAO.Query;
using Alge.Models;
using Alge.Models.Order;

namespace Alge.Controllers
{
    public class CheckoutController : Controller
    {
        

        [ResponseCache(NoStore = true, Duration = 0)]
        [CredentialsFilter(Order = 1)]
        public IActionResult Index()
        {

            Order order = new Order().GetCardUser(AlgeCookieController.UserID);
         
            List<Carrinho> itens = new Carrinho().GetCarrinho(order.id_pedido);




            double total = 0;

            foreach (var item in itens)
            {

                total += item.quantidade_produto * item.valor_produto;

            }

            ViewBag.total = total;
            ViewBag.carrinho = itens;
            return View();


          
        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
           
            using (CallDB db = new CallDB())
            {



                Order order = new Order().GetCardUser(AlgeCookieController.UserID);
                new Carrinho().Update(order.id_pedido);

              

                
            }
            
            
                return RedirectToAction("Orders", "Home");
        }

        private void inserirItems(string pedidoID)
        {

            Cart cart = CartCookieController.ReturnCart();


            for (int i = 0; i < cart.Product.Count; i++)
            {
                List<string> columns = new List<string>();
                List<string> values = new List<string>();

            ListHelper.AddKey(ref columns, ref values, "FK_PRODUTO", cart.Product[i].ProductID.ToString());
            ListHelper.AddKey(ref columns, ref values, "FK_PEDIDO", pedidoID);
            ListHelper.AddKey(ref columns, ref values, "texto_personalizado", cart.Product[i].produtoCartFormat.Texto);
            ListHelper.AddKey(ref columns, ref values, "quantidade", cart.Product[i].produtoCartFormat.Quantidade.ToString());
            ListHelper.AddKey(ref columns, ref values, "valor_total_itens", cart.Product[i].produtoCartFormat.Price.ToString().Replace(",","."));
            ListHelper.AddKey(ref columns, ref values, "preco_produto_unidade", cart.Product[i].produtoCartFormat.PrecoUnitario.ToString().Replace(",","."));

            CallDB db = new CallDB(DBSource.Alge_db);
            bool insert = db.InsertData("itens_pedido", columns, values);

            }
        }
    }

}
