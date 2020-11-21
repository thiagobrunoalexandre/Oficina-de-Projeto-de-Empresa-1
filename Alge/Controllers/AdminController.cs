using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

using Alge.Classes_Cookies;
using System.Security.Cryptography;
using Alge.Models.Admin;
using Alge.Models.Order;

using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Alge.DAO.Query;
using Alge.Procedures;
using Alge.Models;
using Alge.Models.Produto;

namespace Alge.Controllers
{
    public class AdminController : Controller
    {
        private IHostingEnvironment _env;

        public AdminController(IHostingEnvironment env)
        {
            _env = env;
        }

        [AdminCredentialsFilter(Order = 1)]
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            AdminCookieController.ClearSession();
            return View();
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult CadastrarProduto()
        {
            return View();
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult ClientesEmail()
        {
            return View();
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult CadastrarNovoPacote()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            AdminCookieController.ClearSession();
            return RedirectToAction("Index", "Admin");
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult MudarBackgroundHome()
        {
            return View();
        }

        [AdminCredentialsFilter(Order = 1)]
        public ActionResult Clientes()
        {
            return View();
        }
        [HttpPost]
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult Clientes(UserProfileModel _model,
            [FromForm(Name = "SearchEmail")] string searchEmail)
        {
            if (String.IsNullOrEmpty(searchEmail))
            {
                ViewBag.Message = "Preencha pelo menos um dos campos de busca";
                return View();

            }
           
             if (searchEmail != null)
            {
                ViewBag.UsersList = new UsersQuery().ReturnListUserData("email", String.Format("%{0}%", searchEmail));
            }

            return View();
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult Orders(string id)
        {
           
            ViewBag.orders = new Order().GetAllUserOrders(Convert.ToInt32(id));
            ViewBag.UserEmail = new DMLQuery().GetData("email", "usuario", "id_usuario", id);
            ViewBag.UserID = id;

            return View();
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult ChangeOrderStatus([FromBody] Order order)
        {
            bool OrderExist = new DMLQuery().ExistData("pedido", new List<String> { "id_pedido", "fk_usuario" }, new List<String> { order.id_pedido.ToString() , order.fk_usuario.ToString() });
            
            
            
            if (OrderExist)
            {
               
                
                    new DMLQuery().UpdateData("pedido", new List<String> { "fk_status" }, new List<String> { Convert.ToInt32(order.OrderStatus).ToString() }, "id_pedido = " + order.id_pedido);
                    return Json(new { message = "Pedido atualizado" });
               
               
            }
            else
            {
                return Json(new { message = "Pedido não existe" });
            }
        }
        [AdminCredentialsFilter(Order = 1)]
        [HttpGet("/Admin/EditarProduto/{Id}")]
        public IActionResult EditarProduto(int Id)
        {
            Produto model = new UsersQuery().ReturnProdutoDetalhe(Id);
            return View(model);
        }
        [AdminCredentialsFilter(Order = 1)]
        [HttpPost]
        public IActionResult EditarProduto(Produto model, int Id , IList<IFormFile> Imagem)
        {
          


            return RedirectToAction("Produto", "Home");
        }
        [AdminCredentialsFilter(Order = 1)]
        public ActionResult Produto(string idCarrinho = "")
        {

            ViewBag.carrinho = idCarrinho;
            ViewBag.produtos = new UsersQuery().ReturnProdutos();


            return View();
        }

        [AdminCredentialsFilter(Order = 1)]

        public ActionResult Logar(string id, string email)
        {
            AlgeCookieController.UserID = Convert.ToInt32(id);
            AlgeCookieController.UserEmail = email;
            AlgeCookieController.UserStatus = "logado";
            AlgeCookieController.LoggedByAdmin = true;
          
            return RedirectToAction("Profile", "Home");
        }
        [HttpPost]
        public ActionResult Login(UserModelLogin _userModel)
        {
            if (ModelState.IsValid)
            {
                List<string> columns = new List<string>();
                columns.Add("email");

                List<string> values = new List<string>();
                values.Add(_userModel.EmailLogin);

                if (new DMLQuery().ExistData("usuario", columns, values))
                {
                    MD5 md5hash = MD5.Create();
                    string passwordHashed = PasswordProcedures.ToMD5Hash(_userModel.PasswordLogin);

                    if (new UsersQuery().Login(_userModel.EmailLogin, passwordHashed))
                    {
                        var nivel = new DMLQuery().GetData("fk_usuario_tipo", "usuario", "email", _userModel.EmailLogin);

                        if (Convert.ToInt32(nivel) >= 2)
                        { //SE O NIVEL >= 1 O USUARIO TEM PERMISSÃO PARA ACESSAR O INDEX

                            AdminCookieController.AdminID = new UsersQuery().GetUserID(_userModel.EmailLogin); 
                            AdminCookieController.AdminEmail = _userModel.EmailLogin;
                            ModelState.Clear();
                            _userModel = null;
                            return RedirectToAction("Index", "Admin");

                        }
                        else
                        {
                            ViewBag.Message = "Usuário sem permissão";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Usuario ou senha incorreto";
                    }
                }
                else
                {
                    ViewBag.Message = "Usuário Não existe";
                }
            }

            return View(_userModel);

        }

    }
}
