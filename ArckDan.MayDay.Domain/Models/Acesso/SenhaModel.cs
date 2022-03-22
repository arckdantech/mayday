using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Acesso
{
    public class SenhaModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe SenhaModel
        /// </summary>
        public SenhaModel() { }

        /// <summary>
        /// construtor da classe SenhaModel
        /// </summary>
        /// <param name="idLogin">id do login de usuário</param>
        /// <param name="chave">senha de acesso</param>
        /// <param name="expiracao">data de expiração da senha</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de alteração do registro</param>
        /// <param name="id">id do registro</param>
        public SenhaModel(int idLogin, string chave, DateTime expiracao, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            // bloco de construção de objetos
            IdLogin = idLogin;
            Chave = chave;
            Expiracao = expiracao;
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
        [Column("CHAVE", TypeName = "varchar")]
        [StringLength(1000)]
        public string Chave { get; private set; }

        [Required]
        [Column("DATA_EXPIRACAO", TypeName = "datetime")]
        public DateTime Expiracao { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion

        #region factory

        public static class SenhaModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idLogin">id do login de usuário</param>
            /// <param name="chave">senha de acesso</param>
            /// <param name="expiracao">data de expiração da senha</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de alteração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static SenhaModel ObterModel(int idLogin, string chave, DateTime expiracao, DateTime inclusao, DateTime? alteracao = null, int? id = null)
            {
                return new SenhaModel
                {
                    IdLogin = idLogin,
                    Chave = chave,
                    Expiracao = expiracao,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };
            }

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro da senha</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static SenhaModel ObterModel(int? id)
            {
                return new SenhaModel
                {
                    Id = id
                };
            }
        }

        #endregion
    }
}
