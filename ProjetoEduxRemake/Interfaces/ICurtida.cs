using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface ICurtida
    {
        List<Curtida> Listar();
        Curtida BuscarPorId(Guid id);
        void Editar(Curtida curtida);
        void Adicionar(Curtida curtida);
        void Remover(Guid id);
    }
}
