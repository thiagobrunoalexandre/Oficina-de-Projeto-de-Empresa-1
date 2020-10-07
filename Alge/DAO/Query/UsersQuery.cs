using Alge.Models;

using BancodeImagens.Procedures;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

            string QueryString = String.Format("UPDATE CLIENTES_User set CLIENTES_User_password_hash = '{0}' WHERE ID_CLIENTES_User = {1}", newpass, UserID);
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
