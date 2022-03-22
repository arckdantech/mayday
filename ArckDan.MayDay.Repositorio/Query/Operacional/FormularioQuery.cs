using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Query.Operacional
{
    public class FormularioQuery : Connection, IQuery<FormularioModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe FormularioQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public FormularioQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<FormularioModel> GetAll() =>
            _conn.Query<FormularioModel>($"{Query}");

        public IEnumerable<FormularioModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<FormularioModel>($"{Query} { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public FormularioModel GetById(int id) =>
            _conn.Query<FormularioModel>($"{Query} WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<FormularioModel>($"SELECT ID as Id TB_MAYDAY_FORMULARIO { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe FormularioQuery
        /// </summary>
        ~FormularioQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion

        #region propriedades

        private StringBuilder Query => new StringBuilder()
            .AppendLine("SELECT ID as Id")
            .AppendLine(", ID_PERFIL as IdPerfil")
            .AppendLine(", NOME as Nome")
            .AppendLine(", DESCRICAO as Descricao")
            .AppendLine(", DATA_INCLUSAO as Inclusao")
            .AppendLine(", DATA_ALTERACAO as Alteracao")
            .AppendLine(" FROM TB_MAYDAY_FORMULARIO");

        #endregion
    }
}