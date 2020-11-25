using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EduxContext _context;

        public UsuarioRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Usuario usuario)
        {
            try
            {
                /*usuario.DataCadastro = DateTime.Now;
                usuario.DataUltimoAcesso = DateTime.Now;*/

                _context.Usuarios.Add(usuario);

                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);            
            }
        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id">Id de usuario</param>
        /// <returns>O usuario procurado</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.Usuarios.FirstOrDefault(a => a.IdUsuario == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser alterado</param>
        public void Editar(Usuario usuario)
        {
            try
            {
               
                Usuario usuarioEdit = BuscarPorId(usuario.IdUsuario);

                if(usuarioEdit == null)
                {
                    throw new Exception("Usuario nao encontrado");
                }

                usuarioEdit.Nome = usuario.Nome;
                usuarioEdit.Email = usuario.Email;
                usuarioEdit.Senha = usuario.Senha;

                _context.Usuarios.Update(usuarioEdit);
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos os usuarios cadastrados
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            try
            {
                

                return _context.Usuarios.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um usuario
        /// </summary>
        /// <param name="id">Objeto de usuario</param>
        public void Remover(Guid id)
        {
            try
            {
                Usuario usuarioEdit = BuscarPorId(id);

                if (usuarioEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Usuarios.Remove(usuarioEdit);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
