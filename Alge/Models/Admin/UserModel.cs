using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.Admin
{
    public class UserModel
    {

        //EMAIL
        [Required(ErrorMessage = "Informe o Email")]
        [StringLength(50, ErrorMessage = "O email deve conter entre 5 e 50 caracteres", MinimumLength = 5)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        
        
        
        public string EmailRegister { get; set; }
        //SENHA
        [Required(ErrorMessage = "É Necessário digitar uma senha")]
        [StringLength(255, ErrorMessage = "A senha deve ter no mínimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PasswordRegister { get; set; }
        //VERIFICAÇÃO DE SENHA
        [Required(ErrorMessage = "É necessário digitar a confirmação da senha")]
        [StringLength(255, ErrorMessage = "A senha deve ter no mínimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("PasswordRegister")]
        public string ConfirmPasswordRegister { get; set; }

        //ID
        public int IdCountry { get; set; }
        //COUNTRY
        [Required(ErrorMessage = "É necessário selecionar um país")]
        public string CountryRegister { get; set; }

        public string NivelPermissao { get; set; }

        public int ID { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTime DataCadastro { get; set; }
    }
    
}
