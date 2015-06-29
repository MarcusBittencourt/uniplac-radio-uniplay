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
    public class ProgramaRepository : IRepository<Programa>
    {
        private ProgramaContext contexto;
        public ProgramaRepository() 
        {
            contexto = new ProgramaContext();
        }

        public Programa Salvar(Programa modelo)
        {
            var novo = contexto.Programas.Add(modelo);
            contexto.SaveChanges();
            return novo;
        }

        public Programa Alterar(Programa modelo)
        {
            DbEntityEntry entradas = contexto.Entry(modelo);
            entradas.State = EntityState.Modified;
            contexto.SaveChanges();
            return modelo;
        }

        public Programa Excluir(int indice)
        {
            var excluido = contexto.Programas.Find(indice);
            DbEntityEntry entry = contexto.Entry(excluido);
            entry.State = EntityState.Deleted;
            contexto.SaveChanges();
            return excluido;
        }

        public Programa Obter(int indice)
        {
            var obtido = contexto.Programas.Find(indice);
            return obtido;
        }

        public List<Programa> ObterTodos() 
        {
            return contexto.Programas.ToList<Programa>();
        }
    }
}
