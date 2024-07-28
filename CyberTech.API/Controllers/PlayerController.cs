using AutoMapper;
using CyberTech.API.ModelViews.Player;
using CyberTech.Core.Dto.Player;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Игроки
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PlayerController(IPlayerService playerService, IMapper mapper) : ControllerBase
    {
        private readonly IPlayerService _service = playerService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Получить список игроков c пагинацией
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<PlayerModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получить весь список игроков
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<PlayerModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получить игрока по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var playerDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<PlayerDto, PlayerModel>(playerDto));
        }

        /// <summary>
        /// Добавить игрока
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingPlayerModel creatingPlayerModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map< CreatingPlayerDto>(creatingPlayerModel)));
        }

        /// <summary>
        /// Измененить данные об игроке
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingPlayerModel updatingPlayerModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingPlayerModel, UpdatingPlayerDto>(updatingPlayerModel));
            return Ok();
        }

        /// <summary>
        /// Удалить игрока
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