using AutoMapper;
using CyberTech.API.ModelViews.TournamentMeet;
using CyberTech.Core.Dto.TournamentMeet;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Таблица "Встречи турнира"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TournamentMeetController : ControllerBase
    {
        private readonly ITournamentMeetService _service;
        private readonly IMapper _mapper;

        public TournamentMeetController(ITournamentMeetService tournamentMeetService, IMapper mapper)
        {
            _service = tournamentMeetService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всего списка встреч турнира из таблицы "Встречи турнира"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<TournamentMeetModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Встречи турнира"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournamentMeetDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TournamentMeetDto, TournamentMeetModel>(tournamentMeetDto));
        }

        /// <summary>
        /// Вставка записи в таблице "Встречи турнира"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingTournamentMeetModel creatingTournamentMeetModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingTournamentMeetDto>(creatingTournamentMeetModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Встречи турнира"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTournamentMeetModel updatingTournamentMeetModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTournamentMeetModel, UpdatingTournamentMeetDto>(updatingTournamentMeetModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Встречи турнира"
        /// </summary>        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
