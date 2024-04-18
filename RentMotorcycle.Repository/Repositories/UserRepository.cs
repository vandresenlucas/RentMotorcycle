using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentMotorcycleContext context) : base(context)
        {
        }
    }
}
