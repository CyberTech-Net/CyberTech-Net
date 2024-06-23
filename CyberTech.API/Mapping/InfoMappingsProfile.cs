using AutoMapper;
using CyberTech.API.ModelViews.Info;
using CyberTech.Core.Dto.Info;

namespace CyberTech.API.Mapping
{
    public class InfoMappingsProfile :Profile
    {
        public InfoMappingsProfile()
        {
            CreateMap<InfoDto, InfoModel>()
                .ForMember(d => d.DataInfo, map => map.MapFrom(m=>m.DataInfo.ToShortDateString()));
            CreateMap<CreatingInfoModel, CreatingInfoDto>();
            CreateMap<UpdatingInfoModel, UpdatingInfoDto>();
        }
    }
}
