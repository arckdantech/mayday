using System.Collections.Generic;

namespace ArckDan.MayDay.Repositorio.Interface
{
    public interface IQuery<TEntity> where TEntity : class
    {
        #region métodos

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20);

        int GetTotalCount(string where = "");

        TEntity GetById(int id);

        #endregion
    }
}
