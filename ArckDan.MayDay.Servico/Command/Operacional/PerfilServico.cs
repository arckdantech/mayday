using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class PerfilServico : ICommandHandler<PerfilModel>
    {
        #region atributos

        readonly ICommand<PerfilModel> _perfil;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe PerfilServico
        /// </summary>
        /// <param name="perfil">objeto command do perfil</param>
        public PerfilServico(ICommand<PerfilModel> perfil)
        {
            // bloco de construção de objetos
            _perfil = perfil;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id) 
            => _perfil.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(PerfilModel entity)
            => _perfil.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(PerfilModel entity) 
            => _perfil.Put(entity);

        #endregion
    }
}
