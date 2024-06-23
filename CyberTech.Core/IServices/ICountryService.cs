using CyberTech.Core.Dto.Country;

namespace CyberTech.Core.IServices
{
    public interface ICountryService                
    {
        Task<CountryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingCountryDto creatingCountryDto);
        Task UpdateAsync(Guid id, UpdatingCountryDto updatingCountryDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<CountryDto>> GetPagedAsync(int page, int pageSize);
        Task<ICollection<CountryDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
