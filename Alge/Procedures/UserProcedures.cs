
using Alge.DAO.Query;
using Alge.Models;
using Alge.Models.Produto;
using Alge.DAO.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Alge.Procedures
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

                if (model.ID == 0)
                {
                    throw new Exception();
                }





                if (model.ID == 0)
                {
                    throw new Exception();
                }



            }
        }

        public static void ChangePassword(string newPassword, int UserID)
        {
            MD5 md5hash = MD5.Create();
            string passwordHashed = PasswordProcedures.ToMD5Hash(newPassword);

            using (CallDB db = new CallDB())
            {

                new UsersQuery(db).ChangePassword(passwordHashed, UserID);
                db.conexao.Close();


            }



        }
        public static void ChangeEmail(string emailFrom, string emailTo, string idUser)
        {
            using (CallDB db = new CallDB())
            {

                new DMLQuery(db).UpdateData("usuario", new List<string> { "email" }, new List<string> { emailTo }, "id_usuario =" + idUser);
                db.conexao.Close();



            }

        }

        public static UserProfileModel GetProfileModel(int userID)
        {
            using (CallDB db = new CallDB())
            {

                var profile = new UsersQuery(db).GetProfile(userID);
                if (profile == null)
                {
                    return new UserProfileModel();
                }
                return profile;
            }
        }

        public static RegisterModel RegisterFaturamento(RegisterModel model,int userID) 
        {
            if (FaturamentoExist(userID))
            {

                using (CallDB db = new CallDB())
                {

                    new UsersQuery(db).UpdateDadosFaturamento(model,userID);


                   
                }


            }
            else
            {


            }
            var Dados = GetDadosFaturamento(AlgeCookieController.UserID);
            return Dados;
        }
        public static bool FaturamentoExist(int userID)
        {
            List<string> columns = new List<string>();
            List<string> values = new List<string>();

           
            ListHelper.AddKey(ref columns, ref values, "fk_usuario", userID.ToString());
            bool retorno = new DMLQuery(new CallDB()).ExistData("usuario_fatuamento", columns, values);

            return retorno;
        }
        public static RegisterModel GetDadosFaturamento(int userID)
        {
            using (CallDB db = new CallDB())
            {

                var dadosFaturamento = new UsersQuery(db).GetFaturamento(userID);
                if (dadosFaturamento == null)
                {
                    return new RegisterModel();
                }
                return dadosFaturamento;
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
