using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly EduxContext _context;

        public CategoriaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Categoria categoria)
        {
            try
            {
                

                _context.Categorias.Add(categoria);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id">Id de usuario</param>
        /// <returns>O usuario procurado</returns>
        public Categoria BuscarPorId(Guid id)
        {
            try
            {
                return _context.Categorias.FirstOrDefault(a => a.IdCategoria == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser alterado</param>
        public void Editar(Categoria categoria)
        {
            try
            {
                Categoria categoriaEdit = BuscarPorId(categoria.IdCategoria);

                if (categoriaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                categoriaEdit.Tipo = categoria.Tipo;

                _context.Categorias.Update(categoriaEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos os usuarios cadastrados
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Categoria> Listar()
        {
            try
            {
                

                return _context.Categorias.ToList();
            }
            catch (Exception ex)
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
                Categoria categoriaEdit = BuscarPorId(id);

                if (categoriaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Categorias.Remove(categoriaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
