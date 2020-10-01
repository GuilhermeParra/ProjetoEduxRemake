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
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivo _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }

        // GET: api/<ObjetivoController>
        [HttpGet]
        public List<Objetivo> Get()
        {
            return _objetivoRepository.Listar();
        }

        // GET api/<ObjetivoController>/5
        [HttpGet("{id}")]
        public Objetivo Get(Guid id)
        {
            return _objetivoRepository.BuscarPorId(id);
        }

        // POST api/<ObjetivoController>
        [HttpPost]
        public void Post([FromForm] Guid id, Objetivo objetivo)
        {
            _objetivoRepository.Adicionar(objetivo);
        }

        // PUT api/<ObjetivoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Objetivo objetivo)
        {
            objetivo.IdObjetivo = id;
            _objetivoRepository.Editar(objetivo);
        }

        // DELETE api/<ObjetivoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _objetivoRepository.Remover(id);
        }
    }
}
