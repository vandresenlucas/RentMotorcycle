using RentMotorcicle.Domain.UserAggregate;

namespace RentMotorcicle.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentMotorcicleContext context) : base(context)
        {
        }
    }
}
