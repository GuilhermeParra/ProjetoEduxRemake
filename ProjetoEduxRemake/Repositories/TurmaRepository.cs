using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class TurmaRepository : ITurma
    {
        private readonly EduxContext _context;

        public TurmaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Turma turma)
        {
            try
            {
                

                _context.Turmas.Add(turma);

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
        public Turma BuscarPorId(Guid id)
        {
            try
            {
                return _context.Turmas.FirstOrDefault(a => a.IdTurma == id);
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
        public void Editar(Turma turma)
        {
            try
            {
                Turma turmaEdit = BuscarPorId(turma.IdTurma);

                if (turmaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                turmaEdit.Descricao = turma.Descricao;

                _context.Turmas.Update(turmaEdit);
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
        public List<Turma> Listar()
        {
            try
            {
               

                return _context.Turmas.ToList();
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
                Turma turmaEdit = BuscarPorId(id);

                if (turmaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Turmas.Remove(turmaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
