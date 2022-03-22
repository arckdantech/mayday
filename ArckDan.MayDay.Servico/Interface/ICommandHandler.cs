namespace ArckDan.MayDay.Servico.Interface
{
    public interface ICommandHandler<TEntity> where TEntity : class
    {
        #region métodos

        void Post(TEntity entity);
        void Put(TEntity entity);
        void Delete(int id);

        #endregion
    }
}
