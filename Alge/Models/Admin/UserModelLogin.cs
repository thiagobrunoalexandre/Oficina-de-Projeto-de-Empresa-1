using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.Admin
{
    public class UserModelLogin
    {
        [Required(ErrorMessage = "É Necessário digitar uma senha")]
        [StringLength(255, ErrorMessage = "A senha deve ter no mínimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string PasswordLogin { get; set; }

        //EMAIL > LOGIN

        [Required(ErrorMessage = "Informe o Email")]
        [StringLength(50, ErrorMessage = "O email deve conter entre 5 e 50 caracteres", MinimumLength = 5)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string EmailLogin { get; set; }


    }

}
