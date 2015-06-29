using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniplac.Radio.Uniplay.Dominio
{
    public class DominioException : Exception
    {
        public DominioException(String mensagem) : base(mensagem) {} 
    }
}
