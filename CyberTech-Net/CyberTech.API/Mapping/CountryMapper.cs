using AutoMapper;
using CyberTech.API.ModelViews.Country;
using CyberTech.Core.Dto.Country;

namespace CyberTech.API.Mapping
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<CountryDto, CountryModel>();
            CreateMap<CreatingCountryModel, CreatingCountryDto>();
            CreateMap<UpdatingCountryModel, UpdatingCountryDto>();
        }
    }
}
