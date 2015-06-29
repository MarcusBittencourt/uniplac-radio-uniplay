using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Radio.Uniplay.Dominio;
using Uniplac.Radio.Uniplay.Dominio.Teste;
using System.Data.Entity;

namespace Uniplac.Radio.Uniplay.Persistencia.Teste
{
    [TestClass]
    public class LocutorRepositoryTest
    {
        private LocutorContext _contextoParaTeste;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LocutorContext>());
            _contextoParaTeste = new LocutorContext();
            _contextoParaTeste.Locutores.Add(LocutorMother.produzirLocutorValido());
            _contextoParaTeste.SaveChanges();
        }

        [TestMethod]
        public void SalvandoLocutor()
        {
            Locutor locutor = LocutorMother.produzirLocutorValido();
            IRepository<Locutor> repositorio = new LocutorRepository();
            Locutor novoLocutor = repositorio.Salvar(locutor);
            Assert.IsTrue(novoLocutor.Id > 0);
        }

        [TestMethod]
        public void ObtendoLocutor()
        {
            IRepository<Locutor> repository = new LocutorRepository();
            Locutor locutor = repository.Obter(1);
            Assert.IsNotNull(locutor);
            Assert.IsTrue(locutor.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(locutor.Nome));
            Assert.IsFalse(string.IsNullOrEmpty(locutor.Sobrenome));
            Assert.IsFalse(string.IsNullOrEmpty(locutor.Apelido));
            Assert.IsFalse(string.IsNullOrEmpty(locutor.Biografia));
        }

        [TestMethod]
        public void AlterandoLocutor()
        {
            IRepository<Locutor> repositorio = new LocutorRepository();
            Locutor locutor = _contextoParaTeste.Locutores.Find(1);
            locutor.Nome = "Teste";

            var locutorAtualizado = repositorio.Alterar(locutor);
            var locutorPersistido = _contextoParaTeste.Locutores.Find(1);
            
            Assert.IsNotNull(locutorAtualizado);
            Assert.AreEqual(locutorAtualizado.Id, locutorPersistido.Id);
            Assert.AreEqual(locutorAtualizado.Nome, locutorPersistido.Nome);
            Assert.AreEqual(locutorAtualizado.Sobrenome, locutorPersistido.Sobrenome);
            Assert.AreEqual(locutorAtualizado.Apelido, locutorPersistido.Apelido);
            Assert.AreEqual(locutorAtualizado.Biografia, locutorPersistido.Biografia);
            Assert.AreEqual(locutorAtualizado.DataNascimento, locutorPersistido.DataNascimento);
        }

        [TestMethod]
        public void ExcluindoLocutor()
        {
            IRepository<Locutor> repositorio = new LocutorRepository();
            var locutorExcluido = repositorio.Excluir(1);
            var locutorPersistido = _contextoParaTeste.Locutores.Find(1);
            Assert.IsNull(locutorPersistido);
        }
    }
}
