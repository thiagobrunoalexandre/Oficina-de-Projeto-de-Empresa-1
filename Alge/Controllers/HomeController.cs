using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alge.Models;

using Alge.DAO;
using BancodeImagens.Procedures;

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

        public IActionResult Register()
        {



            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {

                if (model.Exist())
                {
                    using (var db = new CallDB())
                    {
                        db.conexao.Open();

                        var loginModel = new LoginQuery(db).GetLoginModel(model.Email, model.ToMD5Hash(model.Senha)).Result;
                        if (loginModel != null)
                        {
                            AlgeCookieController.LoggedByAdmin = false;
                            AlgeCookieController.UserEmail = model.Email;
                            AlgeCookieController.UserStatus = "logado";
                            AlgeCookieController.UserID = loginModel.ID;
                            return RedirectToAction("Index", "Home");

                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Senha incorreta";
                        }
                    }
                }
                else
                {

                    ViewBag.ErrorMessage = "Usuário não encontrado";
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {

           
            var Validation = model.ValidateRegister();

            if (Validation.valid)
            {
                if (!UserProcedures.EmailExist(model.Email))
                {
                    try
                    {
                        UserProcedures.RegisterUser(model);
                        AlgeCookieController.LoggedByAdmin = false;
                        AlgeCookieController.UserEmail = model.Email;
                        AlgeCookieController.UserStatus = "logado";
                        AlgeCookieController.UserID = model.ID;
                       
                        
                    }
                    catch (Exception e)
                    {
                        ViewBag.MessageRegister = "Ocorreu um erro ao tentar cadastrar, tente novamente ou entre em contato conosco";
                        return View(model);
                    }

                }
                else
                {
                    ViewBag.MessageRegister = "já existe um e-mail castrado";
                    return View(model);
                }
            }
            else
            {
                ViewBag.MessageRegister = Validation.message;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [CredentialsFilter(Order = 1)]
        public IActionResult Profile()
        {
            UserProfileModel model = UserProcedures.GetProfileModel(AlgeCookieController.UserID);
            return View(model);
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
