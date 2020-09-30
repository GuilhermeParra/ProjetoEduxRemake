using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IDica
    {
        List<Dica> Listar();
        Dica BuscarPorId(Guid id);
        void Editar(Dica dica);
        void Adicionar(Dica dica);
        void Remover(Guid id);
    }
}
