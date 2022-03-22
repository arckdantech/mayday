using ArckDan.MayDay.Domain.Models.Operacional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Acesso
{
    public class LoginModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe LoginModel
        /// </summary>
        public LoginModel() { }

        /// <summary>
        /// construtor da classe LoginModel
        /// </summary>
        /// <param name="idUsuario">id do usuário</param>
        /// <param name="chaveUsuario">chave de usuário do login</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro</param>
        public LoginModel(int idUsuario, string chaveUsuario, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            IdUsuario = idUsuario;
            ChaveUsuario = chaveUsuario;
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
        [Column("ID_USUARIO", TypeName = "int")]
        public int IdUsuario { get; private set; }

        [Required]
        [Column("CHAVE_USUARIO", TypeName = "varchar")]
        [StringLength(50)]
        public string ChaveUsuario { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; }

        [NotMapped]
        public CadastroSistemaModel Cadastro { get; set; }

        [NotMapped]
        public UsuarioModel Usuario { get; set; }

        [NotMapped]
        public ICollection<SenhaModel> Senha { get; set; }

        #endregion

        #region factory

        public static class LoginModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idUsuario">id do usuário</param>
            /// <param name="chaveUsuario">chave de usuário do login</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static LoginModel ObterModel(int idUsuario, string chaveUsuario, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new LoginModel
                {
                    IdUsuario = idUsuario,
                    ChaveUsuario = chaveUsuario,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com o id do registro
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static LoginModel ObterModel(int? id)
                => new LoginModel
                {
                    Id = id
                };
        }

        #endregion
    }
}
