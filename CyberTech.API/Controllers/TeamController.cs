using AutoMapper;
using CyberTech.API.ModelViews.Team;
using CyberTech.Core.Dto.Team;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Команды
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TeamController(ITeamService teamService, IMapper mapper) : Controller
    {
        private readonly ITeamService _service = teamService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Получить команды c пагинацией
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<TeamModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получить весь список команд 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<TeamModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получить команду по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var teamDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TeamDto, TeamModel>(teamDto));
        }

        /// <summary>
        /// Добавить команду
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingTeamModel creatingTeamModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map< CreatingTeamDto>(creatingTeamModel)));
        }

        /// <summary>
        /// Изменить данные о команде
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTeamModel updatingTeamModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTeamModel, UpdatingTeamDto>(updatingTeamModel));
            return Ok();
        }

        /// <summary>
        /// Удалить команду
        /// </summary>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}

