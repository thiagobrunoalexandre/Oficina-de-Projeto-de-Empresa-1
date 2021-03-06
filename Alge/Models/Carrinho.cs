﻿

using Alge.DAO.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models
{
    public class Carrinho
    {
        //ID

        public int idItem { get; set; }
        public int Id_produto { get; set; }
        public String nome_produto { get; set; }
     
        public String descricao_produto { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "double(18, 2)")]
        public double valor_produto  { get; set; }

        public String texto_personalizado { get; set; }
        public String imagemProduto { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Display(Name = "Quantidade")]
        public int quantidade_produto { get; set; }



        public List<Carrinho> GetCarrinho(int pedido)
        {


            List<Carrinho> itens = new OrdersQuery().ReturnIntensCarrinho(pedido);

            return itens;
        }

        public int DeletarIntemCarrinho(int Iditem)
        {


            int  delete = new OrdersQuery().DeleteIntenCarrinho(Iditem);

            return delete;
        }
        public void Update(int id)
        {
            using (CallDB db = new CallDB())
            {

                new UsersQuery(db).UpdatePedido(id);



            }
        }
    }

    
    
}