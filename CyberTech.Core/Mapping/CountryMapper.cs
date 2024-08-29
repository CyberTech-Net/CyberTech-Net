using AutoMapper;
using CyberTech.Core.Dto.Country;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class CountryMapper : Profile
    {
        public CountryMapper() 
        {
            CreateMap<CountryEntity, CountryDto>();

            CreateMap<CreatingCountryDto, CountryEntity>()
                .ForMember(d => d.Id, map => map.Ignore())                
                .ForMember(d=>d.Players, map => map.Ignore());

            CreateMap<UpdatingCountryDto, CountryEntity>()
                .ForMember(d => d.Id, map => map.Ignore())                
                .ForMember(d => d.Players, map => map.Ignore());
        }
    }
}
