using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.IRepositories
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {
        Task<List<Country>> GetPagedAsync(int page, int itemsPerPage);
    }
}