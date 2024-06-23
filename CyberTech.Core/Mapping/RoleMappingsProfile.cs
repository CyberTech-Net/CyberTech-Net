using AutoMapper;
using CyberTech.Core.Dto.Role;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class RoleMappingsProfile : Profile
    {
        public RoleMappingsProfile()
        {
            CreateMap<RoleEntity, RoleDto>();
        }
    }
}
