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
    public class TurmaController : ControllerBase
    {
        private readonly ITurma _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();
        }

        // GET: api/<TurmaController>
        /// <summary>
        /// Lista todas as turmas
        /// </summary>
        /// <returns>uma lista de tuma</returns>
        [HttpGet]
        public List<Turma> Get()
        {
            return _turmaRepository.Listar();
        }

        // GET api/<TurmaController>/5
        /// <summary>
        /// Busca uma turma pelo seu id
        /// </summary>
        /// <param name="id">id da turma</param>
        /// <returns>retorna id da turma</returns>
        [HttpGet("{id}")]
        public Turma Get(Guid id)
        {

            return _turmaRepository.BuscarPorId(id);
        }

        // POST api/<TurmaController>
        /// <summary>
        /// Adiciona uma turma
        /// </summary>
        /// <param name="id">id de uma turma</param>
        /// <param name="turma">nome do objeto</param>
        [HttpPost]
        public void Post([FromForm] Guid id, Turma turma)
        {
            _turmaRepository.Adicionar(turma);
        }

        // PUT api/<TurmaController>/5
        /// <summary>
        /// Altera uma turma 
        /// </summary>
        /// <param name="id">Id de uma turma</param>
        /// <param name="turma">Nome do objeto</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Turma turma)
        {
            turma.IdTurma = id;
            _turmaRepository.Editar(turma);
        }

        // DELETE api/<TurmaController>/5
        /// <summary>
        /// Exclui uma turma
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _turmaRepository.Remover(id);
        }
    }
}