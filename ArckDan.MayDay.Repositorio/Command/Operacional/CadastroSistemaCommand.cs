using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class CadastroSistemaCommand : Connection, ICommand<CadastroSistemaModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe CadastroSistemaCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public CadastroSistemaCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            _db.Remove(CadastroSistemaModel.CadastroSistemaModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(CadastroSistemaModel entity)
        {
            _db.Add(CadastroSistemaModel.CadastroSistemaModelFactory.ObterModel(entity.IdLogin, entity.IdFormulario, entity.DadosUsuario, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(CadastroSistemaModel entity)
        {
            _db.Update(CadastroSistemaModel.CadastroSistemaModelFactory.ObterModel(entity.IdLogin, entity.IdFormulario, entity.DadosUsuario, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        #endregion
    }
}
