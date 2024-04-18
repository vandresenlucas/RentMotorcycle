﻿using RentMotorcycle.Domain.Repositories;

namespace RentMotorcycle.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RentMotorcycleContext _context;

        public Repository(RentMotorcycleContext context)
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