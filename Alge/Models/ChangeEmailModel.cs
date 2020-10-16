using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Alge.Models
{
    public class ChangeEmailModel
    {
        [Required(ErrorMessage =  "Voçê precisa inserir um email")]
        [DisplayName("Novo email")]
        [StringLength(50, ErrorMessage = "O email deve conter entre 5 e 50 caracteres", MinimumLength = 5)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string NewEmail { get; set; }

        [Required(ErrorMessage = "Voçê precisa confimar o email")]
        [DisplayName("Confirme seu novo email")]
        [StringLength(50, ErrorMessage = "o email deve ter entra 5 e 50 caracteres ", MinimumLength = 5)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um email válido")]
        [Compare("NewEmail", ErrorMessage = "o email e confimação devem ser os mesmos")]
        public string ConfirmNewEmail { get; set; }


        //[Required(ErrorMessageResourceType = typeof(Internacionalizacao.MainModelValidationResx), ErrorMessageResourceName = "you_must_insert_your_current_password")]
        [DisplayName("Senha Atual")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}
