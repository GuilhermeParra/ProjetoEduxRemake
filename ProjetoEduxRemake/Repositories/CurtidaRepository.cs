using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class CurtidaRepository : ICurtida
    {
        private readonly EduxContext _context;

        public CurtidaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Curtida curtida)
        {
            try
            {
                

                _context.Curtidas.Add(curtida);

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
        public Curtida BuscarPorId(Guid id)
        {
            try
            {
                return _context.Curtidas.FirstOrDefault(a => a.IdCurtida == id);
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
        public void Editar(Curtida curtida)
        {
            try
            {
                Curtida curtidaEdit = BuscarPorId(curtida.IdCurtida);

                if (curtidaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Curtidas.Update(curtidaEdit);
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
        public List<Curtida> Listar()
        {
            try
            {
                

                return _context.Curtidas.ToList();
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
                Curtida curtidaEdit = BuscarPorId(id);

                if (curtidaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Curtidas.Remove(curtidaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
