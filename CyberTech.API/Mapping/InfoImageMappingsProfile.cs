using AutoMapper;
using CyberTech.API.ModelViews.InfoImage;
using CyberTech.Core.Dto.InfoImage;

namespace CyberTech.API.Mapping
{
    public class InfoImageMappingsProfile : Profile
    {
        public InfoImageMappingsProfile()
        {
            CreateMap<InfoImageDto, InfoImageModel>()
                .ForMember(d => d.Info, map => map.MapFrom(m => m.Info))
                .ForMember(d => d.InfoId, map => map.MapFrom(m => m.InfoId));
            CreateMap<CreatingInfoImageModel, CreatingInfoImageDto>();
            CreateMap<UpdatingInfoImageModel, UpdatingInfoImageDto>();
        }
    }
}
