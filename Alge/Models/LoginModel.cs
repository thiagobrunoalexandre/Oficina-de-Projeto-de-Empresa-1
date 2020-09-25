
using Alge.DAO;
using Alge.Performance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Alge.Models
{
    public class LoginModel
    {
       
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É Necessário digitar uma senha")]
        [Display(Name = "Senha")]
        
        public string Senha { get; set; }
        
       
        
        public bool Login()
        {
            string loginPasswordHashed = ToMD5Hash(this.Senha);

            using (var db = new CallDB())
            {
                db.Connection.OpenAsync();
                


                var passwordHash = new LoginQuery(db).GetPasswordHash(this.Email).Result;
                return loginPasswordHashed == passwordHash;
            }
        }
        
        public bool Exist()
        {
            using (var db = new CallDB())
            {
                db.Connection.Open();
                var exist = new LoginQuery(db).Exist(this.Email);

                return exist.Result;
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
       
    }
}
