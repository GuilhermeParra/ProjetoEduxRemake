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
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAluno _ObjAlunoRepository;

        public ObjetivoAlunoController()
        {
            _ObjAlunoRepository = new ObjetivoAlunoRepository();
        }

        // GET: api/<ObjetivoAlunoController>
        [HttpGet]
        public List<ObjetivoAluno> Get()
        {
            return _ObjAlunoRepository.Listar();
        }

        // GET api/<ObjetivoAlunoController>/5
        [HttpGet("{id}")]
        public ObjetivoAluno Get(Guid id)
        {
            return _ObjAlunoRepository.BuscarPorId(id);
        }

        // POST api/<ObjetivoAlunoController>
        [HttpPost]
        public void Post([FromForm] Guid id, ObjetivoAluno objetivoAluno)
        {
            _ObjAlunoRepository.Adicionar(objetivoAluno);
        }

        // PUT api/<ObjetivoAlunoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, ObjetivoAluno objetivoAluno)
        {
            objetivoAluno.IdObjetivoAluno = id;
            _ObjAlunoRepository.Editar(objetivoAluno);
        }

        // DELETE api/<ObjetivoAlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _ObjAlunoRepository.Remover(id);
        }
    }
}