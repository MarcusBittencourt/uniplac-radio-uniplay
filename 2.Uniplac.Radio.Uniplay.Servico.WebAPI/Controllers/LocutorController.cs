using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Uniplac.Radio.Uniplay.Dominio;
using Uniplac.Radio.Uniplay.Persistencia;

namespace _2.Uniplac.Radio.Uniplay.Servico.WebAPI.Controllers
{
    public class LocutorController : ApiController
    {
        private IRepository<Locutor> _repositorio;
        private ILocutorService _servico;

        public LocutorController() {
            _repositorio = new LocutorRepository();
            _servico = new LocutorService(_repositorio);
        }

        // GET api/locutor
        public IEnumerable<Locutor> Get()
        {
            return _servico.ObterTodos();
        }

        // GET api/locutor/5
        public Locutor Get(int id)
        {
            return _servico.Obter(id);
        }

        // POST api/locutor
        public void Post([FromBody]Locutor locutor)
        {
            _servico.Salvar(locutor);
        }

        // PUT api/locutor/5
        public void Put(int id, [FromBody]Locutor locutor)
        {
            _servico.Alterar(locutor);
        }

        // DELETE api/locutor/5
        public void Delete(int id)
        {
            _servico.Excluir(id);
        }

    }
}
