using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Uniplac.Radio.Uniplay.Dominio.Teste
{
    [TestClass]
    public class ValidacaoLocutor
    {
        [TestMethod]
        public void ValidacaoComLocutorValido()
        {
            Locutor locutor = LocutorMother.produzirLocutorValido();
            locutor.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void ValidacaoComLocutorInvalido()
        {
            Locutor locutor = LocutorMother.produzirLocutorInvalido();
            locutor.Validar();
        }

    }
}
