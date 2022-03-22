using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class CampoServico : ICommandHandler<CampoModel>
    {
        #region atributos

        readonly ICommand<CampoModel> _campo;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CampoServico
        /// </summary>
        /// <param name="campo">objeto command do campo</param>
        public CampoServico(ICommand<CampoModel> campo)
        {
            // bloco de construção de objetos
            _campo = campo;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _campo.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Campo</param>
        public void Post(CampoModel entity)
            => _campo.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Campo</param>
        public void Put(CampoModel entity)
            => _campo.Put(entity);

        #endregion
    }
}
