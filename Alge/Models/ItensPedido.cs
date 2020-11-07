
using Alge.DAO.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.ItensPedido
{
    public class ItensPedido
    {
        public int ID { get; set; }
        public int FK_PRODUTO { get; set; }
        public int FK_PEDIDO { get; set; }  
        public String nome { get; set; }
        public  String texto_personalizado { get; set; }
        public int quantidade { get; set; }
        public Double valor { get; set; }
        public Double precoProduto { get; set; }

        public String imagem { get; set; }


        public List<ItensPedido> GetItensPedido(int produtoID)
        {


            List<ItensPedido> itens = new OrdersQuery().ReturnItensPedido(produtoID);
            
            return itens;
        }


    }


}
