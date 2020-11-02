

using Alge.DAO.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models
{
    public class UserProfileModel
    {
        //ID
        [Required]
        public int Id { get; set; }
        public String Name { get; set; }
     
        public String CompanyName { get; set; }
        public string Phone { get; set; }
       
 
        //EMAIL
        [Required(ErrorMessage = "INFORME UM EMAIL VALIDO")]
        [StringLength(50, ErrorMessage = "O email deve conter entre 5 e 50 caracteres", MinimumLength = 5)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "INFORME UM EMAIL VALIDO")]
        public string Email { get; set; }
        //COUNTRY
        [Required(ErrorMessage = "É necessário selecionar um país")]
        public string Country { get; set; }
        //PERMISSÃO(PARA VIEW CLIENTE DO ADMIN)
        public string Nivel { get; set; }


        public void Update()
        {
            using (CallDB db = new CallDB())
            {

                new UsersQuery(db).UpdateProfile(this);
               

               
            }
        }

    }

    public class PhoneModel
    {
        public String ID { get; set; }
        public String PhoneTypeID { get; set; }
        public String PhoneNumber { get; set; }
        public PhoneModelAction PhoneModelAction { get; set; }
    }

    public enum PhoneModelAction
    {
        _new,
        _update,
        _remove
    }

    public enum PersonType
    {
        fisica = 1,
        juridica = 2

    }

    
}