using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess.Repositories
{
    public class CountryRepository : Repository<CountryEntity, Guid>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<CountryEntity>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
