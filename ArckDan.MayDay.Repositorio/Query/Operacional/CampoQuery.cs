using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Operacional
{
    public class CampoQuery : Connection, IQuery<CampoModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe CampoQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public CampoQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<CampoModel> GetAll() =>
            _conn.Query<CampoModel>($"SELECT ID, NOME, NOME_TECNICO, DESCRICAO, TIPO, TAMANHO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_CAMPO");

        public IEnumerable<CampoModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<CampoModel>($"SELECT ID, NOME, NOME_TECNICO, DESCRICAO, TIPO, TAMANHO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_CAMPO { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public CampoModel GetById(int id) =>
            _conn.Query<CampoModel>($"SELECT ID, NOME, NOME_TECNICO, DESCRICAO, TIPO, TAMANHO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_CAMPO WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<CampoModel>($"SELECT ID TB_MAYDAY_CAMPO { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// destrutor da classe CampoQuery
        /// </summary>
        ~CampoQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}