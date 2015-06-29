using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;
using Uniplac.Radio.Uniplay.Infraestrutura;
using Uniplac.Radio.Uniplay.Persistencia;

namespace _2.Uniplac.Radio.Uniplay.Servico
{
    public class ProgramaService : IProgramaService
    {
        private IRepository<Programa> _repositorio;
        public ProgramaService(IRepository<Programa> repositorio) 
        {
            _repositorio = repositorio;
        }

        public Programa Salvar(Programa programa) 
        {
            Validador.Validar(programa);
            return _repositorio.Salvar(programa);
        }

        public Programa Excluir(int id) {
            return _repositorio.Excluir(id);
        }

        public Programa Alterar(Programa programa) {
            Validador.Validar(programa);
            return _repositorio.Alterar(programa);
        }

        public Programa Obter(int id)
        {
            return _repositorio.Obter(id);
        }

        public List<Programa> ObterTodos() {
            return _repositorio.ObterTodos();
        }
    }
}
