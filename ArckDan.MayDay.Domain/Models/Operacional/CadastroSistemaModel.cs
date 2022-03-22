using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class CadastroSistemaModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe CadastroSistemaModel
        /// </summary>
        public CadastroSistemaModel() { }

        /// <summary>
        /// construtor da classe CadastroSistemaModel
        /// </summary>
        /// <param name="idLogin">id do login</param>
        /// <param name="idFormulario">id do formulário</param>
        /// <param name="dadosUsuario">dados de cadastro do formulário do usuário</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro</param>
        public CadastroSistemaModel(int idLogin, int idFormulario, string dadosUsuario, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            IdLogin = idLogin;
            IdFormulario = idFormulario;
            DadosUsuario = dadosUsuario;
            Inclusao = inclusao;
            Alteracao = alteracao;
            Id = id;
        }

        #endregion

        #region propriedades

        [Required]
        [Column("ID", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; private set; } = null!;

        [Required]
        [Column("ID_LOGIN", TypeName = "int")]
        public int IdLogin { get; private set; }

        [Required]
        [Column("ID_FORMULARIO", TypeName = "int")]
        public int IdFormulario { get; private set; }

        [Required]
        [Column("DADOS_USUARIO", TypeName = "varchar")]
        [StringLength(8000)]
        public string DadosUsuario { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion

        #region factory

        public static class CadastroSistemaModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idLogin">id do login</param>
            /// <param name="idFormulario">id do formulário</param>
            /// <param name="dadosUsuario">dados de cadastro do formulário do usuário</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static CadastroSistemaModel ObterModel(int idLogin, int idFormulario, string dadosUsuario, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new CadastroSistemaModel
                {
                    IdLogin = idLogin,
                    IdFormulario = idFormulario,
                    DadosUsuario = dadosUsuario,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static CadastroSistemaModel ObterModel(int id)
                => new CadastroSistemaModel
                {
                    Id = id
                };
        }

        #endregion
    }
}
