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
    public class CursoController : ControllerBase
    {
        private readonly ICurso _CursoRepository;

        public CursoController()
        {
            _CursoRepository = new CursoRepository();
        }

        // GET: api/<CursoController>
        [HttpGet]
        public List<Curso> Get()
        {
            return _CursoRepository.Listar();
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public Curso Get(Guid id)
        {
            return _CursoRepository.BuscarPorId(id);
        }

        // POST api/<CursoAlunoController>
        [HttpPost]
        public void Post([FromForm] Guid id, Curso curso)
        {
            _CursoRepository.Adicionar(curso);
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Curso curso)
        {
            curso.IdCurso = id;
            _CursoRepository.Editar(curso);
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _CursoRepository.Remover(id);
        }
    }
}
