using AutoMapper;
using CyberTech.Core.Dto.Country;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class CountryMappingsProfile : Profile
    {
        public CountryMappingsProfile() 
        {
            CreateMap<CountryEntity, CountryDto>();

            CreateMap<CreatingCountryDto, CountryEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d=>d.MongoCountryPic, map =>map.Ignore())
                .ForMember(d=>d.Players, map => map.Ignore());

            CreateMap<UpdatingCountryDto, CountryEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.MongoCountryPic, map => map.Ignore())
                .ForMember(d => d.Players, map => map.Ignore());
        }
    }
}
