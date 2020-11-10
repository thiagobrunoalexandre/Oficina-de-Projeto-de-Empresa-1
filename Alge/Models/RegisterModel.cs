
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("E-mail")]
        public String Email { get; set; }
        [DisplayName("Senha")]
        public String Password { get; set; }
        [DisplayName("Confirme a senha")]
        public String ConfirmPassword { get; set; }
        [DisplayName("Nome completo")]
        public String Name { get; set; }
        
        [DisplayName("Celular")]
        public String MobilePhone { get; set; }
        [DisplayName("Endereço")]
        public String endereco { get; set; }
        [DisplayName("número")]
        public String numero_endereco { get; set; }
        [DisplayName("complemento")]
        public String complemento { get; set; }
        [DisplayName("cidade")]
        public String  cidade { get; set; }
        [DisplayName("estado")]
        public String  estado { get; set; }
        [DisplayName("CEP")]
        public String  cep { get; set; }
        [DisplayName("CPF")]
        public String  cpf { get; set; }

     

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

            bool telefone  = !String.IsNullOrEmpty(this.MobilePhone);
            if (!email)
            {
                return (email,"insira um email válido");
            }
            if (!telefone)
            {
                return (telefone, "insira um numero de telefone");
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
            
            

            return ((name && email && password && telefone),"true");
        }
        
        public (bool valid, string message) ValidateFaturamento()
        {

                int cpfdMinimuMSize = 11;


                bool endereco = !String.IsNullOrEmpty(this.endereco);
                bool numero_endereco = !String.IsNullOrEmpty(this.numero_endereco);
                bool complemento = !String.IsNullOrEmpty(this.complemento);
                bool cidade = !String.IsNullOrEmpty(this.cidade);
                bool estado = !String.IsNullOrEmpty(this.estado);
                bool cep = !String.IsNullOrEmpty(this.cep);
                bool cpf = !String.IsNullOrEmpty(this.cpf);





            if (!cpf)
            {
                return (cpf, "insira um cpf");
            }
            if (!endereco)
            {
                return (endereco, "insira um endereço");
            }
            if (!numero_endereco)
            {
                return (numero_endereco, "insira o número do endereço");
            }
            if (!complemento)
            {
                return (complemento, "insira um complemento ou N ");
            }
            if (!cidade)
            {
                return (cidade, "insira o nome da sua cidade");
            }
            if (!estado)
            {
                return (estado, "insira o nome do seu estado");
            }
            if (!cep)
            {
                return (cep, "insira um cep");
            }





            return ((endereco && numero_endereco && complemento && cidade && estado && cep && cpf), "true");
            
        }

        
    }
}