
using Alge.DAO.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.Order
{
    public class Order
    {
        public int id_pedido { get; set; }
       
        public DateTime data_pedido { get; set; }
        public int fk_usuario { get; set; }
        public double valor_total { get; set; }
       
        public int fk_status { get; set; }



        public OrderStatus OrderStatus { get; set; }


        public List<Order> GetAllUserOrders(int userID)
        {
            

            List<Order> Orders = new OrdersQuery().ReturnOrders(userID);

            return Orders;
        }

    }


    public class OrderProduct
    {
        public String Description { get; set; }
        public String ID { get; set; }
        public Double Value { get; set; }
    }

    public enum OrderStatus
    {
        Aguarando_aprovacao = 1,
        completed = 2,
        cancelado = 3,
        payment_denied = 4,
        awaiting_billing_data = 5
    }

}
