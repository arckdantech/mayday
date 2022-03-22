using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class UsuarioServico : ICommandHandler<UsuarioModel>
    {
        #region atributos

        readonly ICommand<UsuarioModel> _usuario;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe UsuarioServico
        /// </summary>
        /// <param name="usuario">objeto command do Usuário</param>
        public UsuarioServico(ICommand<UsuarioModel> usuario)
        {
            // bloco de construção de objetos
            _usuario = usuario;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _usuario.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Usuario</param>
        public void Post(UsuarioModel entity)
            => _usuario.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Usuario</param>
        public void Put(UsuarioModel entity)
            => _usuario.Put(entity);

        #endregion

    }
}
