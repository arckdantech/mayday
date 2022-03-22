using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Acesso
{
    public class SenhaCommand : Connection, ICommand<SenhaModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe SenhaCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public SenhaCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command) 
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(SenhaModel entity)
        {
            _db.Add(SenhaModel.SenhaModelFactory.ObterModel(entity.IdLogin, entity.Chave, entity.Expiracao, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(SenhaModel entity)
        {
            _db.Update(SenhaModel.SenhaModelFactory.ObterModel(entity.IdLogin, entity.Chave, entity.Expiracao, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            _db.Remove(SenhaModel.SenhaModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        #endregion
    }
}
