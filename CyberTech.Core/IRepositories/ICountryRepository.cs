using CyberTech.Domain.Entities;

namespace CyberTech.Core.IRepositories
{
    public interface ICountryRepository : IRepository<CountryEntity, Guid>
    {
        Task<List<CountryEntity>> GetPagedAsync(int page, int itemsPerPage);
    }
}