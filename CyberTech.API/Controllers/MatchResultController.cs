using AutoMapper;
using CyberTech.API.ModelViews.MatchResult;
using CyberTech.Core.Dto.MatchResult;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Команды участники встречи турнира
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MatchResultController(IMatchResultService matchResultsService, IMapper mapper) : ControllerBase
    {
        private readonly IMatchResultService _service = matchResultsService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Получить весь список результатов встречи турниров
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<MatchResultModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получить результатов встречи по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(id, cancellationToken);            
            return Ok(_mapper.Map<MatchResultDto, MatchResultModel>(result));
        }

        /// <summary>
        /// Добавить результат встречи
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingMatchResultModel creatingMatchResultModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingMatchResultDto>(creatingMatchResultModel)));            
        }

        /// <summary>
        /// Изменение записи в таблице "Команды участники встречи турнира"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingMatchResultModel updatingMatchResultModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingMatchResultDto>(updatingMatchResultModel));
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
