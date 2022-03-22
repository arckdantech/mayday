using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Operacional
{
    public class CadastroSistemaQuery : Connection, IQuery<CadastroSistemaModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe CadastroSistemaQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public CadastroSistemaQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<CadastroSistemaModel> GetAll() =>
            _conn.Query<CadastroSistemaModel>($"SELECT ID, NOME, NOME_TECNICO, DESCRICAO, TIPO, TAMANHO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_CadastroSistema");

        public IEnumerable<CadastroSistemaModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            _conn.Query<CadastroSistemaModel>($"SELECT ID, NOME, NOME_TECNICO, DESCRICAO, TIPO, TAMANHO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_CadastroSistema { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public CadastroSistemaModel GetById(int id) =>
            _conn.Query<CadastroSistemaModel>($"SELECT ID, NOME, NOME_TECNICO, DESCRICAO, TIPO, TAMANHO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_CadastroSistema WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)_conn.Query<CadastroSistemaModel>($"SELECT ID TB_MAYDAY_CadastroSistema { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// destrutor da classe CadastroSistemaQuery
        /// </summary>
        ~CadastroSistemaQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}
