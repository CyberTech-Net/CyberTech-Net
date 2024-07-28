using CyberTech.API.Mapping;
using CyberTech.API.ModelViews.MatchResult;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Команды участники встречи турнира
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MatchResultsController(IMatchResultsService matchResultsService) : ControllerBase
    {
        private readonly IMatchResultsService _service = matchResultsService;

        /// <summary>
        /// Получить весь список результатов встречи турниров
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var results = await _service.GetAllAsync(cancellationToken);
            if(results == null) 
                return NotFound();

            return Ok(MatchResultMapper.ConvertToModelApi(results));
        }

        /// <summary>
        /// Получить результатов встречи по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(id, cancellationToken);
            if (result == null)
                return NotFound();

            return Ok(MatchResultMapper.ConvertToModelApi(result));
        }

        /// <summary>
        /// Добавить результат встречи
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingResultModel creatingTournamentMeetTeamModel)
        {
            return Ok(await _service.CreateAsync(MatchResultMapper.ConvertToDto(creatingTournamentMeetTeamModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Команды участники встречи турнира"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingResultModel updatingTournamentMeetTeamModel)
        {
            await _service.UpdateAsync(id, MatchResultMapper.ConvertToDto(updatingTournamentMeetTeamModel));
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
