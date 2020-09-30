using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IProfessorTurma
    {
        List<ProfessorTurma> Listar();
        ProfessorTurma BuscarPorId(Guid id);
        void Editar(ProfessorTurma professorTurma);
        void Adicionar(ProfessorTurma professorTurma);
        void Remover(Guid id);
    }
}
