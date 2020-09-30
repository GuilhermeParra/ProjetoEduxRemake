using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IInstituicao
    {
        List<Instituicao> Listar();
        Instituicao BuscarPorId(Guid id);
        void Editar(Instituicao instituicao);
        void Adicionar(Instituicao instituicao);
        void Remover(Guid id);
    }
}
