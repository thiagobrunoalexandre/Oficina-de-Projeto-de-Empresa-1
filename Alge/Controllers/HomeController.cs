﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alge.Models;

using Alge.DAO;

using Microsoft.AspNetCore.Http;
using Alge.DAO.Query;
using Alge.Models.Produto;
using Alge.Procedures;
using Alge.Models.Order;
using Alge.Models.ItensPedido;

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

        [CredentialsFilter(Order = 1)]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [CredentialsFilter(Order = 1)]
        public IActionResult ChangeEmail()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [CredentialsFilter(Order = 1)]
        [HttpPost]
        public IActionResult ChangeEmail(ChangeEmailModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserProcedures.EmailExist(model.NewEmail))
                {
                    ViewBag.Message = "O email já esta em uso";
                    return View();
                }
                else
                {
                    UserProcedures.ChangeEmail(AlgeCookieController.UserEmail, model.NewEmail, AlgeCookieController.UserID.ToString());
                    ViewBag.Message = "Email atualizado com sucesso";
                    AlgeCookieController.UserEmail = model.NewEmail;
                    return View();
                }
            }
            else
            {
                return View(model);
            }

        }
        [CredentialsFilter(Order = 1)]
        public IActionResult RemoverCartItem(int id)
        {
            CartCookieController.RemoveCartItem(id);
            return RedirectToAction("Index", "Checkout");
        }

        [CredentialsFilter(Order = 1)]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
             if (ModelState.IsValid)
            {
                UserProcedures.ChangePassword(model.NewPassword, AlgeCookieController.UserID);
                ViewBag.Message = "Senha alterada com sucesso!!";
                return View();
            }
            else
            {
                return View(model);
            }
        }
            [HttpPost]
        public IActionResult RecoveryPassword(UserModelRecovery model)
        { 
        
        return null;
        }

        [CredentialsFilter(Order = 1)]
        public ActionResult Orders()
        {
            
            
            List<Order> orders = new Order().GetAllUserOrders(AlgeCookieController.UserID);

           


            ViewBag.orders = orders;
        

            return View();
        }
        [CredentialsFilter(Order = 1)]
        public ActionResult ItensPedido(int id)
        {
            List<ItensPedido> itens = new ItensPedido().GetItensPedido(id);


            ViewBag.pedido = id;
            ViewBag.itensPedido = itens;
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
        [HttpGet("/Home/Detalhe/{Id}")]
        [CredentialsFilter(Order = 1)]
        public IActionResult Detalhe(int Id)
        {
            ViewBag.produtos = new UsersQuery().ReturnProdutosDetalhe(Id);
            return View(); 
        }

        [HttpPost]
        [CredentialsFilter(Order = 1)]
        public IActionResult Detalhe(Carrinho model, int Id, int quantidade)
        {

          
            
                Produto produto = new Produto();
                produto.texto_personalizado = model.texto_personalizado;
                produto.id_produto = Id;
                var itens = new UsersQuery().ReturnProdutos(Id);
                List<string> columns = new List<string>();
                List<string> values = new List<string>();



                ListHelper.AddKey(ref columns, ref values, "fk_usuario", AlgeCookieController.UserID.ToString());
                ListHelper.AddKey(ref columns, ref values, "fk_status", "5");//5 carrinho

                bool retorno = new DMLQuery(new CallDB()).ExistData("pedido", columns, values);

                if (retorno == false)
                {
                    int user = AlgeCookieController.UserID;
                    using (CallDB db = new CallDB())
                    {
                        int pedidoID = new UsersQuery(db).RegisterCart(user);

                        inserirItems(model,quantidade, pedidoID.ToString(), itens.preco, itens.id_produto);

                    }
                    return RedirectToAction("Produto", "Home", new { idCarrinho = "" });
                }
                else
                {

                    Order order = new Order().GetCardUser(AlgeCookieController.UserID);

                    inserirItems(model,quantidade, order.id_pedido.ToString(), itens.preco, itens.id_produto);

                    return RedirectToAction("Produto", "Home", new { idCarrinho = "" });
                }
            
           
        }
        private void inserirItems(Carrinho model , int quantidade,  string pedidoID ,double preco,int idproduto)
        {
            List<string> columns = new List<string>();
            List<string> values = new List<string>();

            ListHelper.AddKey(ref columns, ref values, "FK_PRODUTO", idproduto.ToString());
            ListHelper.AddKey(ref columns, ref values, "FK_PEDIDO", pedidoID.ToString());
            ListHelper.AddKey(ref columns, ref values, "texto_personalizado", model.texto_personalizado);
            ListHelper.AddKey(ref columns, ref values, "quantidade", quantidade.ToString());
            ListHelper.AddKey(ref columns, ref values, "preco_produto_unidade", preco.ToString().Replace(',','.'));

            using (CallDB db = new CallDB())
            {
                bool insert = db.InsertData("itens_pedido", columns, values);

            }

        }

            public ActionResult Produto(string  idCarrinho = "")
        {
            
            ViewBag.carrinho = idCarrinho;
            ViewBag.produtos = new UsersQuery().ReturnProdutos();


            return View();
        }


        [CredentialsFilter(Order = 1)]
        [HttpPost]
        public IActionResult Profile(UserProfileModel model)
        {
            model.Update();

            return View(model);
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
        [CredentialsFilter(Order = 1)]
        public IActionResult Faturamento()
        {
            RegisterModel model = UserProcedures.GetDadosFaturamento(AlgeCookieController.UserID);
            return View(model);

        }
        [CredentialsFilter(Order = 1)]
        [HttpPost]
        public IActionResult Faturamento(RegisterModel model)
        {
            var Validation = model.ValidateFaturamento();

            if (Validation.valid)
            {

                var dadosFaturamento = UserProcedures.RegisterFaturamento(model, AlgeCookieController.UserID);


                return View(dadosFaturamento);
            }
            else
            {
                ViewBag.MessageRegister = Validation.message;
                return View(model);

            }


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
