using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class FormularioCommand : Connection, ICommand<FormularioModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe FormularioCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public FormularioCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
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
        public void Post(FormularioModel entity)
        {
            _db.Add(FormularioModel.FormularioModelFactory.ObterModel(entity.IdPerfil, entity.Nome, entity.Descricao, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(FormularioModel entity)
        {
            _db.Update(FormularioModel.FormularioModelFactory.ObterModel(entity.IdPerfil, entity.Nome, entity.Descricao, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            _db.Remove(FormularioModel.FormularioModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        #endregion
    }
}