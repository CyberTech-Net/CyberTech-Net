using AutoMapper;
using CyberTech.API.ModelViews.GameType;
using CyberTech.Core.Dto.GameType;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Справочник "Игры"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GameTypeController : ControllerBase
    {
        private readonly IGameTypeService _service;
        private readonly IMapper _mapper;

        public GameTypeController(IGameTypeService gameTypeService, IMapper mapper)
        {
            _service = gameTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всего списка игр из справочника "Игры"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<GameTypeModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из справочника "Игры"
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var gameTypeDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<GameTypeDto, GameTypeModel>(gameTypeDto));
        }

        /// <summary>
        /// Вставка записи в справочник "Игры"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingGameTypeModel creatingGameTypeModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingGameTypeDto>(creatingGameTypeModel)));
        }

        /// <summary>
        /// Изменение записи в справочнике "Игры"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingGameTypeModel updatingGameTypeModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingGameTypeModel, UpdatingGameTypeDto>(updatingGameTypeModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из справочника "Игры"
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
