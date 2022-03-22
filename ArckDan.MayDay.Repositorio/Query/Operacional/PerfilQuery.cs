using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Query.Operacional
{
    public class PerfilQuery : Connection, IQuery<PerfilModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe PerfilQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public PerfilQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<PerfilModel> GetAll() =>
            _conn.Query<PerfilModel>($"{Query.ToString()}");
        public IEnumerable<PerfilModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<PerfilModel>($"{Query.ToString() } { where } { (nroPagina > 0 ? $"ORDER BY OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");
        public PerfilModel GetById(int id) =>
            _conn.Query<PerfilModel>($"{Query.ToString()} WHERE ID = @Id", new { Id = id }).FirstOrDefault();        
        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<PerfilModel>($"SELECT ID as Id TB_MAYDAY_PERFIL { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe PerfilQuery
        /// </summary>
        ~PerfilQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion

        #region propriedades

        private StringBuilder Query  => new StringBuilder()
            .Append("SELECT ID as Id")
            .Append(", NOME as Nome")
            .Append(", DESCRICAO as Descricao")
            .Append(", ATIVO as Ativo")
            .Append(", DATA_INCLUSAO as Inclusao")
            .Append(", DATA_ALTERACAO as Alteracao")
            .Append(" FROM TB_MAYDAY_PERFIL");

        #endregion
    }
}