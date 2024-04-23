namespace RentMotorcycle.Data.Base
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
