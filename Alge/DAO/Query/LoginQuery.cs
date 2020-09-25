using Alge.Models;
using Alge.Performance;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.DAO
{
    public class LoginQuery
    {
        public readonly CallDB Db;
      
        public LoginQuery(CallDB db)
        {
            Db = db;
        }
        public async Task<bool> Exist(string email)
        {
            var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = String.Format("SELECT * FROM `usuario` WHERE `email` = '{0}'", email);

            try
            {
             
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch(Exception e)
            {
            
                return false ;
            }
            finally
            {
                Db.Connection.Close();
            }
        }

        public async Task<string> GetPasswordHash(string email)
        {
            var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = String.Format("SELECT Password_hash FROM `CorretoraUsuario` WHERE `Email` = '{0}'", email);
            DbDataReader reader = await cmd.ExecuteReaderAsync();
            reader.Read();
            string value = await reader.GetFieldValueAsync<string>(0);
            return value;
        }

      

        public async Task<LoginModel> GetLoginModel(string email,string passwordHsh)
        {
            var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = String.Format("SELECT * FROM usuario WHERE email = '{0}' AND password_hash = '{1}';",email,passwordHsh);
            try
            {
                DbDataReader reader = await cmd.ExecuteReaderAsync();

                await reader.ReadAsync();
                var loginModel = new LoginModel();

                loginModel.ID = reader.GetInt32(0);
                loginModel.Email = Convert.ToString(reader[1]);
               
           
                return loginModel;
            }
            catch (Exception e)
            {
               
                return null;
            }
            finally
            {
                Db.Connection.Close();

            }
        }
    }
}
