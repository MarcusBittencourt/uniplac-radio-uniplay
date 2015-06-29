using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Infraestrutura;

namespace Uniplac.Radio.Uniplay.Dominio
{
    public class Locutor : IValidavel
    {
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public String Apelido { get; set; }
        public String  Biografia { get; set; }
        public DateTime DataNascimento { get; set; }

        public void Validar() 
        {
            TimeSpan diferenca = DateTime.Now - DataNascimento;
            DateTime data = new DateTime() + diferenca;
            if(data.Year <= 12) {
                throw new DominioException("O Locutor possui dados inválidos");
            }
        }

        public int Id { get; set; }
    }
}
