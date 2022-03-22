using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class EnderecoServico : ICommandHandler<EnderecoModel>
    {
        #region atributos

        readonly ICommand<EnderecoModel> _endereco;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe EnderecoServico
        /// </summary>
        /// <param name="endereco">objeto command do endereço do usuário</param>
        public EnderecoServico(ICommand<EnderecoModel> endereco)
        {
            // bloco de construção de objetos
            _endereco = endereco;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _endereco.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Endereco</param>
        public void Post(EnderecoModel entity)
            => _endereco.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Endereco</param>
        public void Put(EnderecoModel entity)
            => _endereco.Put(entity);

        #endregion
    }
}
