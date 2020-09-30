using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly EduxContext _context;

        public PerfilRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo perfil
        /// </summary>
        /// <param name="perfil">Objeto a ser cadastrado</param>
        public void Adicionar(Perfil perfil)
        {
            try
            {
                _context.Perfis.Add(perfil);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um perfil pelo id
        /// </summary>
        /// <param name="id">Id de perfil</param>
        /// <returns>O perfil procurado</returns>
        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                return _context.Perfis.FirstOrDefault(a => a.IdPerfil == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um perfil
        /// </summary>
        /// <param name="perfil">Objeto a ser alterado</param>
        public void Editar(Perfil perfil)
        {
            try
            {
                Perfil perfilEdit = BuscarPorId(perfil.IdPerfil);

                if (perfilEdit == null)
                {
                    throw new Exception("Perfil nao encontrado");
                }

                perfilEdit.Permissao = perfil.Permissao;

                _context.Perfis.Update(perfilEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos os perfis cadastrados
        /// </summary>
        /// <returns>Uma lista de perfis</returns>
        public List<Perfil> Listar()
        {
            try
            {
                return _context.Perfis.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um perfil
        /// </summary>
        /// <param name="id">Objeto de perfil</param>
        public void Remover(Guid id)
        {
            try
            {
                Perfil perfilEdit = BuscarPorId(id);

                if (perfilEdit == null)
                {
                    throw new Exception("Perfil nao encontrado");
                }

                _context.Perfis.Remove(perfilEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
