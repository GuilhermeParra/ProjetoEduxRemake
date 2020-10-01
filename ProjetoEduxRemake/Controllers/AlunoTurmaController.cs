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
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurma _alunoTurmaRepository;

        public AlunoTurmaController()
        {
            _alunoTurmaRepository = new AlunoTurmaRepository();
        }

        // GET: api/<AlunoTurmaController>
        [HttpGet]
        public List<AlunoTurma> Get()
        {
            return _alunoTurmaRepository.Listar();
        }

        // GET api/<AlunoTurmaController>/5
        [HttpGet("{id}")]
        public AlunoTurma Get(Guid id)
        {
            return _alunoTurmaRepository.BuscarPorId(id);
        }

        // POST api/<AlunoTurmaController>
        [HttpPost]
        public void Post([FromForm] Guid id, AlunoTurma alunoTurma)
        {
            _alunoTurmaRepository.Adicionar(alunoTurma);
        }

        // PUT api/<AlunoTurmaController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, AlunoTurma alunoTurma)
        {
            alunoTurma.IdAlunoTurma = id;
            _alunoTurmaRepository.Editar(alunoTurma);
        }

        // DELETE api/<AlunoTurmaController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _alunoTurmaRepository.Remover(id);
        }
    }
}
