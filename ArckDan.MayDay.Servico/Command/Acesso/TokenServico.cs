using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Acesso
{
    public class TokenServico : ICommandHandler<TokenModel>
    {
        #region atributos

        readonly ICommand<TokenModel> _token;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe TokenServico
        /// </summary>
        /// <param name="token">objeto command do token</param>
        public TokenServico(ICommand<TokenModel> token)
        {
            // bloco de construção de objetos
            _token = token;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _token.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade token</param>
        public void Post(TokenModel entity)
            => _token.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade token</param>
        public void Put(TokenModel entity)
            => _token.Put(entity);

        #endregion
    }
}