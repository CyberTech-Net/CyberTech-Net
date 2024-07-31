using AutoMapper;
using CyberTech.API.ModelViews.GameType;
using CyberTech.Core.Dto.GameType;
using CyberTech.Core.IServices;
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
    public class GameTypeController(IGameTypeService gameTypeService, IMapper mapper) : ControllerBase
    {
        private readonly IGameTypeService _service = gameTypeService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Получение всего списка игр
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<GameTypeModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение игры по ее ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
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
        public async Task<IActionResult> CreateAsync(CreatingGameTypeModel creatingGameTypeModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingGameTypeDto>(creatingGameTypeModel)));
        }

        /// <summary>
        /// Изменение данных об игре
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingGameTypeModel updatingGameTypeModel)
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
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
