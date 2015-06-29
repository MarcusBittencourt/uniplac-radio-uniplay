using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Radio.Uniplay.Dominio;

namespace _2.Uniplac.Radio.Uniplay.Servico
{
    public interface ILocutorService
    {
        Locutor Salvar(Locutor locutor);
        Locutor Alterar(Locutor locutor);
        Locutor Obter(int id);
        Locutor Excluir(int id);
        List<Locutor> ObterTodos();
    }
}
