using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IRanking
    {
        List<Ranking> Listar();
        Ranking BuscarPorId(Guid id);

    }
}