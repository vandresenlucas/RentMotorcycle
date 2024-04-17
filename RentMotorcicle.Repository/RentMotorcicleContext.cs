using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RentMotorcicle.Repository
{
    public class RentMotorcicleContext : DbContext
    {

        public RentMotorcicleContext(DbContextOptions<RentMotorcicleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
