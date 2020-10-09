using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Alge.Models
{
    public class ChangePasswordModel{

        [Required(ErrorMessage = "you_must_insert_your_new_password")]
        [DisplayName("Nova senha")]
        [StringLength(255, ErrorMessage = "password_must_be_at_least_8_characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "you_must_insert_your_new_password_confirm")]
        [DisplayName("Confirme sua nova senha")]
        [StringLength(255, ErrorMessage = "password_must_be_at_least_8_characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}