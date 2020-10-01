using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurma
    {
        private readonly EduxContext _context;

        public ProfessorTurmaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(ProfessorTurma professorTurma)
        {
            try
            {
                

                _context.ProfessoresTurmas.Add(professorTurma);

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
        public ProfessorTurma BuscarPorId(Guid id)
        {
            try
            {
                return _context.ProfessoresTurmas.FirstOrDefault(a => a.IdProfessorTurma == id);
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
        public void Editar(ProfessorTurma professorTurma)
        {
            try
            {
                ProfessorTurma professorEdit = BuscarPorId(professorTurma.IdProfessorTurma);

                if (professorEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                professorEdit.Descricao = professorTurma.Descricao;

                _context.ProfessoresTurmas.Update(professorEdit);
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
        public List<ProfessorTurma> Listar()
        {
            try
            {
                

                return _context.ProfessoresTurmas.ToList();
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
                ProfessorTurma professorEdit = BuscarPorId(id);

                if (professorEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.ProfessoresTurmas.Remove(professorEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
