using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;

namespace Uniplac.Radio.Uniplay.Persistencia
{
    public class ProgramaContext : DbContext
    {
        public DbSet<Programa> Programas { get; set; }
        public DbSet<Locutor> Locutores { get; set; }
        public ProgramaContext() : base("uniplac.radio.uniplay") { }
    }
}
