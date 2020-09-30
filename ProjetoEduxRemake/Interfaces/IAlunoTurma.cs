using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IAlunoTurma
    {
        List<AlunoTurma> Listar();
        AlunoTurma BuscarPorId(Guid id);
        void Editar(AlunoTurma alunoTurma);
        void Adicionar(AlunoTurma alunoTurma);
        void Remover(Guid id);
    }
}
