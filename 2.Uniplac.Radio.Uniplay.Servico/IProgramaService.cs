using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;

namespace _2.Uniplac.Radio.Uniplay.Servico
{
    public interface IProgramaService
    {
        Programa Salvar(Programa programa);
        Programa Alterar(Programa programa);
        Programa Obter(int id);
        Programa Excluir(int id);
        List<Programa> ObterTodos();
    }
}
