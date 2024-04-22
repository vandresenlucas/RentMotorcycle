using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Data.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}