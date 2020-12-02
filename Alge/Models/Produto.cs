
using Alge.DAO.Query;
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
        public decimal precoproduto { get; set; }
        public String descricao { get; set; }
        public String imagem { get; set; }

        public String texto_personalizado { get; set; }
        public int categoria { get; set; }



        public void Update(int id,string caminhoImagem)
        {
            using (CallDB db = new CallDB())
            {

                new UsersQuery(db).UpdateProduto(this,caminhoImagem,id);



            }
        }
        public void Update2(int id)
        {
            using (CallDB db = new CallDB())
            {

                new UsersQuery(db).UpdateProduto2(this,id);



            }
        }

        public void RegisterProduto(string caminhoImg)
        {
            using (CallDB db = new CallDB())
            {
               

               this.id_produto =   new UsersQuery(db).RegisteProduto(this, caminhoImg);


                if (this.id_produto == 0)
                {
                    throw new Exception();
                }





               



            }
        }

    }


}
