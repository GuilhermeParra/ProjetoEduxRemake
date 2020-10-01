using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAluno
    {
        private readonly EduxContext _context;

        public ObjetivoAlunoRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(ObjetivoAluno objetivoAluno)
        {
            try
            {
                
                objetivoAluno.DataAlcancado = DateTime.Now;

                _context.ObjetivosAlunos.Add(objetivoAluno);

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
        public ObjetivoAluno BuscarPorId(Guid id)
        {
            try
            {
                return _context.ObjetivosAlunos.FirstOrDefault(a => a.IdObjetivoAluno == id);
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
        public void Editar(ObjetivoAluno objetivoAluno)
        {
            try
            {
                ObjetivoAluno objAlunoEdit = BuscarPorId(objetivoAluno.IdObjetivoAluno);

                if (objAlunoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                objAlunoEdit.Nota = objetivoAluno.Nota;

                _context.ObjetivosAlunos.Update(objAlunoEdit);
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
        public List<ObjetivoAluno> Listar()
        {
            try
            {
                

                return _context.ObjetivosAlunos.ToList();
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
                ObjetivoAluno objAlunoEdit = BuscarPorId(id);

                if (objAlunoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.ObjetivosAlunos.Remove(objAlunoEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
