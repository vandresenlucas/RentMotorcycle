using RentMotorcycle.Data.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Data.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}