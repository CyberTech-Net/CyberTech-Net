using AutoMapper;
using CyberTech.API.Mapping;
using CyberTech.API.ModelViews.Match;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Встречи турниров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController(IMatchesService tournamentMeetService, IMapper mapper) : ControllerBase
    {
        private readonly IMatchesService _service = tournamentMeetService;

        /// <summary>
        /// Получить весь список встреч
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _service.GetAllAsync(cancellationToken);

            if(response == null) 
                return NotFound();

            return Ok(MatchMapper.ConvertToModelApi(response));
        }

        /// <summary>
        /// Получить встречу по ее ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _service.GetByIdAsync(id, cancellationToken);
            if (response == null)
                return NotFound();

            return Ok(MatchMapper.ConvertToModelApi(response));
        }

        /// <summary>
        /// Добавить встречи
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingMatchModel creatingTournamentMeetModel)
        {
            return Ok(await _service.CreateAsync(MatchMapper.ConvertToDto(creatingTournamentMeetModel)));
        }

        /// <summary>
        /// Измененить данные о встрече
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingMatchModel updatingTournamentMeetModel)
        {
            await _service.UpdateAsync(id, MatchMapper.ConvertToDto(updatingTournamentMeetModel));
            return Ok();
        }

        /// <summary>
        /// Удалить встречу
        /// </summary>        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
