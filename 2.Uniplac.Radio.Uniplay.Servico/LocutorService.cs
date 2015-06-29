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
    public class LocutorService : ILocutorService
    {
        private IRepository<Locutor> _repositorio;
        public LocutorService(IRepository<Locutor> repositorio) 
        {
            _repositorio = repositorio;
        }

        public Locutor Salvar(Locutor locutor) 
        {
            Validador.Validar(locutor);
            return _repositorio.Salvar(locutor);
        }

        public Locutor Excluir(int id) {
            return _repositorio.Excluir(id);
        }

        public Locutor Alterar(Locutor locutor) {
            Validador.Validar(locutor);
            return _repositorio.Alterar(locutor);
        }

        public Locutor Obter(int id)
        {
            return _repositorio.Obter(id);
        }

        public List<Locutor> ObterTodos() {
            return _repositorio.ObterTodos();
        }

    }
}
