using Microsoft.EntityFrameworkCore;
using Sales.API.Domain.Entities;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Infra.Data.Context;

namespace Sales.API.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreContext _appDbContext;
        public UserRepository(CoreContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _appDbContext.Add(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _appDbContext.User.ToListAsync();
        }
    }
}
