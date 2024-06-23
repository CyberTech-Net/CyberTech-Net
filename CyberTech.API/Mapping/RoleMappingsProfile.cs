using AutoMapper;
using CyberTech.API.ModelViews.Role;
using CyberTech.Core.Dto.Role;

namespace CyberTech.API.Mapping
{
    public class RoleMappingsProfile : Profile
    {
        public RoleMappingsProfile()
        {
            CreateMap<RoleDto, RoleModel>();
        }
    }
}
