using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using ProjetoEduxRemake.Repositories;

namespace ProjetoEduxRemake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRanking _rankingRepository;

        public RankingController()
        {
            _rankingRepository = new RankingRepository();
        }

        // GET: api/<RankingController>
        [HttpGet]
        public List<Ranking> Get()
        {

            return _rankingRepository.Listar();
        }


        // GET api/<PerfiloController>/5
        [HttpGet("{id}")]
        public Ranking Get(Guid id)
        {
            return _rankingRepository.BuscarPorId(id);
        }

        
    }
}
