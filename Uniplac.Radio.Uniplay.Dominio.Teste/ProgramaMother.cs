using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Radio.Uniplay.Dominio.Teste
{
    public static class ProgramaMother
    {
        public static Programa produzirProgramaValido() 
        {
            Programa programa = new Programa();
            programa.Nome = "Programa que inicia as 22:00 e termina as 23:00";
            programa.HorarioInicio = new DateTime(2015, 01, 01, 22, 00, 00);
            programa.HorarioFim = new DateTime(2015, 01, 01, 23, 00, 00);
            programa.Locutor = "Testonildo";
            return programa;
        }

        public static Programa produzirProgramaInvalido()
        {
            Programa programa = new Programa();
            programa.Nome = "Programa que inicia as 22:00 e termina as 23:00";
            programa.HorarioInicio = new DateTime(2015, 01, 01, 22, 00, 00);
            programa.HorarioFim = new DateTime(2015, 01, 01, 23, 00, 00);
            return programa;
        }

    }
}
