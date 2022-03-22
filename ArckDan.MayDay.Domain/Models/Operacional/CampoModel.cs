using ArckDan.MayDay.Domain.Models.Relacional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class CampoModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe CampoModel
        /// </summary>
        public CampoModel() { }

        /// <summary>
        /// construtor da classe CampoModel
        /// </summary>
        /// <param name="nome">nome do campo</param>
        /// <param name="nomeTecnico">nome técnico para o campo</param>
        /// <param name="descricao">descrição do campo</param>
        /// <param name="tipo">tipo do campo</param>
        /// <param name="tamanho">tamanho do campo</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro</param>
        public CampoModel(string nome, string nomeTecnico, string descricao, string tipo, int tamanho, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            Nome = nome;
            NomeTecnico = nomeTecnico;
            Descricao = descricao;
            Tipo = tipo;
            Tamanho = tamanho;
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
        [Column("NOME", TypeName = "varchar")]
        [StringLength(20)]
        public string Nome { get; private set; }

        [Required]
        [Column("NOME_TECNICO", TypeName = "varchar")]
        [StringLength(70)]
        public string NomeTecnico { get; private set; }

        [Required]
        [Column("DESCRICAO", TypeName = "varchar")]
        [StringLength(100)]
        public string Descricao { get; private set; }

        [Required]
        [Column("TIPO", TypeName = "varchar")]
        [StringLength(100)]
        public string Tipo { get; private set; }

        [Required]
        [Column("TAMANHO", TypeName = "int")]
        public int Tamanho { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion

        #region factory

        public static class CampoModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="nome">nome do campo</param>
            /// <param name="nomeTecnico">nome técnico para o campo</param>
            /// <param name="descricao">descrição do campo</param>
            /// <param name="tipo">tipo do campo</param>
            /// <param name="tamanho">tamanho do campo</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static CampoModel ObterModel(string nome, string nomeTecnico, string descricao, string tipo, int tamanho, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new CampoModel
                {
                    Nome = nome,
                    NomeTecnico = nomeTecnico,
                    Descricao = descricao,
                    Tipo = tipo,
                    Tamanho = tamanho,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static CampoModel ObterModel(int? id)
                => new CampoModel
                {
                    Id = id
                };
        }

        #endregion
    }
}
