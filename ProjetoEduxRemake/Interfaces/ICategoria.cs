using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface ICategoria
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(Guid id);
        void Editar(Categoria categoria);
        void Adicionar(Categoria categoria);
        void Remover(Guid id);
    }
}
