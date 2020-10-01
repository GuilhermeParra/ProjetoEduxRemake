using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EduxContext _context;

        public InstituicaoRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto a ser cadastrado</param>
        public void Adicionar(Instituicao instituicao)
        {
            try
            {
                

                _context.Instituicoes.Add(instituicao);

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
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _context.Instituicoes.FirstOrDefault(a => a.IdInstituicao == id);
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
        public void Editar(Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoEdit = BuscarPorId(instituicao.IdInstituicao);

                if (instituicaoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                instituicaoEdit.Nome = instituicao.Nome;
                instituicaoEdit.Logradouro = instituicao.Logradouro;
                instituicaoEdit.Numero = instituicao.Numero;
                instituicaoEdit.Complemento = instituicao.Complemento;
                instituicaoEdit.Bairro = instituicao.Bairro;
                instituicaoEdit.Cidade = instituicao.Cidade;
                instituicaoEdit.UF = instituicao.UF;
                instituicaoEdit.CEP = instituicao.CEP;

                _context.Instituicoes.Update(instituicaoEdit);
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
        public List<Instituicao> Listar()
        {
            try
            {

                return _context.Instituicoes.ToList();
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
                Instituicao instituicaoEdit = BuscarPorId(id);

                if (instituicaoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Instituicoes.Remove(instituicaoEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
