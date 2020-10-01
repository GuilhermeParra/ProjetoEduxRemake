using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurma
    {
        private readonly EduxContext _context;

        public AlunoTurmaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(AlunoTurma alunoTurma)
        {
            try
            {
                _context.AlunosTurmas.Add(alunoTurma);

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
        public AlunoTurma BuscarPorId(Guid id)
        {
            try
            {
                return _context.AlunosTurmas.FirstOrDefault(a => a.IdAlunoTurma == id);
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
        public void Editar(AlunoTurma alunoTurma)
        {
            try
            {
                AlunoTurma alunTurmaEdit = BuscarPorId(alunoTurma.IdAlunoTurma);

                if (alunTurmaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                alunTurmaEdit.Matricula = alunoTurma.Matricula;

                _context.AlunosTurmas.Update(alunTurmaEdit);
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
        public List<AlunoTurma> Listar()
        {
            try
            {
                

                return _context.AlunosTurmas.ToList();
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
                AlunoTurma alunTurmaEdit = BuscarPorId(id);

                if (alunTurmaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.AlunosTurmas.Remove(alunTurmaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
