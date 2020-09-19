using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alge.Models;
using Alge.Performance;
using Alge.DAO;

namespace Alge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpPost]
        public IActionResult Login(LoginRegisterModel model, string fr, string redirectUrl)
        {

            if (fr == "1") // LOGIN
            {

                var Validation = model.ValidateLogin();

                if (Validation.valid)
                {
                    model.Login();

                    if (model.Login_SuccessFull)
                    {
                        AlgeCookieController.LoggedByAdmin = false;
                        AlgeCookieController.UserEmail = model.Login_Email;
                        AlgeCookieController.UserStatus = "logado";
                        AlgeCookieController.UserID = model.ID;





                        if (String.IsNullOrEmpty(redirectUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return Redirect(redirectUrl);
                        }
                    }
                    else
                    {
                        ViewBag.MessageLogin = "Email ou senha INCORRETO!";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.MessageLogin = Validation.message;
                    return View(model);
                }
            }
            else if (fr == "2")//REGISTRO
            {
                /*
                var Validation = model.ValidateRegister();

                if (Validation.valid)
                {
                    if (!UserProcedures.EmailExist(model.Register_Email))
                    {
                        try
                        {
                            UserProcedures.RegisterUser(model);
                            UserCustomerCookieController.LoggedByAdmin = false;
                            UserCustomerCookieController.UserEmail = model.Register_Email;
                            UserCustomerCookieController.UserStatus = "logado";
                            UserCustomerCookieController.UserID = model.ID;
                            UserCustomerCookieController.ContributorEnabled = false;
                            EmailProcedures.SendRegisterEmail(model.Register_Email, model.ID.ToString(), model.Register_Name);
                        }
                        catch (Exception e)
                        {
                            ViewBag.MessageRegister = "Ocorreu um erro ao tentar cadastrar, tente novamente ou entre em contato conosco";
                            return View(model);
                        }

                    }
                    else
                    {
                        ViewBag.MessageRegister = MainMessages.email_already_in_use;
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.MessageRegister = Validation.message;
                    return View(model);
                }
                //_IMPLEMENTAR_  SubscriptionCookieController.LoadSubscriptionsFromDB();
                if (String.IsNullOrEmpty(redirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(redirectUrl);
                }
            }*/
                return View();
            }
            return View();
        }
        public ActionResult LogOut()
        {
            AlgeCookieController.ClearSession();
          
            return RedirectToAction("Index", "Home");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
