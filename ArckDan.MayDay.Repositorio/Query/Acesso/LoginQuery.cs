using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Query.Acesso
{
    public class LoginQuery : Connection, IQuery<LoginModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe LoginQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public LoginQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<LoginModel> GetAll() =>
            _conn.Query<LoginModel>($"{Query}");

        public IEnumerable<LoginModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<LoginModel>($"{Query} { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");
         
        public LoginModel GetById(int id) =>
            _conn.Query<LoginModel>($"{Query} WHERE ID = { id }", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<LoginModel>($"SELECT ID TB_MAYDAY_LOGIN { where }").FirstOrDefault().Id;

        #endregion

        #region propriedades

        private StringBuilder Query => new StringBuilder()
            .AppendLine("SELECT ID as Id")
            .AppendLine(", ID_PERFIL as IdPerfil")
            .AppendLine(", CHAVE_ACESSO as ChaveAcesso")
            .AppendLine(", DATA_INCLUSAO as Inclusao")
            .AppendLine(", DATA_ALTERACAO as Alteracao")
            .AppendLine(" FROM TB_MAYDAY_LOGIN");

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe LoginQuery
        /// </summary>
        ~LoginQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}