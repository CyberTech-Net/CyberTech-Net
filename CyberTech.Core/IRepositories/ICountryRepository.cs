using CyberTech.Domain.Entities;

namespace CyberTech.Core.IRepositories
{
    public interface ICountryRepository : IRepository<CountryEntity, Guid>
    {
    }
}