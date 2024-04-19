using Microsoft.EntityFrameworkCore;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentMotorcycleContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmail(string email)
            => await _context.Set<User>().FirstOrDefaultAsync(motorcycle => motorcycle.Email.Equals(email));
    }
}
