using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Radio.Uniplay.Persistencia
{
    public interface IRepository<M>
    {

        M Salvar(M modelo);

        M Alterar(M modelo);

        M Excluir(int indice);

        M Obter(int indice);
        List<M> ObterTodos();
    }
}
