using Alge.Models;
using Alge.Models.Produto;
using Alge.Procedures;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static CallDB;

namespace Alge.DAO.Query
{
    public class UsersQuery
    {
        public CallDB db;

        public UsersQuery(CallDB db)
        {
            this.db = db;
        }
        public UsersQuery()
        {
            this.db = new CallDB();
        }

        public int RegisterUser(RegisterModel model)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("INSERT INTO usuario(nome ,email,password_hash, DataInsercao , telefone ,fk_usuario_tipo ) VALUES('{0}', '{1}', '{2}','{3}','{4}','{5}'); SELECT LAST_INSERT_ID() as ID",model.Name , model.Email, model.Register_PasswordHash, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), model.MobilePhone , 1);// 1 usuario comum

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetInt32("ID");

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                db.conexao.Close();
            }
        }
        public int RegisterPedido(double valorTotal,int user)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("INSERT INTO pedido(data_pedido ,fk_usuario,valor_total, fk_status ) VALUES('{0}', '{1}', '{2}','{3}'); SELECT LAST_INSERT_ID() as ID",  DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), user,valorTotal.ToString().Replace(',', '.'),1);// 1 staus 1 aguardando aprovação

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetInt32("ID");

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                db.conexao.Close();
            }
        }
        public void UpdateProfile(UserProfileModel model)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "UPDATE usuario set nome = @nome, telefone = @telefone  WHERE id_usuario = @id_usuario";

            comm.Parameters.AddWithValue("@nome", model.Name);
            comm.Parameters.AddWithValue("@telefone", model.Phone);
            comm.Parameters.AddWithValue("@id_usuario", model.Id);
          

            try
            {
                db.conexao.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                db.conexao.Close();
            }
        }
        public void UpdateDadosFaturamento(RegisterModel model, int ID_usuario)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "UPDATE usuario_fatuamento set endereco = @endereco, numero_endereco = @numero_endereco ,complemento_endereco = @complemento_endereco  ,cidade  = @cidade ,estado = @estado , cep = @cep , cpf = @cpf WHERE fk_usuario = @fk_usuario";


            comm.Parameters.AddWithValue("@fk_usuario", ID_usuario);
            comm.Parameters.AddWithValue("@endereco", model.endereco); 
            comm.Parameters.AddWithValue("@numero_endereco", model.numero_endereco);
            comm.Parameters.AddWithValue("@complemento_endereco", model.complemento);
            comm.Parameters.AddWithValue("@cidade", model.cidade);
            comm.Parameters.AddWithValue("@estado", model.estado);
            comm.Parameters.AddWithValue("@cep", model.cep);   
            comm.Parameters.AddWithValue("@cpf", model.cpf);


            try
            {
                db.conexao.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                db.conexao.Close();
            }
        }
        public void inserirFaturamento(RegisterModel model, int ID_usuario)
        {

           

                List<string> columns = new List<string>();
                List<string> values = new List<string>();

                ListHelper.AddKey(ref columns, ref values, "fk_usuario", ID_usuario.ToString());
                ListHelper.AddKey(ref columns, ref values, "endereco", model.endereco);
                ListHelper.AddKey(ref columns, ref values, "numero_endereco", model.numero_endereco);
                ListHelper.AddKey(ref columns, ref values, "complemento_endereco", model.complemento);
                ListHelper.AddKey(ref columns, ref values, "cidade",model.cidade);
                ListHelper.AddKey(ref columns, ref values, "estado", model.estado); 
                ListHelper.AddKey(ref columns, ref values, "cep", model.cep);
                ListHelper.AddKey(ref columns, ref values, "cpf", model.cpf.ToString());

                CallDB db = new CallDB(DBSource.Alge_db);
                db.InsertData("usuario_fatuamento", columns, values);

               
            
        }
        public List<Produto> ReturnProdutos()
        {
           
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM produto ;");
            try
                {
                    db.conexao.Open();
                    using (MySqlDataReader reader = comm.ExecuteReader())
                    {
                        List<Produto> produtos = new List<Produto>();


                        while (reader.Read())
                        {
                            try
                            {
                                produtos.Add(new Produto()
                                {
                                    id_produto = reader.GetInt32("idProduto"),
                                    nome = reader.GetString("nome"),
                                    quantidade = reader.GetInt32("quantidade"),
                                    descricao = reader.GetString("descricao"),
                                    preco = reader.GetDouble("preco"),
                                    categoria = reader.GetInt32("fk_categoria"),
                                    imagem = reader.GetString("imagem_url"),
                                });
                            }
                            catch (Exception e)
                            {
                            }
                        };

                        return produtos;
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

        public List<Produto> ReturnProdutosDetalhe(int id )
        {

            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM produto WHERE idProduto = {0};", id);
            try
            {
                db.conexao.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    List<Produto> produtos = new List<Produto>();


                    while (reader.Read())
                    {
                        try
                        {
                            produtos.Add(new Produto()
                            {
                                id_produto = reader.GetInt32("idProduto"),
                                nome = reader.GetString("nome"),
                                quantidade = reader.GetInt32("quantidade"),
                                descricao = reader.GetString("descricao"),
                                preco = reader.GetDouble("preco"),
                                categoria = reader.GetInt32("fk_categoria"),
                                imagem = reader.GetString("imagem_url"),
                            });
                        }
                        catch (Exception e)
                        {
                        }
                    };

                    return produtos;
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
        public Produto ReturnProdutos(int id)
        {


            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM produto WHERE idProduto = {0};", id);
            try
            {
               
                
                  

                    db.conexao.Open();
                    using (MySqlDataReader reader = comm.ExecuteReader())
                    {
                        reader.Read();
                        return new Produto
                        {
                            id_produto = reader.GetInt32("idProduto"),
                            nome = reader.GetString("nome"),
                            quantidade = reader.GetInt32("quantidade"),
                            descricao = reader.GetString("descricao"),
                            preco = reader.GetDouble("preco"),
                            categoria = reader.GetInt32("fk_categoria"),
                            imagem = reader.GetString("imagem_url"),
                        };
                    }
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro na consulta GetPoolObjects: {0}", e.Message);
                return null;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }



        }
        public UserProfileModel GetProfile(int userID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT * FROM usuario WHERE id_usuario = @id ;");
            comm.Parameters.AddWithValue("@id", userID);

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                List<UserProfileModel> listProfile = new List<UserProfileModel>();
                reader.Read();

                return new UserProfileModel
                {
                    Id = Convert.ToInt32(reader["id_usuario"]),
                    Name = Convert.ToString(reader["nome"]),
                    Email = Convert.ToString(reader["email"]),
                    Phone = Convert.ToString(reader["telefone"]),
                  
                 
                   
                };
            }
            catch (Exception e)
            {
                return new UserProfileModel();
            }
            finally
            {
                db.conexao.Close();
            }
        }
        public RegisterModel GetFaturamento(int userID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT * FROM usuario_fatuamento WHERE fk_usuario = @id ;");
            comm.Parameters.AddWithValue("@id", userID);

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                List<RegisterModel> listProfile = new List<RegisterModel>();
                reader.Read();

                return new RegisterModel
                {
                    endereco = Convert.ToString(reader["endereco"]),
                    numero_endereco = Convert.ToString(reader["numero_endereco"]),
                    complemento = Convert.ToString(reader["complemento_endereco"]),
                    cidade = Convert.ToString(reader["cidade"]),
                    estado = Convert.ToString(reader["estado"]),
                    cep = Convert.ToString(reader["cep"]),
                    cpf = Convert.ToString(reader["cpf"]),


                };
            }
            catch (Exception e)
            {
                return new RegisterModel();
            }
            finally
            {
                db.conexao.Close();
            }
        }













        public int GetUserID(string login_Email)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT * FROM CLIENTES_User WHERE CLIENTES_User_email = @CLIENTES_User_email");
            comm.Parameters.AddWithValue("@CLIENTES_User_email", login_Email);
            try
            {
                db.conexao.Open();

                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetInt32("ID_CLIENTES_User");

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                db.conexao.Close();
            }
        }

        public string GetUserEmail(int userID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT CLIENTES_User_email FROM CLIENTES_User WHERE ID_CLIENTES_User = @ID_CLIENTES_User");
            comm.Parameters.AddWithValue("@ID_CLIENTES_User", userID);
            try
            {
                db.conexao.Open();

                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetString("CLIENTES_User_email");

            }
            catch (Exception e)
            {
                return "not found";
            }
            finally
            {
                db.conexao.Close();
            }
        }



        public void ChangePassword(string newpass, int UserID)
        {

            string QueryString = String.Format("UPDATE usuario set password_hash = '{0}' WHERE id_usuario = {1}", newpass, UserID);
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = QueryString;
            try
            {
                db.conexao.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                db.conexao.Close();
            }
        }

        public void InsertRecoveryCode(string recoveryCode, string userEmail)
        {
            string QueryString = String.Format("UPDATE CLIENTES_User set CLIENTES_User_recovery_code = '{0}' WHERE CLIENTES_User_email = '{1}'", recoveryCode, userEmail);
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = QueryString;

            try
            {
                db.conexao.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                db.conexao.Close();
            }


        }

    }
}
