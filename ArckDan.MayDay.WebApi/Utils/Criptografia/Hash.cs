using ArckDan.MayDay.WebApi.Models.Acesso;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ArckDan.MayDay.WebApi.Utils.Criptografia
{
    public class Hash
    {
        #region atributos

        private HashAlgorithm _algoritmo;

        #endregion

        #region construtores

        public Hash(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }

        #endregion

        #region métodos

        internal StringBuilder Retornar(byte[] encryptedPassword)
        {
            // bloco de construçao de objetos
            var sb = new StringBuilder();

            // implementa um laço para criptografar a senha
            foreach (var caracter in encryptedPassword)
                sb.Append(caracter.ToString("X2"));

            return sb;
        }


        /// <summary>
        /// prepara a criptgrafia da senha
        /// </summary>
        /// <param name="senha">senha gerada sem criptografia</param>
        /// <returns>retorno da senha criptografada</returns>
        public SenhaViewModel Criptografar(SenhaViewModel senha)
        {
            // bloco de construção de objetos
            var encodedValue = Encoding.UTF8.GetBytes(senha.Chave);

            // recupera a senha criptografada
            senha.Chave = Retornar(_algoritmo.ComputeHash(encodedValue)).ToString();

            return senha;
        } 

        /// <summary>
        /// prepara para validar a senha gravada no banco de dados
        /// </summary>
        /// <param name="senhaUsuario">senha informarda do usuário</param>
        /// <param name="senhaCadastrada">senha cadastrada no banco de dados</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public bool Validar(string senhaUsuario, string senhaCadastrada)
        {
            // condição para analisar a senha vinda do banco de dados
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Cadastre uma senha.");

            return Retornar(_algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaUsuario))).ToString() == senhaCadastrada;
        }

        #endregion
    }
}
