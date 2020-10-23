
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.Produto
{
    public class Produto
    {
        public int Id { get; set; }
        public String nome { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        public String descricao { get; set; }

        public int categoria { get; set; }

       
    }
}
