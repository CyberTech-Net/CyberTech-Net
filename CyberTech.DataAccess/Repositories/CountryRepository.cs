using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess.Repositories
{
    public class CountryRepository : Repository<Country, Guid>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Country>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
