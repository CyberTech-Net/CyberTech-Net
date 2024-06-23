using AutoMapper;
using CyberTech.API.ModelViews.Country;
using CyberTech.Core.Dto.Country;

namespace CyberTech.API.Mapping
{
    public class CountryMappingsProfile : Profile
    {
        public CountryMappingsProfile()
        {
            CreateMap<CountryDto, CountryModel>();                
            CreateMap<CreatingCountryModel, CreatingCountryDto>();
            CreateMap<UpdatingCountryModel, UpdatingCountryDto>();
        }
    }
}
