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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _CategoriaRepository;

        public CategoriaController()
        {
            _CategoriaRepository = new CategoriaRepository();
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public List<Categoria> Get()
        {
            return _CategoriaRepository.Listar();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categoria Get(Guid id)
        {
            return _CategoriaRepository.BuscarPorId(id);
        }

        // POST api/<CategoriaAlunoController>
        [HttpPost]
        public IActionResult Post([FromForm] Guid id, Categoria categoria)
        {
            _CategoriaRepository.Adicionar(categoria);

            return CreatedAtAction("GetCategoria", new { id = categoria.IdCategoria }, categoria);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Categoria categoria)
        {
            categoria.IdCategoria = id;
            _CategoriaRepository.Editar(categoria);

            return CreatedAtAction("GetCategoria", new { id = categoria.IdCategoria }, categoria);

        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _CategoriaRepository.Remover(id);
        }
    }
}