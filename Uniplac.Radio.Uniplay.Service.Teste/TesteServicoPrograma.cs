using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Radio.Uniplay.Dominio;
using Uniplac.Radio.Uniplay.Dominio.Teste;
using Uniplac.Radio.Uniplay.Persistencia;
using Moq;
using Uniplac.Radio.Uniplay.Infraestrutura;
using _2.Uniplac.Radio.Uniplay.Servico;

namespace Uniplac.Radio.Uniplay.Service.Teste
{
    [TestClass]
    public class TesteServicoPrograma
    {
        [TestMethod]
        public void SalvandoPrograma()
        {
            Programa programa = ProgramaMother.produzirProgramaValido();
            var repositorioFalso = new Mock<IRepository<Programa>>();
            repositorioFalso.Setup(repositorio => repositorio.Salvar(programa)).Returns(programa);
            var ProgramaFalso = new Mock<Programa>();
            ProgramaFalso.As<IValidavel>().Setup(l => l.Validar());
            IProgramaService servico = new ProgramaService(repositorioFalso.Object);
            servico.Salvar(ProgramaFalso.Object);
            ProgramaFalso.As<IValidavel>().Verify(l => l.Validar());
            repositorioFalso.Verify(repositorio => repositorio.Salvar(ProgramaFalso.Object));
        }

        [TestMethod]
        public void ObtendoPrograma()
        {
            Programa programa = ProgramaMother.produzirProgramaValido();
            var repositorioFalso = new Mock<IRepository<Programa>>();
            repositorioFalso.Setup(repositorio => repositorio.Obter(1)).Returns(programa);
            IProgramaService servico = new ProgramaService(repositorioFalso.Object);
            var programaFalso = servico.Obter(1);
            repositorioFalso.Verify(repositorio => repositorio.Obter(1));
            Assert.IsNotNull(programaFalso);
        }

        [TestMethod]
        public void AlterandoPrograma()
        {
            Programa programa = ProgramaMother.produzirProgramaValido();
            var repositorioFalso = new Mock<IRepository<Programa>>();
            repositorioFalso.Setup(r => r.Alterar(programa)).Returns(programa);
            var programaFalso = new Mock<Programa>();
            programaFalso.As<IValidavel>().Setup(l => l.Validar());
            IProgramaService service = new ProgramaService(repositorioFalso.Object);
            service.Alterar(programaFalso.Object);
            programaFalso.As<IValidavel>().Verify(l => l.Validar());
            repositorioFalso.Verify(l => l.Alterar(programaFalso.Object));
        }

        [TestMethod]
        public void ExcluindoPrograma()
        {
            Programa programa = null;
            var repositorioFalso = new Mock<IRepository<Programa>>();
            repositorioFalso.Setup(l => l.Excluir(1)).Returns(programa);
            IProgramaService service = new ProgramaService(repositorioFalso.Object);
            var programaFalso = service.Excluir(1);
            repositorioFalso.Verify(l => l.Excluir(1));
            Assert.IsNull(programaFalso);
        }
    }
}
