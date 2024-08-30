using AutoMapper;
using CyberTech.API.ModelViews.GameType;
using CyberTech.Core.Dto.GameType;
using CyberTech.Core.IServices;
using CyberTech.MessagesContracts.MongoRecord;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Игры
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class GameTypeController(IGameTypeService gameTypeService, IMapper mapper, 
        IPublishEndpoint publishEndpoint, ILogger<GameTypeController> logger) : ControllerBase
    {
        private readonly IGameTypeService _service = gameTypeService;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly ILogger<GameTypeController> _logger = logger;

        /// <summary>
        /// Получение всего списка игр
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<GameTypeModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response.OrderBy(x => x.TitleGame));
        }

        /// <summary>
        /// Получение игры по ее ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var gameTypeDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<GameTypeDto, GameTypeModel>(gameTypeDto));
        }

        /// <summary>
        /// Добавление игры
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromBody] CreatingGameTypeModel creatingGameTypeModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingGameTypeDto>(creatingGameTypeModel)));
        }

        /// <summary>
        /// Изменение данных об игре
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, [FromBody] UpdatingGameTypeModel updatingGameTypeModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingGameTypeModel, UpdatingGameTypeDto>(updatingGameTypeModel));
            return Ok();
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // берем Id картинки по Id записи
            var ImageId = _service.GetGameTypeImageIdAsync(id).Result;
            if (ImageId.ToString().Length > 0)
            {
                await _publishEndpoint.Publish(new MongoRecDeleted
                {
                    Id = ImageId
                });
                _logger.LogInformation("{data} Publish MongoRecDeleted with Id={id}", DateTime.UtcNow, ImageId);
            }
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
