using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class FormularioModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe FormularioModel
        /// </summary>
        public FormularioModel() { }

        /// <summary>
        /// construtor da classe FormularioModel
        /// </summary>
        /// <param name="idPerfil">id do perfil para configuração do formulário</param>
        /// <param name="nome">nome do formulário</param>
        /// <param name="descricao">descrição do formulário</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro</param>
        public FormularioModel(int idPerfil, string nome, string descricao, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            IdPerfil = idPerfil;
            Nome = nome;
            Descricao = descricao;
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
        [Column("ID_PERFIL", TypeName = "int")]
        public int IdPerfil { get; private set; }

        [Required]
        [Column("NOME", TypeName = "varchar")]
        [StringLength(50)]
        public string Nome { get; private set; }

        [Required]
        [Column("DESCRICAO", TypeName = "varchar")]
        [StringLength(200)]
        public string Descricao { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        [NotMapped]
        public PerfilModel Perfil { get; set; }

        #endregion

        #region factory

        public static class FormularioModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idPerfil">id do perfil para configuração do formulário</param>
            /// <param name="nome">nome do formulário</param>
            /// <param name="descricao">descrição do formulário</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static FormularioModel ObterModel(int idPerfil, string nome, string descricao, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new FormularioModel
                {
                    IdPerfil = idPerfil,
                    Nome = nome,
                    Descricao = descricao,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static FormularioModel ObterModel(int? id)
                => new FormularioModel
                {
                    Id = id
                };
        }
        #endregion
    }
}