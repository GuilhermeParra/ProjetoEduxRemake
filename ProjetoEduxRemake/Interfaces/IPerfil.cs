using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IPerfil
    {
        List<Perfil> Listar();
        Perfil BuscarPorId(Guid id);
        void Editar(Perfil perfil);
        void Adicionar(Perfil perfil);
        void Remover(Guid id);

    }
}
