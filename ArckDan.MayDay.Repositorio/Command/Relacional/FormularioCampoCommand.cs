using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Command.Relacional
{
    public class FormularioCampoCommand : Connection, ICommand<FormularioCampoModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe CampoCommand
        /// </summary>
        /// <param name="configuration">coleção de objetos de configuração do sistema</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public FormularioCampoCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
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
            _db.Remove(FormularioCampoModel.FormularioCampoModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(FormularioCampoModel entity)
        {
            _db.Add(FormularioCampoModel.FormularioCampoModelFactory.ObterModel(entity.IdFormulario, entity.IdCampo, entity.Inclusao, entity.Alteracao));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(FormularioCampoModel entity)
        {
            _db.Update(FormularioCampoModel.FormularioCampoModelFactory.ObterModel(entity.IdFormulario, entity.IdCampo, entity.Inclusao, entity.Alteracao, entity.Id));
            _db.SaveChanges();
        }

        #endregion
    }
}
