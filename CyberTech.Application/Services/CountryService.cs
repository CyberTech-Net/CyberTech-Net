using AutoMapper;
using CyberTech.Core.Dto.Country;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

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
            var country = await _countryRepository.GetAsync(id, CancellationToken.None);
            if (country == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            country.TitleCountry = updatingCountryDto.TitleCountry;            
            _countryRepository.Update(country);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var course = await _countryRepository.GetAsync(id, CancellationToken.None);
            if (course == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            var country = await _countryRepository.GetAsync(id, CancellationToken.None);
            _countryRepository.Delete(country);
            await _countryRepository.SaveChangesAsync();
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
