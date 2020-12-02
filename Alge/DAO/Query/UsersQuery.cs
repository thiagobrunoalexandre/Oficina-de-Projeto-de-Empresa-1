using Alge.Models;
using Alge.Models.Admin;
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
            int usuario_admin = 0;
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("INSERT INTO usuario(nome ,email,password_hash, DataInsercao , telefone ,usuario_admin ) VALUES('{0}', '{1}', '{2}','{3}','{4}','{5}'); SELECT LAST_INSERT_ID() as ID", model.Name , model.Email, model.Register_PasswordHash, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), model.MobilePhone , usuario_admin);// 0 usuario comum

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
        public int RegisteProduto(Produto model,string caminhoImg)
        {
            string preco = model.preco.ToString();
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("INSERT INTO produto(nome ,preco, descricao  ,imagem_url ) VALUES('{0}', '{1}', '{2}','{3}'); SELECT LAST_INSERT_ID() as ID", model.nome ,model.preco, model.descricao, caminhoImg);

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
        public int RegisterPedido(int user)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("INSERT INTO pedido(data_pedido ,fk_usuario, fk_status ) VALUES('{0}', '{1}', '{2}'); SELECT LAST_INSERT_ID() as ID",  DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss"), user,1);// 1 staus 1 aguardando aprovação

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
        public int RegisterCart(int user)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("INSERT INTO pedido(data_pedido ,fk_usuario, fk_status ) VALUES('{0}', '{1}', '{2}'); SELECT LAST_INSERT_ID() as ID", DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss"), user, 5);// 5 carrinho

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
        public void UpdateProduto(Produto model,string caminhoimagem,int ID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "UPDATE produto set nome = @nome, preco = @preco , descricao = @descricao , imagem_url = @imagem_url WHERE idProduto = @idProduto";

           comm.Parameters.AddWithValue("@nome", model.nome);
           comm.Parameters.AddWithValue("@preco", model.preco);  
           comm.Parameters.AddWithValue("@descricao", model.descricao); 
            comm.Parameters.AddWithValue("@imagem_url", caminhoimagem);
           comm.Parameters.AddWithValue("@idProduto", ID);

          

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
        public void UpdatePedido(int idPedido)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "UPDATE pedido set fk_status = @fk_status, data_pedido = @data_pedido WHERE id_pedido = @id_pedido";

           comm.Parameters.AddWithValue("@fk_status", "1");//Aguardando aprovação de orçamento
           comm.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
           comm.Parameters.AddWithValue("@id_pedido", idPedido);
          

          

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
        public void UpdateProduto2(Produto model,int ID)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "UPDATE produto set nome = @nome, preco = @preco , descricao = @descricao  WHERE idProduto = @idProduto";

           comm.Parameters.AddWithValue("@nome", model.nome);
           comm.Parameters.AddWithValue("@preco", model.preco);  
           comm.Parameters.AddWithValue("@descricao", model.descricao); 
           comm.Parameters.AddWithValue("@idProduto", ID);

          

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



        public List<UserModel> ReturnListUserData(string where, string like1, string like2 = "")
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = (String.Format("SELECT * FROM usuario WHERE {0} LIKE @_like1 OR {0} LIKE @_like2", where));
            comm.Parameters.AddWithValue("@_like1", like1);
            if (like2 == "")
            {
                like2 = like1;
            }
            comm.Parameters.AddWithValue("@_like2", like2);

            List<UserModel> usersList = new List<UserModel>();

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    usersList.Add(new UserModel
                    {
                        ID = reader.GetInt32("id_usuario"),
                        EmailRegister = reader.GetString("email"),
                        NivelPermissao = reader.GetString("usuario_admin")
                    });
                }
                return usersList;
            }
            catch (Exception e)
            {
                db.conexao.Close();
                return usersList;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }

        

        internal bool Login(string emailLogin, string passwordHashed)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT * FROM usuario WHERE email = @email and password_hash = @password_hash");
            comm.Parameters.AddWithValue("@email", emailLogin);
            comm.Parameters.AddWithValue("@password_hash", passwordHashed);

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.HasRows;

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                db.conexao.Close();
            }
        }

        public void UpdateDadosFaturamento(RegisterModel model, int id_usuario)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "UPDATE usuario set endereco = @endereco, numero_endereco = @numero_endereco ,complemento_endereco = @complemento_endereco  ,cidade  = @cidade ,estado = @estado , cep = @cep , cpf = @cpf WHERE id_usuario = @id_usuario";


            comm.Parameters.AddWithValue("@id_usuario", id_usuario);
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
                                 
                                    descricao = reader.GetString("descricao"),
                                    preco = reader.GetDouble("preco"),
                                
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
                           
                                descricao = reader.GetString("descricao"),
                                preco = reader.GetDouble("preco"),
                            
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
        public Produto ReturnProdutoDetalhe(int id)
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
                          
                            descricao = reader.GetString("descricao"),
                            preco = reader.GetDouble("preco"),
                         
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
            comm.CommandText = ("SELECT * FROM usuario WHERE id_usuario = @id ;");
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
            comm.CommandText = ("SELECT * FROM usuario WHERE email = @email");
            comm.Parameters.AddWithValue("@email", login_Email);
            try
            {
                db.conexao.Open();

                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetInt32("id_usuario");

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
