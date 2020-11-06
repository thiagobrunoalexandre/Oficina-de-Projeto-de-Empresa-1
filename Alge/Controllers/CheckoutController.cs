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

namespace Alge.Controllers
{
    public class CheckoutController : Controller
    {
        

        [ResponseCache(NoStore = true, Duration = 0)]
        [CredentialsFilter(Order = 1)]
        public IActionResult Index()
        {
            if (CartCookieController.ReturnCartProductsCount() > 0)
            {
               
            }
            return View(new CheckoutModel { });
        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            Cart cart = CartCookieController.ReturnCart();
            CartCookieController.RefreshCartAmounts();
            using (CallDB db = new CallDB())
            {

                double valorTotal = cart.CartTotalAmount;
                int user = AlgeCookieController.UserID;

                int pedidoID = new UsersQuery(db).RegisterPedido(valorTotal, user);
              

                insetirIntems(pedidoID.ToString());
            }
            
            
                return View();
        }

        private void insetirIntems(string pedidoID)
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
            ListHelper.AddKey(ref columns, ref values, "valor", cart.Product[i].produtoCartFormat.Price.ToString().Replace(",","."));

            CallDB db = new CallDB(DBSource.Alge_db);
            bool insert = db.InsertData("itens_pedido", columns, values);

            }
        }
    }

}
