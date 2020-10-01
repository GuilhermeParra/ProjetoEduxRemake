using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class CursoRepository : ICurso
    {
        private readonly EduxContext _context;

        public CursoRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Curso curso)
        {
            try
            {
                

                _context.Cursos.Add(curso);

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
        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _context.Cursos.FirstOrDefault(a => a.IdCurso == id);
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
        public void Editar(Curso curso)
        {
            try
            {
                Curso cursoEdit = BuscarPorId(curso.IdCurso);

                if (cursoEdit == null)
                {
                    throw new Exception("Usuario nao encontrado");
                }

                cursoEdit.Titulo = curso.Titulo;

                _context.Cursos.Update(cursoEdit);
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
        public List<Curso> Listar()
        {
            try
            {
                

                return _context.Cursos.ToList();
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
                Curso cursoEdit = BuscarPorId(id);

                if (cursoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Cursos.Remove(cursoEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
