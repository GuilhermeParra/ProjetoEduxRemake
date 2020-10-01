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
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        // GET: api/<PerfilController>
        [HttpGet]
        public List<Perfil> Get()
        {
            return _perfilRepository.Listar();
        }

        // GET api/<PerfiloController>/5
        [HttpGet("{id}")]
        public Perfil Get(Guid id)
        {
            return _perfilRepository.BuscarPorId(id);
        }

        // POST api/<PerfilController>
        [HttpPost]
        public void Post([FromForm] Guid id, Perfil perfil)
        {
            _perfilRepository.Adicionar(perfil);
        }

        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Perfil perfil)
        {
            perfil.IdPerfil = id;
            _perfilRepository.Editar(perfil);
        }

        // DELETE api/<PerfilController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _perfilRepository.Remover(id);
        }
    }
}
