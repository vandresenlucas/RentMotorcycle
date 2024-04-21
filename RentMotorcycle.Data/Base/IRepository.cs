namespace RentMotorcycle.Data.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}
