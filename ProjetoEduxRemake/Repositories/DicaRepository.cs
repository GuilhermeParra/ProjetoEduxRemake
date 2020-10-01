using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class DicaRepository : IDica
    {
        private readonly EduxContext _context;

        public DicaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Dica dica)
        {
            try
            {
                

                _context.Dicas.Add(dica);

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
        public Dica BuscarPorId(Guid id)
        {
            try
            {
                return _context.Dicas.FirstOrDefault(a => a.IdDica == id);
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
        public void Editar(Dica dica)
        {
            try
            {
                Dica dicaEdit = BuscarPorId(dica.IdDica);

                if (dicaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                dicaEdit.Texto = dica.Texto;

                _context.Dicas.Update(dicaEdit);
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
        public List<Dica> Listar()
        {
            try
            {
                

                return _context.Dicas.ToList();
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
                Dica dicaEdit = BuscarPorId(id);

                if (dicaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Dicas.Remove(dicaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
