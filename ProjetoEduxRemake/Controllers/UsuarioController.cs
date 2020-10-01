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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            return _usuarioRepository.Listar();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(Guid id)
        {
            return _usuarioRepository.BuscarPorId(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromForm] Guid id, Usuario usuario)
        {
            _usuarioRepository.Adicionar(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put([FromForm] Guid id, Usuario usuario)
        {
            usuario.IdUsuario = id;
            _usuarioRepository.Editar(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _usuarioRepository.Remover(id);
        }
    }
}
