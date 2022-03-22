using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class EnderecoCommand : Connection, ICommand<EnderecoModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe CampoCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public EnderecoCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
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
            _db.Remove(EnderecoModel.EnderecoModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(EnderecoModel entity)
        {
            _db.Add(EnderecoModel.EnderecoModelFactory.ObterModel(entity.IdUsuario, entity.CEP, entity.Logradouro, entity.Numero, entity.Complemento, entity.Bairro, entity.Cidade, entity.UF, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(EnderecoModel entity)
        {
            _db.Update(EnderecoModel.EnderecoModelFactory.ObterModel(entity.IdUsuario, entity.CEP, entity.Logradouro, entity.Numero, entity.Complemento, entity.Bairro, entity.Cidade, entity.UF, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        #endregion
    }
}
