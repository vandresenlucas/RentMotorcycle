using RentMotorcicle.Domain;

namespace RentMotorcicle.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentMotorcicleContext context) : base(context) 
        {
        }
    }
}
