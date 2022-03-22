using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Relacional
{
    public class FormularioCampoQuery : Connection, IQuery<FormularioCampoModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe FormularioCampoQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public FormularioCampoQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<FormularioCampoModel> GetAll() =>
            _conn.Query<FormularioCampoModel>($"SELECT ID, ID_FORMULARIO, ID_CAMPO, DATA_INCLUSAO, DATA_ALTERACAO FROM TB_MAYDAY_FORMULARIO_CAMPO");

        public IEnumerable<FormularioCampoModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<FormularioCampoModel>($"SELECT ID, ID_FORMULARIO, ID_CAMPO, DATA_INCLUSAO, DATA_ALTERACAO FROM TB_MAYDAY_FORMULARIO_CAMPO { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public FormularioCampoModel GetById(int id) =>
            _conn.Query<FormularioCampoModel>($"SELECT ID, ID_FORMULARIO, ID_CAMPO, DATA_INCLUSAO, DATA_ALTERACAO FROM TB_MAYDAY_FORMULARIO_CAMPO WHERE ID = { id }", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<FormularioCampoModel>($"SELECT ID TB_MAYDAY_FORMULARIO_CAMPO { where }").FirstOrDefault().Id;

        #endregion

        #region destrutores

        /// <summary>
        /// destrutor da classe FormularioCampoQuery
        /// </summary>
        ~FormularioCampoQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}
