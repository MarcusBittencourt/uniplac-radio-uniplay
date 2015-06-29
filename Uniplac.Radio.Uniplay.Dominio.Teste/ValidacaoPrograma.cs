using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Radio.Uniplay.Dominio.Teste
{
    [TestClass]
    public class ValidacaoPrograma
    {
        [TestMethod]
        public void ValidacaoComProgramaValido()
        {
            Programa programa = ProgramaMother.produzirProgramaValido();
            programa.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void ValidacaoComProgramaInvalido()
        {
            Programa programa = ProgramaMother.produzirProgramaInvalido();
            programa.Validar();
        }
    }
}
