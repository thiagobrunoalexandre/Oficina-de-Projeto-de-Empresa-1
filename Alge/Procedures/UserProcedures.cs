
using Alge.DAO.Query;
using Alge.Models;

using BancodeImagens.DAO.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BancodeImagens.Procedures
{
    public static class UserProcedures
    {
        public static bool EmailExist(string Email)
        {
            using (CallDB db = new CallDB())//Open
            {
                return new DMLQuery(db).ExistData("usuario", new List<string> { "email" }, new List<string> { Email });
            }
        }

        
        public static void RegisterUser(RegisterModel model)
        {
            using (CallDB db = new CallDB())
            {
                model.Register_PasswordHash = PasswordProcedures.ToMD5Hash(model.Password);

                
                model.ID = new UsersQuery(db).RegisterUser(model);

                if(model.ID == 0)
                {
                    throw new Exception();
                }

                

              

                if (model.ID == 0)
                {
                    throw new Exception();
                }

               
                
            }
        }

       

       

       
        public static Tuple<int, bool, string> VerifyRecoveryCode(string code)
        {
            int userID;
            string userEmail;
            bool found = false;
            using (CallDB db = new CallDB())
            {
                
                userEmail = new DMLQuery(db).GetData("CLIENTES_User_email", "CLIENTES_User", "CLIENTES_User_recovery_code", code);
                db.conexao.Close();
                
                userID = new UsersQuery(db).GetUserID(userEmail);
                found = !String.IsNullOrEmpty(userEmail) && !String.IsNullOrEmpty(userID.ToString());
            }
            if (found)
            {
                return new Tuple<int, bool, string>(userID, found, userEmail);
            }
            else
            {
                return new Tuple<int, bool, string>(0, false, "");
            }
        }

       
      
    }
}
