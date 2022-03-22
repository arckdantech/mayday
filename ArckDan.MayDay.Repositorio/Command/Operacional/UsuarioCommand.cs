

using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class UsuarioCommand : Connection, ICommand<UsuarioModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe UsuarioCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>

        public UsuarioCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade usuário</param>
        public void Post(UsuarioModel entity)
        {
            _db.Add(UsuarioModel.UsuarioModelFactory.ObterModel(entity.IdPerfil, entity.Nome, entity.Ativo, entity.CPF, entity.Nascimento, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade usuário</param>
        public void Put(UsuarioModel entity)
        {
            _db.Update(UsuarioModel.UsuarioModelFactory.ObterModel(entity.IdPerfil, entity.Nome, entity.Ativo, entity.CPF, entity.Nascimento, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            _db.Remove(UsuarioModel.UsuarioModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        #endregion
    }
}