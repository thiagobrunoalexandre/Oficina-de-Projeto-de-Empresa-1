
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.Produto
{
    public class Produto
    {
        public int id_produto{ get; set; }
        public String nome { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        public String descricao { get; set; }
        public String imagem { get; set; }

        public String texto_personalizado { get; set; }
        public int categoria { get; set; }


      
       
    }


}
