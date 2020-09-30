using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IObjetivoAluno
    {
        List<ObjetivoAluno> Listar();
        ObjetivoAluno BuscarPorId(Guid id);
        void Editar(ObjetivoAluno objetivoAluno);
        void Adicionar(ObjetivoAluno objetivoAluno);
        void Remover(Guid id);
    }
}
