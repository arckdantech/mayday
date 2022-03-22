using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Query.Acesso
{
    public class SenhaQuery : Connection, IQuery<SenhaModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe SenhaQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public SenhaQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<SenhaModel> GetAll() =>
            _conn.Query<SenhaModel>($"{ Query.ToString() }");

        public IEnumerable<SenhaModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<SenhaModel>($"{Query.ToString() } { where } { (nroPagina > 0 ? $"ORDER BY OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public SenhaModel GetById(int id) =>
            _conn.Query<SenhaModel>($"{ Query.ToString() } WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<SenhaModel>($"SELECT ID as Id TB_MAYDAY_SENHA { where }").FirstOrDefault().Id;

        #endregion

        #region propriedades

        public StringBuilder Query => new StringBuilder()
            .Append(" SELECT ID as Id ")
            .Append(", ID_LOGIN as IdLogin ")
            .Append(", CHAVE as Chave ")
            .Append(", DATA_EXPIRACAO as Expiracao ")
            .Append(", DATA_INCLUSAO as Inclusao ")
            .Append(", DATA_ALTERACAO as Alteracao ")
            .Append(" FROM TB_MAYDAY_SENHA");

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe SenhaQuery
        /// </summary>
        ~SenhaQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}