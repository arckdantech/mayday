using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class PerfilCommand : Connection, ICommand<PerfilModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe PerfilCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public PerfilCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
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
        public void Post(PerfilModel entity)
        {
            _db.Add(PerfilModel.PerfilModelFactory.ObterModel(entity.Nome, entity.Descricao, entity.Ativo, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(PerfilModel entity)
        {
            _db.Update(PerfilModel.PerfilModelFactory.ObterModel(entity.Nome, entity.Descricao, entity.Ativo, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            _db.Remove(PerfilModel.PerfilModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        #endregion
    }
}
