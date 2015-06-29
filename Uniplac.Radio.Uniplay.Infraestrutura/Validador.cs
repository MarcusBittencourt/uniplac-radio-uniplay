using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Radio.Uniplay.Infraestrutura
{
    public static class Validador
    {
        public static void Validar(IValidavel validavel) 
        {
            validavel.Validar();   
        }
    }
}
