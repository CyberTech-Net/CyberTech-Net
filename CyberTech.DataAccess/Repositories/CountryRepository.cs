using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class CountryRepository : Repository<CountryEntity, Guid>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
