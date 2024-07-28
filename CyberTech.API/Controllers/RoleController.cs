using AutoMapper;
using CyberTech.API.ModelViews.Role;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Роли
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RoleController(IRoleService roleService, IMapper mapper) : ControllerBase
    {
        private readonly IRoleService _service = roleService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Получить весь список ролей
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<RoleModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }
    }
}
