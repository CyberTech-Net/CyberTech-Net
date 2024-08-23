using AutoMapper;
using CyberTech.API.ModelViews.Team;
using CyberTech.Core.Dto.Team;
using CyberTech.Core.IServices;
using MassTransit.Transports;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CyberTech.MessagesContracts.MongoRecord;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Команды
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TeamController(ITeamService teamService, IMapper mapper,
        IPublishEndpoint publishEndpoint, ILogger<TeamController> logger) : Controller
    {
        private readonly ITeamService _service = teamService;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<TeamController> _logger = logger;

        /// <summary>
        /// Получить команды c пагинацией
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<TeamModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получить весь список команд 
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var test = await _service.GetAllAsync(cancellationToken);
            var response = _mapper.Map<List<TeamModel>>(test);
            return Ok(response);
        }

        /// <summary>
        /// Получить команду по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var teamDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TeamDto, TeamModel>(teamDto));
        }

        /// <summary>
        /// Добавить команду
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingTeamModel creatingTeamModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingTeamDto>(creatingTeamModel)));
        }

        /// <summary>
        /// Изменить данные о команде
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTeamModel updatingTeamModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTeamModel, UpdatingTeamDto>(updatingTeamModel));
            return Ok();
        }

        /// <summary>
        /// Удалить команду
        /// </summary>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // берем Id картинки по Id записи
            var ImageId = _service.GetTeamImageIdAsync(id).Result;
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

