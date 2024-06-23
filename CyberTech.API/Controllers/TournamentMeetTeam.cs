using AutoMapper;
using CyberTech.API.ModelViews.TournamentMeetTeam;
using CyberTech.Core.Dto.TournamentMeetTeam;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Таблица "Команды участники встречи турнира"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TournamentMeetTeam : ControllerBase
    {
        private readonly ITournamentMeetTeamService _service;
        private readonly IMapper _mapper;
        public TournamentMeetTeam(ITournamentMeetTeamService tournamentMeetTeamService, IMapper mapper)
        {
            _service = tournamentMeetTeamService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всего списка результатов встречи турнира из таблицы "Команды участники встречи турнира"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<TournamentMeetTeamModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Команды участники встречи турнира"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournamentMeetTeamDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TournamentMeetTeamDto, TournamentMeetTeamModel>(tournamentMeetTeamDto));
        }

        /// <summary>
        /// Вставка записи в таблицу "Команды участники встречи турнира"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingTournamentMeetTeamModel creatingTournamentMeetTeamModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingTournamentMeetTeamDto>(creatingTournamentMeetTeamModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Команды участники встречи турнира"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTournamentMeetTeamModel updatingTournamentMeetTeamModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTournamentMeetTeamModel, UpdatingTournamentMeetTeamDto>(updatingTournamentMeetTeamModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Команды участники встречи турнира"
        /// </summary>        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
