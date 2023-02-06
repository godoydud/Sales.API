using Microsoft.EntityFrameworkCore;
using Sales.API.Domain.Entities;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Infra.Data.Context;

namespace Sales.API.Infra.Data.Repositories
{
    public class ComissionRepository : IComissionRepository
    {
        private readonly CoreContext _appDbContext;
        public ComissionRepository(CoreContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Comission> CreateAsync(Comission comission)
        {
            _appDbContext.Add(comission);
            await _appDbContext.SaveChangesAsync();
            return comission;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await GetByIdAsync(id);

                if (result == null)
                    return false;

                _appDbContext.Remove(result);

                _appDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditAsync(Comission comission)
        {
            _appDbContext.Update(comission);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Comission>> GetAllAsync()
        {
            return await _appDbContext.Comission.ToListAsync();
        }
        public async Task<Comission> GetByIdAsync(Guid id)
        {
            return _appDbContext.Comission.FirstOrDefault(x => x.Id == id);
        }
    }
}
