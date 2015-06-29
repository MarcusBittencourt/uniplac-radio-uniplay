using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;

namespace Uniplac.Radio.Uniplay.Persistencia
{
    public class LocutorRepository : IRepository<Locutor>
    {
        private LocutorContext contexto;

        public LocutorRepository() 
        {
            contexto = new LocutorContext();
        }

        public Locutor Salvar(Locutor modelo)
        {
            var novo = contexto.Locutores.Add(modelo);
            contexto.SaveChanges();
            return novo;
        }

        public Locutor Alterar(Locutor modelo)
        {
            DbEntityEntry entradas = contexto.Entry(modelo);
            entradas.State = EntityState.Modified;
            contexto.SaveChanges();
            return modelo;
        }

        public Locutor Excluir(int indice)
        {
            var excluido = contexto.Locutores.Find(indice);
            DbEntityEntry entry = contexto.Entry(excluido);
            entry.State = EntityState.Deleted;
            contexto.SaveChanges();
            return excluido;
        }

        public Locutor Obter(int indice)
        {
            var obtido = contexto.Locutores.Find(indice);
            return obtido;
        }

        public List<Locutor> ObterTodos() 
        {
            return contexto.Locutores.ToList<Locutor>();
        }
    }
}
