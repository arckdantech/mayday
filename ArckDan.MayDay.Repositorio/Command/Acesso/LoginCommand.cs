using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Acesso
{
    public class LoginCommand : Connection, ICommand<LoginModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe LoginCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public LoginCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command) 
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade login</param>
        public void Post(LoginModel entity)
        {
            _db.Add(LoginModel.LoginModelFactory.ObterModel(entity.IdUsuario, entity.ChaveUsuario, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade login</param>
        public void Put(LoginModel entity)
        {
            _db.Update(LoginModel.LoginModelFactory.ObterModel(entity.IdUsuario, entity.ChaveUsuario, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            _db.Remove(LoginModel.LoginModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        #endregion
    }
}
