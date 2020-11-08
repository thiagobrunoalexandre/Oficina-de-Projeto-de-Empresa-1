﻿
using Alge.Models.ItensPedido;
using Alge.Models.Order;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.DAO.Query
{
    public class OrdersQuery
    {
        public CallDB db;

        public OrdersQuery(CallDB db)
        {
            this.db = db;
        }
        public OrdersQuery()
        {
            this.db = new CallDB();
        }

        public List<Order> ReturnOrders(int UserID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM pedido where fk_usuario = {0} Order by id_pedido desc ;", UserID);
            try
            {
                db.conexao.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    List<Order> orders = new List<Order>();


                    while (reader.Read())
                    {
                        try
                        {
                            orders.Add(new Order()
                            {
                                id_pedido = reader.GetInt32("id_pedido"),
                                data_pedido = reader.GetDateTime("data_pedido"),
                                fk_usuario = reader.GetInt32("fk_usuario"),
                                valor_total = reader.GetDouble("valor_total"),
                                OrderStatus  = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader.GetString("fk_status"))

                            });
                        }
                        catch (Exception e)
                        {
                        }
                    };

                    return orders;
                };
            }
            catch
            {

                return null;
            }
            finally
            {
                db.conexao.Close();
            }

        }
        public List<ItensPedido> ReturnItensPedido(int PedidoID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM itens_pedido where FK_PEDIDO = {0} Order by ID desc ;", PedidoID);
            try
            {
                db.conexao.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    List<ItensPedido> orders = new List<ItensPedido>();


                    while (reader.Read())
                    {
                        try
                        {
                            orders.Add(new ItensPedido()
                            {
                                ID = reader.GetInt32("ID"),
                                FK_PRODUTO = reader.GetInt32("FK_PRODUTO"),
                                FK_PEDIDO = reader.GetInt32("FK_PEDIDO"),
                                texto_personalizado = reader.GetString("texto_personalizado"),
                                quantidade =  reader.GetInt32("quantidade"),
                                valor = reader.GetDouble("valor_total_itens"),
                                precoProduto = reader.GetDouble("preco_produto_unidade"),

                            });
                        }
                        catch (Exception e)
                        {
                        }
                    };

                    return orders;
                };
            }
            catch
            {

                return null;
            }
            finally
            {
                db.conexao.Close();
            }

        }

    }
}