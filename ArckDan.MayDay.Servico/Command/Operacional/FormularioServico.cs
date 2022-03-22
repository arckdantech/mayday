using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class FormularioServico : ICommandHandler<FormularioModel>
    {
        #region atributos

        readonly ICommand<FormularioModel> _Formulario;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe FormularioServico
        /// </summary>
        /// <param name="Formulario">objeto command do Formulario</param>
        public FormularioServico(ICommand<FormularioModel> Formulario)
        {
            // bloco de construção de objetos
            _Formulario = Formulario;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _Formulario.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Formulario</param>
        public void Post(FormularioModel entity)
            => _Formulario.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Formulario</param>
        public void Put(FormularioModel entity)
            => _Formulario.Put(entity);

        #endregion
    }
}
