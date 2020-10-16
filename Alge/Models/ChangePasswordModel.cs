using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Alge.Models
{
    public class ChangePasswordModel{

        [Required(ErrorMessage = "Você precisa inserir uma nova senha!")]
        [DisplayName("Nova senha")]
        [StringLength(255, ErrorMessage = "a senha deve conter no minimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Voçê deve confirmar a senha")]
        [DisplayName("Confirme sua nova senha")]
        [StringLength(255, ErrorMessage = "a senha deve conter no minimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}