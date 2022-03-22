using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class EnderecoModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe EnderecoModel
        /// </summary>
        public EnderecoModel() { }

        /// <summary>
        /// construtor da classe EnderecoModel
        /// </summary>
        /// <param name="idUsuario">id do registro de usuário</param>
        /// <param name="cep">cep do endereço do usuário</param>
        /// <param name="logradouro">logradouro do usuário</param>
        /// <param name="numero">número do endereço do usuário</param>
        /// <param name="complemento">complemento do endereço do usuário</param>
        /// <param name="bairro">bairro do endereço do usuário</param>
        /// <param name="cidade">cidade do usuário</param>
        /// <param name="uf">uf do usuário</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de alteração do registro</param>
        /// <param name="id">id do registro de endereço</param>
        public EnderecoModel(int idUsuario, string cep, string logradouro, int numero, string complemento, string bairro, string cidade, string uf, DateTime inclusao, DateTime? alteracao = null, int? id = null) 
        {
            IdUsuario = idUsuario;
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
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
        [Column("CEP", TypeName = "char")]
        [StringLength(8)]
        public string CEP { get; private set; }

        [Required]
        [Column("LOGRADOURO", TypeName = "varchar")]
        [StringLength(30)]
        public string Logradouro { get; private set; }

        [Required]
        [Column("NUMERO", TypeName = "int")]
        public int Numero { get; private set; }

        [Column("COMPLEMENTO", TypeName = "varchar")]
        [StringLength(20)]
        public string Complemento { get; private set; } = null;

        [Required]
        [Column("BAIRRO", TypeName = "varchar")]
        [StringLength(20)]
        public string Bairro { get; private set; }

        [Required]
        [Column("CIDADE", TypeName = "varchar")]
        [StringLength(30)]
        public string Cidade { get; private set; }

        [Required]
        [Column("UF", TypeName = "char")]
        [StringLength(2)]
        public string UF { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion

        #region factory

        public static class EnderecoModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idUsuario">id do registro de usuário</param>
            /// <param name="cep">cep do endereço do usuário</param>
            /// <param name="logradouro">logradouro do usuário</param>
            /// <param name="numero">número do endereço do usuário</param>
            /// <param name="complemento">complemento do endereço do usuário</param>
            /// <param name="bairro">bairro do endereço do usuário</param>
            /// <param name="cidade">cidade do usuário</param>
            /// <param name="uf">uf do usuário</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de alteração do registro</param>
            /// <param name="id">id do registro de endereço</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static EnderecoModel ObterModel(int idUsuario, string cep, string logradouro, int numero, string complemento, string bairro, string cidade, string uf, DateTime inclusao, DateTime? alteracao = null, int? id = null)
            {
                return new EnderecoModel
                {
                    IdUsuario = idUsuario,
                    CEP = cep,
                    Logradouro = logradouro,
                    Numero = numero,
                    Complemento = complemento,
                    Bairro = bairro,
                    Cidade = cidade,
                    UF = uf,
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
            public static EnderecoModel ObterModel(int? id)
            {
                return new EnderecoModel
                {
                    Id = id
                };
            }
        }

        #endregion
    }
}
