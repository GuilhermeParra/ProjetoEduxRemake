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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        // GET: api/<InstituicaoController>
        [HttpGet]
        public List<Instituicao> Get()
        {
            return _instituicaoRepository.Listar();
        }

        // GET api/<InstituicaoController>/5
        [HttpGet("{id}")]
        public Instituicao Get(Guid id)
        {
            return _instituicaoRepository.BuscarPorId(id);
        }

        // POST api/<InstituicaoController>
        [HttpPost]
        public void Post([FromForm] Guid id, Instituicao instituicao)
        {
            _instituicaoRepository.Adicionar(instituicao);
        }

        // PUT api/<InstituicaoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Instituicao instituicao)
        {
            instituicao.IdInstituicao = id;
            _instituicaoRepository.Editar(instituicao);
        }

        // DELETE api/<InstituicaoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _instituicaoRepository.Remover(id);
        }
    }
}
