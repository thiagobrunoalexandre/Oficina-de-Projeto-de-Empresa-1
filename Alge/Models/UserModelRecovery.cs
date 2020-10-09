using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models
{
    public class UserModelRecovery
    {

        //SENHA
        [Required(ErrorMessage = "você deve inserir sua nova_senha")]
        [StringLength(255, ErrorMessage = "a senha deve conter no minimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PasswordRecovery { get; set; }
        //VERIFICAÇÃO DE SENHA
        [Required(ErrorMessage = "você deve inserir sua nova senha para confirmar")]
        [StringLength(255, ErrorMessage = "a senha deve conter no minimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("PasswordRecovery", ErrorMessage = "as senhas não coincidem")]
        public string ConfirmPasswordRecovery { get; set; }

    }
}
