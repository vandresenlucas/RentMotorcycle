using RentMotorcycle.Data.MotorcycleAggregate;
using RentMotorcycle.Domain.Repositories;

namespace RentMotorcycle.Domain.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}