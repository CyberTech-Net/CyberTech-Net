using AutoMapper;
using CyberTech.Core.Dto.Info;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class InfoMappingsProfile : Profile
    {
        public InfoMappingsProfile()
        {
            CreateMap<InfoEntity, InfoDto>();                

            CreateMap<CreatingInfoDto, InfoEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d=> d.InfoImages, map => map.Ignore());

            CreateMap<UpdatingInfoDto, InfoEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.InfoImages, map => map.Ignore());
        }
    }
}
