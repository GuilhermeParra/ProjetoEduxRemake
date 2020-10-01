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
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurma _professorTurmaRepository;

        public ProfessorTurmaController()
        {
            _professorTurmaRepository = new ProfessorTurmaRepository();
        }

        // GET: api/<ProfessorTurmaController>
        /// <summary>
        /// Lista todos os professores
        /// </summary>
        /// <returns>retorna uma lista de prodessores</returns>
        [HttpGet]
        public List<ProfessorTurma> Get()
        {
            return _professorTurmaRepository.Listar();
        }

        // GET api/<ProfessorTurmaController>/5
        /// <summary>
        /// Busca determinado professor por seu id
        /// </summary>
        /// <param name="id">id do professor turma</param>
        /// <returns>retorna o professor </returns>
        [HttpGet("{id}")]
        public ProfessorTurma Get(Guid id)
        {

            return _professorTurmaRepository.BuscarPorId(id);
        }

        // POST api/<ProfessorTurmaController>
        /// <summary>
        /// Adciona um novo Professor 
        /// </summary>
        /// <param name="id">id do professor</param>
        /// <param name="professorTurma">nome do objeto</param>

        [HttpPost]
        public void Post([FromForm] Guid id, ProfessorTurma professorTurma)
        {
            _professorTurmaRepository.Adicionar(professorTurma);
        }

        // PUT api/<ProfessorTurmaController>/5
        /// <summary>
        /// Edita um professor da turma
        /// </summary>
        /// <param name="id">id do professor </param>
        /// <param name="professorTurma">nome do objeto</param>
        [HttpPut("{id}")]
        public void Put(Guid id, ProfessorTurma professorTurma)
        {
            professorTurma.IdProfessorTurma = id;
            _professorTurmaRepository.Editar(professorTurma);
        }

        // DELETE api/<ProfessorTurmaController>/5
        /// <summary>
        /// Exclui um professor
        /// </summary>
        /// <param name="id">id do professor</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _professorTurmaRepository.Remover(id);
        }
    }
}