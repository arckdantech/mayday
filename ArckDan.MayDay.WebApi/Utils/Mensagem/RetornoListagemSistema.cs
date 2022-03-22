using System.Collections.Generic;

namespace ArckDan.MayDay.WebApi.Utils.Mensagem
{
    public class RetornoListagemSistema<TEntity> : RetornoSistema
        where TEntity : class 
    {
        #region métodos

        public RetornoListagemSistema<TEntity> RetornoSistema()
        { 
        }

        #endregion

        #region propriedades

        public IEnumerable<TEntity> Registros => new List<TEntity>();

        #endregion
    }
}
