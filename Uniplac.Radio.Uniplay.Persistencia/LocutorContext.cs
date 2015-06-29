using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;

namespace Uniplac.Radio.Uniplay.Persistencia
{
    public class LocutorContext : DbContext
    {
        public DbSet<Locutor> Locutores { get; set; }
        public LocutorContext() : base("uniplac.radio.uniplay") { }

    }
}
