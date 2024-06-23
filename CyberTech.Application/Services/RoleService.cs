using AutoMapper;
using CyberTech.Core.Dto.Role;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<ICollection<RoleDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<RoleEntity> entities = await _roleRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<RoleEntity>, ICollection<RoleDto>>(entities);
        }
    }
}
