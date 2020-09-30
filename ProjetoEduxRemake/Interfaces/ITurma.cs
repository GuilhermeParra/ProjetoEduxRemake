using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface ITurma
    {
        List<Turma> Listar();
        Turma BuscarPorId(Guid id);
        void Editar(Turma turma);
        void Adicionar(Turma turma);
        void Remover(Guid id);
    }
}
