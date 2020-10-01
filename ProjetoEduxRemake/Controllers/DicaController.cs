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
    public class DicaController : ControllerBase
    {
        private readonly IDica _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        // GET: api/<DicaController>
        [HttpGet]
        public List<Dica> Get()
        {
            return _dicaRepository.Listar();
        }

        // GET api/<DicaController>/5
        [HttpGet("{id}")]
        public Dica Get(Guid id)
        {
            return _dicaRepository.BuscarPorId(id);
        }

        // POST api/<DicaController>
        [HttpPost]
        public void Post([FromForm] Guid id, Dica dica)
        {
            _dicaRepository.Adicionar(dica);
        }

        // PUT api/<DicaController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Dica dica)
        {
            dica.IdDica = id;
            _dicaRepository.Editar(dica);
        }

        // DELETE api/<DicaController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _dicaRepository.Remover(id);
        }
    }
}