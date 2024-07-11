using AutoMapper;
using CyberTech.Core.Dto.InfoImage;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class InfoImageMappingsProfile : Profile
    {
        public InfoImageMappingsProfile()
        {
            CreateMap<InfoImageEntity, InfoImageDto>()
                .ForMember(d => d.Info, map => map.MapFrom(m => m.Info.TitleInfo))
                .ForMember(d => d.InfoId, map => map.MapFrom(m => m.InfoId));

            CreateMap<CreatingInfoImageDto, InfoImageEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Info, map => map.Ignore());

            CreateMap<UpdatingInfoImageDto, InfoImageEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Info, map => map.Ignore());
        }
    }
}
