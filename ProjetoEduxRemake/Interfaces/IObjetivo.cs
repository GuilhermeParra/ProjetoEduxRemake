using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IObjetivo
    {
        List<Objetivo> Listar();
        Objetivo BuscarPorId(Guid id);
        void Editar(Objetivo objetivo);
        void Adicionar(Objetivo objetivo);
        void Remover(Guid id);
    }
}
