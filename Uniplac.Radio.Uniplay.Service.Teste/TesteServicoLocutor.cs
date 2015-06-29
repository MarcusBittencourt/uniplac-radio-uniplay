using _2.Uniplac.Radio.Uniplay.Servico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;
using Uniplac.Radio.Uniplay.Dominio.Teste;
using Uniplac.Radio.Uniplay.Infraestrutura;
using Uniplac.Radio.Uniplay.Persistencia;

namespace Uniplac.Radio.Uniplay.Service.Teste
{
    [TestClass]
    public class TesteServicoLocutor
    {
        [TestMethod]
        public void SalvandoLocutor()
        {
            Locutor locutor = LocutorMother.produzirLocutorValido();
            var repositorioFalso = new Mock<IRepository<Locutor>>();
            repositorioFalso.Setup(repositorio => repositorio.Salvar(locutor)).Returns(locutor);
            var locutorFalso = new Mock<Locutor>();
            locutorFalso.As<IValidavel>().Setup(l => l.Validar());
            ILocutorService servico = new LocutorService(repositorioFalso.Object);
            servico.Salvar(locutorFalso.Object);
            locutorFalso.As<IValidavel>().Verify(l => l.Validar());
            repositorioFalso.Verify(repositorio => repositorio.Salvar(locutorFalso.Object));
        }

        [TestMethod]
        public void ObtendoLocutor()
        {
            Locutor locutor = LocutorMother.produzirLocutorValido();
            var repositorioFalso = new Mock<IRepository<Locutor>>();
            repositorioFalso.Setup(repositorio => repositorio.Obter(1)).Returns(locutor);
            ILocutorService servico = new LocutorService(repositorioFalso.Object);
            var locutorFalso = servico.Obter(1);
            repositorioFalso.Verify(repositorio => repositorio.Obter(1));
            Assert.IsNotNull(locutorFalso);
        }

        [TestMethod]
        public void AlterandoLocutor()
        {
            Locutor locutor = LocutorMother.produzirLocutorValido();
            var repositorioFalso = new Mock<IRepository<Locutor>>();
            repositorioFalso.Setup(r => r.Alterar(locutor)).Returns(locutor);
            var locutorFalso = new Mock<Locutor>();
            locutorFalso.As<IValidavel>().Setup(l => l.Validar());
            ILocutorService service = new LocutorService(repositorioFalso.Object);
            service.Alterar(locutorFalso.Object);
            locutorFalso.As<IValidavel>().Verify(l => l.Validar());
            repositorioFalso.Verify(l => l.Alterar(locutorFalso.Object));
        }

        [TestMethod]
        public void ExcluindoLocutor()
        {
            Locutor locutor = null;
            var repositorioFalso = new Mock<IRepository<Locutor>>();
            repositorioFalso.Setup(l => l.Excluir(1)).Returns(locutor);
            ILocutorService service = new LocutorService(repositorioFalso.Object);
            var locutorFalso = service.Excluir(1);
            repositorioFalso.Verify(l => l.Excluir(1));
            Assert.IsNull(locutorFalso);
        }
    }
}
