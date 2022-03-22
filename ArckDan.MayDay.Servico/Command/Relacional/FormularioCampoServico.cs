using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Relacional
{
    public class FormularioCampoServico : ICommandHandler<FormularioCampoModel>
    {
        #region atributos

        readonly ICommand<FormularioCampoModel> _formularioCampo;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe FormularioCampoServico
        /// </summary>
        /// <param name="FormularioCampo">objeto command do endereço do usuário</param>
        public FormularioCampoServico(ICommand<FormularioCampoModel> formularioCampo)
        {
            // bloco de construção de objetos
            _formularioCampo = formularioCampo;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _formularioCampo.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade FormularioCampo</param>
        public void Post(FormularioCampoModel entity)
            => _formularioCampo.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade FormularioCampo</param>
        public void Put(FormularioCampoModel entity)
            => _formularioCampo.Put(entity);

        #endregion
    }
}
