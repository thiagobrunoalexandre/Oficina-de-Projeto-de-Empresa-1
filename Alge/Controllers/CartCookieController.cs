using Alge;
using Alge.Models;
using Alge.DAO.Query;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Alge.Procedures;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Alge.Models.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Alge
{
    public static class CartCookieController
    {
        const string CART_KEY = "CART";

        public static Cart ReturnCart()
        {
            Cart cart = AppHttpContext.Current.Session.GetString(CART_KEY) != null ? JsonConvert.DeserializeObject<Cart>(AppHttpContext.Current.Session.GetString(CART_KEY)) : new Cart();
            return cart;
        }

        public static bool AddCartItem(Produto produto,double preco,int quantidade,string imagem , string texto)//CARRINHO 
        {
           
            Cart cart = ReturnCart() != null ? ReturnCart() : new Cart();
            if (!ReturnCart().Product.Exists(p => p.produtoCartFormat.ProdutoID == produto.id_produto.ToString() && p.produtoCartFormat.Texto == texto ))
            {

                cart.Product.Add(new Product(produto, preco , quantidade, imagem,texto));
                AppHttpContext.Current.Session.SetString(CART_KEY, JsonConvert.SerializeObject(cart));
                
                RefreshCartAmounts();
                return true;
            }
            return false;
        }
        public static void ClearCartItens()
        {
            AppHttpContext.Current.Session.SetString(CART_KEY, JsonConvert.SerializeObject(new Cart()));
        }
        public static void ClearSubscriptionItens()
        {
            Cart cart = ReturnCart();

            AppHttpContext.Current.Session.SetString(CART_KEY, JsonConvert.SerializeObject(cart));
            RefreshCartAmounts();
        }
        public static void RemoveCartItem(string ProductCartUniqueID)
        {
            Cart cart = ReturnCart();
            cart.Product.RemoveAll(i => i.ProductCartUniqueKey == ProductCartUniqueID);
            AppHttpContext.Current.Session.SetString(CART_KEY, JsonConvert.SerializeObject(cart));
            RefreshCartAmounts();
        }
        public static void RefreshCartAmounts()
        {
            Cart cart = ReturnCart();
            cart.CartSubTotalAmout = cart.Product.Sum(v => v.produtoCartFormat.Price);
            cart.CartTotalAmount = cart.CartSubTotalAmout;
          
            AppHttpContext.Current.Session.SetString(CART_KEY, JsonConvert.SerializeObject(cart));
        }
        public static int ReturnCartProductsCount()
        {
            return ReturnCart().Product.Count;
        }

    }

    public class Cart
    {
        public List<Product> Product { get; set; }

        public Double CartTotalAmount { get; set; }
        public Double CartSubTotalAmout { get; set; }
        public Double CartFeeAmount { get; set; }
        public Double CartDiscountAmount { get; set; }
        public Double FeePercentage { get; set; }


        public Cart()
        {
            Product = new List<Product>();
        }
    }
    public class Product
    {

        public string ProductCartUniqueKey { get; set; }
        public int ProductID { get; set; }
        //Essa propriedade cria uma descrição completa do produto a ser comprado em relação a lingua que está sendo utilizada
        
        
        public ProdutoCartFormat produtoCartFormat { get; set; }//Used just when the product type is a image
       
        public Product()
        {



        }



        public Product(Produto produto, double price, int quantidade,string imagem, string texto)//Produto
        {
            // using (CallDB db = new CallDB())
            // {
            //   this.ProductID = Convert.ToInt32(new DMLQuery(db).GetData("ID_Preco", "VIEW_Preco", "ID_PLANOS_Pacotes", image.SelectedResolutionCode.ToString()));
            //}
            this.ProductID = produto.id_produto;
            this.ProductCartUniqueKey = Convert.ToString(Guid.NewGuid());
            this.produtoCartFormat = new ProdutoCartFormat(produto, price, quantidade , imagem,texto);


        }
    }
    public class ProdutoCartFormat
    {
        public string ProdutoID { get; set; }

        public int Quantidade { get; set; }
        public string DataBaseOrigin { get; set; }
        public string Imagem { get; set; }
        public string Texto { get; set; }
        public Double Price { get; set; }  
        public Double PrecoUnitario { get; set; }



        public ProdutoCartFormat()
        {
            this.ProdutoID = "0";


        }

        public ProdutoCartFormat(Produto produto , double price,int quantidade ,string imagem,string texto)
        {
           
            this.ProdutoID = produto.id_produto.ToString();
            this.PrecoUnitario = price;
            this.Price = price * quantidade;
            this.Imagem = imagem;
            this.Texto = texto;
            this.Quantidade = quantidade;


        }

    }
   




        public enum ProductsType
        {
            subscription,
            singleImage
        }
        public enum SubscriptionType
        {
            mensal,
            diario,
            anual
        }
    
}