using ArckDan.MayDay.Domain.Models.Operacional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArckDan.MayDay.Domain.Models.Relacional
{
    public class FormularioCampoModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe FormularioCampoModel
        /// </summary>
        public FormularioCampoModel() { }

        /// <summary>
        /// construtor da classe FormularioCampoModel
        /// </summary>
        /// <param name="idFormulario">id do formulário</param>
        /// <param name="idCampo">id do campo</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro</param>
        public FormularioCampoModel(int idFormulario, int idCampo, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            IdFormulario = idFormulario;
            IdCampo = idCampo;
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
        [Column("ID_FORMULARIO", TypeName = "int")]
        public int IdFormulario { get; private set; }

        [Required]
        [Column("ID_CAMPO", TypeName = "int")]
        public int IdCampo { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion

        #region factory

        public static class FormularioCampoModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idFormulario">id do formulário</param>
            /// <param name="idCampo">id do campo</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static FormularioCampoModel ObterModel(int idFormulario, int idCampo, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new FormularioCampoModel
                {
                    IdFormulario = idFormulario,
                    IdCampo = idCampo,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static FormularioCampoModel ObterModel(int? id)
                => new FormularioCampoModel
                {
                    Id = id
                };
        }

        #endregion
    }
}