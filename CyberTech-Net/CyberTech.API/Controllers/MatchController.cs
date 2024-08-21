using AutoMapper;
using CyberTech.API.ModelViews.Match;
using CyberTech.Core.Dto.Match;
using CyberTech.Core.IServices;
using CyberTech.MessagesContracts.TournamentMeets;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Встречи турниров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController(IMatchService matchService, IMapper mapper, 
        IPublishEndpoint publishEndpoint, ILogger<MatchController> logger) : ControllerBase
    {
        private readonly IMatchService _service = matchService;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        ILogger<MatchController> _logger = logger;

        /// <summary>
        /// Получить весь список встреч
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<MatchModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получить встречу по ее ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<MatchDto, MatchModel>(result));
        }

        /// <summary>
        /// Добавить встречи
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingMatchModel creatingMatchModel)
        {
            var newId = await _service.CreateAsync(_mapper.Map<CreatingMatchDto>(creatingMatchModel));
            DateTime startDateTime = creatingMatchModel.StartDateTime;
            if (startDateTime > DateTime.UtcNow)
            {
                await _publishEndpoint.Publish(new MatchPlanned
                {
                    StartDateTime = startDateTime,
                    Id = newId
                });
                _logger.LogInformation("{data} Publish MatchPlanned with Id={id}", DateTime.UtcNow, newId);
            }
            else
            // Запускаем сервис генерации результатов сразу.
            {

            }
            return Ok(newId);
        }

        /// <summary>
        /// Измененить данные о встрече
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingMatchModel updatingMatchModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingMatchDto>(updatingMatchModel));
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
