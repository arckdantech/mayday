using System;
using System.Collections.Generic;

namespace ArckDan.MayDay.WebApi.Models.PatternObjectFactory.Product.Abstract
{
    public interface IProdutoViewModel<TEntity> 
        where TEntity : class
    {
        #region métodos

        TEntity Retornar(TEntity p);

        #endregion
    }
}
