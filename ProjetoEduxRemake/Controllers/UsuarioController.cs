using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEdux2._0.Utils.Crypt;
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
        public IActionResult Post([FromForm] Guid id, Usuario usuario)
        {
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
            try
            {
                usuario.DataUltimoAcesso = DateTime.Now;
                usuario.DataCadastro = DateTime.Now;

                _usuarioRepository.Adicionar(usuario);

                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put( Guid id, Usuario usuario)
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
