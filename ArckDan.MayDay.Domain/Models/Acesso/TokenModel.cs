using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Acesso
{
    public class TokenModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe TokenModel
        /// </summary>
        public TokenModel() { }

        /// <summary>
        /// construtor da classe TokenModel
        /// </summary>
        /// <param name="userId">id do usuário JWT</param>
        /// <param name="senha">senha do usuário JWT</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de alteração do registro</param>
        /// <param name="id">id do registro</param>
        public TokenModel(string userId, string senha, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            UserId = userId;
            Senha = senha;
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
        public int? Id { get; private set; }

        [Required]
        [Column("USER_ID", TypeName = "char")]
        [StringLength(10)]
        public string UserId { get; private set; }

        [Required]
        [Column("SENHA", TypeName = "char")]
        [StringLength(10)]
        public string Senha { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion

        #region factory

        public static class TokenModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="userId">id do usuário JWT</param>
            /// <param name="senha">senha do usuário JWT</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de alteração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static TokenModel ObterModel(string userId, string senha, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new TokenModel()
                {
                    UserId = userId,
                    Senha = senha,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com o id do registro
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static TokenModel ObterModel(int? id) 
                => new TokenModel() 
                { 
                    Id = id 
                };        
        }

        #endregion
    }
}
