using ArckDan.MayDay.Domain.Models.Acesso;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class UsuarioModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe UsuarioModel
        /// </summary>
        public UsuarioModel() { }

        /// <summary>
        /// construtor da classe UsuarioModel
        /// </summary>
        /// <param name="idPerfil">id do perfil do usuário</param>
        /// <param name="nome">nome do usuário</param>
        /// <param name="ativo">usuário ativo ou inativo</param>
        /// <param name="cpf">cpf do usuário</param>
        /// <param name="nascimento">data de nascimento do usuário</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro do usuário</param>
        public UsuarioModel(int idPerfil, string nome, bool ativo, string cpf, DateTime nascimento, DateTime inclusao, DateTime? alteracao = null, int? id = null)
        {
            IdPerfil = idPerfil;
            Nome = nome;
            Ativo = ativo;
            CPF = cpf;
            Nascimento = nascimento;
            Inclusao = inclusao;
            Alteracao = alteracao;
            Id = id;
        }

        #endregion

        #region propriedades

        [Required]
        [Column("ID", TypeName = "int")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int? Id { get; private set; }

        [Required]
        [Column("ID_PERFIL", TypeName = "int")]
        public int IdPerfil { get; private set; }

        [Required]
        [Column("NOME", TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; private set; }

        [Required]
        [Column("ATIVO", TypeName = "bit")]
        public bool Ativo { get; private set; }

        [Required]
        [Column("NOME", TypeName = "char")]
        [StringLength(11)]
        public string CPF { get; private set; }

        [Required]
        [Column("DATA_NASCIMENTO", TypeName = "datetime")]
        public DateTime Nascimento { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; }

        [NotMapped]
        public ICollection<LoginModel> Login { get; set; }

        [NotMapped]
        public ICollection<EnderecoModel> Endereco { get; set; }

        #endregion

        #region factory

        public static class UsuarioModelFactory
        {
            /// <summary>
            /// construtor da classe UsuarioModel
            /// </summary>
            /// <param name="idPerfil">id do perfil do usuário</param>
            /// <param name="nome">nome do usuário</param>
            /// <param name="ativo">usuário ativo ou inativo</param>
            /// <param name="cpf">cpf do usuário</param>
            /// <param name="nascimento">data de nascimento do usuário</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro do usuário</param>
            public static UsuarioModel ObterModel(int idPerfil, string nome, bool ativo, string cpf, DateTime nascimento, DateTime inclusao, DateTime? alteracao = null, int? id = null)
                => new UsuarioModel
                {
                    IdPerfil = idPerfil,
                    Nome = nome,
                    Ativo = ativo,
                    CPF = cpf,
                    Nascimento = nascimento,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro do administrador</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static UsuarioModel ObterModel(int? id)
                => new UsuarioModel
                {
                    Id = id
                };
        }

        #endregion
    }
}
