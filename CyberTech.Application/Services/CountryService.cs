using AutoMapper;
using CyberTech.Core.Dto.Country;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Handbooks;
using CyberTech.Domain.Models.Tournaments;
using System.Text.Json;

namespace CyberTech.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountryService(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;            
        }

        public async Task<CountryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<CountryEntity, CountryDto>(country);
        }

        public async Task<Guid> CreateAsync(CreatingCountryDto creatingCountryDto)
        {
            var country = _mapper.Map<CreatingCountryDto, CountryEntity>(creatingCountryDto);
            var creatingCountry = await _countryRepository.AddAsync(country);
            await _countryRepository.SaveChangesAsync();
            return creatingCountry.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingCountryDto updatingCountryDto)
        {
            var country = await _countryRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            country.TitleCountry = updatingCountryDto.TitleCountry;
            country.ImageId = updatingCountryDto.ImageId;
            _countryRepository.Update(country);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var country = await _countryRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _countryRepository.Delete(country);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task<string> GetCountryImageIdAsync(Guid id)
        {
            var country = await _countryRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            return country.ImageId;
        }

        public async Task<ICollection<CountryDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<CountryEntity> entities = await _countryRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<CountryEntity>, ICollection<CountryDto>>(entities);
        }

        public async Task<ICollection<CountryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<CountryEntity> entities = await _countryRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<CountryEntity>, ICollection<CountryDto>>(entities);
        }
    }
}
