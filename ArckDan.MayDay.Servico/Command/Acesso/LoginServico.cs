using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Acesso
{
    public class LoginServico : ICommandHandler<LoginModel>
    {
        #region atributos

        readonly ICommand<LoginModel> _login;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe LoginServico
        /// </summary>
        /// <param name="login">objeto command do Login</param>
        public LoginServico(ICommand<LoginModel> login)
        {
            // bloco de construção de objetos
            _login = login;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _login.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Login</param>
        public void Post(LoginModel entity)
            => _login.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Login</param>
        public void Put(LoginModel entity)
            => _login.Put(entity);

        #endregion
    }
}
