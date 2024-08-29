using AutoMapper;
using CyberTech.API.ModelViews.Match;
using CyberTech.Core.Dto.Match;
using CyberTech.Core.IServices;
using CyberTech.MessagesContracts.TournamentMeets;
using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Встречи турниров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController(IMatchService matchService, IMapper mapper, 
        IPublishEndpoint publishEndpoint, ILogger<MatchController> logger, IValidator<CreatingMatchModel> createValidator) : ControllerBase
    {
        private readonly IMatchService _service = matchService;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        ILogger<MatchController> _logger = logger;
        private readonly IValidator<CreatingMatchModel> _createValidator = createValidator;

        /// <summary>
        /// Получить весь список встреч
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        public async Task<IActionResult> AddAsync([FromBody] CreatingMatchModel creatingMatchModel)
        {
            var validation = _createValidator.Validate(creatingMatchModel);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var newId = await _service.CreateAsync(_mapper.Map<CreatingMatchDto>(creatingMatchModel));
            DateTime startDateTime = creatingMatchModel.StartDateTime;

            await _publishEndpoint.Publish(new MatchPlanned
            {
                StartDateTime = startDateTime,
                Id = newId
            });
            _logger.LogInformation("{data} Publish MatchPlanned with Id={id}", DateTime.UtcNow, newId);

            return Ok(newId);
        }

        /// <summary>
        /// Измененить данные о встрече
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, [FromBody] UpdatingMatchModel updatingMatchModel)
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
