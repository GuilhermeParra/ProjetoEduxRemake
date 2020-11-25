using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class RankingRepository : IRanking
    {
        private readonly EduxContext _context;

        public RankingRepository()
        {
            _context = new EduxContext();
        }

        

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id">Id de usuario</param>
        /// <returns>O usuario procurado</returns>
        public Ranking BuscarPorId(Guid id)
        {
            try
            {
                return _context.Rankings.FirstOrDefault(a => a.IdRanking == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos os usuarios cadastrados
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Ranking> Listar()
        {
            try
            {


                return _context.Rankings.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
