using AutoMapper;
using CyberTech.API.ModelViews.TeamPlayer;
using CyberTech.Core.Dto.TeamPlayer;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamPlayerController : ControllerBase
    {
        private readonly ITeamPlayerService _service;
        private readonly IMapper _mapper;

        public TeamPlayerController(ITeamPlayerService teamPlayerService, IMapper mapper)
        {
            _service = teamPlayerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всего списка игроков команды из таблицы "Состав команды"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<TeamPlayerModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Состав команды"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var teamPlayerDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TeamPlayerDto, TeamPlayerModel>(teamPlayerDto));
        }

        /// <summary>
        /// Вставка записи в таблицу "Состав команды"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingTeamPlayerModel creatingTeamPlayerModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingTeamPlayerDto>(creatingTeamPlayerModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Состав команды"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTeamPlayerModel updatingTeamPlayerModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTeamPlayerModel, UpdatingTeamPlayerDto>(updatingTeamPlayerModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Состав команды"
        /// </summary>        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
