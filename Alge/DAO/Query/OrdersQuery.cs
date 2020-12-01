
using Alge.Models;
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
            comm.CommandText = String.Format("SELECT * FROM pedido where fk_usuario = {0} and fk_status <> 5 Order by id_pedido desc ;", UserID);
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
        public Order ReturnOrderCart(int UserID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM pedido where fk_usuario = {0} and fk_status = {1};", UserID , "5");//carrinho
            try
            {
                db.conexao.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    Order order = new Order();

                    while (reader.Read())
                    {


                        try
                        {
                            order = new Order()
                            {
                                id_pedido = reader.GetInt32("id_pedido"),
                                data_pedido = reader.GetDateTime("data_pedido"),
                                fk_usuario = reader.GetInt32("fk_usuario"),
                          
                                OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader.GetString("fk_status"))

                            };
                        }
                        catch (Exception e)
                        {
                        }

                    };
                    return order;
                };
            }
            catch(Exception e)
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
        public List<Carrinho> ReturnIntensCarrinho(int PedidoID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM itens_pedido where FK_PEDIDO = {0} Order by ID desc ;", PedidoID);
            try
            {
                db.conexao.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    List<Carrinho> orders = new List<Carrinho>();


                    while (reader.Read())
                    {
                        try
                        {
                            orders.Add(new Carrinho()
                            {
                                idItem = reader.GetInt32("ID"),
                                Id_produto = reader.GetInt32("FK_PRODUTO"),
                                texto_personalizado = reader.GetString("texto_personalizado"),
                                quantidade_produto =  reader.GetInt32("quantidade"),
                                valor_produto = reader.GetDouble("preco_produto_unidade"),
                             

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
        public int DeleteIntenCarrinho(int itemID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("Delete from itens_pedido where ID = @itemID;");
            comm.Parameters.AddWithValue("@itemID", itemID);

            try
            {
                db.conexao.Open();
                comm.ExecuteNonQuery();
                return 1;
            }
            catch
            {

                return 0;
            }
            finally
            {
                db.conexao.Close();
            }

        } 
        public int ReturnItensCard(int PedidoID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT count(*) FROM itens_pedido where FK_PEDIDO = {0} ", PedidoID);
            try
            {
                db.conexao.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {


                    reader.Read();

                    return reader.GetInt32(0); 
                };
            }
            catch
            {

                return 0;
            }
            finally
            {
                db.conexao.Close();
            }

        }

    }
}
