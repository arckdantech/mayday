namespace ArckDan.MayDay.Repositorio.Interface
{
    public interface ICommand<TEntity> where TEntity : class
    {
        #region método

        void Post(TEntity entity);

        void Put(TEntity entity);

        void Delete(int id);

        #endregion
    }
}
