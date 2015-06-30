using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Uniplac.Radio.Uniplay.Dominio.Teste;
using Uniplac.Radio.Uniplay.Dominio;

namespace Uniplac.Radio.Uniplay.Persistencia.Teste
{
    [TestClass]
    public class TestePersistenciaPrograma
    {
        private ProgramaContext _contextoParaTeste;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ProgramaContext>());
            _contextoParaTeste = new ProgramaContext();
            _contextoParaTeste.Programas.Add(ProgramaMother.produzirProgramaValido());
            _contextoParaTeste.SaveChanges();
        }

        [TestMethod]
        public void SalvandoPrograma()
        {
            Programa Programa = ProgramaMother.produzirProgramaValido();
            IRepository<Programa> repositorio = new ProgramaRepository();
            Programa novoPrograma = repositorio.Salvar(Programa);
            Assert.IsTrue(novoPrograma.Id > 0);
        }

        [TestMethod]
        public void ObtendoPrograma()
        {
            IRepository<Programa> repository = new ProgramaRepository();
            Programa programa = repository.Obter(1);
            Assert.IsNotNull(programa);
            Assert.IsTrue(programa.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(programa.Nome));
            Assert.IsFalse(string.IsNullOrEmpty(programa.Locutor));
            Assert.IsFalse(programa.HorarioInicio == null);
            Assert.IsFalse(programa.HorarioFim == null);
        }

        [TestMethod]
        public void AlterandoPrograma()
        {
            IRepository<Programa> repositorio = new ProgramaRepository();
            Programa Programa = _contextoParaTeste.Programas.Find(1);
            Programa.Nome = "Teste";

            var ProgramaAtualizado = repositorio.Alterar(Programa);
            var ProgramaPersistido = _contextoParaTeste.Programas.Find(1);

            Assert.IsNotNull(ProgramaAtualizado);
            Assert.AreEqual(ProgramaAtualizado.Id, ProgramaPersistido.Id);
            Assert.AreEqual(ProgramaAtualizado.Nome, ProgramaPersistido.Nome);
            Assert.AreEqual(ProgramaAtualizado.HorarioInicio, ProgramaPersistido.HorarioInicio);
            Assert.AreEqual(ProgramaAtualizado.HorarioFim, ProgramaPersistido.HorarioFim);
            Assert.AreEqual(ProgramaAtualizado.Locutor, ProgramaPersistido.Locutor);
        }

        [TestMethod]
        public void ExcluindoPrograma()
        {
            IRepository<Programa> repositorio = new ProgramaRepository();
            var ProgramaExcluido = repositorio.Excluir(1);
            var ProgramaPersistido = _contextoParaTeste.Programas.Find(1);
            Assert.IsNull(ProgramaPersistido);
        }
    }
}
