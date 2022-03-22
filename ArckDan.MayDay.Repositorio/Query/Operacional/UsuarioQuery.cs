using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Query.Cadastro
{
    public class UsuarioQuery : Connection, IQuery<UsuarioModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe UsuarioQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public UsuarioQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<UsuarioModel> GetAll() =>
            _conn.Query<UsuarioModel>($"{ Query.ToString() }");

        public IEnumerable<UsuarioModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<UsuarioModel>($"{Query.ToString() } { where } { (nroPagina > 0 ? $"ORDER BY OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public UsuarioModel GetById(int id) =>
            _conn.Query<UsuarioModel>($"{ Query.ToString() } WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<UsuarioModel>($"SELECT ID as Id FROM TB_MAYDAY_USUARIO { where }").FirstOrDefault().Id;

        #endregion

        #region destrutores

        /// <summary>
        /// destrutor da classe UsuarioQuery
        /// </summary>
        ~UsuarioQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion

        #region propriedades

        private StringBuilder Query => new StringBuilder()
            .Append("SELECT ID as Id")
            .Append(", NOME as Nome")
            .Append(", ATIVO as Ativo")
            .Append(", CPF as Cpf")
            .Append(", DATA_NASCIMENTO as Nascimento")
            .Append(", DATA_INCLUSAO as Inclusao")
            .Append(", DATA_ALTERACAO as Alteracao")
            .Append(" FROM TB_MAYDAY_USUARIO");

        #endregion
    }
}