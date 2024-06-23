using AutoMapper;
using CyberTech.API.ModelViews.Role;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Таблица "Роли"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _service = roleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всего списка игроков из таблицы "Роли"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<RoleModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }
    }
}
