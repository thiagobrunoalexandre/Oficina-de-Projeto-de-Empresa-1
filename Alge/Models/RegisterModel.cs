
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;

namespace Alge.Models
{
    public class RegisterModel
    {

       

        public int ID {get;set;}

        public String Email { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
       
        public String Name { get; set; }
     
        public String MobilePhone { get; set; }

        public String Register_PasswordHash { get; set; }

       
       

        
        
        public (bool valid, string message) ValidateRegister()
        {

            Regex rgxEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            int passwordMinimuMSize = 8;

            bool email = false;
            if (!String.IsNullOrEmpty(this.Email))
            {
                email = rgxEmail.IsMatch(this.Email);
            }

            bool password = false;
            bool samePassword = false;
            if (!String.IsNullOrEmpty(this.Password) && !String.IsNullOrEmpty(this.Password))
            {
                password = (this.Password.Length >= passwordMinimuMSize);
                samePassword = (this.Password == this.ConfirmPassword);
            }


        
            bool name = !String.IsNullOrEmpty(this.Name);
        

            if (!email)
            {
                return (email,"insira um email válido");
            }
            else if (!name)
            {
                return (name,"insira seu nome ");
            }
            
            else if (!password)
            {
                return (password, "a senha deve conter no minimo 8 caracteres");
            }
            else if (!samePassword)
            {
                return (samePassword, "digite uma senha ");
            }
            
            

            return ((name && email && password ),"true");
        }

        
    }
}