using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RentMotorcycle.Repository
{
    public class RentMotorcycleContext : DbContext
    {

        public RentMotorcycleContext(DbContextOptions<RentMotorcycleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
