


using Alge.DAO;
using Alge.Performance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Alge.Models
{
    public class LoginRegisterModel
    {

        public String Login_Email { get; set; }
        public String Login_Password { get; set; }
        public bool Login_SuccessFull { get; set; }

        public int ID {get;set;}

        public String Register_Email { get; set; }
        public String Register_Password { get; set; }
        public String Register_ConfirmPassword { get; set; }
        public String Register_Country { get; set; }
        public String Register_Name { get; set; }
        public String Register_LastName { get; set; }
        public String Register_MobilePhone { get; set; }

        public String Register_PasswordHash { get; set; }

        public bool ContributorEnabled { get; set; }
        public string GoogleDriveFolderID { get; set; }


        public bool Login()
        {
            string loginPasswordHashed = ToMD5Hash(this.Login_Password);

            using (var db = new CallDB())
            {
                db.Connection.OpenAsync();



                var passwordHash = new LoginQuery(db).GetPasswordHash(this.Login_Email).Result;
                return loginPasswordHashed == passwordHash;
            }
        }

        public string ToMD5Hash(string value)
        {
            MD5 md5hash = MD5.Create();
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public (bool valid, string message) ValidateRegister()
        {

            Regex rgxEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            int passwordMinimuMSize = 8;

            bool email = false;
            if (!String.IsNullOrEmpty(this.Register_Email))
            {
                email = rgxEmail.IsMatch(this.Register_Email);
            }

            bool password = false;
            bool samePassword = false;
            if (!String.IsNullOrEmpty(this.Register_Password) && !String.IsNullOrEmpty(this.Register_Password))
            {
                password = (this.Register_Password.Length >= passwordMinimuMSize);
                samePassword = (this.Register_Password == this.Register_ConfirmPassword);
            }


            bool country = !String.IsNullOrEmpty(this.Register_Country);
            bool name = !String.IsNullOrEmpty(this.Register_Name);
            bool lastName = !String.IsNullOrEmpty(this.Register_LastName);

          

            return ((name && lastName && email && password && country),"true");
        }

        public (bool valid, string message) ValidateLogin()
         {
            bool valid = !String.IsNullOrEmpty(this.Login_Email) && !String.IsNullOrEmpty(this.Login_Password);
            if (!valid)
            {
                return (valid, "Para fazer login digite seu nome e sua senha");
            }
            return (true,"true");
        }
    }
}