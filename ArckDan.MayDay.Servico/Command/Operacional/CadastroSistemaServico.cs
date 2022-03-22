using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class CadastroSistemaServico : ICommandHandler<CadastroSistemaModel>
    {
        #region atributos

        readonly ICommand<CadastroSistemaModel> _cadastro;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CadastroSistemaServico
        /// </summary>
        /// <param name="cadastro">objeto command do cadastro</param>
        public CadastroSistemaServico(ICommand<CadastroSistemaModel> cadastro)
        {
            // bloco de construção de objetos
            _cadastro = cadastro;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => _cadastro.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Campo</param>
        public void Post(CadastroSistemaModel entity)
            => _cadastro.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Campo</param>
        public void Put(CadastroSistemaModel entity)
            => _cadastro.Put(entity);

        #endregion
    }
}
