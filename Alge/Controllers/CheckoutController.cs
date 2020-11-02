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

        //[CredentialsFilter(Order = 1)]
        //public ActionResult CheckoutResult()
        //{
        //    if (TempData["CheckoutResultModel"] != null)
        //    {
        //        CheckoutResultModel checkoutResultModel = (CheckoutResultModel)TempData["CheckoutResultModel"];
        //        if (checkoutResultModel.CheckoutResultStatus == Classes_Enum.CheckoutResultStatus.awaiting_billing_data)
        //        {
        //            CartCookieController.ClearCartItens();
        //            TempData["CheckoutResultModel"] = checkoutResultModel;
        //            return RedirectToAction("Billing", "Usuario");
        //        }
        //        else if (checkoutResultModel.CheckoutResultStatus == Classes_Enum.CheckoutResultStatus.awaiting_payment)
        //        {
        //            CartCookieController.ClearCartItens();
        //            return RedirectToAction("Orders", "Usuario", new { BillingInserted = true });
        //        }
        //        else
        //        {
        //            CartCookieController.ClearCartItens();

        //            Order order = new Order().GetOrder(checkoutResultModel.OrderID.ToString());
        //            if (order.ProductsType == ProductsType.singleImage)
        //            {
        //                return RedirectToAction("Orders", "Usuario", new { BillingInserted = true, RedirectOrderID = checkoutResultModel.OrderID });
        //            }
        //            else
        //            {
        //                return RedirectToAction("Orders", "Usuario", new { Succes = true });
        //            }

        //            return RedirectToAction("Orders", "Usuario", new { Succes = true });
        //        }
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        


        

       
    }

}
