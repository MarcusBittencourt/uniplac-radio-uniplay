using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Radio.Uniplay.Dominio.Teste
{
    public static class LocutorMother
    {
        public static Locutor produzirLocutorValido() 
        {
            Locutor locutor = new Locutor();
            locutor.DataNascimento = new DateTime(1990, 5, 8);
            locutor.Nome = "Testonildo";
            locutor.Sobrenome = "Locutor";
            locutor.Apelido = "Locutonildo";
            locutor.Biografia = @"Testonildo cresceu em uma familia carente de classe alta no leblon
                                  vivia em baladas e quando cresceu, decidiu se tornar DJ mais tarde
                                  pagava pra trabalhar neste emprego e logo depois criou sua própria radio
                                  onde realizou o sonho de interpretar o papel de Don Ruan em Coração de Manteiga
                                ";

            return locutor;
        }

        public static Locutor produzirLocutorInvalido() 
        {
            Locutor locutor = new Locutor();
            locutor.DataNascimento = new DateTime(2015, 5, 8);
            locutor.Nome = "Testonildo";
            locutor.Sobrenome = "Locutor";
            locutor.Apelido = "Locutonildo";
            locutor.Biografia = @"Testonildo cresceu em uma familia carente de classe alta no leblon
                                  vivia em baladas e quando cresceu, decidiu se tornar DJ mais tarde
                                  pagava pra trabalhar neste emprego e logo depois criou sua própria radio
                                  onde realizou o sonho de interpretar o papel de Don Ruan em Coração de Manteiga
                                ";

            return locutor;
        }

    }
}
