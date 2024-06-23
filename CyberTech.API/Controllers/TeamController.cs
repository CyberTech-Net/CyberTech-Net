using AutoMapper;
using CyberTech.API.ModelViews.Team;
using CyberTech.Core.Dto.Team;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Таблица "Новости"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _service;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _service = teamService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение команд c пагинацией из таблицы "Команды"
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<TeamModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получение всего списка команд из таблицы "Команды"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<TeamModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Команды"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var teamDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TeamDto, TeamModel>(teamDto));
        }

        /// <summary>
        /// Вставка записи в таблицу "Команды"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingTeamModel creatingTeamModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map< CreatingTeamDto>(creatingTeamModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Команды"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTeamModel updatingTeamModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTeamModel, UpdatingTeamDto>(updatingTeamModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Команды"
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

