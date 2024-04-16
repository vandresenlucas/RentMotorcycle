using RentMotorcicle.Domain.Repositories;

namespace RentMotorcicle.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RentMotorcicleContext _context;

        public Repository(RentMotorcicleContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _context.AddAsync(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}