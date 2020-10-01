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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtida _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }

        // GET: api/<DicaController>
        [HttpGet]
        public List<Curtida> Get()
        {
            return _curtidaRepository.Listar();
        }

        // GET api/<DicaController>/5
        [HttpGet("{id}")]
        public Curtida Get(Guid id)
        {
            return _curtidaRepository.BuscarPorId(id);
        }

        // POST api/<DicaController>
        [HttpPost]
        public void Post([FromForm] Guid id, Curtida curtida)
        {
            _curtidaRepository.Adicionar(curtida);
        }

        // PUT api/<DicaController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Curtida curtida)
        {
            curtida.IdCurtida = id;
            _curtidaRepository.Editar(curtida);
        }

        // DELETE api/<DicaController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _curtidaRepository.Remover(id);
        }
    }
}