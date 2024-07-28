using AutoMapper;
using CyberTech.Core.Dto.Country;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class CountryMappingsProfile : Profile
    {
        public CountryMappingsProfile() 
        {
            CreateMap<Country, CountryDto>();

            CreateMap<CreatingCountryDto, Country>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d=>d.MongoCountryPic, map =>map.Ignore())
                .ForMember(d=>d.Players, map => map.Ignore());

            CreateMap<UpdatingCountryDto, Country>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.MongoCountryPic, map => map.Ignore())
                .ForMember(d => d.Players, map => map.Ignore());
        }
    }
}
