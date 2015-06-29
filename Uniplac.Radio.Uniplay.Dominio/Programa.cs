using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Infraestrutura;

namespace Uniplac.Radio.Uniplay.Dominio
{
    public class Programa : IValidavel
    {
        public String Nome { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public Locutor Locutor { get; set; }
        public void Validar() 
        {
            if (Locutor == null) 
            {
                throw new DominioException("Não há nenhum locutor vinculado a este programa");
            }
        }

        public int Id { get; set; }
    }
}
