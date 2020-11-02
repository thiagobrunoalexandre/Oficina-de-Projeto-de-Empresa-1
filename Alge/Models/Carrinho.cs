

using Alge.DAO.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models
{
    public class Carrinho
    {
        //ID
       
        public int Id_produto { get; set; }
        public String nome_produto { get; set; }
     
        public String descricao_produto { get; set; }
        public string valor_produto  { get; set; }

        public String texto_personalizado { get; set; }
        public int quantidade_produto { get; set; }
       


       

    }

    
    
}