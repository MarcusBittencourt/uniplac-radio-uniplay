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
    public class ProgramaController : ApiController
    {
        private IProgramaService _servico;
        private IRepository<Programa> _repositorio;
        public ProgramaController() {
            _repositorio = new ProgramaRepository();
            _servico = new ProgramaService(_repositorio);
        }
        // GET api/programa
        public IEnumerable<Programa> Get()
        {
            return _servico.ObterTodos();
        }

        // GET api/programa/5
        public Programa Get(int id)
        {
            return _servico.Obter(id);
        }

        // POST api/programa
        public void Post([FromBody]Programa programa)
        {
            _servico.Salvar(programa);
        }

        // PUT api/programa/5
        public void Put(int id, [FromBody]Programa programa)
        {
            _servico.Alterar(programa);
        }

        // DELETE api/programa/5
        public void Delete(int id)
        {
            _servico.Excluir(id);
        }
    }
}
