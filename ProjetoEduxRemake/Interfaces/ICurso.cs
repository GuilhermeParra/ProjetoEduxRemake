using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface ICurso
    {
        List<Curso> Listar();
        Curso BuscarPorId(Guid id);
        void Editar(Curso curso);
        void Adicionar(Curso curso);
        void Remover(Guid id);
    }
}
